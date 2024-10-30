namespace PhoneBookApi.Models.Concrete
{
    public class Category: BaseEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
