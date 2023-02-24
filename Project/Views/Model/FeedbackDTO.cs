using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Model
{
    public class FeedbackDTO
    {
        public long Id {get;set;}
        public string Type { get; set; }
        public string Description { get; set; }

        public FeedbackDTO() { }
        public FeedbackDTO(long id, string type,string desc)
        {
            Id = id;
            Type = type;
            Description = desc;
        }

        public FeedbackDTO(string type,string desc)
        {
            Type = type;
            Description = desc;
        }
    }
}
