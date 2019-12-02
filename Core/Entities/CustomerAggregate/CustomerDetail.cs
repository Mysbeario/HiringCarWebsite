using System.ComponentModel.DataAnnotations;

namespace Core.Entities.CustomerAggregate
{
    public class CustomerDetail
    {
        [Key]
        public string CustomerAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}