using System.ComponentModel;

namespace ShopOnline.Api.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
