using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;

namespace MainForms.Controllers
{
    public class BillDetailController
    {
        private readonly IBillDetailService billDetailService;

        public BillDetailController()
        {
            billDetailService = (IBillDetailService)Startup.ServiceProvider.GetService(typeof(IBillDetailService));
        }
        public IEnumerable<BillDetailDto> Gets(int billId)
        {
            return billDetailService.GetBillDetails(billId);
        }
        public BillDetailDto Get(int billDetailId)
        {
            return billDetailService.GetBillDetail(billDetailId);
        }
        public void Create(BillDetailDto billDetailDto)
        {
            billDetailService.CreateBillDetail(billDetailDto);
        }
        public void Update(BillDetailDto billDetailDto)
        {
            billDetailService.UpdateBillDetail(billDetailDto);
        }
        public void Delete(int billDetailId)
        {
            billDetailService.DeleteBillDetail(billDetailId);
        }
    }
}
