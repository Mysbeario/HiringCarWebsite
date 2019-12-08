namespace Core.ValueObjects {
	public class CarQuery : PaginateQuery {
		public int CarTypeId { get; set; } = 0;
		public int Seat { get; set; } = 0;
		public int MinPrice { get; set; } = 0;
		public int MaxPrice { get; set; } = 0;
	}
}