using OpencvMe.DTO.CompanyDTO;
using OpencvMe.Repository.Interface;
using OpencvMe.Repository.Repositories;
using OpencvMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using OpencvMe.Model.Model;
using OpencvMe.Common.Helper;
using OpencvMe.Common.Model;

namespace OpencvMe.Service.Service
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _companyRepository;
        IUserCompanyRepository _userCompanyRepository;
        IMapper _mapper;
        public CompanyService(
            ICompanyRepository companyRepository,
            IUserCompanyRepository userCompanyRepository,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _userCompanyRepository = userCompanyRepository;
            _mapper = mapper;
        }

        public ServiceResponse<List<UserCompanyDTO>> GetUserCompanies(int userId)
        {

            var serviceResponse = new ServiceResponse<List<UserCompanyDTO>>();

            serviceResponse.Data = (
                    from uc in _userCompanyRepository.Find(x => x.UserId == userId)
                    join c in _companyRepository.GetAll() on uc.CompanyId equals c.CompanyId
                    where c.CompanyId == uc.CompanyId
                    select new UserCompanyDTO()
                    {
                        UserCompanyId = uc.UserCompanyId,
                        CompanyName = c.Name,
                        CompanyId = c.CompanyId,
                        Description = uc.Description,
                        IsWorking = uc.IsWorking,
                        Position = uc.Position,
                        StartDate = uc.StartDate,
                        EndDate = uc.EndDate,
                        StartDateStr = uc.StartDate.CustomDateStr(),
                        EndDateStr = uc.IsWorking ? " Devam ediyor " : uc.EndDate.CustomDateStr(),

                    }
                ).ToList();


           return serviceResponse.Success();

        }
        public ServiceResponse<List<CompanyDTO>> SearchCompany(string searchText)
        {
            var serviceResponse = new ServiceResponse<List<CompanyDTO>>();
            var schools = _companyRepository.Find(x => x.Name.Contains(searchText)).ToList();
            serviceResponse.Data = _mapper.Map<List<CompanyDTO>>(schools);
            return serviceResponse.Success();

        }
        public ServiceResponse<int> CreateCompany (string companyName)
        {
            var serviceResponse = new ServiceResponse<int>();

            var company = new Company() { Name = companyName };
            _companyRepository.Create(company);
            serviceResponse.Data = company.CompanyId;
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> AddUserCompanyList(List<UserCompanyDTO> request,int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            request.ForEach(item =>
            {
                if (item.CompanyId < 1)
                    item.CompanyId = CreateCompany(item.CompanyName).Data;
            });

            var userCompanies = _mapper.Map<List<UserCompany>>(request);
            userCompanies.ForEach(item => item.UserId = userId);
            serviceResponse.Data = _userCompanyRepository.CreateRange(userCompanies);

            return serviceResponse.Success();
        }

        public ServiceResponse<int> AddUserCompany(UserCompanyDTO request,int userId)
        {
            var serviceResponse = new ServiceResponse<int>();

            if (request.CompanyId < 1) // eğer yeni bir okul ekliyorsa kaydet
                request.CompanyId = CreateCompany(request.CompanyName).Data;


            var userCompany = _mapper.Map<UserCompany>(request);
            userCompany.UserId = userId;
            _userCompanyRepository.Create(userCompany);
            serviceResponse.Data = userCompany.UserCompanyId;
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> DeleteUserCompany(int userCompanyId)
        {
            var serviceResponse = new ServiceResponse<bool>();
            serviceResponse.Data = _userCompanyRepository.Delete(userCompanyId);
            return serviceResponse.Success();
        }

        public ServiceResponse<bool> UpdateUserCompany(UserCompanyDTO request, int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            if (request.CompanyId < 1) // eğer yeni bir okul ekliyorsa kaydet
                request.CompanyId = CreateCompany(request.CompanyName).Data;

            var userCompany = _mapper.Map<UserCompany>(request);
            userCompany.UserId = userId;
            _userCompanyRepository.Update(userCompany);
            serviceResponse.Data = true;
            return serviceResponse.Success();
        }
    }
}
