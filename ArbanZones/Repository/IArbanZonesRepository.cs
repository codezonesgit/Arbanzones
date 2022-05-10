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
        bool CreateServiceProviderCategory(Service service);
        List<Service> GetServiceByCategoryRegId(string RegId);
        Task<UserDetails> CreateUser(UserDetails userDetails);
        UserDetails Login(Login login);
        IEnumerable<UserDetails> GetUserList();
        UserDetails GetUserById(string Id);
        DashboardDetails GetDashboardDetails();
        ServiceCategory GetServiceByCategoryId(int CategoryId);
        UserDetails ProfileUpdate(UserDetails userDetails);
        bool ForgotPassword(ForgotPassword forgotPassword);
        Task<List<ServiceItemMaster>> GetServiceItemListByServiceId(int SeviceId);
        Task<ServiceItemMaster> GetViewServiceDetailsByServiceItemId(int SeviceItemId);
        Task<bool> CreateServiceProblem(ServiceProblem serviceProblem);
    }
}
