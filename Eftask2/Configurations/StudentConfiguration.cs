using Eftask2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eftask2.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
			try
			{
                builder.ToTable("Students");
                builder.HasKey(s => s.Id);
                builder.Property(s => s.FirstName).HasMaxLength(50);

			}
			catch (Exception ex)
			{

                MessageBox.Show(ex.Message);			}
        }
    }
}
