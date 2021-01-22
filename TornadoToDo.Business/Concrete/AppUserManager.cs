using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _genericDal.GetByFilter(I => I.Email == email);
        }

    }
}
