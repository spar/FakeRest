namespace FakeRest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }

        public string GetSearchableText()
        {
            return Id + FirstName + LastName + Email + Gender;
        }
    }
}