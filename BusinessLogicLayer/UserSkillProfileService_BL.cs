using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUserSkillSearch.DBServiceLayer;
using AdminUserSkillSearch.Models;

namespace AdminUserSkillSearch.BusinessLogicLayer
{
    public class UserSkillProfileService_BL:IUserSkillProfileService_BL
    {
        private readonly UserSkillProfileService _userService;

        public UserSkillProfileService_BL(UserSkillProfileService userService)
        {
            _userService = userService;
        }



        public List<UserSkillProfile> GetByCriteria(string skillname, string skillvalue)
        {
            return _userService.GetByCriteria(skillname, skillvalue);
        }

      
        
    }
}
