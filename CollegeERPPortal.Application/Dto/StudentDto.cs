using System;

namespace CollegeERPPortal.Application.DTOs
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }

        // ✅ This line MUST be present
        public DateTime DOB { get; set; }
    }
}
