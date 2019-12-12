using System.ComponentModel.DataAnnotations;

namespace WebApp.Model {
	public class BookingVM {
		public int Id { get; set; }
		public string UserId { get; set; }
		public string Status { get; set; }

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