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

        public List<UserCompanyResponseDTO> GetUserCompanies(int userId)
        {

            var response = (
                    from uc in _userCompanyRepository.Find(x => x.UserId == userId)
                    join c in _companyRepository.GetAll() on uc.CompanyId equals c.CompanyId
                    where c.CompanyId == uc.CompanyId
                    select new UserCompanyResponseDTO()
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
                        EndDateStr = uc.EndDate.CustomDateStr(),
                    }
                ).ToList();


            return response;
        }
        public List<CompanyResponseDTO> SearchCompany(string searchText)
        {
            var schools = _companyRepository.Find(x => x.Name.Contains(searchText)).ToList();
            var response = _mapper.Map<List<CompanyResponseDTO>>(schools);
            return response;
        }
        public int CreateCompany (CompanyCreateDTO companyRequest)
        {
            var company = _mapper.Map<Company>(companyRequest);
            _companyRepository.Create(company);
            return company.CompanyId;
        }

        public bool AddUserCompanyList(List<UserCompanyCreateDTO> request,int userId)
        {
            var userCompanies= _mapper.Map<List<UserCompany>>(request);
            userCompanies.ForEach(item => item.UserId = userId);
            var response = _userCompanyRepository.CreateRange(userCompanies);
            return response;
        }

        public int AddUserCompany(UserCompanyCreateDTO request,int userId)
        {
            var userCompany = _mapper.Map<UserCompany>(request);
            userCompany.UserId = userId;
            var response = _userCompanyRepository.Create(userCompany);
            return response.UserCompanyId;
        }

        public bool DeleteUserCompany(int userCompanyId)
        {
            return _userCompanyRepository.Delete(userCompanyId);
        }

        public bool UpdateUserCompany(UserCompanyUpdateDTO request, int userId)
        {
            var userCompany = _mapper.Map<UserCompany>(request);
            userCompany.UserId = userId;
            _userCompanyRepository.Update(userCompany);
            return true;
        }
    }
}
