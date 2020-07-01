﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configurataion
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasData
           (
               new Section
               {
                   Id = new Guid("80abbca8-664d-4b20-b5de-024705497d5a"),
                   StartDate = Convert.ToDateTime("05/21/2020"),
                   EndDate = Convert.ToDateTime("08/08/2020"),
                   CreatedDate = Convert.ToDateTime("11/16/2019"),
                   UpdatedDate = Convert.ToDateTime("06/24/2019"),
                   CourseId = new Guid("80abbca8-664d-4b20-b5de-024705497d4b")
               },
                new Section
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d6a"),
                    StartDate = Convert.ToDateTime("05/21/2020"),
                    EndDate = Convert.ToDateTime("08/08/2020"),
                    CreatedDate = Convert.ToDateTime("11/16/2019"),
                    UpdatedDate = Convert.ToDateTime("06/24/2019"),
                    CourseId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52c")
                }
                );
        }
    }
}
