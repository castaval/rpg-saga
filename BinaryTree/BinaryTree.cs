namespace BinaryTreePlayers;
using Players;

public class BinaryTree<T> where T: IPlayer
{
    public Node<T>? Root { get; set; } = null;

    public int Index { get; set; } = 0;

    public void Insert(T data)
    {
        Root = InnerInsert(data, Root);
        Root.Index = Index++;
    }

    public void RemoveData(T data)
    {
        Root = RemoveInnerData(Root, data);
    }

    public void RemoveIndex(int index)
    {
        Root = RemoveInnerIndex(Root, index);
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

    private Node<T>? RemoveInnerData(Node<T>? parent, T data)
    {
        if (parent == null) return parent;

        if (data.Strength < parent.Data.Strength)
            parent.NodeLeft = RemoveInnerData(parent.NodeLeft, data);
        else if (data.Strength > parent.Data.Strength)
            parent.NodeRight = RemoveInnerData(parent.NodeRight, data);

        else
        {
            if (parent.NodeLeft == null)
                return parent.NodeRight;
            else if (parent.NodeRight == null)
                return parent.NodeLeft;

            parent.Data.Strength = MinValue(parent.NodeRight, false);

            parent.NodeRight = RemoveInnerData(parent.NodeRight, parent.Data);
        }

        return parent;
    }

    private Node<T>? RemoveInnerIndex(Node<T>? parent, int index)
    {
        if (parent == null) return parent;

        if (index < parent.Index)
            parent.NodeLeft = RemoveInnerIndex(parent.NodeLeft, index);
        else if (index > parent.Data.Strength)
            parent.NodeRight = RemoveInnerIndex(parent.NodeRight, index);

        else
        {
            if (parent.NodeLeft == null)
                return parent.NodeRight;
            else if (parent.NodeRight == null)
                return parent.NodeLeft;

            parent.Index = MinValue(parent.NodeRight, true);

            parent.NodeRight = RemoveInnerIndex(parent.NodeRight, parent.Index);
        }

        return parent;
    }

    private int MinValue(Node<T> node, bool isIndex)
    {
        int minValue;

        if (isIndex)
        {
            minValue = node.Index;

             while (node.NodeLeft != null)
            {
                minValue = node.NodeLeft.Index;
                node = node.NodeLeft;
            }
        }
        else
        {
            minValue = node.Data.Strength;

            while (node.NodeLeft != null)
            {
                minValue = node.NodeLeft.Data.Strength;
                node = node.NodeLeft;
            }
        }

        return minValue;
    }
}