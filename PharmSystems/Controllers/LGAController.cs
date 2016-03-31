using Pharm.Core.Entities;
using Pharm.Repository.ErrorHandler;
using Pharm.Repository.LGARepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PharmSystems.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LGAController : ApiController
    {
        LRepository _Lga = null;
        public void Lazy(bool lazy)
        {
            _Lga = new LRepository(lazy);
        }
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllLGA(bool lazy = false)
        {
            this.Lazy(lazy);
            var message = new ErrorHandler("GetAllLGA");
            try
            {
                var _result = _Lga.GetAll();
                if (_result != null)
                {
                    return Json(_result);
                }
                else
                {
                    var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult);
                    return Json(_responseMessage);
                }
            }
            catch (Exception)
            {
                var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError);
                return Json(_responseMessage);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetLGAByCode(string code = "",bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetLGAByCode");
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    var _result = _Lga.FindWithClause(x=>x.Code == code);
                    if (_result != null)
                    {
                        return Json(_result);
                    }
                    else
                    {
                        var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult);
                        return Json(_responseMessage);
                    }
                }
                else
                {
                    var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ParametersIncomplete);
                    return Json(_responseMessage);
                }
            }
            catch (Exception)
            {
                var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError);
                return Json(_responseMessage);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lga"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        public IHttpActionResult AddNewLGA([FromBody]IList<LGA> lga)
        {
            this.Lazy(false);
            ErrorHandler message = new ErrorHandler("AddNewLGA");
            try
            {
                if (ModelState.IsValid)
                {
                    if (lga.Count > 0)
                    {
                        foreach (LGA item in lga)
                        {
                            _Lga.Add(item);
                        }
                    }
                    _Lga.SaveChanges();
                    var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Successful);
                    return Json(_responseMessage);
                }
                else
                {
                    var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure);
                    return Json(_responseMessage);
                }
            }
            catch (Exception)
            {

                var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError);
                return Json(_responseMessage);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetLGAByPagination(int pageIndex = 0, int pageSize = 0, bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetLGAByPagination");
            try
            {
                var _result = _Lga.GetLGAPagination(pageIndex, pageSize);
                if (_result.Count > 0)
                {
                    return Json(_result);
                }
                else
                {
                    var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult);
                    return Json(_responseMessage);
                }
            }
            catch (Exception)
            {
                var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError);
                return Json(_responseMessage);
            }
        }

    }
}
