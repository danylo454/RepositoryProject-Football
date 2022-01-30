using Football.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Data.Data.ClassesRepository
{
    public static class PlayersRepository
    {
        public static void AddPlayer(Player player)
        {
            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    Console.Clear();
                    Console.WriteLine($"The player was successfully add!!!");

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Error!!!  {ex.Message}");
                }

            }
        }
        public static void DeletePlayer(int idP)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Player player = context.Players.Where(p => p.Id == idP).FirstOrDefault();
                if (player != null)
                {
                    try
                    {
                        context.Players.Remove(player);
                        context.SaveChanges();
                        Console.Clear();
                        Console.WriteLine($"The player was successfully removed!!!");

                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine($"Erorr!!!  {ex.Message}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"The player with Id: {idP} is not exist!!!");
                }
            }
        }

    }
}
