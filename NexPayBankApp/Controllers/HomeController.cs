using NexPayBankApp.Filters;
using NexPayBankApp.Logging;
using NexPayBankApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace NexPayBankApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [TraceFilter]
        public ActionResult AddBankAccount(BankModel BankModelClient)
        {
            return PartialView();
        }

        public List<BankModel> BankAccountsList = null;
        public ActionResult AddBankDetails(BankModel BankModelClient)
        {
            try
            {
                //Inserting the entered details to the notepad
                InsertBankDetailsIntoNotePad(BankModelClient);
                List<BankModel> list = new List<BankModel>();
                list.Add(BankModelClient);
                return Json(list, JsonRequestBehavior.AllowGet);
            }            
              catch (Exception e)
            {
                Log.LogException(e.InnerException.ToString(), "AddBankDetails", "Home", Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5)));

                throw;
            }
        
        }

        private void InsertBankDetailsIntoNotePad(BankModel bank)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;
                string file_name = path + "BankDetails.txt";
                //If file does not exist creating the file
                if (!System.IO.File.Exists(file_name))
                {
                    using (StreamWriter objWriter = System.IO.File.CreateText(file_name))
                    {
                        WriteToNotePad(objWriter, bank);
                    }
                }//If file exists , appending the text
                else
                {
                    using (StreamWriter objWriter = System.IO.File.AppendText(file_name))
                    {
                        WriteToNotePad(objWriter, bank);
                    }
                }

            }
            catch(Exception e)
            {
                Log.LogException(e.InnerException.ToString(), "InsertBankDetailsIntoNotePad","Home", Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5)));

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
            catch(Exception e)
            {
                Log.LogException(e.InnerException.ToString(), "WriteToNotePad", "Home", Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5)));

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
