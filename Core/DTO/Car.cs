namespace Core.DTO
{
	public class CarDTO
	{
		public string Id { get; set; }
		public string NumberPlate { get; set; }
		public string Color { get; set; }
		public bool IsWifiAvailable { get; set; }
		public string CarTypeId { get; set; }
		public string CarTypeName { get; set; }

		public CarDTO(string id, string numberPlate, string color, bool isWifiAvailable, string carTypeId, string carTypeName)
		{
			this.Id = id;
			this.NumberPlate = numberPlate;
			this.Color = color;
			this.IsWifiAvailable = isWifiAvailable;
			this.CarTypeId = carTypeId;
			this.CarTypeName = carTypeName;
		}
	}
}