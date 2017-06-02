using System.Runtime.InteropServices;

namespace FakeRest.Models
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public abstract string GetSearchableText();
    }
}