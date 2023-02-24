using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class ReportDTO
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public ReportDTO() { }
        public ReportDTO(long id, string path, DateTime date, string type)
        {
            Id = id;
            Path = path;
            Date = date;
            Type = type;
        }
        public ReportDTO(string path, DateTime date, string type)
        {
            Path = path;
            Date = date;
            Type = type;
        }
    }
}
