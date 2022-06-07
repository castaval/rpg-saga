namespace BinaryTree;
using Players;

public class BinaryTree<T> where T: IPlayer
{
    public Node<T>? Root { get; set; } = null;

    public int Index { get; set; } = 0;

    public void Insert(T data)
    {
        Root = InnerInsert(data, Root);
        Root.index = Index++;
    }

    public void Remove(T data)
    {
        Root = RemoveInner(Root, data);
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

    private Node<T>? RemoveInner(Node<T>? parent, T data)
    {
        if (parent == null) return parent;

        if (data.Strength < parent.Data.Strength)
            parent.NodeLeft = RemoveInner(parent.NodeLeft, data);
        else if (data.Strength > parent.Data.Strength)
            parent.NodeRight = RemoveInner(parent.NodeRight, data);

        else
        {
            if (parent.NodeLeft == null)
                return parent.NodeRight;
            else if (parent.NodeRight == null)
                return parent.NodeLeft;

            parent.Data.Strength = MinValue(parent.NodeRight);

            parent.NodeRight = RemoveInner(parent.NodeRight, parent.Data);
        }

        return parent;
    }

    private int MinValue(Node<T> node)
    {
        int minValue = node.Data.Strength;

        while (node.NodeLeft != null)
        {
            minValue = node.NodeLeft.Data.Strength;
            node = node.NodeLeft;
        }

        return minValue;
    }
}