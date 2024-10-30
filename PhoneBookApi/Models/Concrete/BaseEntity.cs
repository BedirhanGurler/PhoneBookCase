using PhoneBookApi.Models.Abstract;

namespace PhoneBookApi.Models.Concrete
{
    public class BaseEntity: IEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
