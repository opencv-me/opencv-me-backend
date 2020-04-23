using OpencvMe.Model.Context;
using OpencvMe.Model.Model;
using OpencvMe.Repository.Base;
using OpencvMe.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Repository.Repositories
{
    public class UserCompanyRepository : RepositoryBase<UserCompany>, IUserCompanyRepository
    {
        public UserCompanyRepository(EfContext efContext) : base(efContext) { }
    }
}
