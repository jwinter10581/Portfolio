using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class RoleRepositoryMock : IRoleRepository
    {
        private static List<Role> _roles = new List<Role>
        {
            new Role
            {RoleId = 1, RoleName = "Admin" },
            new Role
            {RoleId = 2, RoleName = "Sales" },
            new Role
            {RoleId = 3, RoleName = "Disabled" }
        };

        public List<Role> GetAll()
        {
            return _roles;
        }
    }
}
