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
    public interface IClientService
    {
        ReturnObject Post(Client obj);
        ReturnObject Update(ClientFm obj, int Id);
        Task<ReturnObject> GetAllByCoyIdByclientId(string CoyId, string clientId);
    }
    public class ClientService : IClientService
    {
        private string errMsg = "An Error Occured";
        private readonly IMapper _mapper;
        private readonly IRepository<Client> _repo;
        public ClientService(IRepository<Client> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        Task<ReturnObject> IClientService.GetAllByCoyIdByclientId(string CoyId, string clientId)
        {
            long det1 = 0;
            if (!string.IsNullOrWhiteSpace(clientId))
                det1 = Convert.ToInt64(clientId);


            var r = new ReturnObject();
            r.status = true;
            r.message = "Record Fetched Successfully";
            var res = _repo.GetAll()
                .Where(o => o.CoyId == Convert.ToInt64(CoyId)
              && o.Id == det1 || det1 == 0)
                .ToList();
            r.data = res;
            return Task.FromResult(r);
        }

        public ReturnObject Post(Client obj)
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

        public ReturnObject Update(ClientFm obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
