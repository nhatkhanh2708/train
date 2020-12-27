using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }
        public void CreateStaff(StaffDto staffDto)
        {
            var staff = staffDto.MappingStaff();
            staffRepository.Add(staff);
        }

        public void DeleteStaff(int staffId)
        {
            var staff = staffRepository.GetBy(staffId);
            staffRepository.Delete(staff);
        }

        public StaffDto GetStaff(int staffId)
        {
            var staff = staffRepository.GetBy(staffId);
            return staff.MappingDto();
        }

        public IEnumerable<StaffDto> GetStaffs(string searchString, string position, bool? status)
        {
            var staffs = staffRepository.Filter(searchString, position, status);
            return staffs.MappingDtos();
        }

        public void UpdateStaff(StaffDto staffDto)
        {
            var staff = staffRepository.GetBy(staffDto.Id);
            staffDto.MappingStaff(staff);
            staffRepository.Update(staff);
        }
    }
}
