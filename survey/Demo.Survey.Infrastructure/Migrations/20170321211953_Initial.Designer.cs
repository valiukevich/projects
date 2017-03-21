using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Demo.Survey.Infrastructure;
using Demo.Survey.Model;

namespace Demo.Survey.Infrastructure.Migrations
{
    [DbContext(typeof(SurveyContext))]
    [Migration("20170321211953_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Demo.Survey.Model.QuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<long?>("SurveyQuestionId");

                    b.Property<long?>("UserQuestionAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyQuestionId");

                    b.HasIndex("UserQuestionAnswerId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("Demo.Survey.Model.Survey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Demo.Survey.Model.SurveyQuestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionType");

                    b.Property<long?>("SurveyId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyQuestion");
                });

            modelBuilder.Entity("Demo.Survey.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Demo.Survey.Model.UserQuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("QuestionId");

                    b.Property<long?>("UserSurveyId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserSurveyId");

                    b.ToTable("UserQuestionAnswer");
                });

            modelBuilder.Entity("Demo.Survey.Model.UserSurvey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("SurveyId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSurvey");
                });

            modelBuilder.Entity("Demo.Survey.Model.QuestionAnswer", b =>
                {
                    b.HasOne("Demo.Survey.Model.SurveyQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("SurveyQuestionId");

                    b.HasOne("Demo.Survey.Model.UserQuestionAnswer")
                        .WithMany("Answers")
                        .HasForeignKey("UserQuestionAnswerId");
                });

            modelBuilder.Entity("Demo.Survey.Model.SurveyQuestion", b =>
                {
                    b.HasOne("Demo.Survey.Model.Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("Demo.Survey.Model.UserQuestionAnswer", b =>
                {
                    b.HasOne("Demo.Survey.Model.SurveyQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("Demo.Survey.Model.UserSurvey")
                        .WithMany("Answers")
                        .HasForeignKey("UserSurveyId");
                });

            modelBuilder.Entity("Demo.Survey.Model.UserSurvey", b =>
                {
                    b.HasOne("Demo.Survey.Model.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyId");

                    b.HasOne("Demo.Survey.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
