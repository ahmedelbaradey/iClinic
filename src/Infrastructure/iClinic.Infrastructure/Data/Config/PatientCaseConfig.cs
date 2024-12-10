using iClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iClinic.Infrastructure.Data.Config
{
    public class PatientCaseConfig : IEntityTypeConfiguration<PatientCase>
    {
        public void Configure(EntityTypeBuilder<PatientCase> builder)
        {
            builder.ToTable("PatientCases");
            builder.HasKey(x => x.PatientCaseId);
            builder.Property(x => x.PatientCaseId).HasColumnName("Id").ValueGeneratedOnAdd();

        }
    }
}
