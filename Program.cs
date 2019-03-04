using OwnsManyIssue.Aggregates;
using OwnsManyIssue.Aggregates.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace OwnsManyIssue
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using(var context = new OwnsManyIssueContext())
            {
                var aggregate = new Aggregate
                {
                    FirstValueObject = new FirstValueObject
                    {
                        SecondValueObjects = new List<SecondValueObject>
                        {
                            new SecondValueObject
                            {
                                FourthValueObject = new FourthValueObject
                                {
                                    FifthValueObjects = new List<FifthValueObject>
                                    {
                                        new FifthValueObject(10)
                                    }
                                },
                                ThirdValueObjects = new List<ThirdValueObject>
                                {
                                    new ThirdValueObject
                                    {
                                        FourthValueObject = new FourthValueObject
                                        {
                                            FifthValueObjects = new List<FifthValueObject>
                                            {
                                                new FifthValueObject(10)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                context.Aggregates.Add(aggregate);
                context.SaveChanges();

                var dbAggregate = context.Aggregates.FirstOrDefault();
            }
        }
    }
}