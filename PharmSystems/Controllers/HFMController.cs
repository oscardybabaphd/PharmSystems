using Pharm.Core.Entities;
using Pharm.Repository.ErrorHandler;
using Pharm.Repository.HFMRepository;
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
    public class HFMController : ApiController
    {
        HFMRepository _hfm = null;
        public void Lazy(bool lazy)
        {
            _hfm = new HFMRepository(lazy);
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllHFM(bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetAllHFM");
            try
            {
                var _result = _hfm.GetAll();
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
        public IHttpActionResult GetHFMByPagination(int pageIndex = 0, int pageSize = 0, bool lazy = false)
        {
            this.Lazy(lazy);
            ErrorHandler message = new ErrorHandler("GetHFMByPagination");
            try
            {
                var _result = _hfm.GetByPagination(pageIndex, pageSize);
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

        [AcceptVerbs("POST")]
        public IHttpActionResult AddNewHFM([FromBody]IList<HFManager> hfmanager)
        {
            this.Lazy(false);
            ErrorHandler message = new ErrorHandler("AddNewHFM");
            try
            {
                if(ModelState.IsValid)
                {
                    if(hfmanager.Count > 0)
                    {
                        foreach (var item in hfmanager)
                        {
                            _hfm.Add(item);
                        }
                        _hfm.SaveChanges();
                        var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Successful);
                        return Json(_responseMessage);
                    }
                    else
                    {
                        var _responseMessage = message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure);
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
    }
}
