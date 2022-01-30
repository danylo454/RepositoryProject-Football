using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Data.Data.Models
{
    public class TeamFights
    {
        public int Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int IdPlayerWhyScored { get; set; }
        public int GoalsScoredTeam1 { get; set; }
        public int GoalsScoredTeam2 { get; set; }
        public DateTime Data { get; set; }
        public Player Players { get; set; }
    }
}
