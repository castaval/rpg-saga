namespace RpgSagaTests;


public class SelectorTest
{
    [Theory]
    [InlineData("1", "Да", "Да")]
    [InlineData("2", "Да", "Да")]
    [InlineData("3", "Да", "Да")]
    public void SelectCustomClassTest(string number, string isAdd, string startChoicePlayers)
    {
        // Arrange
        var selector = new Selector(new GameLogger());
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(number);
        stringBuilder.AppendLine(isAdd);
        stringBuilder.AppendLine(startChoicePlayers);
        var stringReader = new StringReader(stringBuilder.ToString());
        Console.SetIn(stringReader);

        // Act
        bool result = false;
        List<bool> ListBool = selector.SelectCustomClass();

        foreach (var element in ListBool)
        {
            result = element;

            if (result == true)
            {
                break;
            }
        }

        // Assert
        Assert.True(result);
    }
}