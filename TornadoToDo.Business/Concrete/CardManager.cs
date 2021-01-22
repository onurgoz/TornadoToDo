using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Concrete
{
    public class CardManager : GenericManager<Card> , ICardService
    {
        public CardManager(IGenericDal<Card> genericDal) : base(genericDal)
        {
        }
    }
}
