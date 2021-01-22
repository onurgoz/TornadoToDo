using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.Business.Interfaces;

using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.Business.Concrete
{
    public class BoardManager : GenericManager<Board>, IBoardService
    {
        private readonly IGenericDal<Board> _genericDal;
        private readonly IBoardDal _boardDal;
        public BoardManager(IBoardDal boardDal,IGenericDal<Board> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _boardDal = boardDal;
        }

        public async Task AddCard(Card card, int boardId)
        {
            await _boardDal.AddCard(card, boardId);
        }

        public async Task<Board> GetBoardInfo(int boardId)
        {
            return await _boardDal.GetBoardInfo(boardId);
        }

        public async Task<List<Board>> GetBoardsByAppUserId(int id)
        {
            return await _genericDal.GetAllByFilter(I => I.AppUserId == id);
        }

        public async Task MoveAsync(int cardId, int columnId)
        {
            await _boardDal.MoveAsync(cardId, columnId);
        }
    }
}
