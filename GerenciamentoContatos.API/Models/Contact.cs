namespace GerenciamentoContatos.API.Models
{
    public class Contact
    {
        public Contact()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


        public void Update(int id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

       
    }
}
