using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.DataAccess.Context;
using TornadoToDo.DataAccess.Interface;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBoardRepository : EfGenericRepository<Board>, IBoardDal
    {
        public async Task<Board> GetBoardInfo(int boardId)
        {
            using var context = new TornadoToDoDbContext();

            var board = await context.Boards.Include(b => b.Columns).ThenInclude(c => c.Cards).SingleOrDefaultAsync(x => x.Id == boardId);

            if (board == null)
            {
                return null;
            }

            return board;

            //var model = new BoardView();
            //var modelColumn = new BoardView.Column();
            //var result = await context.Boards.Join(context.Columns, b => b.Id, co => co.BoardId, (board, columns) => new
            //{
            //    columns,
            //    board
            //}).Join(context.Cards, two => two.columns.Id, c => c.Id, (twoTable, card) => new
            //{
            //    board = twoTable.board,
            //    column = twoTable.columns,
            //    card
            //}).Where(I => I.board.Id == boardId).Select(I => new
            //{
            //    I.board,
            //    I.column,
            //    I.card
            //}).ToListAsync();
        }

        public async Task AddCard(Card card, int boardId)
        {
            using var context = new TornadoToDoDbContext();

            var board = await context.Boards.Include(b => b.Columns).ThenInclude(c=>c.Cards).SingleOrDefaultAsync(x => x.Id == boardId);

            if (board != null)
            {
                var firstColumn = board.Columns.FirstOrDefault();
                var secondColumn = board.Columns.FirstOrDefault();
                var thirdColumn = board.Columns.FirstOrDefault();

                if (firstColumn == null || secondColumn == null || thirdColumn == null)
                {
                    firstColumn = new Column { Title = "Yapılacaklar" };
                    secondColumn = new Column { Title = "Yapılıyor" };
                    thirdColumn = new Column { Title = "Tamamlandı" };
                    board.Columns.Add(firstColumn);
                    board.Columns.Add(secondColumn);
                    board.Columns.Add(thirdColumn);

                    await context.SaveChangesAsync();
                }

                var updatedBoard = await context.Boards.Include(b => b.Columns).ThenInclude(c => c.Cards).FirstOrDefaultAsync(x => x.Id == boardId);
                var updatedColumn = updatedBoard.Columns.FirstOrDefault();

                await context.Cards.AddAsync(new Card
                {
                    Note = card.Note,
                    Title=card.Title,
                    Description=card.Description,
                    TaskDate=card.TaskDate,
                    ColumnId = updatedColumn.Id
                });

                await context.SaveChangesAsync();
           
            }
        }

        public async Task MoveAsync(int cardId, int columnId)
        {
            using var context = new TornadoToDoDbContext();
            var card = await context.Cards.SingleOrDefaultAsync(x => x.Id == cardId);
            card.ColumnId = columnId;
            await context.SaveChangesAsync();
        }
    }
}
