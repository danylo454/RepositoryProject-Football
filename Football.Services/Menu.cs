using Football.Data.Data.ClassesRepository;
using Football.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services
{
    public static class Menu
    {
        public static void AddPlayer()
        {
            Console.Clear();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
            Player player = new Player()
            {
                Name = name,
                Surname = surname,
                Position = position,
                Number = number
            };
            PlayersRepository.AddPlayer(player);
        }
        public static void DeletePlayer()
        {
            Console.Clear();
            Console.Write($"Enter id player which you want delete: ");
            int id = int.Parse(Console.ReadLine());
            PlayersRepository.DeletePlayer(id);
        }
        public static void AddTeam()
        {
            Console.Clear();
            DateTime dateTime = new DateTime();
            Console.Write("Enter Name Team 1 : ");
            string teamName = Console.ReadLine();
            Console.Write("Enter Name Team 2 : ");
            string teamNam2 = Console.ReadLine();
            Console.Write("Enter id player why scored goal: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter count scored team 1: ");
            int goal1 = int.Parse(Console.ReadLine());
            Console.Write("Enter count scored team 2: ");
            int goal2 = int.Parse(Console.ReadLine());
            Console.Write("Enter Date Match [dd:mm:yyyy]: ");
            dateTime = DateTime.Parse(Console.ReadLine());
            TeamFights teamFights = new TeamFights()
            {
                Team1 = teamName,
                Team2 = teamNam2,
                IdPlayerWhyScored = id,
                GoalsScoredTeam1 = goal1,
                GoalsScoredTeam2 = goal2,
                Data = dateTime
            };
            TeamsRepository.AddTeam(teamFights);

        }
        public static void ShowDifferenceGoals()
        {
            Console.Clear();
            TeamsRepository.DifferenceScoredGoals();
        }
        public static void ShowAll()
        {
            TeamsRepository.ShowStatsMatch();
        }
        public static void ShowMathcByDate()
        {
            DateTime date = new DateTime();
            Console.Clear();
            Console.WriteLine(new String('=', 30));
            Console.Write("Enter PLS Date Match format dd:mm:yyyy\nEnter: ");
            date = DateTime.Parse(Console.ReadLine());
            TeamsRepository.ShowMatchByDate(date);

        }
        public static void ShowMathcByOneTeam()
        {
            Console.Clear();
            Console.Write("Enter name Team: ");
            string name = Console.ReadLine();
            TeamsRepository.ShowAllMathOneTeam(name);
        }
        public static void ShowAllPlayersByDate()
        {
            DateTime date = new DateTime();
            Console.Clear();
            Console.WriteLine(new String('=', 30));
            Console.Write("Enter PLS Date format dd:mm:yyyy\nEnter: ");
            date = DateTime.Parse(Console.ReadLine());
            TeamsRepository.ShowAllPlayerWhyScoredGoalsByDate(date);
        }
        public static void UpdateMath()
        {
            Console.Clear();
            Console.Write("Enter id team which you want to change: ");
            int id = int.Parse(Console.ReadLine());
            int init = -1;
            Console.Clear();
            if (TeamsRepository.IfExistMath(id) == true)
            {
                TeamFights oldTeam = TeamsRepository.GetTeam(id);
                TeamFights newTeam = new TeamFights();
                do
                {
                    Console.Write($"1)Change Name team 1: {oldTeam.Team1}\n" +
                        $"2)Change Name team 1: {oldTeam.Team2}\n" +
                        $"3)Change Ip player why scored goal: {oldTeam.IdPlayerWhyScored}\n" +
                        $"4)Change Count goals team 1: {oldTeam.GoalsScoredTeam1}\n" +
                        $"5)Change Count goals team 2: {oldTeam.GoalsScoredTeam2}\n" +
                        $"6)Change date {oldTeam.Data}\n" +
                        $"7)Exit\n" +
                        $"Enter: ");
                    init = int.Parse(Console.ReadLine());

                    switch (init)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine($"Old name {oldTeam.Team1}");
                                Console.Write("Enter new name: ");
                                string name = Console.ReadLine();
                                newTeam.Team1 = name;
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine($"Old name {oldTeam.Team2}");
                                Console.Write("Enter new name: ");
                                string name = Console.ReadLine();
                                newTeam.Team2 = name;
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine($"Old Ip player why scored goal {oldTeam.IdPlayerWhyScored}");
                                Console.Write("Enter new ip: ");
                                int name = int.Parse(Console.ReadLine());
                                newTeam.IdPlayerWhyScored = name;
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine($"Old count goals team 1: {oldTeam.GoalsScoredTeam1}");
                                Console.Write("Enter new count goals: ");
                                int count = int.Parse(Console.ReadLine());
                                newTeam.GoalsScoredTeam1 = count;
                                break;
                            }
                        case 5:
                            {

                                Console.Clear();
                                Console.WriteLine($"Old count goals team 2: {oldTeam.GoalsScoredTeam2}");
                                Console.Write("Enter new count goals: ");
                                int count = int.Parse(Console.ReadLine());
                                newTeam.GoalsScoredTeam2 = count;
                                break;
                            }
                        case 6:
                            {
                                Console.Clear();
                                DateTime dateTime = new DateTime();
                                Console.Write($"Old date: {oldTeam.Data}");
                                Console.Write("Enter new date dd:mm:yy: ");
                                dateTime = DateTime.Parse(Console.ReadLine());
                                newTeam.Data = dateTime;
                                break;
                            }
                        case 7:
                            {
                                Console.Clear();
                                init = 0;
                                TeamsRepository.UpdateMath(newTeam, id);
                                break;
                            }
                    }
                } while (init != 0);


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"The team with id: {id} is not exist!!!");
            }
        }
        public static void DeleteMath()
        {
            Console.Clear();
            DateTime dateTime = new DateTime();
            Console.Write("Enter date match dd:mm:yyyy: ");
            dateTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter name team 1 :");
            string name1 = Console.ReadLine();
            Console.Write("Enter name team 2 :");
            string name2 = Console.ReadLine();
            TeamsRepository.DeleteMath(dateTime, name1, name2);
        }
        public static void MenuMatch()
        {
            int init = -1;
            do
            {
                Console.Write($"1)Add Player\n" +
                    $"2)Add Match\n" +
                    $"3)Delete Player\n" +
                    $"4)Show Difference goals\n" +
                    $"5)Show All Match\n" +
                    $"6)Show Match by Date\n" +
                    $"7)Show One Team\n" +
                    $"8)Show player why scored goals by date\n" +
                    $"9)Update Match\n" +
                    $"10)Delete Match\n" +
                    $"0)Exit\n" +
                    $"Enter: ");
                init = int.Parse(Console.ReadLine());
                switch (init)
                {
                    case 0: { Console.Clear(); init = 0; break; }
                    case 1: { Console.Clear(); AddPlayer(); break; }
                    case 2: { Console.Clear();AddTeam();break; }
                    case 3: { Console.Clear(); DeletePlayer(); break; }
                    case 4: { Console.Clear(); ShowDifferenceGoals(); break; }
                    case 5: { Console.Clear(); ShowAll(); break; }
                    case 6: { Console.Clear(); ShowMathcByDate(); break; }
                    case 7: { Console.Clear(); ShowMathcByOneTeam(); break; }
                    case 8: { Console.Clear(); ShowAllPlayersByDate(); break; }
                    case 9: { Console.Clear(); UpdateMath(); break; }
                    case 10: { Console.Clear(); DeleteMath(); break; }
                }

            } while (init != 0);
        }
    }
}


