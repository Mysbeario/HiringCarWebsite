using System.Collections.Generic;

namespace Core.Entities {
    public class CarType : BaseEntity {
        public CarType() {
            this.Cars = new HashSet<Car>();
        }
        
        public string Name { get; set; }
        public byte Seat { get; set; }
        public decimal Cost { get; set; } // cost per day

        public ICollection<Car> Cars { get; private set; }
    }
}