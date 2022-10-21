using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        public List<Player> Roster
        {
            get { return roster; }
            set { roster = value; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => Roster.Count;

        public void AddPlayer(Player player) 
        {
            if (Capacity > Count)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name) 
        {
            var playerTorRemove = Roster.FirstOrDefault(x => x.Name == name);
            if (playerTorRemove != null)
            {
                Roster.Remove(playerTorRemove);
                return true;
            }
            else return false;
        }
        public void PromotePlayer(string name) 
        {
            var playerToPromote = Roster.First(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var playerToDemote = Roster.First(x => x.Name == name);
            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class) 
        {
            Player[] kicked = Roster.FindAll(x => x.Class == @class).ToArray();
            Roster.RemoveAll(x => x.Class == @class);
            return kicked;
        }
        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in Roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
