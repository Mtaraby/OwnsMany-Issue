using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnsManyIssue.Aggregates;

namespace OwnsManyIssue.Configurations
{
    public class AggregateTypeConfiguration : IEntityTypeConfiguration<Aggregate>
    {
        public void Configure(EntityTypeBuilder<Aggregate> builder)
        {
            builder.ToTable("Aggregates");
            builder.HasKey(e => e.Id);
            builder.OwnsOne(e => e.FirstValueObject, dr =>
            {
                dr.OwnsMany(d => d.SecondValueObjects, c =>
                {
                    c.ToTable("SecondValueObjects");
                    c.Property<int>("Id").IsRequired();
                    c.HasKey("Id");
                    c.OwnsOne(b => b.FourthValueObject, b =>
                    {
                        b.OwnsMany(t => t.FifthValueObjects, sp =>
                        {
                            sp.ToTable("FourthFifthValueObjects");
                            sp.Property<int>("Id").IsRequired();
                            sp.HasKey("Id");
                            sp.Property(e => e.AnyValue).IsRequired();
                            sp.HasForeignKey("SecondValueObjectId").OnDelete(DeleteBehavior.Cascade);
                        });
                    });
                    c.OwnsMany(b => b.ThirdValueObjects, b =>
                    {
                        b.ToTable("ThirdValueObjects");
                        b.Property<int>("Id").IsRequired();
                        b.HasKey("Id");

                        b.OwnsOne(d => d.FourthValueObject, dpd =>
                        {
                            dpd.OwnsMany(d => d.FifthValueObjects, sp =>
                            {
                                sp.ToTable("ThirdFifthValueObjects");
                                sp.Property<int>("Id").IsRequired();
                                sp.HasKey("Id");
                                sp.Property(e => e.AnyValue).IsRequired();
                                sp.HasForeignKey("ThirdValueObjectId").OnDelete(DeleteBehavior.Cascade);
                            });
                        });
                        b.HasForeignKey("SecondValueObjectId").OnDelete(DeleteBehavior.Cascade);
                    });
                    c.HasForeignKey("AggregateId").OnDelete(DeleteBehavior.Cascade);
                });
            });
        }
    }
}