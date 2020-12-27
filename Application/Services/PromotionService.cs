using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        public PromotionService(IPromotionRepository promotionRepository)
        {
            this.promotionRepository = promotionRepository;
        }
        public void CreatePromotion(PromotionDto promotionDto)
        {
            var promotion = promotionDto.MappingPromotion();
            promotionRepository.Add(promotion);
        }

        public void DeletePromotion(int promotionId)
        {
            var promotion = promotionRepository.GetBy(promotionId);
            promotionRepository.Delete(promotion);
        }

        public PromotionDto GetPromotion(int promotionId)
        {
            var promotion = promotionRepository.GetBy(promotionId);
            return promotion.MappingDto();
        }

        public IEnumerable<PromotionDto> GetPromotions(string searchString, DateTime? startDate, DateTime? finishDate, sbyte? status)
        {
            var promotions = promotionRepository.Filter(searchString, startDate, finishDate, status);
            return promotions.MappingDtos();
        }

        public void UpdatePromotion(PromotionDto promotionDto)
        {
            var promotion = promotionRepository.GetBy(promotionDto.Id);
            promotionDto.MappingPromotion(promotion);
            promotionRepository.Update(promotion);
        }
    }
}
