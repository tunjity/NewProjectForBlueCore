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
    public interface IMarketerService
    {
        ReturnObject Post(Marketer obj);
        ReturnObject Update(MarketerFmUpdate obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByMemberId(string CoyId, string memberId);
    }
    public class MarketerService : IMarketerService
    {        private readonly NPDbContext _context;
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Marketer> _repo;
        public MarketerService(IRepository<Marketer> repo,NPDbContext context, IMapper mapper)
        {
            _repo = repo;
            _context = context;
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

        public ReturnObject Post(Marketer obj)
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

        public ReturnObject Update(MarketerFmUpdate obj, int Id)
        {
             var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            try
            {
                _context.Marketers.Where(b => b.Id == Id)
                .ExecuteUpdate(setters => setters.SetProperty(b => b.F1, obj.F1)
               .SetProperty(b => b.F2, obj.F2)
               .SetProperty(b => b.F3, obj.F3)
               .SetProperty(b => b.F4, obj.F4)
               .SetProperty(b => b.F5, obj.F5)
               .SetProperty(b => b.MobileNo, obj.MobileNo)
               .SetProperty(b => b.Email, obj.Email)
               .SetProperty(b => b.DateOfBirth, obj.DateOfBirth)
               .SetProperty(b => b.Gender, obj.Gender)
               .SetProperty(b => b.Address, obj.Address)
               .SetProperty(b => b.State, obj.State)
               .SetProperty(b => b.ExpiryDate, obj.ExpiryDate)
               .SetProperty(b => b.Plan, obj.Plan)
              .SetProperty(b => b.Country, obj.Country));
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
