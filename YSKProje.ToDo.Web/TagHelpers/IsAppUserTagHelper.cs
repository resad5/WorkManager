using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class IsAppUserTagHelper:TagHelper
    {

        private readonly IisService _IisService;
        public IsAppUserTagHelper(IisService IisService)
        {
            _IisService = IisService;
        }


        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            List<Is> isler = _IisService.GetirAppUserId(AppUserId).ToList();
            int tamamlananIsSayi = isler.Where(i => i.Durum == true).Count();
            int tamamlanmayanISayi = isler.Where(i => i.Durum == false).Count();

            string htmlstring = $"<strong> Tamaldadigi is sayi :</strong> {tamamlananIsSayi} <br><strong>Ustunde islediyi is sayi:</strong>{tamamlanmayanISayi}";

            output.Content.SetHtmlContent(htmlstring);
        }
    }
}
