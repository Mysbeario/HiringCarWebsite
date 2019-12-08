using System.Collections.Generic;

namespace Core.DTO
{
    public class PageData<T>
    {
        public int TotalPages { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}