using System.ComponentModel;

namespace PhoneBookApi.Models.Concrete
{
    public class Person: BaseEntity
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CategoryID { get; set; }
        public bool IsActive { get; set; } = true;
        public Category? Category { get; set; }
    }
}
