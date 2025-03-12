using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Doctor;

namespace eUseControl.Web1.Controllers
{
    public class DoctorDetailController : Controller
    {
        private IDoctor _doctor;
        // GET: DoctorDetail
        DoctorDetailController()
        {
            DoctorBL business1 = new DoctorBL();

            _doctor = business1.GetDoctorBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDoctor(int id)
        {

            DoctorDetail doctorDetail = _doctor.GetDetailDoctor(id);
            return View();
        
    }
    }
}