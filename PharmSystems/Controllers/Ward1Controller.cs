using Pharm.Repository.ErrorHandler;
using Pharm.Repository.WardRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace PharmSystems.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Ward1Controller : Controller
    {
        //
        // GET: /Ward1/
            protected WRepository _Ward = null;
            public Ward1Controller()
            {
                _Ward = new WRepository();
            }

            [System.Web.Http.Route("GetAllWard")]
            [HttpGet]

            // Api/Ward/GetAllWard/
            public ActionResult GetAllWard()
            {
                var _getAllWards = _Ward.GetAll();
                if (_getAllWards.Count > 0)
                {
                    return Json(_getAllWards, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //ErrorHandler 
                    var message = new ErrorHandler("GetAllWard", _getAllWards.Count);
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure), JsonRequestBehavior.AllowGet);
                }
            }

            [System.Web.Http.Route("GetWardById")]
            [HttpGet]
            // Api/Ward/GetWardById/Id
            public ActionResult GetWardById(int Id)
            {
                var _getWardById = _Ward.GetById(Id);
                if (_getWardById != null)
                {
                    return Json(_getWardById,JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var message = new ErrorHandler("GetWardById");
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure), JsonRequestBehavior.AllowGet);
                }
            }

            [System.Web.Http.Route("GetWardByCode")]
            [HttpGet]
            // Api/Ward/GetWardByCode/Code
            public ActionResult GetWardByCode(string Code)
            {
                var _getWardByCode = _Ward.GetByCode(Code);
                if (_getWardByCode != null)
                {
                    return Json(_getWardByCode);
                }
                else
                {
                    var message = new ErrorHandler("GetWardByCode");
                    return Json(message.ResponseMessageHandler(Pharm.Repository.ErrorHandler.ResponseMessage.AppResponseCode.Failure), JsonRequestBehavior.AllowGet);
                }
            }
        

    }
}
