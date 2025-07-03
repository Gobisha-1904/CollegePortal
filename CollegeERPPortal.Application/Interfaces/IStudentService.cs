using CollegeERPPortal.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeERPPortal.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task AddAsync(StudentDto student);
        Task<StudentDto> GetByIdAsync(int id);
        Task UpdateAsync(StudentDto Dto);
        Task DeleteAsync(int id);
    }
}
