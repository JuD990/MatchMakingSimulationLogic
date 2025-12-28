using System;
using System.Collections.Generic;
using System.Linq;

public class Match
{
    //MVP
    public Player MVP =>
        HeroTeam.Concat(VillainTeam)
                .FirstOrDefault(p => p.IsMVP);

    private void CalculateMvpSvp()
    {
        // Separate winner and loser teams
        List<Player> winnerTeam = Verdict == Side.Hero ? HeroTeam : VillainTeam;
        List<Player> loserTeam  = Verdict == Side.Hero ? VillainTeam : HeroTeam;

        // MVP: highest PerformanceScore in winning team
        var mvp = winnerTeam.OrderByDescending(p => p.PerformanceScore).FirstOrDefault();
        if (mvp != null) mvp.IsMVP = true;

        // SVP: highest PerformanceScore in losing team
        var svp = loserTeam.OrderByDescending(p => p.PerformanceScore).FirstOrDefault();
        if (svp != null) svp.IsSVP = true;
    }

    public int MatchID { get; }
    public DateTime StartTime { get; }
    public TimeSpan Duration { get; }
    public DateTime EndTime => StartTime + Duration;

    public List<Player> HeroTeam { get; }
    public List<Player> VillainTeam { get; }

    //Totals
    public int TotalHeroKills => HeroTeam.Sum(p => p.Kills);
    public int TotalHeroDeaths => HeroTeam.Sum(p => p.Deaths);
    public int TotalHeroAssists => HeroTeam.Sum(p => p.Assists);

    public int TotalVillainKills => VillainTeam.Sum(p => p.Kills);
    public int TotalVillainDeaths => VillainTeam.Sum(p => p.Deaths);
    public int TotalVillainAssists => VillainTeam.Sum(p => p.Assists);

    public int HeroNetworth => HeroTeam.Sum(p => p.Networth);
    public int VillainNetworth => VillainTeam.Sum(p => p.Networth);

    //win condition (kills + networth)
    private const int KillWeight = 100;

    public int HeroScore => (TotalHeroKills * KillWeight) + HeroNetworth;
    public int VillainScore => (TotalVillainKills * KillWeight) + VillainNetworth;

    public Side Verdict =>
        HeroScore >= VillainScore ? Side.Hero : Side.Villain;

    public Match(int matchID, DateTime startTime, TimeSpan duration,
                List<Player> heroTeam, List<Player> villainTeam)
    {
        MatchID = matchID;
        StartTime = startTime;
        Duration = duration;
        HeroTeam = heroTeam;
        VillainTeam = villainTeam;

        CalculateMvpSvp();
    }

    public void PrintMatch()
    {
        Console.WriteLine($"\nMatch ID: {MatchID}");
        Console.WriteLine($"Start Time: {StartTime}");
        Console.WriteLine($"Duration: {Duration.TotalMinutes} minutes");
        Console.WriteLine($"End Time: {EndTime}");

        if (Verdict == Side.Hero)
        {
            Console.WriteLine($"\nHero Team: {TotalHeroKills} Kills | HEROES WIN");
            HeroTeam.ForEach(player => Console.WriteLine($"    {player}"));

            Console.WriteLine($"\nVillain Team: {TotalVillainKills} Kills");
            VillainTeam.ForEach(player => Console.WriteLine($"    {player}"));
        }
        else
        {
            Console.WriteLine($"\nHero Team: {TotalHeroKills} Kills");
            HeroTeam.ForEach(player => Console.WriteLine($"    {player}"));

            Console.WriteLine($"\nVillain Team: {TotalVillainKills} Kills | VILLAINS WIN");
            VillainTeam.ForEach(player => Console.WriteLine($"    {player}"));
        }

        Console.WriteLine("\nGame Summary | Total Networth | Kills/Deaths/Assists | Verdict");

        if (Verdict == Side.Hero)
        {
            Console.WriteLine(
                $"Heroes:   | {HeroNetworth} Gold | {TotalHeroKills}/{TotalHeroDeaths}/{TotalHeroAssists} | Winner");
            Console.WriteLine(
                $"Villains: | {VillainNetworth} Gold | {TotalVillainKills}/{TotalVillainDeaths}/{TotalVillainAssists} | Loser\n");
        }
        else
        {
            Console.WriteLine(
                $"Heroes:   | {HeroNetworth} Gold | {TotalHeroKills}/{TotalHeroDeaths}/{TotalHeroAssists} | Loser");
            Console.WriteLine(
                $"Villains: | {VillainNetworth} Gold | {TotalVillainKills}/{TotalVillainDeaths}/{TotalVillainAssists} | Winner\n");
        }
    }
}
