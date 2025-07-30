using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MdmApi.Controllers
{
	[EnableCors]
	[Route("api/[controller]")]
	public class TokenController : ControllerBase
	{
		private readonly AuthSettings _authSettings;
		private readonly IUserManagementRepository _userManagementRepository;
		public TokenController(IOptions<AuthSettings> authSettings, IUserManagementRepository userManagementRepository) {
			_authSettings = authSettings.Value;
			_userManagementRepository = userManagementRepository;
		}
		[HttpPost("[action]")]
		public IActionResult Auth([FromBody] TokenRequestModel model) {

			if (model == null)
			{
				return Ok(APIResponse.SendResponse(Messages.InvalidRequest));
			}
			string clientId = "ABCDEFGH";
			if (string.IsNullOrEmpty(model.ClientId) || string.IsNullOrEmpty(clientId) || clientId != model.ClientId) {
				return Ok(APIResponse.SendResponse(Messages.InvalidRequest));
			}
			switch (model.GrantType) {
				case "create_token":
					return GenerateNewToken(model);
				case "refresh_token":
					return RefreshToken(model);
				default:
					return Ok(APIResponse.SendResponse(Messages.InvalidRequest, "Provide Grant Type"));
			}
		
		}

		private IActionResult GenerateNewToken(TokenRequestModel model)
		{
			var tupleresponse = _userManagementRepository.GetUserDetailsByUserLoginId(model.UserName, Guid.NewGuid().ToString());
			if (tupleresponse.Item1 == 1) {
				UserInformation userInformation = new UserInformation();
				userInformation = tupleresponse.Item2;
				var newRtoken = CreateRefreshToken(model.ClientId, userInformation.UserId.ToString(), userInformation.UserToken);
				var accessToken = CreateAccessToken(userInformation, newRtoken.Value);
				return Ok(new { authToken = accessToken });

			}
			return Ok(APIResponse.SendResponse(Messages.DataNotFound));
		}

		private TokenResponseModel CreateAccessToken(UserInformation userInformation, string refreshToken) 
		{
			string expireTime = "20";
			double tokenExpiryTime = Convert.ToDouble(expireTime);
			var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authSettings.Secret));
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[] 
				{
					new Claim(JwtRegisteredClaimNames.Sub,userInformation.EmailAddress),
					new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
					new Claim(ClaimTypes.NameIdentifier, userInformation.UserId.ToString()),
					new Claim(ClaimTypes.Role, userInformation.UserId.ToString()),
					new Claim("LoggedOn",DateTime.Now.ToString())

				 }),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
				Issuer = _authSettings.Site,
				Audience = _authSettings.Audience,
				Expires = DateTime.Now.AddMinutes(tokenExpiryTime),
			};
			var newtoken = tokenHandler.CreateToken(tokenDescriptor);
			var encodedToken = tokenHandler.WriteToken(newtoken);
			return new TokenResponseModel()
			{
				token = encodedToken,
				expiration = newtoken.ValidTo,
				refresh_token = refreshToken,
				username = userInformation.EmailAddress
			};
		}

		private TokenModel CreateRefreshToken(string clientId, string userId, string token)
		{
			return new TokenModel()
			{
				ClinetId = clientId,
				UserId = userId,
				Value = token,
				CreatedDate = DateTime.Now
			};
		}

		private IActionResult RefreshToken(TokenRequestModel model)
		{
			var tupleresponse = _userManagementRepository.GetUserTokenDetails(model, Guid.NewGuid().ToString("N"));
			if (tupleresponse.Item1 == 0)
			{
				return Ok(APIResponse.SendResponse(Messages.DataNotFound));
			}
			else if (tupleresponse.Item1 == 2)
			{
				return Ok(APIResponse.SendResponse(Messages.DataNotFound, "Token Expired"));
			}
			else if (tupleresponse.Item1 == 1)
			{
				UserInformation userInformation = new UserInformation();
				userInformation = tupleresponse.Item2;
				var rtNew = CreateRefreshToken(model.ClientId, userInformation.UserId.ToString(), userInformation.UserToken);
				var response = CreateAccessToken(userInformation, rtNew.Value);
				return Ok(new { authToken = response});
			}
			return Ok(APIResponse.SendResponse(Messages.DataNotFound));
		}
	
	}
}
