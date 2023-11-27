

using AutoMapper;
using NewProject.Domain.Models;

namespace NewProject.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
          //  CreateMap<CompanyFm, Company>();
            CreateMap<CompanyFm, Company>();
            //CreateMap<CampaignFm, Campaign>();
            //CreateMap<ClientFm, Client>();
            //CreateMap<CommissionFm, Commission>();
            //CreateMap<LogFm, Log>();
            //CreateMap<MarketerFm, Marketer>();
            //CreateMap<ProductFm, Product>();
            //CreateMap<SubscriptionFm, Subscription>();
        }
    }
}
