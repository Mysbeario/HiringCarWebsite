namespace Core.Entities.CustomerAggregate
{
    public class CustomerAccount: BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public CustomerDetail CustomerDetail { get; private set;}

        public void CreateProfile (CustomerDetail profile) {
            this.CustomerDetail = profile;
        }
    }
}