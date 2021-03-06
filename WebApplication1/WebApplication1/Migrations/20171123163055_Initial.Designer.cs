﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20171123163055_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Mail", b =>
                {
                    b.Property<int>("MailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<string>("User_mail");

                    b.Property<string>("User_pass");

                    b.HasKey("MailId");

                    b.HasIndex("UserId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("First_name");

                    b.Property<string>("Last_name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.Mail", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
