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
using System.Threading.Tasks;

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
        /// <summary>
        /// This method is use to get Service cattegory by Id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [Route("GetServiceCategoryById/{CategoryId}")]
        [HttpGet]
        public HttpResponseMessage GetServiceCategoryById(int CategoryId)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetServiceByCategoryId(CategoryId);
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

        #region Service Master Area
        /// <summary>
        /// This Action is get to Service Item by Service Id
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        [Route("GetServicItem/{ServiceId}")]
        [HttpGet]
        public HttpResponseMessage ServiceItemListByServiceId(int ServiceId)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetServiceItemListByServiceId(ServiceId);
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
        /// This Action is View Service Item Details by Service Item Id
        /// </summary>
        /// <param name="ServiceItemId"></param>
        /// <returns></returns>
        [Route("ViewServiceDetails/{ServiceItemId}")]
        [HttpGet]
        public HttpResponseMessage ViewServiceDetails(int ServiceItemId)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetViewServiceDetailsByServiceItemId(ServiceItemId);
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
        /// This Action is get to Service by Services Provider Id
        /// </summary>
        /// <param name="RegId"></param>
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
        public HttpResponseMessage Login(Login login)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Data = _repository.Login(login);
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

        /// <summary>
        /// This Action to update user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [Route("ProfileUpdate")]
        [HttpPost]
        public HttpResponseMessage ProfileUpdate(UserDetails userDetails)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Data = _repository.ProfileUpdate(userDetails);
                rd.Message = rd.Data != null ? "Record Update Successfully" : "Record Not update";
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
        /// This Action to for Forgot password
        /// </summary>
        /// <param name="forgotPassword"></param>
        /// <returns></returns>
        [Route("ForgotPassword")]
        [HttpPost]
        public HttpResponseMessage ForgotPassword(ForgotPassword forgotPassword)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Data = _repository.ForgotPassword(forgotPassword);
                rd.Message = rd.Data != null ? "Record Update Successfully" : "Record Not update";
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

        #region This area define related to Dashboard
        [Route("GetDashboardDetails")]
        [HttpGet]
        public HttpResponseMessage GetDashboardDetails()
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                rd.Message = "";
                rd.Data = _repository.GetDashboardDetails();
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

        #region Order Area
        /// <summary>
        /// This Action to create a user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [Route("SendServiceProblem")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateServiceProblem(ServiceProblem serviceProblem)
        {
            try
            {
                rd.Status = "Success";
                rd.Code = 200;
                var result = await _repository.CreateServiceProblem(serviceProblem);
                rd.Message = result == true ? "Your order has been placed!" : "Opps";
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
