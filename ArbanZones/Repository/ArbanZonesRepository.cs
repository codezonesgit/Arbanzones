﻿using ArbanZones.CommonMethod;
using ArbanZones.Models;
using ArbanZonesDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Repository
{
    public class ArbanZonesRepository : IArbanZonesRepository
    {
        private ArbanZonesEntities _db;
        public ArbanZonesRepository(ArbanZonesEntities db)
        {
            this._db = db;
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
                        Name = userDetails.FirstName,
                        LastName = userDetails.LastName,
                        EmailId = userDetails.EmailId,
                        MobileNo = userDetails.MobileNo,
                        Address = userDetails.Address,
                        UserRoleId = userDetails.UserRole,
                        IsActive = true,
                        IsDeleted = false,
                        UserId = "Arz." + userDetails.EmailId,
                        Password = password,
                        VCode = keyNew,
                        EntryDate = DateTime.Now,

                    };
                    _db.tbl_UserDetail.Add(newUser);
                    _db.SaveChanges();
                    return _db.tbl_UserDetail.Where(x => x.Id == newUser.Id)
                        .Select(x => new UserDetails
                        {
                            FirstName = x.Name,
                            LastName = x.LastName,
                            Address = x.Address,
                            EmailId = x.EmailId,
                            IsActive = (bool)x.IsActive,
                            IsDeleted = (bool)x.IsDeleted,
                            MobileNo = x.MobileNo,
                            UserName = x.UserId
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
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Images = x.Images,
                EntryDate = x.EntryDate
            }).ToList();
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

        public List<Service> GetServiceByCategoryId(int CatId)
        {
            return _db.tbl_Service.Where(x => x.CatId == CatId && x.IsActive == true && x.IsDeleted == false).Select(x => new Service
            {
                ServiceId = x.ServiceId,
                CategoryId = x.CatId,
                ServiceName = x.ServiceName,
                EntryDate = x.EntryDate
            }).ToList();
        }

        public UserDetails GetUserById(string Id)
        {
            UserDetails list = new UserDetails();

            if (Id != null && !string.IsNullOrEmpty(Id))
            {
              var  list1 = _db.tbl_UserDetail.Where(x => x.Id == Id).FirstOrDefault();

                list= new UserDetails
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
    }
}