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
    public interface ICampaignService
    {
        ReturnObject Post(CampaignFm obj);
        ReturnObject Update(CampaignFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByProductIdByCamapagnid(string CoyId, string productId, string campagnId);
    }
    public class CampaignService : ICampaignService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Campaign> _repo;
        public CampaignService(IRepository<Campaign> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByProductIdByCamapagnid(string CoyId, string productId, string campagnId)
        {
            long det1 = 0, det2 = 0;
            if (!string.IsNullOrWhiteSpace(productId))
                det1= Convert.ToInt64(productId); 
            if (!string.IsNullOrWhiteSpace(campagnId))
                det2= Convert.ToInt64(campagnId);

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

        public ReturnObject Post(CampaignFm obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var emp = _mapper.Map<Campaign>(obj);
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

        public ReturnObject Update(CampaignFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
