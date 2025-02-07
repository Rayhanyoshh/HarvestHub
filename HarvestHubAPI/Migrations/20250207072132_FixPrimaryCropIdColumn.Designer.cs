﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HarvestHubProjectAPI.Migrations
{
    [DbContext(typeof(HarvestHubContext))]
    [Migration("20250207072132_FixPrimaryCropIdColumn")]
    partial class FixPrimaryCropIdColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.Crop", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("CropCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.HasKey("CropId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.FarmField", b =>
                {
                    b.Property<int>("FarmFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmFieldId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("FarmFieldCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FarmFieldColorHexCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("FarmFieldName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FarmFieldRowDirection")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FarmSiteId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryCropId")
                        .HasColumnType("int");

                    b.Property<float>("RowWidth")
                        .HasColumnType("real");

                    b.HasKey("FarmFieldId");

                    b.HasIndex("FarmSiteId");

                    b.HasIndex("PrimaryCropId");

                    b.ToTable("FarmFields");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.FarmSite", b =>
                {
                    b.Property<int>("FarmSiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmSiteId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DefaultPrimaryCropId")
                        .HasColumnType("int");

                    b.Property<string>("FarmSiteName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.HasKey("FarmSiteId");

                    b.ToTable("FarmSites");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("FarmSiteId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCustomerUser")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserEmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserGivenName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex("FarmSiteId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.WorkTask", b =>
                {
                    b.Property<int>("WorkTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTaskId"));

                    b.Property<DateTimeOffset>("CanceledDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("FarmFieldId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WorkTaskStatusCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkTaskTypeCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WorkTaskId");

                    b.HasIndex("FarmFieldId");

                    b.HasIndex("WorkTaskTypeCode");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.WorkTaskType", b =>
                {
                    b.Property<string>("WorkTaskTypeCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("int");

                    b.HasKey("WorkTaskTypeCode");

                    b.ToTable("WorkTaskTypes");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.FarmField", b =>
                {
                    b.HasOne("HarvestHubAPI.Models.Entities.FarmSite", "FarmSite")
                        .WithMany("FarmFields")
                        .HasForeignKey("FarmSiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HarvestHubAPI.Models.Entities.Crop", "PrimaryCrop")
                        .WithMany("FarmFields")
                        .HasForeignKey("PrimaryCropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FarmSite");

                    b.Navigation("PrimaryCrop");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.User", b =>
                {
                    b.HasOne("HarvestHubAPI.Models.Entities.FarmSite", "FarmSite")
                        .WithMany("Users")
                        .HasForeignKey("FarmSiteId");

                    b.Navigation("FarmSite");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.WorkTask", b =>
                {
                    b.HasOne("HarvestHubAPI.Models.Entities.FarmField", "FarmField")
                        .WithMany("WorkTasks")
                        .HasForeignKey("FarmFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HarvestHubAPI.Models.Entities.WorkTaskType", "WorkTaskType")
                        .WithMany("WorkTasks")
                        .HasForeignKey("WorkTaskTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FarmField");

                    b.Navigation("WorkTaskType");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.Crop", b =>
                {
                    b.Navigation("FarmFields");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.FarmField", b =>
                {
                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.FarmSite", b =>
                {
                    b.Navigation("FarmFields");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HarvestHubAPI.Models.Entities.WorkTaskType", b =>
                {
                    b.Navigation("WorkTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
