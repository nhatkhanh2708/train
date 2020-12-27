using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace MainForms.Controllers
{
    public class BillController
    {
        private readonly IBillService billService;
        public BillController()
        {
            billService = (IBillService)Startup.ServiceProvider.GetService(typeof(IBillService));
        }

        public IEnumerable<BillDto> Gets(string searchString, DateTime? dayFrom, DateTime? dayTo, decimal? priceFrom, decimal? priceTo)
        {
            return billService.GetBills(searchString, dayFrom, dayTo, priceFrom, priceTo);
        }

        public BillDto Get(int billId)
        {
            return billService.GetBill(billId);
        }

        public void Create(BillDto billDto)
        {
            billService.CreateBill(billDto);
        }

        public void Update(BillDto billDto)
        {
            billService.UpdateBill(billDto);
        }

        public void Delete(int billId)
        {
            billService.DeleteBill(billId);
        }

        public int GetIdLast()
        {
            return billService.GetIdLast();
        }

        public int GetDiscount(int billId)
        {
            return billService.GetDiscount(billId);
        }

        public decimal GetTotal(int billId)
        {
            return billService.GetTotal(billId);
        }
    }
}
