using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities {
    public class CarType: BaseEntity {
        public CarType() {
            this.Cars = new HashSet<Car>();
        }
        
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(2, 10)]
        public byte Seat { get; set; }
        [Required]
        public decimal Cost { get; set; } // cost per day

        public ICollection<Car> Cars { get; private set; }
    }
}