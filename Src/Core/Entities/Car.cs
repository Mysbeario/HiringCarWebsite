using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities {
    public class Car : BaseEntity {
        public Car() {
            this.Bookings = new HashSet<Booking>();
        }

        [Required]
        public int CarTypeId { get; set; }

        [Required]
        [RegularExpression ("^[0-9]{2}[A-Za-z]{1}-[0-9]{4,5}$", ErrorMessage = "Invalid number plate!")]
        public string NumberPlate { get; set; }

        [Required]
        public string Color { get; set; }
        public string ImgPath { get; set; }

        public virtual CarType CarType { get; set; }
        public ICollection<Booking> Bookings { get; private set; }
    }
}