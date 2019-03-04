namespace OwnsManyIssue.Aggregates.ValueObjects
{
    public class FifthValueObject
    {
        public FifthValueObject(int anyValue)
        {
            AnyValue = anyValue;
        }

        public int AnyValue { get; set; }
    }
}