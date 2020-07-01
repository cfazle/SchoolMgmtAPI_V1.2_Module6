using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configurataion
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasData
           (
               new Submission
               {
                   Id = new Guid("80abbca8-664d-4b20-b5de-024705493d5a"),
                   SubmissionText = "Module 1 submission",
                   CreatedDate = Convert.ToDateTime("11/16/2019"),
                   UpdatedDate = Convert.ToDateTime("06/24/2019"),
                   Score = 100,
                  AssignmentId = new Guid("80abbca8-664d-4b20-b5de-024705498a4b"),
                  UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")

               }
              ); ; ;
        }

    }

}
