namespace RpgSagaTests;
using System.Text.Json;

[Collection("Sequential")]
public class PlayersGeneratorTest
{
    [Theory]
    [InlineData("1", "Да", "Да", "10")]
    [InlineData("2", "Да", "Да", "12")]
    [InlineData("3", "Да", "Да", "14")]
    public void GeneratePlayersArrayTest(string number, string isAdd, string startChoicePlayers, string numberPlayers)
    {
        // Arrange
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(number);
        stringBuilder.AppendLine(isAdd);
        stringBuilder.AppendLine(startChoicePlayers);
        stringBuilder.AppendLine(numberPlayers);
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);


        Selector selector = new Selector(new GameLogger());
        List<bool> newClasses = selector.SelectCustomClass();

        const string filepath = @"/home/alexander/Develop/rpg-saga-refactoring/KEKW/rpg-saga/RpgSaga/Main/Names.json";
        var json = File.ReadAllText(filepath);
        var playerNames = JsonSerializer.Deserialize<List<Names>>(json);

        int playerNumbers = selector.SelectNumbPlayers();

        var playersGenerator = new PlayersGenerator(playerNumbers, playerNames, newClasses);


        // Act
        var players = playersGenerator.GeneratePlayersArray();


        // Assert
        Assert.NotEmpty(players);
    }
}