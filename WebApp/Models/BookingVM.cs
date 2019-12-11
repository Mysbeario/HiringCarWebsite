using System.ComponentModel.DataAnnotations;

namespace WebApp.Model {
	public class BookingVM {
		[Required]
		public string PickUpDate { get; set; }
		[Required]
		public string DropOffDate { get; set; }
		[Required]
		public string PickUpLocation { get; set; }
		[Required]
		public string DropOffLocation { get; set; }
		[Required]
		public int CarId { get; set; }
	}
}