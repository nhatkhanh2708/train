using Application.DTOs;
using Domain.Entities.BillAggregate;
using Domain.Entities.ManageAccount;
using Domain.Entities.Product;
using Domain.Entities.PromotionAggregate;
using Domain.Entities.StaffAggregate;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class MappingProfile
    {
        //Drink
        #region
        public static DrinkDto MappingDto(this Drink drink)
        {
            return new DrinkDto
            {
                Id = drink.Id,
                Name = drink.Name,
                DrinkCategoryId = drink.DrinkCategoryId,
                Descript = drink.Descript,
                Price = drink.Price,
                Img = drink.Img,
                Status = drink.Status
            };
        }
        public static Drink MappingDrink(this DrinkDto drinkDto)
        {
            return new Drink
            {
                Id = drinkDto.Id,
                Name = drinkDto.Name,
                DrinkCategoryId = drinkDto.DrinkCategoryId,
                Descript = drinkDto.Descript,
                Price = drinkDto.Price,
                Img = drinkDto.Img,
                Status = drinkDto.Status
            };
        }
        public static void MappingDrink(this DrinkDto drinkDto, Drink drink)
        {
            drink.Id = drinkDto.Id;
            drink.Name = drinkDto.Name;
            drink.DrinkCategoryId = drinkDto.DrinkCategoryId;
            drink.Descript = drinkDto.Descript;
            drink.Price = drinkDto.Price;
            drink.Img = drinkDto.Img;
            drink.Status = drinkDto.Status;
        }
        public static IEnumerable<DrinkDto> MappingDtos(this IEnumerable<Drink> drinks)
        {
            foreach(var drink in drinks)
            {
                yield return drink.MappingDto();
            }
        }
        #endregion

        //DrinkCategory
        #region
        public static DrinkCategoryDto MappingDto(this DrinkCategory drinkCategory)
        {
            return new DrinkCategoryDto
            {
                Id = drinkCategory.Id,
                Title = drinkCategory.Title
            };
        }

        public static DrinkCategory MappingDrinkCategory(this DrinkCategoryDto drinkCategoryDto)
        {
            return new DrinkCategory
            {
                Id = drinkCategoryDto.Id,
                Title = drinkCategoryDto.Title
            };
        }
        public static void MappingDrinkCategory(this DrinkCategoryDto drinkCategoryDto, DrinkCategory drinkCategory)
        {
            drinkCategory.Id = drinkCategoryDto.Id;
            drinkCategory.Title = drinkCategoryDto.Title;
        }
        public static IEnumerable<DrinkCategoryDto> MappingDtos(this IEnumerable<DrinkCategory> drinkCategories)
        {
            foreach(var drinkCategory in drinkCategories)
            {
                yield return drinkCategory.MappingDto();
            }
        }
        #endregion

        //Bill
        #region
        public static BillDto MappingDto(this Bill bill)
        {
            return new BillDto
            {
                Id = bill.Id,
                StaffId = bill.StaffId,
                DayOfSale = bill.DayOfSale,
                PromotionDetailId = bill.PromotionDetailId
            };
        }

        public static Bill MappingBill(this BillDto billDto)
        {
            return new Bill
            {
                Id = billDto.Id,
                StaffId = billDto.StaffId,
                DayOfSale = billDto.DayOfSale,
                PromotionDetailId = billDto.PromotionDetailId
            };
        }
        public static void MappingBill(this BillDto billDto, Bill bill)
        {
            bill.Id = billDto.Id;
            bill.StaffId = billDto.StaffId;
            bill.DayOfSale = billDto.DayOfSale;
            bill.PromotionDetailId = billDto.PromotionDetailId;
        }
        public static IEnumerable<BillDto> MappingDtos(this IEnumerable<Bill> bills)
        {
            foreach (var bill in bills)
            {
                yield return bill.MappingDto();
            }
        }
        #endregion

        //BillDetail
        #region
        public static BillDetailDto MappingDto(this BillDetail billDetail)
        {
            return new BillDetailDto
            {
                Id = billDetail.Id,
                BillId = billDetail.BillId,
                DrinkId = billDetail.DrinkId,
                Quantity = billDetail.Quantity
            };
        }

        public static BillDetail MappingBillDetail(this BillDetailDto billDetailDto)
        {
            return new BillDetail
            {
                Id = billDetailDto.Id,
                BillId = billDetailDto.BillId,
                DrinkId = billDetailDto.DrinkId,
                Quantity = billDetailDto.Quantity
            };
        }
        public static void MappingBillDetail(this BillDetailDto billDetailDto, BillDetail billDetail)
        {
            billDetail.Id = billDetailDto.Id;
            billDetail.BillId = billDetailDto.BillId;
            billDetail.DrinkId = billDetailDto.DrinkId;
            billDetail.Quantity = billDetailDto.Quantity;
        }
        public static IEnumerable<BillDetailDto> MappingDtos(this IEnumerable<BillDetail> billDetails)
        {
            foreach (var billDetail in billDetails)
            {
                yield return billDetail.MappingDto();
            }
        }
        #endregion

        //Account
        #region
        public static AccountDto MappingDto(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                Username = account.Username,
                PasswordSalt = account.PasswordSalt,
                PasswordHash = account.PasswordHash,
                Status = account.Status,
                StaffId = account.StaffId
            };
        }

        public static Account MappingAccount(this AccountDto accountDto)
        {
            return new Account
            {
                Id = accountDto.Id,
                Username = accountDto.Username,
                PasswordSalt = accountDto.PasswordSalt,
                PasswordHash = accountDto.PasswordHash,
                Status = accountDto.Status,
                StaffId = accountDto.StaffId
            };
        }
        public static void MappingAccount(this AccountDto accountDto, Account account)
        {
            account.Id = accountDto.Id;
            account.Username = accountDto.Username;
            account.PasswordSalt = accountDto.PasswordSalt;
            account.PasswordHash = accountDto.PasswordHash;
            account.Status = accountDto.Status;
            account.StaffId = accountDto.StaffId;
        }
        public static IEnumerable<AccountDto> MappingDtos(this IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                yield return account.MappingDto();
            }
        }
        #endregion

        //Staff
        #region
        public static StaffDto MappingDto(this Staff staff)
        {
            return new StaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Gender = staff.Gender,
                DateOfBirth = staff.DateOfBirth,
                Email = staff.Email,
                Phone = staff.Phone,
                Street = staff.Address.Street,
                Ward = staff.Address.Ward,
                City = staff.Address.City,
                Position = staff.Position,
                Salary = staff.Salary,
                Img = staff.Img,
                Status = staff.Status
            };
        }

        public static Staff MappingStaff(this StaffDto staffDto)
        {
            return new Staff
            {
                Id = staffDto.Id,
                Name = staffDto.Name,
                Gender = staffDto.Gender,
                DateOfBirth = staffDto.DateOfBirth,
                Email = staffDto.Email,
                Phone = staffDto.Phone,
                Address = new Address { 
                            Street = staffDto.Street,
                            Ward = staffDto.Ward,
                            City = staffDto.City
                },
                Position = staffDto.Position,
                Salary = staffDto.Salary,
                Img = staffDto.Img,
                Status = staffDto.Status
            };
        }
        public static void MappingStaff(this StaffDto staffDto, Staff staff)
        {
            staff.Id = staffDto.Id;
            staff.Name = staffDto.Name;
            staff.Gender = staffDto.Gender;
            staff.DateOfBirth = staffDto.DateOfBirth;
            staff.Email = staffDto.Email;
            staff.Phone = staffDto.Phone;
            staff.Address = new Address { 
                            Street = staffDto.Street,
                            Ward = staffDto.Ward,
                            City = staffDto.City
            };
            staff.Position = staffDto.Position;
            staff.Salary = staffDto.Salary;
            staff.Img = staffDto.Img;
            staff.Status = staffDto.Status;
        }
        public static IEnumerable<StaffDto> MappingDtos(this IEnumerable<Staff> staffs)
        {
            foreach (var staff in staffs)
            {
                yield return staff.MappingDto();
            }
        }
        #endregion

        //Promotion
        #region
        public static PromotionDto MappingDto(this Promotion promotion)
        {
            return new PromotionDto
            {
                Id = promotion.Id,
                Title = promotion.Title,
                StartDate = promotion.StartDate,
                FinishDate = promotion.FinishDate,
                Status = promotion.Status
            };
        }

        public static Promotion MappingPromotion(this PromotionDto promotionDto)
        {
            return new Promotion
            {
                Id = promotionDto.Id,
                Title = promotionDto.Title,
                StartDate = promotionDto.StartDate,
                FinishDate = promotionDto.FinishDate,
                Status = promotionDto.Status
            };
        }
        public static void MappingPromotion(this PromotionDto promotionDto, Promotion promotion)
        {
            promotion.Id = promotionDto.Id;
            promotion.Title = promotionDto.Title;
            promotion.StartDate = promotionDto.StartDate;
            promotion.FinishDate = promotionDto.FinishDate;
            promotion.Status = promotionDto.Status;
        }
        public static IEnumerable<PromotionDto> MappingDtos(this IEnumerable<Promotion> promotions)
        {
            foreach (var promotion in promotions)
            {
                yield return promotion.MappingDto();
            }
        }
        #endregion

        //PromotionDetail
        #region
        public static PromotionDetailDto MappingDto(this PromotionDetail promotionDetail)
        {
            return new PromotionDetailDto
            {
                Id = promotionDetail.Id,
                Content = promotionDetail.Content,
                Discount = promotionDetail.Discount,
                PromotionId = promotionDetail.PromotionId
            };
        }

        public static PromotionDetail MappingPromotionDetail(this PromotionDetailDto promotionDetailDto)
        {
            return new PromotionDetail
            {
                Id = promotionDetailDto.Id,
                Content = promotionDetailDto.Content,
                Discount = promotionDetailDto.Discount,
                PromotionId = promotionDetailDto.PromotionId
            };
        }
        public static void MappingPromotionDetail(this PromotionDetailDto promotionDetailDto, PromotionDetail promotionDetail)
        {
            promotionDetail.Id = promotionDetailDto.Id;
            promotionDetail.Content = promotionDetailDto.Content;
            promotionDetail.Discount = promotionDetailDto.Discount;
            promotionDetail.PromotionId = promotionDetailDto.PromotionId;
        }
        public static IEnumerable<PromotionDetailDto> MappingDtos(this IEnumerable<PromotionDetail> promotionDetails)
        {
            foreach (var promotionDetail in promotionDetails)
            {
                yield return promotionDetail.MappingDto();
            }
        }
        #endregion
    }
}