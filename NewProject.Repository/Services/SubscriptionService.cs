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
    public interface ISubscriptionService
    {
        ReturnObject Post(Subscription obj);
        ReturnObject Update(SubscriptionFmUpdate obj, int Id);
        Task<ReturnObject> GetAllByCoyIdBymarketerIdBytranxid(string CoyId, string marketerId, string tranxid);
    }
    public class SubscriptionService : ISubscriptionService
    {
        private readonly NPDbContext _context;
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Subscription> _repo;
        public SubscriptionService(IRepository<Subscription> repo, NPDbContext context, IMapper mapper)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdBymarketerIdBytranxid(string CoyId, string marketerId, string tranxid)
        {
            long det1 = 0;
            if (!string.IsNullOrWhiteSpace(marketerId))
                det1 = Convert.ToInt64(marketerId);

            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll()
                .Where(o => o.CoyId == Convert.ToInt64(CoyId)
              && o.MarketerId == det1 || det1 == 0
              && o.TranxId == tranxid || tranxid == null)
                .ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Subscription obj)
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

        public ReturnObject Update(SubscriptionFmUpdate obj, int Id)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            try
            {
                _context.Subscriptions.Where(b => b.Id == Id)
                .ExecuteUpdate(setters => setters.SetProperty(b => b.MarketerId, obj.MarketerId)
               .SetProperty(b => b.SubAmount, obj.SubAmount)
              .SetProperty(b => b.StartDate, obj.StartDate)
               .SetProperty(b => b.ExpiryDate, obj.ExpiryDate));
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
