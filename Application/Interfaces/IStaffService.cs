using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IStaffService
    {
        IEnumerable<StaffDto> GetStaffs(string searchString, string position, bool? status);
        StaffDto GetStaff(int staffId);
        void CreateStaff(StaffDto staffDto);
        void UpdateStaff(StaffDto staffDto);
        void DeleteStaff(int staffId);
    }
}
