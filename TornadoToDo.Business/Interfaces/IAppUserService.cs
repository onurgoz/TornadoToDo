using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> GetUserByEmail(string email);
    }
}
