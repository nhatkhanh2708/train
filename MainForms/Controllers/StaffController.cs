using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;

namespace MainForms.Controllers
{
    public class StaffController
    {
        private readonly IStaffService staffService;

        public StaffController()
        {
            staffService = (IStaffService)Startup.ServiceProvider.GetService(typeof(IStaffService));
        }

        public IEnumerable<StaffDto> Gets(string searchString, string position, bool? status)
        {
            return staffService.GetStaffs(searchString, position, status);
        }

        public StaffDto Get(int staffId)
        {
            return staffService.GetStaff(staffId);
        }

        public void Create(StaffDto staffDto)
        {
            staffService.CreateStaff(staffDto);
        }

        public void Update(StaffDto staffDto)
        {
            staffService.UpdateStaff(staffDto);
        }

        public void Delete(int staffId)
        {
            staffService.DeleteStaff(staffId);
        }
    }
}
