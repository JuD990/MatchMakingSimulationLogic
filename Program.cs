using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var random = new Random();
        int matchID = 1;
        int length = 10000000;
        matchID = random.Next(1, length);
        int playerIdCounter = 0;
        var availableRoles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
        
        var heroTeam = new List<Player>();
        var villainTeam = new List<Player>();

        // Assign roles and generate players
        var heroRoles = availableRoles.OrderBy(x => random.Next()).Take(5).ToList();
        var villainRoles = availableRoles.OrderBy(x => random.Next()).Take(5).ToList();

        for (int i = 0; i < 5; i++)
        {
            heroTeam.Add(new Player(playerIdCounter++, Helper.GenerateUsername(6), heroRoles[i]) { Side = Side.Hero });
            villainTeam.Add(new Player(playerIdCounter++, Helper.GenerateUsername(6), villainRoles[i]) { Side = Side.Villain });
        }

        DateTime startTime = DateTime.Now;
        TimeSpan duration = TimeSpan.FromMinutes(Helper.RandomDurationMinutes());

        var match = new Match(matchID, startTime, duration, heroTeam, villainTeam);

        match.PrintMatch();
    }
}
