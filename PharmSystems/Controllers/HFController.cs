using Pharm.Core.Entities;
using Pharm.Repository.ErrorHandler;
using Pharm.Repository.HFRepository;
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
    public class HFController : ApiController
    {
        HFRepository _hf = null;
        public void Lazy(bool lazy)
        {
            _hf = new HFRepository(lazy);
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllHF(bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetAllHF");
            try
            {
                var _result = _hf.GetAll();
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

        [AcceptVerbs("GET")]
        public IHttpActionResult GetHFById(int Id = 0, bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetHFByCode");
            try
            {
                if (Id > 0)
                {
                    var _result = _hf.GetById(Id);
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

        [AcceptVerbs("POST")]
        public IHttpActionResult AddNewHF([FromBody]IList<HealthFacility> hf)
        {
            this.Lazy(false);
            ErrorHandler message = new ErrorHandler("AddNewHF");
            try
            {
                if (ModelState.IsValid)
                {
                    if (hf.Count > 0)
                    {
                        foreach (HealthFacility item in hf)
                        {
                            _hf.Add(item);
                        }
                        _hf.SaveChanges();
                        var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Successful);
                        return Json(_responseMessage);
                    }
                    else
                    {
                        var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ParametersIncomplete);
                        return Json(_responseMessage);
                    }
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
        [AcceptVerbs("GET")]
        public IHttpActionResult GetHFByWardId(int Id = 0, bool lazy = false)
        {
            ErrorHandler message = new ErrorHandler("GetHFByWardId");
            this.Lazy(lazy);
            try
            {
                var _result = _hf.FindWithClauseList(x => x.WardID == Id);
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

        [AcceptVerbs("GET")]
        public IHttpActionResult GetHFByPagination(int pageIndex = 0, int pageSize = 0, bool lazy = false)
        {
            ErrorHandler message = new ErrorHandler("GetHFByPagination");
            this.Lazy(lazy);
            try
            {
                var _result = _hf.GetByPagination(pageIndex, pageSize);
                if(_result.Count > 0)
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
