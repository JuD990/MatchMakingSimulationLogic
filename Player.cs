public class Player
{
    public int PlayerID { get; }
    public string Username { get; }
    public Role Role { get; }
    public Side Side { get; set; }

    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int Assists { get; set; }
    public int Networth { get; }

    // ✅ NEW
    public bool IsMVP { get; set; }
    public bool IsSVP { get; set; }

    // ✅ Performance score (used by Match)
    public int PerformanceScore =>
        (Kills * 2) + Assists - Deaths + (Networth / 1000);

    public Player(int playerID, string username, Role role)
    {
        PlayerID = playerID;
        Username = username;
        Role = role;

        Kills = Helper.RandomKDA();
        Deaths = Helper.RandomKDA();
        Assists = Helper.RandomKDA();
        Networth = Helper.RandomNetworth();
    }

    public override string ToString()
    {
        string badge =
            IsMVP ? " | MVP" :
            IsSVP ? " | SVP" : "";

        return $"Player {PlayerID} | {Username} | {Role} | " +
               $"KDA: {Kills}/{Deaths}/{Assists} | " +
               $"NW: {Networth} Gold{badge}";
    }
}
