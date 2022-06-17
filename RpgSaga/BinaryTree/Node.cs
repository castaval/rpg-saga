namespace BinaryTreePlayers
{
    using Players;

    public class Node<T> where T: IPlayer
    {
        public T? Data { get; set; }

        public int? Index { get; set; } = 0;

        public Node(T? data)
        {
            Data = data;
        }

        public int Weight { get; set; } = 1;

        public Node<T>? NodeLeft { get; set; } = null;
        public Node<T>? NodeRight { get; set; } = null;
    }

}

