using ArbanZones.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ArbanZones.Repository;
using ArbanZonesDataAccess;

namespace ArbanZones.Controllers
{
    public class AccountController : ApiController
    {
        readonly ResponseData rd = new ResponseData();
        private IArbanZonesRepository _repository;
        public AccountController()
        {
            this._repository = new ArbanZonesRepository(new ArbanZonesEntities());
        }

        #region  OTP Service to get by Mobile Number

        /// <summary>
        /// This Action to use get OTP
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        [Route("GetOtp/{MobileNo}")]
        [HttpGet]
        public HttpResponseMessage MobileVerify(string MobileNo)
        {
            Random rnd = new Random();
            int num = rnd.Next(1111, 9999);
            rd.Status = "Success";
            rd.Code = 200;
            rd.Message = "";
            rd.Data = num;
            return Request.CreateResponse(HttpStatusCode.OK, rd);

        }
        #endregion

        #region User Role Area

        /// <summary>
        /// This Action to Get All Role
        /// </summary>
        /// <returns></returns>
        [Route("GetRole")]
        [HttpGet]
        public HttpResponseMessage RoleList()
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetRoleList();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        #endregion

        #region Category Area
        /// <summary>
        /// This Action to Get All Category
        /// </summary>
        /// <returns></returns>
        [Route("GetCategory")]
        [HttpGet]
        public HttpResponseMessage CategoryList()
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetCategoryList();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        #endregion

        #region Service Proivder Area
        [Route("CreateServiceProviderCategory")]
        [HttpPost]
        public HttpResponseMessage CreateServiceProviderCategory(Service service)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = _repository.CreateServiceProviderCategory(service) ? "Record saved successfully" : "Record Not Saved!";
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        /// <summary>
        /// This Action is get to Service by Category Id
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        [Route("GetServicesProviderCategory")]
        [HttpPost]
        public HttpResponseMessage ServiceListByCategoryRegId(string RegId)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetServiceByCategoryRegId(RegId);
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        #endregion

        #region This area define related to user 
        /// <summary>
        /// This Action to create a user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [Route("Registration")]
        [HttpPost]
        public HttpResponseMessage Registration(UserDetails userDetails)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Data = _repository.CreateUser(userDetails);
                rd.Message = rd.Data != null ? "Registration Successfully!" : "Old User";

                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }

        /// <summary>
        /// This Action to create a user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login(UserDetails userDetails)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Data = _repository.Login(userDetails);
                rd.Message = rd.Data != null ? "Old User" : "New User";
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }

        /// <summary>
        /// This Action to get user by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetUser/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetUserList(string Id)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetUserById(Id);
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        /// <summary>
        /// This action to get all user
        /// </summary>
        /// <returns></returns>
        [Route("GetUser")]
        [HttpGet]
        public HttpResponseMessage GetUserList()
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetUserList();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
            }
            catch (Exception ex)
            {
                rd.Status = "Fail";
                rd.Code = 201;
                rd.Message = ex.ToString();
                return Request.CreateResponse(HttpStatusCode.OK, rd);
                throw;
            }
        }
        #endregion
    }
}
