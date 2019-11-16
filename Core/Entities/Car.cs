namespace Core.Entities {
    public class Car : BaseEntity {
        public string CarTypeId { get; set; }
        public string NumberPlate { get; set; }
        public string Color { get; set; }
        public bool isWifiAvailable { get; set; }

        public virtual CarType CarType { get; set; }
    }
}