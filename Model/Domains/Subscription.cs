namespace MovieAPI.Model.Domains
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public decimal SubscriptionPlan { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }
}
