﻿// <auto-generated />
using DSTutorials1909.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DSTutorials1909.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240926092653_AddMenuUrlToCourseTable")]
    partial class AddMenuUrlToCourseTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DSTutorials1909.Models.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentId"));

                    b.Property<string>("ContentDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("SideSubMenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubMenuId")
                        .HasColumnType("int");

                    b.HasKey("ContentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("MenuId");

                    b.HasIndex("SubMenuId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("DSTutorials1909.Models.Courses", b =>
                {
                    b.Property<int>("CoursesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursesId"));

                    b.Property<string>("CourseDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseSequence")
                        .HasColumnType("int");

                    b.Property<string>("MenuUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoursesId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DSTutorials1909.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuSequence")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("CourseId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("DSTutorials1909.Models.SubMenu", b =>
                {
                    b.Property<int>("SubMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubMenuId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("SubMenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubMenuSequence")
                        .HasColumnType("int");

                    b.Property<string>("SubMenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubMenuId");

                    b.HasIndex("CourseId");

                    b.HasIndex("MenuId");

                    b.ToTable("SubMenus");
                });

            modelBuilder.Entity("DSTutorials1909.Models.Content", b =>
                {
                    b.HasOne("DSTutorials1909.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DSTutorials1909.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DSTutorials1909.Models.SubMenu", "SubMenu")
                        .WithMany()
                        .HasForeignKey("SubMenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Menu");

                    b.Navigation("SubMenu");
                });

            modelBuilder.Entity("DSTutorials1909.Models.Menu", b =>
                {
                    b.HasOne("DSTutorials1909.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("DSTutorials1909.Models.SubMenu", b =>
                {
                    b.HasOne("DSTutorials1909.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DSTutorials1909.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
