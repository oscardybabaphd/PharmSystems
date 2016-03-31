using Pharm.Repository.ErrorHandler;
using Pharm.Repository.StateRepository;
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
    public class StateController : ApiController
    {
        SRepository _State = null;
        public void Lazy(bool lazy)
        {
            _State = new SRepository(lazy);
        }
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllState(bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetAllState");
            try
            {
                var _result = _State.GetAll();
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
        public IHttpActionResult GetStateByCode(string code = "", bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetByCode");
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    var _result = _State.FindWithClause(x=>x.Code == code);
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
    }
}
