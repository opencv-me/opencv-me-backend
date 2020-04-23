using OpencvMe.Model.Context;
using OpencvMe.Model.Model;
using OpencvMe.Repository.Base;
using OpencvMe.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpencvMe.Repository.Repositories
{
    public class CompanyRepository :RepositoryBase<Company> , ICompanyRepository
    {
        public CompanyRepository(EfContext efContext) : base(efContext) { }

        //public IEnumerable<Company> GetUserCompanies(int id)
        //{
        //    _context.Company.Join(
        //        _context.UserCompany, 
        //        company =>  company.CompanyId,
        //        userCompany => userCompany.U )



        //}
    }
}
