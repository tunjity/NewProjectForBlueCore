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
    public interface ICommissionService
    {
        ReturnObject Post(CommissionFm obj);
        ReturnObject Update(CommissionFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByBenId(string CoyId, string BenId);
    }
    public class CommissionService : ICommissionService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Commission> _repo;
        public CommissionService(IRepository<Commission> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByBenId(string CoyId, string BenId)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll().Where(o => o.CoyId == Convert.ToInt64(CoyId)).ToList();
            //if pinnacleid not null
            if (!string.IsNullOrEmpty(BenId))
                res = res.Where(o => o.BenId == Convert.ToInt64(BenId)
                    ).ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(CommissionFm obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var emp = _mapper.Map<Commission>(obj);
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

        public ReturnObject Update(CommissionFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
