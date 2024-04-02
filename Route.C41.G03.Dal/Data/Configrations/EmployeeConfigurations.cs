using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.C41.G03.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G03.Dal.Data.Configrations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(emp => emp.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Property(emp => emp.Address).IsRequired();
            builder.Property(emp => emp.Salary).HasColumnType("decimal(12,2)");

            builder.Property(emp => emp.Gender)
                .HasConversion(
                (Gender) => Gender.ToString(),
                (genderAsString) => (Gender)Enum.Parse(typeof(Gender), genderAsString, true)
                );
        }
    }
}
