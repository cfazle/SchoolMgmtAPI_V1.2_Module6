using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configurataion
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData
            (
                new Assignment
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705498a4b"),
                    Title = "Module 1",
                    Description = "Entity and databae connection",
                    SectionId = new Guid("80abbca8-664d-4b20-b5de-024705497d5a")
                }
                );
        }
    }

}
