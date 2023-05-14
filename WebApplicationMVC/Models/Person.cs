using System.ComponentModel;

namespace WebApplicationMVC.Models
{
    public class Person
    {
        [DisplayName("Id")]
        public int PersonId { get; set; }

        [DisplayName("Name")]
        public string PersonName { get; set; } = "";

        [DisplayName("Age")]
        public int PersonAge { get; set; }
    }
}
