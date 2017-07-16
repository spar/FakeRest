namespace FakeRest.Models
{
    public class NasaFacility : BaseClass
    {
        public string Center { get; set; }
        public string CenterSearchStatus { get; set; }
        public string Facility { get; set; }
        public string Occupied { get; set; }
        public string Status { get; set; }
        public string UrlLink { get; set; }
        public string RecordDate { get; set; }
        public string LastUpdate { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public override string GetSearchableText()
        {
            return Center + CenterSearchStatus + Status + Facility + Country + City + State + Zipcode;
        }
    }

}