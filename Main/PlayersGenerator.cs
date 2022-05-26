public class PlayersGenerator {
    private int PlayersCount { get; set; }
    private string[] Names { get; set; }
    private List<bool> NewClasses { get; set; }

    public PlayersGenerator(int playerCount, string[] names, List<bool> newClasses) {
        PlayersCount = playerCount;
        Names = names;
        NewClasses = newClasses;
    }

    public List<IPlayer> GeneratePlayersArray() {
        var result = new List<IPlayer>();
        var rand = new Random();
        for (int i = 0; i < PlayersCount; i++) {
            IPlayer player;
            var playerName = Names[rand.Next(PlayersCount)];
            var playerStrength = rand.Next(25, 51);
            var playerHealth = rand.Next(50, 101);
            var playerVariant = rand.Next(0, 3);
            switch (playerVariant) {
                case 0:
                    player = new Knight(playerName, playerStrength, playerHealth, "Рыцарь");
                    break;
                case 1:
                    player = new Mage(playerName, playerStrength, playerHealth, "Маг");
                    break;
                case 2:
                    player = new Archer(playerName, playerStrength, playerHealth, "Лучник");
                    break;
                default:
                    throw new Exception();
            }
            result.Add(player);
        }
        return result;
    }
}