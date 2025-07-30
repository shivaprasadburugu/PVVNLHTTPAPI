using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MdmApi.Repository;
using MdmApi.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdmApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class NavbarController : ControllerBase
    {
        private readonly IUserManagementRepository _userManagementRepo;

        public NavbarController(IUserManagementRepository userManagementRepo)
        {
            _userManagementRepo = userManagementRepo;
        }
        [Route("GetTopNavBar")]
        [HttpPost]
        public async Task<IActionResult> GetTopNavBar(int roleId)
        {            
            var result = await _userManagementRepo.GetTopNavDetails(roleId);
            return Ok(result);
        }
    }
}
