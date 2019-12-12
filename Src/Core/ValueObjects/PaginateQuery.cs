namespace Core.ValueObjects
{
    public class PaginateQuery
    {
        public int PageSize { get; set; }
        public string SortBy { get; set; } = "id";
        public string Search { get; set; } = " ";
        public bool Desc { get; set; } = false;
    }
}