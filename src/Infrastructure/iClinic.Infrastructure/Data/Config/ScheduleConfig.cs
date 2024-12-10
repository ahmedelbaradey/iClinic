﻿using iClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iClinic.Infrastructure.Data.Config
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(x => x.ScheduleId);
            builder.Property(x => x.ScheduleId).HasColumnName("Id").ValueGeneratedOnAdd();

        }
    }
}
