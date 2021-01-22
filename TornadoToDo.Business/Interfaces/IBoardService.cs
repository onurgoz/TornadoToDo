using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Interfaces
{
    public interface IBoardService: IGenericService<Board>
    {
        Task<List<Board>> GetBoardsByAppUserId(int id);
        Task<Board> GetBoardInfo(int boardId);
        Task AddCard(Card card, int boardId);
        Task MoveAsync(int cardId, int columnId);
    }
}
