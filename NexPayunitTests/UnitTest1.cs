using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexPayBankApp;
using NexPayBankApp.Controllers;
using NexPayBankApp.Models;

namespace NexPayunitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForIndex()
        {          
            var controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            //Asert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestForBankAccountView()
        {
            var controller = new HomeController();
            var bankAccount = new BankModel();
            PartialViewResult result = controller.AddBankAccount(bankAccount) as PartialViewResult;
            //Asert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestForBankDetails()
        {
            var controller = new HomeController();
            var bankAccount = new BankModel();
            bankAccount.BSB = 062345;
            bankAccount.AccountNumber = 12345678;
            bankAccount.AccountName = "TestName";
            bankAccount.Reference = "By transfer";
            bankAccount.PaymentAmount = 1500.00;
            List<BankModel> list = new List<BankModel>();
            list.Add(bankAccount);
            var jsonResult = controller.AddBankDetails(bankAccount) as JsonResult;
            //Assert     
            List<BankModel> result = jsonResult.Data as List<BankModel>;

            Assert.AreEqual(list.Count, result.Count);
            Assert.AreEqual(list[0].AccountName, result[0].AccountName);
            Assert.AreEqual(list[0].AccountNumber, result[0].AccountNumber);
            Assert.AreEqual(list[0].BSB, result[0].BSB);
            Assert.AreEqual(list[0].Reference, result[0].Reference);
            Assert.AreEqual(list[0].PaymentAmount, result[0].PaymentAmount);

        }

        [TestMethod]
        public void TestTogetBankDetails()
        {
            var controller = new HomeController();
            List<BankModel> list = new List<BankModel>();
            var jsonResult = controller.GetBankDetails() as JsonResult;
                
            List<BankModel> result = jsonResult.Data as List<BankModel>;
            //Assert 
            Assert.AreEqual(list.Count, result.Count);      

        }
    }
}
