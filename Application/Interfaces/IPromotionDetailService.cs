using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPromotionDetailService
    {
        IEnumerable<PromotionDetailDto> GetPromotionDetails(int promotionId);
        PromotionDetailDto GetPromotionDetail(int promotionDetailId);
        void CreatePromotionDetail(PromotionDetailDto promotionDetailDto);
        void UpdatePromotionDetail(PromotionDetailDto promotionDetailDto);
        void DeletePromotionDetail(int promotionDetailId);
    }
}
