using OwnsManyIssue.Aggregates.ValueObjects;

namespace OwnsManyIssue.Aggregates
{
    public class Aggregate
    {
        public Aggregate()
        {
        }

        public int Id { get; set; }

        public FirstValueObject FirstValueObject { get; set; }
    }
}