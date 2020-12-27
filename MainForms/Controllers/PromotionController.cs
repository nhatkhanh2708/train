using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForms.Controllers
{
    public class PromotionController
    {
        private readonly IPromotionService promotionService;

        public PromotionController()
        {
            promotionService = (IPromotionService)Startup.ServiceProvider.GetService(typeof(IPromotionService));
        }

        public IEnumerable<PromotionDto> Gets(string searchString, DateTime? startDate, DateTime? finishDate, sbyte? status)
        {
            return promotionService.GetPromotions(searchString, startDate, finishDate, status);
        }

        public PromotionDto Get(int promotionId)
        {
            return promotionService.GetPromotion(promotionId);
        }

        public void Create(PromotionDto promotionDto)
        {
            promotionService.CreatePromotion(promotionDto);
        }

        public void Update(PromotionDto promotionDto)
        {
            promotionService.UpdatePromotion(promotionDto);
        }

        public void Delete(int promotionId)
        {
            promotionService.DeletePromotion(promotionId);
        }

        public void UpdateStatusByTimeNow()
        {
            var promotions = Gets(null, null, null, null);
            foreach (PromotionDto p in promotions)
            {
                var _status = GetStatus(p.StartDate, p.FinishDate);
                if (_status < p.Status && p.Status != -1)
                {
                    p.Status = _status;
                    Update(p);
                }
            }
        }

        public sbyte GetStatus(DateTime start, DateTime end)
        {
            int compareDateStart = DateTime.Compare(DateTime.Now, start);
            int compareDateEnd = DateTime.Compare(DateTime.Now, end);
            sbyte status = SByte.MinValue;

            if (compareDateStart < 0)
                status = 1;
            else if (compareDateStart >= 0 && compareDateEnd <= 0)
                status = 0;
            else if (compareDateEnd > 0)
                status = -1;
            return status;
        }
    }
}
