namespace PhoneBookApi.Models.DTO
{
    public class PersonDTO
    {
        public int PersonID { get; set; }         
        public string FullName { get; set; }    
        public string Title { get; set; }         
        public string Description { get; set; }   
        public string PhoneNumber { get; set; }   
        public string Email { get; set; }
        public int CategoryID { get; set; }
        public bool IsActive { get; set; } = true;
        public string? CategoryName { get; set; } 
    }
}
