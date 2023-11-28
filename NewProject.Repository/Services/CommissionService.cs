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
    public interface ICommissionService
    {
        ReturnObject Post(Commission obj);
        ReturnObject Update(CommissionFmUpdate param, int id);
        Task<ReturnObject> GetAllByCoyIdByBenId(string CoyId, string BenId);
    }
    public class CommissionService : ICommissionService
    {
        private readonly NPDbContext _context;
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Commission> _repo;
        public CommissionService(IRepository<Commission> repo, NPDbContext context, IMapper mapper)
        {
            _repo = repo;
            _context = context;
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

        public ReturnObject Post(Commission obj)
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

        public ReturnObject Update(CommissionFmUpdate param, int id)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            try
            {
                _context.Commissions.Where(b => b.Id == id)
                .ExecuteUpdate(setters => setters.SetProperty(b => b.TranxBy, param.TranxBy)
               .SetProperty(b => b.TranxAmount, param.TranxAmount)
              .SetProperty(b => b.BenId, param.BenId)
               .SetProperty(b => b.Description, param.Description));
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
