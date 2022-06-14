namespace BinaryTreePlayers
{
    using Players;
    class NodeInfo<T> where T: IPlayer
    {
        public Node<T> Node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo<T> Parent, Left, Right;
    }
}
