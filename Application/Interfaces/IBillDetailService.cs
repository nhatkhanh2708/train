using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBillDetailService
    {
        IEnumerable<BillDetailDto> GetBillDetails(int billId);
        BillDetailDto GetBillDetail(int billDetailId);
        void CreateBillDetail(BillDetailDto billDetailDto);
        void UpdateBillDetail(BillDetailDto billDetailDto);
        void DeleteBillDetail(int billDetailId);
    }
}
