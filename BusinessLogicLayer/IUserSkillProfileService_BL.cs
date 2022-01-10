using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUserSkillSearch.Models;

namespace AdminUserSkillSearch.BusinessLogicLayer
{
    public interface IUserSkillProfileService_BL
    {

        public List<UserSkillProfile> GetByCriteria(string skillname, string skillvalue);

    }
}
