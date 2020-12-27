using Application.DTOs;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBillService
    {
        IEnumerable<BillDto> GetBills(string searchString, DateTime? dayFrom, DateTime? dayTo, decimal? priceFrom, decimal? priceTo);
        BillDto GetBill(int billId);
        void CreateBill(BillDto billDto);
        void UpdateBill(BillDto billDto);
        void DeleteBill(int billId);
        int GetIdLast();
        decimal GetTotal(int billId);
        int GetDiscount(int billId);
    }
}
