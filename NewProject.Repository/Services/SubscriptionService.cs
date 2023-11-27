using AutoMapper;
using NewProject.Domain.Models;
using NewProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Repository.Services
{
    public interface ISubscriptionService
    {
        ReturnObject Post(SubscriptionFm obj);
        ReturnObject Update(SubscriptionFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdBymarketerIdBytranxid(string CoyId, string marketerId, string tranxid);
    }
    public class SubscriptionService : ISubscriptionService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Subscription> _repo;
        public SubscriptionService(IRepository<Subscription> repo, IMapper mapper)
        {
            _repo = repo;
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

        public ReturnObject Post(SubscriptionFm obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var emp = _mapper.Map<Subscription>(obj);
            emp.UniqueId = Guid.NewGuid().ToString();
            try
            {
                _repo.Insert(emp);
            }
            catch (Exception ex)
            {
                r.status = false;
                r.message = errMsg + $"{ex.Message}";
            }
            return r;
        }

        public ReturnObject Update(SubscriptionFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
