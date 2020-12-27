using Application.DTOs;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPromotionService
    {
        IEnumerable<PromotionDto> GetPromotions(string searchString, DateTime? startDate, DateTime? finishDate, sbyte? status);
        PromotionDto GetPromotion(int promotionId);
        void CreatePromotion(PromotionDto promotionDto);
        void UpdatePromotion(PromotionDto promotionDto);
        void DeletePromotion(int promotionId);
    }
}
