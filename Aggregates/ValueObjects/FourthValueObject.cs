using System.Collections.Generic;

namespace OwnsManyIssue.Aggregates.ValueObjects
{
    public class FourthValueObject
    {
        public FourthValueObject()
        {
        }

        public List<FifthValueObject> FifthValueObjects { get; set; }
    }
}