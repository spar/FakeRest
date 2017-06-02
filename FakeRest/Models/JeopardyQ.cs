namespace FakeRest.Models
{
    public class JeopardyQ : BaseClass
    {
        public string Category { get; set; }
        public string AirDate { get; set; }
        public string Question { get; set; }
        public string Value { get; set; }
        public string Answer { get; set; }
        public string Round { get; set; }
        public string ShowNumber { get; set; }
        public override string GetSearchableText()
        {
            return Id + Category + AirDate + Question + Value + Answer + Round + ShowNumber;
        }
    }
}