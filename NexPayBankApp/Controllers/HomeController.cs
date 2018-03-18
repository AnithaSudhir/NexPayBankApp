using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NexPayBankApp.Models;
using System.IO;

namespace NexPayBankApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBankAccount(BankModel BankModelClient)
        {
            return PartialView();
        }

        public List<BankModel> BankAccountsList = null;
        public ActionResult AddBankDetails(BankModel BankModelClient)
        {
            InsertBankDetailsIntoNotePad(BankModelClient);
            List<BankModel> list = new List<BankModel>();
            list.Add(BankModelClient);            
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        private void InsertBankDetailsIntoNotePad(BankModel bank)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                string file_name = path + "BankDetails.txt";
                if (!System.IO.File.Exists(file_name))
                {
                    using (StreamWriter objWriter = System.IO.File.CreateText(file_name))
                    {
                        WriteToNotePad(objWriter, bank);
                    }
                }
                else
                {
                    using (StreamWriter objWriter = System.IO.File.AppendText(file_name))
                    {
                        WriteToNotePad(objWriter, bank);
                    }
                }

            }
            catch
            {
                throw;
            }

        }

        private void WriteToNotePad(StreamWriter objWriter, BankModel bank)
        {
            try
            {
                objWriter.Write(Environment.NewLine);
                objWriter.Write("Account name : " + bank.AccountName + Environment.NewLine);
                objWriter.Write("BSB : " + bank.BSB + Environment.NewLine);
                objWriter.Write("Account number : " + bank.AccountNumber + Environment.NewLine);
                objWriter.Write("Reference : " + bank.Reference + Environment.NewLine);
                objWriter.Write("Amount : " + bank.PaymentAmount + Environment.NewLine);
            }
            catch
            {
                throw;
            }
        }

       
        public ActionResult GetBankDetails()
        {
            BankAccountsList = new List<BankModel>();
            return Json(BankAccountsList, JsonRequestBehavior.AllowGet);
        }
    }
}
