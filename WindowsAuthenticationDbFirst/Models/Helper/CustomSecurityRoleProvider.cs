using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WindowsAuthenticationDbFirst.Models.Helper
{
    public class CustomSecurityRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (SkillAssessmentDbContext _dbContext = new SkillAssessmentDbContext()) {
                username = "ssoni";
                User _user = _dbContext.Users.FirstOrDefault(p => p.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase) || p.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase));
                if (_user != null) {
                    var roles = from ur in _user.UserRoles
                                from r in _dbContext.Roles
                                where ur.RoleId == r.Id
                                select r.RoleName;
                    if (roles != null) { return roles.ToArray(); }
                    
                }
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (SkillAssessmentDbContext _dbContext = new SkillAssessmentDbContext())
            {
                User _user = _dbContext.Users.FirstOrDefault(p => p.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)
                                                                || p.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase));
                var roles = from ur in _user.UserRoles
                            from r in _dbContext.Roles
                            where ur.RoleId == r.Id
                            select r.RoleName;
                if (_user != null)
                    return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
                else
                    return false;
            }
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}