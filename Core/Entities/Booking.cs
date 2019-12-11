using System;

namespace Core.Entities
{
    public class Booking: BaseEntity
    {
        public int CarId { get; set; }
        public string UserId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal TotalCost { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}