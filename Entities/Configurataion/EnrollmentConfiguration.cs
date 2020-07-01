using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Entities.Configurataion
{
    class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData
           (
               new Enrollment
               {
                   Id = new Guid("80abbca8-664d-4b20-b5de-024705497c5e"),
                   AttributeName = "Fazle (Student)",
                   StartDate = Convert.ToDateTime("05/21/2020"),
                   EndDate = Convert.ToDateTime("08/08/2020"),
                   CreatedDate = Convert.ToDateTime("11/16/2019"),
                   UpdatedDate = Convert.ToDateTime("06/24/2019"),
                   UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                   SectionId = new Guid("80abbca8-664d-4b20-b5de-024705497d5a")
               }
               ); ;


        }
    }
}

