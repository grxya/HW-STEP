using System;
using System.Collections.Generic;

namespace HW1
{
    public class User
    {
        public User()
        {
            Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 

        public ICollection<Seller> Sellers { get; set; }
    }
}
