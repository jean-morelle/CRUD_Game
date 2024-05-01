using CRUD_Game.Models;

namespace CRUD_Game.Services
{
    public interface IGameServices
    {
        Task<List<Game>> GetAllAsync();
        Task<Game>GetByIdAsync(int id);
        Task<Game>AddGame (Game game);
        Task<Game> EditGame(int id,Game game);
        Task<bool> DeleteGame(int id);
    }
}
