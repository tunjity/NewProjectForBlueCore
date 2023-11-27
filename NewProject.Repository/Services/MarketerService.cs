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
    public interface IMarketerService
    {
        ReturnObject Post(MarketerFm obj);
        ReturnObject Update(MarketerFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByMemberId(string CoyId, string memberId);
    }
    public class MarketerService : IMarketerService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Marketer> _repo;
        public MarketerService(IRepository<Marketer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByMemberId(string CoyId, string memberId)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll().Where(o => o.CoyId == Convert.ToInt64(CoyId)).ToList();
            //if pinnacleid not null
            if (!string.IsNullOrEmpty(memberId))
                res = res.Where(o => o.MemberId == Convert.ToInt64(memberId)
                    ).ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(MarketerFm obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var emp = _mapper.Map<Marketer>(obj);
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

        public ReturnObject Update(MarketerFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
