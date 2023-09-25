using mvc_task.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_task.Controllers
{
    public class AdminController : Controller
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
        mvc_task.Models.DataServices db = new mvc_task.Models.DataServices();

        // GET: Admin
        
        #region manage subadmin

        public ActionResult add_subadmin(string id)
        {
            manage_subadmin subadmin = new manage_subadmin();


            if (id != null && id != "")
            {
                subadmin = db.getsubadminById(id);
            }
            return View(subadmin);
        }
        [HttpPost]
        public ActionResult insert_subadmin(manage_subadmin subadmin)
        {
            var path = System.IO.Path.Combine(Server.MapPath("~/tempimage/"));


            HttpPostedFileBase file1 = Request.Files["fileupload1"];

            string uploadpayslipss1;

            if (file1 != null && file1.FileName.ToString() != "")
            {
                uploadpayslipss1 = DateTime.Now.ToString("ddMMyy") + System.Guid.NewGuid() + "." + file1.FileName.Split('.')[1];
                file1.SaveAs(path + uploadpayslipss1);
                subadmin.File_Path = "/tempimage/" + uploadpayslipss1;

            }

            var dd = db.insert_subadmin(subadmin);

            if (dd == true)
            {
                TempData["Message"] = "subadmin Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }


            return RedirectToAction("add_subadmin");
        }
        public ActionResult view_subadmin()
        {
            List<manage_subadmin> subadminlist= new List<manage_subadmin>();
            subadminlist = db.getsubadminlist();
            return View(subadminlist);
        }


        public ActionResult delet_subadmin(string id)
        {

            db.delete_subadmin(id);


            return RedirectToAction("view_subadmin");
        }

        #endregion

        #region manage sequence No


        public ActionResult add_sequence( string id)
        {

            manage_sequence sequence = new manage_sequence();


            if (id != null && id != "")
            {
                sequence = db.getsequenceById(id);
            }

            return View(sequence);
        }
        [HttpPost]
        public ActionResult insert_sequence(manage_sequence sequence)
        {

            var dd = db.insert_sequence(sequence);

            if (dd == true)
            {
                TempData["Message"] = "Sequence Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_sequence");
        }

        public ActionResult view_sequence()
        {
            List<manage_sequence> sequencelist = new List<manage_sequence>();
            sequencelist = db.get_sequence_list();
            return View(sequencelist);
        }


        public ActionResult delet_sequence(string id)
        {

            db.delete_sequence(id);


            return RedirectToAction("view_sequence");
        }

        #endregion

        #region manage product master

        public ActionResult add_product(string id)
        {
            manage_product product= new manage_product();

            if(id!=null && id != "")
            {
                product=db.getproductbyId(id);
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult insert_products(manage_product products)
        {


            var path = System.IO.Path.Combine(Server.MapPath("~/tempimage/"));


            HttpPostedFileBase file1 = Request.Files["fileupload1"];

            string uploadpayslipss1;

            if (file1 != null && file1.FileName.ToString() != "")
            {
                uploadpayslipss1 = DateTime.Now.ToString("ddMMyy") + System.Guid.NewGuid() + "." + file1.FileName.Split('.')[1];
                file1.SaveAs(path + uploadpayslipss1);
                products.File_Path = "/tempimage/" + uploadpayslipss1;

            }

            var dd = db.insert_product(products);

            if (dd == true)
            {
                TempData["Message"] = "product Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }


            return RedirectToAction("add_product");
        }
        public ActionResult view_product()
        {
            List<manage_product> products = new List<manage_product>();
            products = db.getproductlist();
            return View(products);
        }


        public ActionResult delet_products(string id)
        {

            db.delete_product(id);


            return RedirectToAction("view_product");
        }

        #endregion

        #region manage vendor master

        public ActionResult add_vendor(string id)
        {
            manage_vendor vendor=new manage_vendor();
            if (id != null && id != "")
            {
                vendor=db.getvendorById(id);
            }

            return View(vendor);
        }
        [HttpPost]
        public ActionResult insert_vendor(manage_vendor vendor)
        {


            var dd = db.insert_vendor(vendor);

            if (dd == true)
            {
                TempData["Message"] = "subadmin Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_vendor");
        }

        public ActionResult view_vendor()
        {
            List<manage_vendor> vendor = new List<manage_vendor>();
            vendor=db.getvendorlist();
            return View(vendor);
        }


        public ActionResult delet_vendor(string id)
        {

            db.delete_vendor(id);


            return RedirectToAction("view_vendor");
        }

        #endregion

        #region manage sale book

        public ActionResult add_salebook(string id)
        {
            manage_salebook salebook= new manage_salebook();
            if(id!=null && id != "")
            {
                salebook=db.getsalebookbyId(id);
            }
            return View(salebook);

        }

        [HttpPost]
        public ActionResult insert_salebook(manage_salebook salebook)
        {


            var dd = db.insert_salebook(salebook);

            if (dd == true)
            {
                TempData["Message"] = "salebook Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_salebook");
        }

        public ActionResult view_salebook()
        {
            List<manage_salebook> salebook=new List<manage_salebook>();
            salebook = db.getsalebooklist();
            return View(salebook);
        }


        public ActionResult delet_salebook(string id)
        {

            db.delete_salebook(id);


            return RedirectToAction("view_salebook");
        }


        #endregion

        #region manage PI

        public ActionResult add_pi(string id)
        {

            manage_pi pi = new manage_pi();
            if (id != null && id != "")
            {
                pi = db.getPIbyId(id);
            }
            return View(pi);
        }
        [HttpPost]
        public ActionResult insert_pi(manage_pi pi)
        {

            var dd = db.insert_PI(pi);

            if (dd == true)
            {
                TempData["Message"] = "PI Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_pi");
        }

        public ActionResult view_pi()
        {
            List<manage_pi> pi = new List<manage_pi>();
            pi=db.getPIlist();
            return View(pi);
        }


        public ActionResult delet_pi(string id)
        {

            db.delete_PI(id);


            return RedirectToAction("view_pi");
        }

        #endregion


        #region manage PO

        public ActionResult add_po(string id)
        {
            manage_po po = new manage_po();


            if (id != null && id != "")
            {
                po = db.getPObyId(id);
            }


            return View(po);
        }
        [HttpPost]
        public ActionResult insert_po(manage_po po)
        {

            var dd = db.insert_PO(po);

            if (dd == true)
            {
                TempData["Message"] = "PO Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_po");
        }

        public ActionResult view_po()
        {
            List<manage_po> polist = new List<manage_po>();
            polist = db.getPOlist();
            return View(polist);
        }

        public ActionResult delet_po(string id)
        {
            db.delete_PO(id);
            return RedirectToAction("view_po");
        }


        #endregion


        #region manage Quotation

        public ActionResult add_quotation(string id)
        {

            manage_quotation quot = new manage_quotation();


            if (id != null && id != "")
            {
                quot = db.getQuotationbyId(id);
            }


            return View(quot);
        }
        [HttpPost]
        public ActionResult insert_quotation(manage_quotation quot)
        {

            var dd = db.insert_Quotation(quot);

            if (dd == true)
            {
                TempData["Message"] = "Quotation Submitted Successfully";
                TempData["para"] = "true";
            }
            else
            {
                TempData["Message"] = "Please Review Your Input Details!!";
                TempData["para"] = "false";
            }

            return RedirectToAction("add_quotation");
        }

        public ActionResult view_quotation()
        {

            List<manage_quotation> quotlist = new List<manage_quotation>();
            quotlist = db.getQuotationlist();
            return View(quotlist);
        }

        public ActionResult delet_quotation(string id)
        {
            db.delete_Quotation(id);
            return RedirectToAction("view_quotation");
        }


        #endregion

    }
}