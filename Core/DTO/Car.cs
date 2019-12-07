namespace Core.DTO
{
	public class CarDTO
	{
		public int Id { get; set; }
		public string NumberPlate { get; set; }
		public string Color { get; set; }
		public string CarTypeId { get; set; }
		public string CarTypeName { get; set; }
		public decimal Cost { get; set; }
		public byte Seat { get; set; }
		public string ImgPath { get; set; }
	}
}