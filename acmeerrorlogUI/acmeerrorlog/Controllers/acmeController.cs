using acmeerrorlogBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acmeerrorlog.Controllers
{
    public class acmeController : Controller
    {
        // GET: acme
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                blObj = new acmeBL();
                var result = blObj.GetAllUsers();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No user found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }

        }
        public HttpResponseMessage GetUsersByemail()
        {
            try
            {
                blObj = new acmeBL();
                var result = blObj.GetAllUsersByemail();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No users found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }

        }

    }
}
    
