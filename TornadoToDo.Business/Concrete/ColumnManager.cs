using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Concrete
{
    public class ColumnManager : GenericManager<Column>, IColumnService
    {
        public ColumnManager(IGenericDal<Column> genericDal) : base(genericDal)
        {
        }
    }
}
