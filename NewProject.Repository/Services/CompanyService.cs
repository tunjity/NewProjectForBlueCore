using AutoMapper;
using NewProject.Domain;
using NewProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewProject.Utility.AllEnum;

namespace NewProject.Repository.Services
{
    public interface ICompanyService
    {
        ReturnObject Post(Company obj);
        ReturnObject Update(CompanyFm obj, int Id);
        Task<ReturnObject> GetallByCoyIdByPinnacleId(string CoyId, string PinnacleId);
    }
    public class CompanyService : ICompanyService
    {
        private string errMsg = "An Error Occured";
        private readonly IRepository<Company> _repo;
        public CompanyService(IRepository<Company> repo)
        {
            _repo = repo;
        }
        public Task<ReturnObject> GetallByCoyIdByPinnacleId(string CoyId, string PinnacleId)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var res = _repo.GetAll().Where(o=>o.Id == Convert.ToInt64(CoyId)).ToList();
            //if pinnacleid not null
            if(!string.IsNullOrEmpty(PinnacleId))
                res = res.Where(o=>o.PinnacleId==PinnacleId).ToList();
            r.data= res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Company obj)
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
                r.message = errMsg +$"{ex.Message}";
            }
            return r;
        }

        public ReturnObject Update(CompanyFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
