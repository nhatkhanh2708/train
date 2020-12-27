using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class BillDetailService : IBillDetailService
    {
        private readonly IBillDetailRepository billDetailRepository;

        public BillDetailService(IBillDetailRepository billDetailRepository)
        {
            this.billDetailRepository = billDetailRepository;
        }

        public void CreateBillDetail(BillDetailDto billDetailDto)
        {
            var billDetail = billDetailDto.MappingBillDetail();
            billDetailRepository.Add(billDetail);
        }

        public void DeleteBillDetail(int billDetailId)
        {
            var billDetail = billDetailRepository.GetBy(billDetailId);
            billDetailRepository.Delete(billDetail);
        }

        public BillDetailDto GetBillDetail(int billDetailId)
        {
            var billDetail = billDetailRepository.GetBy(billDetailId);
            return billDetail.MappingDto();
        }

        public IEnumerable<BillDetailDto> GetBillDetails(int billId)
        {
            var bills_detail = billDetailRepository.GetsByBillId(billId);
            return bills_detail.MappingDtos();
        }

        public void UpdateBillDetail(BillDetailDto billDetailDto)
        {
            var billDetail = billDetailRepository.GetBy(billDetailDto.Id);
            billDetailDto.MappingBillDetail(billDetail);
            billDetailRepository.Update(billDetail);
        }
    }
}
