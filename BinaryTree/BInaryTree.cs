namespace BinaryTree;
using Players;

public class BinaryTree<T> where T: IPlayer
{
    public Node<T>? Root { get; set; } = null;

    public int Index { get; set; } = 0;

    public void Insert (T data)
    {
        Root = InnerInsert(data, Root);
        Root.index = Index++;
    }

    private Node<T> InnerInsert(T data, Node<T>? root)
    {
        if (root == null)
            return new Node<T>(data);

        if (root.Data.Strength > data.Strength)
        {
            root.NodeLeft = InnerInsert(data, root.NodeLeft);
        }
        else if (root.Data.Strength < data.Strength)
        {
            root.NodeRight = InnerInsert(data, root.NodeRight);
        }

        return root;
    }
}