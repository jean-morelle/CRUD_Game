using CRUD_Game.Data;
using CRUD_Game.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Game.Services
{
    public class GameServices : IGameServices
    {
        private readonly ApplicationDbContext context;

        public GameServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Game> AddGame(Game game)
        {
             context.Games.Add(game);
             await context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var dbGame = await context.Games.FindAsync(id);
            if(dbGame != null)
            {
                context.Remove(dbGame);
                await context.SaveChangesAsync(); 
                return true;
            }
            return false;
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var dbGame =await context.Games.FindAsync(id);
            if(dbGame != null)
            {
                context.Remove(dbGame);
                dbGame.Name = game.Name;
                await context.SaveChangesAsync();
                return dbGame;
            }
            throw new Exception("Game has not found");
        }

        public async Task<List<Game>> GetAllAsync()
        {
           return await context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await  context.Games.FindAsync(id);
        }

        public async Task<Game> RemoveGame(int id)
        {
            var gameToRemove = await context.Games.FindAsync(id); // Find the game by ID

            if (gameToRemove != null)
            {
                context.Games.Remove(gameToRemove); // Mark the game for removal
                await context.SaveChangesAsync(); // Save changes to the database
            }

            return gameToRemove; // Return the removed game (or null if not found)
        }

    }
}
