using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities {
    public class User : IdentityUser {
        public User() {
            this.Bookings = new HashSet<Booking>();
        }
        public ICollection<Booking> Bookings { get; private set; }
    }
}