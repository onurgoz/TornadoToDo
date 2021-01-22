using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Interface
{
    public interface IBoardDal : IGenericDal<Board>
    {
        Task<Board> GetBoardInfo(int boardId);
        Task AddCard(Card card, int boardId);
        Task MoveAsync(int cardId, int columnId);
    }
}
