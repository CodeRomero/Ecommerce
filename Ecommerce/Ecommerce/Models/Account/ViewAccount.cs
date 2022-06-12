namespace Ecommerce.Models.Account
{
    public class ViewAccount
    {
        public int AccountId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Usrname { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Membership { get; set; }
        public int Balance { get; set; }
    }
}
