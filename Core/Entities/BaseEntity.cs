using System.ComponentModel.DataAnnotations;

namespace Core.Entities {
    public class BaseEntity {
        [Key]
        public string Id { get; set; }
    }
}