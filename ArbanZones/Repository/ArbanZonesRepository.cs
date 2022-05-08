using ArbanZones.CommonMethod;
using ArbanZones.Models;
using ArbanZonesDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArbanZones.Repository
{
    public class ArbanZonesRepository : IArbanZonesRepository
    {
        private ArbanZonesEntities _db;
        readonly private Services _service = new Services();
        public ArbanZonesRepository(ArbanZonesEntities db)
        {
            this._db = db;
        }

        public bool CreateServiceProviderCategory(Service service)
        {
            try
            {
                List<tbl_ServiceProvider> _Services = new List<tbl_ServiceProvider>();
                var Categories = service.ServiceProivedId.Split(',');
                foreach (var category in Categories)
                {
                    var services = new tbl_ServiceProvider
                    {
                        CatId = Convert.ToInt32(category),
                        IsActive = true,
                        IsDeleted = false,
                        RegId = service.RegId,
                        ServiceName = service.Name,
                        EntryDate = DateTime.Now,

                    };
                    _Services.Add(services);
                }
                _db.tbl_ServiceProvider.AddRange(_Services);
                if (_db.SaveChanges() > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public UserDetails CreateUser(UserDetails userDetails)
        {
            try
            {
                var chkUser = (from s in _db.tbl_UserDetail where s.MobileNo == userDetails.MobileNo || s.EmailId == userDetails.EmailId select s).FirstOrDefault();
                if (chkUser == null)
                {
                    var keyNew = Helper.GeneratePassword(10);
                    var password = Helper.EncodePassword(userDetails.Password, keyNew);
                    var newUser = new tbl_UserDetail
                    {
                        Id = Guid.NewGuid().ToString(),

                        MobileNo = userDetails.MobileNo,
                        UserId = "Arz." + userDetails.EmailId,
                        EntryDate = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false,
                        DeviceToken = userDetails.DeviceToken,
                        DeviceName = userDetails.DeviceName,
                    };
                    _db.tbl_UserDetail.Add(newUser);
                    if (_db.SaveChanges() > 0)
                    {
                        //_service.PushNotification("Hello user", "New User Create Successfully", newUser.DeviceToken);
                    }
                    return _db.tbl_UserDetail.Where(x => x.Id == newUser.Id)
                        .Select(x => new UserDetails
                        {

                            IsActive = (bool)x.IsActive,
                            IsDeleted = (bool)x.IsDeleted,
                            MobileNo = x.MobileNo,
                            UserName = x.UserId,
                            UserMessage = "New User"

                        }
                        ).FirstOrDefault();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _db.tbl_CategoryMaster.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => new Category
            {
                Id = x.CategoryId,
                Name = x.CategoryName,
                Image = x.Images,
                EntryDate = x.EntryDate
            }).ToList();
        }

        public DashboardDetails GetDashboardDetails()
        {
            DashboardDetails dashboardDetails = new DashboardDetails();

            var Offer = _db.tbl_Offer.Where(x => x.IsActive == true && x.IsDeleted == false).FirstOrDefault();

            dashboardDetails.OfferImgUrl = Offer.OfferImgUrl;
            dashboardDetails.serviceCategory = _db.tbl_CategoryMaster.Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new Category
                {
                    Name = x.CategoryName,
                    Id = x.CategoryId,
                    Image = x.Images
                }).ToList();
            dashboardDetails.banners = _db.tbl_Banner.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => new Banner
            {
                ImgUrl = x.ImageUrl,
                Active = x.IsActive
            }).ToList();
            return dashboardDetails;
        }

        public IEnumerable<RoleMaster> GetRoleList()
        {
            return _db.tbl_Role.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => new RoleMaster
            {
                RoleId = x.RoleId,
                RoleName = x.Role,
                EntryDate = x.EntryDate
            }).ToList();
        }

        public ServiceCategory GetServiceByCategoryId(int CategoryId)
        {
            ServiceCategory serviceCategory = new ServiceCategory();
            serviceCategory.banners = _db.tbl_Banner.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => new Banner
            {
                ImgUrl = x.ImageUrl,
                Active = x.IsActive
            }).ToList();
            serviceCategory.servicesList = _db.tbl_ServiceProvider.Where(x => x.CatId == CategoryId && x.IsActive == true && x.IsDeleted == false).Select(x => new Service
            {
                Name = x.ServiceName,
                Id = x.ServiceId,

            }).ToList();
            serviceCategory.Rating = "5";
            serviceCategory.NoOfBookingsPerYear = "100";
            serviceCategory.ServiceCategryName = "";
            return serviceCategory;
        }

        public List<Service> GetServiceByCategoryRegId(string RegId)
        {
            var ServiceProvider = (from s in _db.tbl_ServiceProvider.Where(x => x.RegId == RegId)
                                   join cat in _db.tbl_CategoryMaster on s.CatId equals cat.CategoryId
                                   select new Service
                                   {
                                       Id = s.ServiceId,
                                       CategoryName = cat.CategoryName,
                                       Name = s.ServiceName,
                                       EntryDate = s.EntryDate
                                   }).ToList();
            return ServiceProvider;
        }

        public UserDetails GetUserById(string Id)
        {
            UserDetails list = new UserDetails();

            if (Id != null && !string.IsNullOrEmpty(Id))
            {
                var list1 = _db.tbl_UserDetail.Where(x => x.Id == Id).FirstOrDefault();

                list = new UserDetails
                {
                    FirstName = list1.Name,
                    LastName = list1.LastName,
                    Address = list1.Address,
                    EmailId = list1.EmailId,
                    IsActive = (bool)list1.IsActive,
                    IsDeleted = (bool)list1.IsDeleted,
                    MobileNo = list1.MobileNo,
                    UserName = list1.UserId,
                    EntryDate = list1.EntryDate,
                    Password = Helper.EncodePassword("Admin@123", list1.VCode),
                };
            }
            return list;
        }

        public IEnumerable<UserDetails> GetUserList()
        {
            return _db.tbl_UserDetail
                   .Select(x => new UserDetails
                   {
                       FirstName = x.Name,
                       LastName = x.LastName,
                       Address = x.Address,
                       EmailId = x.EmailId,
                       IsActive = (bool)x.IsActive,
                       IsDeleted = (bool)x.IsDeleted,
                       MobileNo = x.MobileNo,
                       UserName = x.UserId,
                       EntryDate = x.EntryDate
                   }).ToList();
        }

        public UserDetails Login(Login login)
        {
            try
            {
                var chkUser = _db.tbl_UserDetail.Where(x => x.MobileNo == login.Mobile.Trim() && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (chkUser == null)
                {
                    return null;
                }
                else
                {
                    return new UserDetails
                    {
                        FirstName = chkUser.Name,
                        LastName = chkUser.LastName,
                        EmailId = chkUser.EmailId,
                        IsActive = (bool)chkUser.IsActive,
                        MobileNo = chkUser.MobileNo,
                        UserRole = chkUser.UserRoleId,
                        Password = chkUser.Password,
                        Address = chkUser.Address,
                        DeviceName = chkUser.DeviceName,
                        DeviceToken = chkUser.DeviceToken,
                        EntryDate = chkUser.EntryDate

                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserDetails ProfileUpdate(UserDetails userDetails)
        {
            UserDetails user1 = new UserDetails();
            try
            {
                var chkUser = _db.tbl_UserDetail.Where(x => x.Id == userDetails.RegistrationId).FirstOrDefault();
                if (chkUser != null)
                {
                    chkUser.Name = userDetails.FirstName;
                    chkUser.LastName = userDetails.LastName;
                    chkUser.EmailId= userDetails.EmailId != null ? userDetails.EmailId : chkUser.EmailId;
                    chkUser.MobileNo = userDetails.MobileNo!=null? userDetails.MobileNo : chkUser.MobileNo;
                    chkUser.Address = userDetails.Address != null? userDetails.Address : chkUser.Address;
                    chkUser.ModifyDate = DateTime.Now;
                    _db.tbl_UserDetail.Attach(chkUser);
                    _db.Entry(chkUser).State = EntityState.Modified;
                    if (_db.SaveChanges() > 0)
                    {
                        //_service.PushNotification("Hello user", "Update Successfully", newUser.DeviceToken);
                        user1 = new UserDetails
                        {
                            FirstName = chkUser.Name,
                            LastName = chkUser.LastName,
                            EmailId = chkUser.EmailId,
                            MobileNo = chkUser.MobileNo,
                            Address = chkUser.Address,
                            DeviceName = chkUser.DeviceName,
                            DeviceToken = chkUser.DeviceToken,
                            EntryDate = chkUser.EntryDate,
                            ModifyDate = chkUser.ModifyDate
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                return user1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}