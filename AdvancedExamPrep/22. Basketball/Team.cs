using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => Players.Count;

        public string AddPlayer(Player player) 
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                Players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }

        }
        public bool RemovePlayer(string name) 
        {
            var playerToRemove = Players.FirstOrDefault(x => x.Name == name);
            if (playerToRemove == null)
            {
                return false;
            }
            else
            {
                Players.Remove(playerToRemove);
                OpenPositions++;
                return true;
            }
        }
        public int RemovePlayerByPosition(string position) 
        {
            var playersToremove = Players.FindAll(x => x.Position == position);
            if (playersToremove.Count == 0)
            {
                return 0;
            }
            else
            {
                Players.RemoveAll(x => x.Position == position);
                OpenPositions += playersToremove.Count;
                return playersToremove.Count;
            }
        }
        public Player RetirePlayer(string name) 
        {
            var playerToRetire = Players.FirstOrDefault(x => x.Name == name);
            if (playerToRetire == null)
            {
                return null;
            }
            else
            {
                playerToRetire.Retired = true;
                return playerToRetire;
            }
        }
        public List<Player> AwardPlayers(int games) 
        {
            var awardedPlayers = Players.FindAll(x => x.Games >= games);
            return awardedPlayers;
        }
        public string Report() 
        {
            var playersToReport = Players.FindAll(x => x.Retired == false);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in playersToReport)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
