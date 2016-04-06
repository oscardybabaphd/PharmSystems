using Pharm.Core.Entities;
using Pharm.Repository.ErrorHandler;
using Pharm.Repository.WardRepository;
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
    public class WardController : ApiController
    {
        protected WRepository _Ward = null;
      
        public void Lazy(bool lazy)
        {
            _Ward = new WRepository(lazy);
            
        }
        [AcceptVerbs("GET")]
        // Api/Ward/GetAllWard/
        public IHttpActionResult GetAllWard(bool lazy = false)
        {
            this.Lazy(lazy);
            var message = new ErrorHandler("GetAllWard");
            try
            {
                var _getAllWards = _Ward.GetAll();
                if (_getAllWards.Count > 0)
                {
                    //var _wardJoinWithState = _getAllWards
                    return Json(_getAllWards);
                }
                else
                {
                    //ErrorHandler 
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult));
                }
            }
            catch (Exception)
            {
                return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        // Api/Ward/GetWardById/Id
        public IHttpActionResult GetWardById(int Id = 0,bool lazy = false)
        {
            this.Lazy(lazy);
            var message = new ErrorHandler("GetWardById");
            try
            {
                Ward _getWardById = null;
                if (Id > 0)
                {
                    _getWardById = _Ward.GetById(Id);
                    if (_getWardById != null)
                    {
                        return Json(_getWardById);
                    }
                    else
                    {
                        return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult));
                    }

                }
                else
                {
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ParametersIncomplete));
                }
            }
            catch (Exception)
            {
                return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError));
            }
        }
        [AcceptVerbs("GET")]
        // Api/Ward/GetWardByCode/?code=0110&lazy=true
        public IHttpActionResult GetWardByLGAId(int Id = 0,bool lazy = false)
        {
            this.Lazy(lazy);
            var message = new ErrorHandler("GetWardByCode");
            try
            {
                IList<Ward> _getWardByCode = null;
                if (Id > 0)
                {
                    _getWardByCode = _Ward.FindWithClauseList(x => x.LGAID == Id);//GetWardByCode(code);
                    if (_getWardByCode != null)
                    {
                        return Json(_getWardByCode);
                    }
                    else
                    {
                        return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult));
                    }

                }
                else
                {
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ParametersIncomplete));
                }
            }
            catch (Exception)
            {
                return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// { "Name": "isolko North", "Code" : "0807", "LGAID":3}
        /// <returns></returns>
        [AcceptVerbs("POST")]
        // Api/Ward/AddNewWard/ Post json params 
        public IHttpActionResult AddNewWard([FromBody]IList<Ward> ward)
        {
           this.Lazy(false);
            var message = new ErrorHandler("AddNewWard");
            try
            {
                if (ModelState.IsValid)
                {
                    //check if record already exist
                    if (ward.Count > 0)
                    {
                        foreach (Ward item in ward)
                        {
                            _Ward.Add(item);
                        }
                    }
                    _Ward.SaveChanges();
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Successful));
                }
                else
                {
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure));
                }
            }
            catch (Exception)
            {
                return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError));
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetWardByPagination(int pageIndex = 0, int pageSize = 0,bool lazy = false)
        {
            this.Lazy(lazy);
            var message = new ErrorHandler("GetWardByPagination");
            try
            {
                if (pageIndex > 0 && pageSize > 0)
                {
                    var _result = _Ward.GetWardByPagination(pageIndex, pageSize);
                    if (_result.Count > 0)
                    {
                        return Json(_result);
                    }
                    else
                    {
                        return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.SuccessfulWithNoResult));
                    }
                }
                else
                {
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.PaginationValueIsNotCorrect));
                }
            }
            catch (Exception)
            {
                return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.ApplicationError));
            }
        }
    }
}
