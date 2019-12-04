namespace Core.Entities.CustomerAggregate
{
    public class CustomerDetail: BaseEntity
    {
        public int CustomerAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}