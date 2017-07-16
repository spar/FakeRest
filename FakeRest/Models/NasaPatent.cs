using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeRest.Models
{
    public class NasaPatent : BaseClass
    {
        public string Center { get; set; }
        public string Status { get; set; }
        public string CaseNumber { get; set; }
        public string PatentNumber { get; set; }
        public string ApplicationSn { get; set; }
        public string Title { get; set; }
        public string PatentExpirationDate { get; set; }
        public override string GetSearchableText()
        {
            return Center + Status + CaseNumber + PatentNumber + ApplicationSn + Title;
        }
    }
}