using Football.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Data.Data.ClassesRepository
{
    public static class TeamsRepository
    {
        public static TeamFights GetTeam(int id)
        {
            if (IfExistMath(id) == true)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return context.TeamFights.Where(t => t.Id == id).FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }
        public static bool IfExistMath(int id)
        {
            bool flag = true;
            using (AppDbContext context = new AppDbContext())
            {
                flag = context.TeamFights.Where(t => t.Id == id).Any();
            }
            return flag;
        }
        public static void AddTeam(TeamFights team)
        {
            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    context.TeamFights.Add(team);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error!!! {ex.Message}");
                }
            }
        }
        public static void DifferenceScoredGoals()
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (context.TeamFights.Count() == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"The table is empty!!! ");
                }
                else
                {
                    var teams = context.TeamFights;
                    foreach (var team in teams)
                    {
                        int countGoal = 0;
                        Console.WriteLine(new String('=', 30));
                        Console.Write($"{team.Team1}  vs  {team.Team2}\n" +
                                          $"Goals: {team.GoalsScoredTeam1}  vs  {team.GoalsScoredTeam2}\n" +
                                          $"Diferent : ");
                        if (team.GoalsScoredTeam1 > team.GoalsScoredTeam2)
                        {
                            countGoal = team.GoalsScoredTeam1 - team.GoalsScoredTeam2;
                            Console.Write($"{countGoal} won {team.Team1}");
                        }
                        else if (team.GoalsScoredTeam1 < team.GoalsScoredTeam2)
                        {
                            countGoal = team.GoalsScoredTeam2 - team.GoalsScoredTeam1;
                            Console.Write($"{countGoal} won {team.Team2}");
                        }
                        else
                        {
                            Console.Write($" 0 Draw !!! ");
                        }
                    }
                }
            }
        }
        public static void ShowStatsMatch()
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (context.TeamFights.Count() == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"The table is empty!!! ");
                }
                else
                {
                    var teams = context.TeamFights.OrderBy(t => t.Data);
                    foreach (var t in teams)
                    {
                        Console.WriteLine($"Id:  {t.Id}\n" +
                                          $"The name teams:  {t.Team1}  vs  {t.Team2}\n" +
                                          $"Count Scored Goals:  {t.GoalsScoredTeam1}   vs   {t.GoalsScoredTeam2}\n" +
                                          $"Id player why scored Goal:  {t.IdPlayerWhyScored}\n" +
                                          $"Date of the match:  {t.Data}");
                    }
                }
            }
        }
        public static void ShowMatchByDate(DateTime dateTime)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var t = context.TeamFights.Where(t => t.Data == dateTime).FirstOrDefault();
                if (t != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Id:  {t.Id}\n" +
                                          $"The name teams:  {t.Team1}  vs  {t.Team2}\n" +
                                          $"Count Scored Goals:  {t.GoalsScoredTeam1}   vs   {t.GoalsScoredTeam2}\n" +
                                          $"Id player why scored Goal:  {t.IdPlayerWhyScored}\n" +
                                          $"Date of the match:  {t.Data}");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There were no matches on this date!!!");
                }
            }
        }
        public static void ShowAllMathOneTeam(string team)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var mathes = context.TeamFights.Where(t => t.Team1 == team || t.Team2 == team);
                if (mathes.Count() != 0)
                {
                    Console.Clear();
                    foreach (var t in mathes)
                    {
                        Console.WriteLine(new String('=', 30));
                        Console.WriteLine($"Id:  {t.Id}\n" +
                                          $"The name teams:  {t.Team1}  vs  {t.Team2}\n" +
                                          $"Count Scored Goals:  {t.GoalsScoredTeam1}   vs   {t.GoalsScoredTeam2}\n" +
                                          $"Id player why scored Goal:  {t.IdPlayerWhyScored}\n" +
                                          $"Date of the match:  {t.Data}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"There were no Name team {team}!!!");
                }
            }
        }
        public static void ShowAllPlayerWhyScoredGoalsByDate(DateTime time)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var IdP = from t in context.TeamFights
                          where t.Data == time && t.IdPlayerWhyScored != null
                          select t.IdPlayerWhyScored;

                if (IdP.Count() != 0)
                {
                    var players = from c in IdP
                                  from p in context.Players
                                  where c == p.Id
                                  select p;
                    Console.Clear();
                    foreach (var player in players)
                    {
                        Console.WriteLine(new String('=', 30));
                        Console.WriteLine($"Id: {player.Id}\n" +
                            $"Name: {player.Name}\n" +
                            $"Surname: {player.Surname}\n" +
                            $"Position: {player.Position}\n" +
                            $"Number: {player.Number}");
                    }


                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("In this day no one scored a single goal!!!");
                }



            }
        }
        public static void UpdateMath(TeamFights team, int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                TeamFights teamFights = context.TeamFights.Where(t => t.Id == id).FirstOrDefault();
                teamFights.Data = team.Data != null ? team.Data : teamFights.Data;
                teamFights.IdPlayerWhyScored = team.IdPlayerWhyScored != null ? team.IdPlayerWhyScored : teamFights.IdPlayerWhyScored;
                teamFights.GoalsScoredTeam1 = team.GoalsScoredTeam1 != null ? team.GoalsScoredTeam1 : teamFights.GoalsScoredTeam1;
                teamFights.GoalsScoredTeam2 = team.GoalsScoredTeam2 != null ? team.GoalsScoredTeam2 : teamFights.GoalsScoredTeam2;
                teamFights.Team1 = team.Team1 != string.Empty ? team.Team1 : teamFights.Team1;
                teamFights.Team2 = team.Team2 != string.Empty ? team.Team2 : teamFights.Team2;
                context.TeamFights.Update(teamFights);
                context.SaveChanges();
            }
        }
        public static void DeleteMath(DateTime dateTime, string team1, string team2)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var team = context.TeamFights.Where(t => t.Team1 == team1 && t.Team2 == team2
                && t.Data.Day == dateTime.Day && t.Data.Month == dateTime.Month && t.Data.Year == dateTime.Year).FirstOrDefault();
                if (team != null)
                {
                    if (YesOrNo() == true)
                    {
                        context.TeamFights.Remove(team);
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.Clear();
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect syntax of which parameter!!!");
                }
            }
        }
        private static bool YesOrNo()
        {
            int a = 0;
            do
            {
                Console.Clear();
                Console.Write($"If you want reale delete match enter [ 1 ] \n" +
                    "if you not want delete match enter [ 2 ] \n" +
                    "Enter: ");
                a = int.Parse(Console.ReadLine());
            } while (a != 1 || a != 2);
            if (a == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
