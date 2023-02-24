using Project.Model;
using Project.Services;
using Project.Services.Generators;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ReportController
    {
        private ReportConverter _reportConverter;
        public ReportController(ReportConverter reportConverter) {
            _reportConverter = reportConverter;
        }

        ReportDTO Generate(IReportGenerator<TimeInterval> reportGenerator, TimeInterval timeInterval)
         => _reportConverter.ConvertEntityToDTO(reportGenerator.Generate(timeInterval));
        
    }
}
