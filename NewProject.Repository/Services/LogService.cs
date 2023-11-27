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
    public interface ILogService
    {
        ReturnObject Post(Log obj);
        ReturnObject Update(LogFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByClientIdBymarketerIdByprodutid(string CoyId, string ClientId, string productId, string marketerId);
    }
    public class LogService : ILogService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Log> _repo;
        public LogService(IRepository<Log> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByClientIdBymarketerIdByprodutid(string CoyId, string ClientId, string productId, string marketerId)
        {
            long det1 = 0, det2 = 0, det3 = 0;
            if (!string.IsNullOrWhiteSpace(productId))
                det1 = Convert.ToInt64(productId);
            if (!string.IsNullOrWhiteSpace(ClientId))
                det2 = Convert.ToInt64(ClientId); 
            if (!string.IsNullOrWhiteSpace(marketerId))
                det3 = Convert.ToInt64(marketerId);

            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll()
                .Where(o => o.CoyId == Convert.ToInt64(CoyId)
              && o.MarketerId == det3 || det3 == 0
              && o.ProducId == det1 || det1 == 0 
              && o.ClientId == det2 || det2 == 0)
                .ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Log obj)
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

        public ReturnObject Update(LogFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
