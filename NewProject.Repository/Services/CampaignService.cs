using AutoMapper;
using NewProject.Domain.Models;
using NewProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewProject.Repository.Services
{
    public interface ICampaignService
    {
        ReturnObject Post(Campaign obj);
        ReturnObject Update(CampaignUpdateFm param, int id);
        Task<ReturnObject> GetAllByCoyIdByProductIdByCamapagnid(string CoyId, string productId, string campagnId);
    }
    public class CampaignService : ICampaignService
    {
        private readonly NPDbContext _context;
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Campaign> _repo;
        public CampaignService(IRepository<Campaign> repo, NPDbContext context, IMapper mapper)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByProductIdByCamapagnid(string CoyId, string productId, string campagnId)
        {
            long det1 = 0, det2 = 0;
            if (!string.IsNullOrWhiteSpace(productId))
                det1 = Convert.ToInt64(productId);
            if (!string.IsNullOrWhiteSpace(campagnId))
                det2 = Convert.ToInt64(campagnId);

            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll()
                .Where(o => o.CoyId == Convert.ToInt64(CoyId)
              && o.Id == det2 || det2 == 0
              && o.ProductId == det1 || det1 == 0)
                .ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Campaign obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";

            try
            {
                _repo.Insert(obj);
            }
            catch (Exception ex)
            {
                r.status = false;
                r.message = errMsg + $"{ex.Message}";
            }
            return r;
        }

        public ReturnObject Update(CampaignUpdateFm param, int id)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            try
            {
                _context.Campaigns.Where(b => b.Id == id)
             .ExecuteUpdate(setters => setters.SetProperty(b => b.ProductId, param.ProductId)
            .SetProperty(b => b.CampaignType, param.CampaignType)
           .SetProperty(b => b.Content, param.Content)
            .SetProperty(b => b.DaysAfter, param.DaysAfter)
             .SetProperty(b => b.Position, param.Position));

            }
            catch (Exception ex)
            {
                r.status = false;
                r.message = errMsg + $"{ex.Message}";
            }
            return r;
        }
    }
}
