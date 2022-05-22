public class PlayersGenerator {
    private int PlayersCount { get; set; }
    private string[] Names { get; set; } 
    
    public PlayersGenerator(int playerCount, string[] names) {
        PlayersCount = playerCount;
        Names = names;
    }

    public List<IPlayer> GeneratePlayersArray() {
        var result = new List<IPlayer>();
        var rand = new Random();
        for (int i = 0; i < PlayersCount; i++) {
            IPlayer player;
            var playerName = Names[rand.Next(PlayersCount)];
            var playerStrength = rand.Next(25, 50);
            var playerHealth = rand.Next(50, 100);
            var playerVariant = rand.Next(0, 2);
            switch (playerVariant) {
                case 0:
                    player = new Knight(playerName, playerStrength, playerHealth);
                    break;
                case 1:
                    player = new Mage(playerName, playerStrength, playerHealth);
                    break;
                case 2:
                    player = new Archer(playerName, playerStrength, playerHealth);
                    break;
                default:
                    throw new Exception();
            }
            result.Add(player); 
        }
        return result;
    }
}