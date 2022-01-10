using AdminUserSkillSearch.BusinessLogicLayer;
using AdminUserSkillSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserSkillSearch.Controllers
{
    [Route("/skill-tracker/api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserSkillProfileService_BL _userBL;

        public AdminController(IUserSkillProfileService_BL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet("{name}/{value}")]
        public ActionResult<List<UserSkillProfile>> GetByCriteria(string name, string value)
        {
            var result = _userBL.GetByCriteria(name, value);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
