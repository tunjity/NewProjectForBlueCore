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
    public interface IProductService
    {
        ReturnObject Post(Product obj);
        ReturnObject Update(ProductFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByProductIdByMarketerId(string CoyId, string ProductId, string MarketerId);
    }
    public class ProductService : IProductService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repo;
        public ProductService(IRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<ReturnObject> GetAllByCoyIdByProductIdByMarketerId(string CoyId, string ProductId, string MarketerId)
        {
            long det1 = 0, det2 = 0;
            if (!string.IsNullOrWhiteSpace(ProductId))
                det1 = Convert.ToInt64(ProductId);
            if (!string.IsNullOrWhiteSpace(MarketerId))
                det2 = Convert.ToInt64(MarketerId);

            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll()
                .Where(o => o.CoyId == Convert.ToInt64(CoyId)
              && o.Id == det1 || det1 == 0
              && o.MarketerId == det2 || det2 == 0)
                .ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Product obj)
        {
            var r = new ReturnObject();
            r.status = true;
            r.message = "Record saved Successfully";
            var emp = _mapper.Map<Product>(obj);
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

        public ReturnObject Update(ProductFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
