using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForms.Controllers
{
    public class PromotionDetailController
    {
        private readonly IPromotionDetailService promotionDetailService;

        public PromotionDetailController()
        {
            promotionDetailService = (IPromotionDetailService)Startup.ServiceProvider.GetService(typeof(IPromotionDetailService));
        }

        public IEnumerable<PromotionDetailDto> Gets(int promotionId)
        {
            return promotionDetailService.GetPromotionDetails(promotionId);
        }

        public PromotionDetailDto Get(int promotionDetailId)
        {
            return promotionDetailService.GetPromotionDetail(promotionDetailId);
        }

        public void Create(PromotionDetailDto promotionDetailDto)
        {
            promotionDetailService.CreatePromotionDetail(promotionDetailDto);
        }

        public void Update(PromotionDetailDto promotionDetailDto)
        {
            promotionDetailService.UpdatePromotionDetail(promotionDetailDto);
        }

        public void Delete(int promotionDetailId)
        {
            promotionDetailService.DeletePromotionDetail(promotionDetailId);
        }
    }
}
