using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Communication
{
    public class EmailDto
    {
        public string ToEmail { get; set; }
        public string Name { get; set; }
        public EmployeeDto EmployeeDto { get; set; }
        public UserDto UserDto { get; set; }
        public ApplicantDto ApplicantDto { get; set; }
    }

    public class EmailInterviewDto
    {
        public string ToEmail { get; set; }
        public string Name { get; set; }
        public ShortlistDetailDto ShortlistDetailDto { get; set; }
        public ApplicantDto ApplicantDto { get; set; }
    }
}
