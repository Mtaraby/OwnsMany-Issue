using System.Collections.Generic;

namespace OwnsManyIssue.Aggregates.ValueObjects
{
    public class FirstValueObject
    {
        public FirstValueObject()
        {
        }

        public List<SecondValueObject> SecondValueObjects { get; set; }
    }
}