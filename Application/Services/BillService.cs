using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billRepository;
        private readonly IBillDetailRepository billDetailRepository;
        private readonly IDrinkRepository drinkRepository;
        private readonly IPromotionDetailRepository promotionDetailRepository;

        public BillService(IBillRepository billRepository, IBillDetailRepository billDetailRepository, IDrinkRepository drinkRepository, IPromotionDetailRepository promotionDetailRepository)
        {
            this.billRepository = billRepository;
            this.billDetailRepository = billDetailRepository;
            this.drinkRepository = drinkRepository;
            this.promotionDetailRepository = promotionDetailRepository;
        }

        public void CreateBill(BillDto billDto)
        {
            var bill = billDto.MappingBill();
            billRepository.Add(bill);
        }

        public void DeleteBill(int billId)
        {
            var bill = billRepository.GetBy(billId);
            billRepository.Delete(bill);
        }

        public BillDto GetBill(int billId)
        {
            var bill = billRepository.GetBy(billId);
            return bill.MappingDto();
        }

        public IEnumerable<BillDto> GetBills(string searchString, DateTime? dayFrom, DateTime? dayTo, decimal? priceFrom, decimal? priceTo)
        {
            var bills = billRepository.Filter(searchString, dayFrom, dayTo);

            if (dayFrom != null || dayTo != null)
            {
                decimal total;
                List<BillDto> listbill = new List<BillDto>();
                foreach (var b in bills)
                {
                    total = GetTotal(b.Id);
                    if (total >= priceFrom && total <= priceTo)
                        listbill.Add(b.MappingDto());
                }
                return listbill;
            }
            return bills.MappingDtos();
        }

        public int GetDiscount(int billId)
        {
            var bill = GetBill(billId);
            int? proId = bill.PromotionDetailId;
            if (proId == null)
                return 0;
            return (int) promotionDetailRepository.GetBy(proId.Value).Discount;
        }

        public int GetIdLast()
        {
            return billRepository.GetBillIdLast();
        }

        public decimal GetTotal(int billId)
        {
            var bills = billDetailRepository.GetsByBillId(billId);
            decimal total = 0;
            decimal price;
            foreach (var b in bills)
            {
                price = drinkRepository.GetBy(b.DrinkId).Price;
                total += b.Quantity * price;
            }
            return total;
        }

        public void UpdateBill(BillDto billDto)
        {
            var bill = billRepository.GetBy(billDto.Id);
            billDto.MappingBill(bill);
            billRepository.Update(bill);
        }
    }
}
