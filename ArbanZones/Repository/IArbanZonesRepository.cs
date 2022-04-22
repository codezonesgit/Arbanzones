using ArbanZones.Models;
using ArbanZonesDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbanZones.Repository
{
    public interface IArbanZonesRepository
    {
        IEnumerable<RoleMaster> GetRoleList();
        IEnumerable<Category> GetCategoryList();
        List<Service> GetServiceByCategoryId(int CatId);
        UserDetails CreateUser(UserDetails userDetails);
        IEnumerable<UserDetails> GetUserList();
        UserDetails GetUserById(string Id);
    }
}
