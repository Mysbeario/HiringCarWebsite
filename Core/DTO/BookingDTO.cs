namespace Core.DTO {
	public class BookingDTO {
		public int Id { get; set; }
		public string PickUpDate { get; set; }
		public string DropOffDate { get; set; }
		public string PickUpLocation { get; set; }
		public string DropOffLocation { get; set; }
		public string NumberPlate { get; set; }
		public string UserEmail { get; set; }
		public decimal TotalCost { get; set; }
		public string Status { get; set; }
	}
}