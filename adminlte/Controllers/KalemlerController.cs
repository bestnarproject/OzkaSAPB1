using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;
using adminlte.Models;

namespace adminlte.Controllers
{
    public class KalemlerController : Controller
    {
      KalemlerDataAccessLayer objKalem = new KalemlerDataAccessLayer();
      // GET: Kalemler
      public ActionResult Index()
      {
        List<Kalemler> lstKalem = new List<Kalemler>();
        lstKalem = objKalem.GetAllKalemler().ToList();

        return View(lstKalem);
      }
    }
}