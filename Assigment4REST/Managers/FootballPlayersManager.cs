using Assigment4REST.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Assigment4REST.Managers
{
    public class FootballPlayersManager
    {
        private static int nextId = 1;

        private static readonly List<FootballPlayer> playersList = new List<FootballPlayer>
        
        {
            new FootballPlayer() { Id = nextId++, Name = "Tom Brady", ShirtNumber = 12, Age = 45},
            new FootballPlayer() { Id = nextId++, Name = "Patrick Mahomes", ShirtNumber = 15, Age = 25},
            new FootballPlayer() { Id = nextId++, Name = "Aaron Donald", ShirtNumber = 99, Age = 30},
            new FootballPlayer() { Id = nextId++, Name = "Trevon Diggs", ShirtNumber = 7, Age = 24},
            new FootballPlayer() { Id = nextId++, Name = "Micah Parsons", ShirtNumber = 11, Age = 22},
            new FootballPlayer() { Id = nextId++, Name = "Travis Kelce" , ShirtNumber = 17, Age = 32},
        };

        public List<FootballPlayer> GetAll()
        {
            return playersList;
        }

        public FootballPlayer? GetByID(int id)
        {
            return playersList.Find(p => p.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = nextId++;
            playersList.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer? Update(int id, FootballPlayer updatePlayer)
        {
            FootballPlayer? player = playersList.Find(p => p.Id == id);
            if (player == null) return null;
            player.Age = updatePlayer.Age;
            player.ShirtNumber = updatePlayer.ShirtNumber;
            player.Id = updatePlayer.Id;
            return player;
        }
        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? removablePlayer = GetByID(id);

            if (removablePlayer == null)
                return null;

            playersList.Remove(removablePlayer);

            return removablePlayer;
        }
    }
}
