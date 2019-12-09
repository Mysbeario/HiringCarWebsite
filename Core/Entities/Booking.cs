using System;

namespace Core.Entities
{
    public class Booking: BaseEntity
    {
        public int CarId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public virtual Car Car { get; set; }
    }
}