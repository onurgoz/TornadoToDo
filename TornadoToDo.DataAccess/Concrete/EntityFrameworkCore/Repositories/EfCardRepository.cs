using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCardRepository : EfGenericRepository<Card>, ICardDal
    {
    }
}
