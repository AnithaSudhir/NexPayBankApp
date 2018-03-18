using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NexPayBankApp.Models
{
    public class BankModel
    {
        public int BSB { get; set; }               
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public double PaymentAmount { get; set; }
    }
}