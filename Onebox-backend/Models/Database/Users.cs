namespace Onebox_backend.Models.Database
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int KlantID { get; set; } 

        public Klant Klant { get; set; }
    }
}
