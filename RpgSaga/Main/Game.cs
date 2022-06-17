namespace Base
{
    using System.Text.Json;
    using Logger;
    using SelectorGame;
    using GeneratePlayers;
    using Players;
    using Fight;
    using PlayerNames;
    using BinaryTreePlayers;
    public class Game
    {
        private ILogger Logger { get; set; }
        private int numberTour { get; set; }
        private List<Names>? playerNames { get; set; }
        public Game(ILogger GameLogger)
        {
            Logger = GameLogger;
            numberTour = 1;

            const string filepath = @"/home/alexander/Develop/rpg-saga-refactoring/KEKW/rpg-saga/RpgSaga/Main/Names.json";
            var json = File.ReadAllText(filepath);
            playerNames = JsonSerializer.Deserialize<List<Names>>(json);
        }
        public void Run()
        {
            Logger.PrintStart();

            Selector selector = new Selector(Logger);

            List<bool> newClasses = selector.SelectCustomClass();

            int playerNumbers = selector.SelectNumbPlayers();

            PlayersGenerator playersGenerator = new PlayersGenerator(playerNumbers, playerNames, newClasses);

            List<IPlayer> players = new List<IPlayer>(playersGenerator.GeneratePlayersArray());

            while (true)
            {
                Logger.PrintTour(numberTour);
                numberTour++;

                Draft(players);
                Tour(players);

                if (EndGame(players))
                {
                    break;
                }
            }

            BTree();
        }

        public void Draft(List <IPlayer> players)
        {
            Random random = new Random();
            for (int i = players.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = players[j];
                players[j] = players[i];
                players[i] = temp;
            }
        }

        public void Tour(List <IPlayer> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (i + 1 < players.Count)
                {
                    Fight fight = new Fight(players[i], players[i+1], ref players, Logger);
                    fight.Battle();
                }
            }
        }

        public bool EndGame(List <IPlayer> players)
        {
            if (players.Count == 1)
            {
                Logger.PrintEnd(players[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BTree()
        {
            BinaryTree<IPlayer> tree = new BinaryTree<IPlayer>(null, 4, true);
            // BinaryTree<IPlayer> tree = new BinaryTree<IPlayer>(null);
            var archerDelete = new Archer("Max4", 34, 14, "Лучник");
            // tree.Insert(new Archer("Max1", 31, 11, "Лучник"));
            // tree.Insert(new Archer("Max2", 32, 12, "Лучник"));
            // tree.Insert(archerDelete);
            // tree.Insert(new Archer("Max3", 29, 13, "Лучник"));
            // tree.Insert(null);
            Console.Clear();
            tree.Print();
            // tree.RemoveIndex(3);
            // Console.Clear();
            // tree.Print();


        }


    }
}
