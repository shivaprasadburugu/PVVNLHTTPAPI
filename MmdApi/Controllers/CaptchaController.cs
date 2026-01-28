using MdmApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CaptchaController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public CaptchaController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("image")]
        public IActionResult GetCaptcha()
        {
            var captchaText = CaptchaGenerator.GenerateText();
            var captchaId = Guid.NewGuid().ToString();

            var imageBytes = CaptchaGenerator.GenerateImage(captchaText);
            var imageBase64 = Convert.ToBase64String(imageBytes);

            _cache.Set(captchaId, captchaText, TimeSpan.FromMinutes(2));

            return Ok(new CaptchaImageResponse
            {
                CaptchaId = captchaId,
                ImageBase64 = $"data:image/png;base64,{imageBase64}"
            });
        }
    }
}
