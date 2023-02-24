// File:    Report.cs
// Created: Thursday, March 19, 2020 7:31:41 PM
// Purpose: Definition of Class Report

using System;
using Project.Repositories.Abstract;

namespace Project.Model
{
    public class Report : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Report() {}
        public Report(long id, string path, DateTime date, string type)
        {
            Id = id;
            Path = path;
            Date = date;
            Type = type;
        }
        public Report(string path, DateTime date, string type)
        {
            Path = path;
            Date = date;
            Type = type;
        }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }

}