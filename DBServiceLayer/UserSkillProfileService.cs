using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUserSkillSearch.Models;

namespace AdminUserSkillSearch.DBServiceLayer
{
    public class UserSkillProfileService
    {
        private readonly IMongoCollection<UserSkillProfile> _userSkillProfileData;
       
        public UserSkillProfileService(IUserSkillProfileDBDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userSkillProfileData = database.GetCollection<UserSkillProfile>(settings.UserSkillProfileCollectionName);
           
        }

        //public List<UserSkillProfile> GetByName( string name) =>
        //   _userSkillProfileData.Find<UserSkillProfile>(b =>  b.Name.StartsWith(name)).ToList();

        //public List<UserSkillProfile> GetByAssociateID(string assocaiteID) =>
        //  _userSkillProfileData.Find<UserSkillProfile>(b => b.AssociateId.StartsWith(assocaiteID)).ToList();

        public List<UserSkillProfile> GetByCriteria(string skillname,string skillvalue)
        {
            List<UserSkillProfile> result = null;
            switch (skillname)
            {
                case "NAME":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.Name.StartsWith(skillvalue)).ToList();
                    break;
                case "ASSOCIATEID":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.AssociateId.StartsWith(skillvalue)).ToList();
                    break;
                case "HTMLCSSJAVASCRIPT":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.HTMLCSSJAVASCRIPT>10).ToList();
                    break;
                case "ANGULAR":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.ANGULAR > 10).ToList();
                    break;
                case "AspNetCore":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.AspNetCore > 10).ToList();
                    break;
                case "REACT":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.REACT > 10).ToList();
                    break;

                case "RESTFUL":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.RESTFUL > 10).ToList();
                    break;
                case "EntityFramework":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.EntityFramework > 10).ToList();
                    break;
                case "GIT":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.GIT > 10).ToList();
                    break;
                case "DOCKER":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.DOCKER > 10).ToList();
                    break;
                case "JENKINS":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.JENKINS > 10).ToList();
                    break;
                case "Azure":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.Azure > 10).ToList();
                    break;
                case "SPOKEN":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.SPOKEN > 10).ToList();
                    break;
                case "COMMUNICATION":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.COMMUNICATION > 10).ToList();
                    break;
                case "APTITUDE":
                    // code block
                    result = _userSkillProfileData.Find<UserSkillProfile>(b => b.APTITUDE > 10).ToList();
                    break;

            }
               
            return result;
        }

    }
}
