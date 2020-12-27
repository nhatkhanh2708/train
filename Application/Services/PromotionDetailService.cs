using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class PromotionDetailService : IPromotionDetailService
    {
        private readonly IPromotionDetailRepository promotionDetailRepository;

        public PromotionDetailService(IPromotionDetailRepository promotionDetailRepository)
        {
            this.promotionDetailRepository = promotionDetailRepository;
        }
        public void CreatePromotionDetail(PromotionDetailDto promotionDetailDto)
        {
            var promotionDetail = promotionDetailDto.MappingPromotionDetail();
            promotionDetailRepository.Add(promotionDetail);
        }

        public void DeletePromotionDetail(int promotionDetailId)
        {
            var promotionDetail = promotionDetailRepository.GetBy(promotionDetailId);
            promotionDetailRepository.Delete(promotionDetail);
        }

        public PromotionDetailDto GetPromotionDetail(int promotionDetailId)
        {
            var promotionDetail = promotionDetailRepository.GetBy(promotionDetailId);
            return promotionDetail.MappingDto();
        }

        public IEnumerable<PromotionDetailDto> GetPromotionDetails(int promotionId)
        {
            var list = promotionDetailRepository.Filter(promotionId);
            return list.MappingDtos();
        }

        public void UpdatePromotionDetail(PromotionDetailDto promotionDetailDto)
        {
            var promotionDetail = promotionDetailRepository.GetBy(promotionDetailDto.Id);
            promotionDetailDto.MappingPromotionDetail(promotionDetail);
            promotionDetailRepository.Update(promotionDetail);
        }
    }
}
