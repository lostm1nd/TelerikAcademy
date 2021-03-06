﻿namespace StudentSystem.Models
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}