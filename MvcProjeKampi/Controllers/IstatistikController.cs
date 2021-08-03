using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {

        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        HeadingManager hm = new HeadingManager(new EFHeadingDal());

        WriterManager wm = new WriterManager(new EFWriterDal());

        // GET: Istatistikh
        public ActionResult Index()
        {



            var categoryValues = cm.GetList();

            ViewBag.categoriesLength = categoryValues.Count();

            var trueCount = categoryValues.Where(c => c.CategoryStatus == true).Count();
            var falseCount = categoryValues.Where(c => c.CategoryStatus == false).Count();
            ViewBag.statusDifferenceValue = trueCount - falseCount;

            ViewBag.softwareCategoryLength = hm.GetHeadings().Where(c => c.CategoryID == 25).Count();

            ViewBag.containLetter  = wm.GetWriters().Where(h => h.WriterName.Contains("A") || h.WriterName.Contains("a")).Count();

            ViewBag.repetedCategoryInHeadings = cm.GetList().Where(x => x.CategoryID == (hm.GetHeadings().GroupBy(h => h.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();









            return View(categoryValues);
        }
    }
}