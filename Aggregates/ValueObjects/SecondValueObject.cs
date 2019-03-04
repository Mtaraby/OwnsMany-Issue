using System.Collections.Generic;

namespace OwnsManyIssue.Aggregates.ValueObjects
{
    public class SecondValueObject
    {
        public SecondValueObject()
        {
        }

        public FourthValueObject FourthValueObject { get; set; }

        public List<ThirdValueObject> ThirdValueObjects { get; set; }
    }
}