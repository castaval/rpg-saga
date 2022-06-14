namespace BinaryTreePlayers
{
    using Players;

    // public class BinaryTree<T> where T: IPlayer
    // {
    //     public Node<T>? Root { get; set; } = null;

    //     public int Index { get; set; } = 0;

    //     public void Insert(T data)
    //     {
    //         Root = InnerInsert(data, Root);
    //         Root.Index = Index++;
    //     }

    //     public void RemoveData(T data)
    //     {
    //         Root = RemoveInnerData(Root, data);
    //     }

    //     public void RemoveIndex(int index)
    //     {
    //         Root = RemoveInnerIndex(Root, index);
    //     }

    //     public void Print(int spacing = 1, int topMargin = 2, int leftMargin = 2)
    //     {
    //         if (Root == null) return;
    //         int rootTop = Console.CursorTop + topMargin;
    //         var last = new List<NodeInfo<T>>();
    //         var next = Root;
    //         for (int level = 0; next != null; level++)
    //         {
    //             var item = new NodeInfo<T> { Node = next, Text = $"({next.Data.ClassName}) {next.Data.Name}" };
    //             if (level < last.Count)
    //             {
    //                 item.StartPos = last[level].EndPos + spacing;
    //                 last[level] = item;
    //             }
    //             else
    //             {
    //                 item.StartPos = leftMargin;
    //                 last.Add(item);
    //             }
    //             if (level > 0)
    //             {
    //                 item.Parent = last[level - 1];
    //                 if (next == item.Parent.Node.NodeLeft)
    //                 {
    //                     item.Parent.Left = item;
    //                     item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
    //                 }
    //                 else
    //                 {
    //                     item.Parent.Right = item;
    //                     item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
    //                 }
    //             }
    //             next = next.NodeLeft ?? next.NodeRight;
    //             for (; next == null; item = item.Parent)
    //             {
    //                 int top = rootTop + 2 * level;
    //                 PrintNode(item.Text, top, item.StartPos);
    //                 if (item.Left != null)
    //                 {
    //                     PrintNode("/", top + 1, item.Left.EndPos);
    //                     PrintNode("_", top, item.Left.EndPos + 1, item.StartPos);
    //                 }
    //                 if (item.Right != null)
    //                 {
    //                     PrintNode("_", top, item.EndPos, item.Right.StartPos - 1);
    //                     PrintNode("\\", top + 1, item.Right.StartPos - 1);
    //                 }
    //                 if (--level < 0) break;
    //                 if (item == item.Parent.Left)
    //                 {
    //                     item.Parent.StartPos = item.EndPos + 1;
    //                     next = item.Parent.Node.NodeRight;
    //                 }
    //                 else
    //                 {
    //                     if (item.Parent.Left == null)
    //                         item.Parent.EndPos = item.StartPos - 1;
    //                     else
    //                         item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
    //                 }
    //             }
    //         }
    //         Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
    //     }

    //     private void PrintNode(string s, int top, int left, int right = -1)
    //     {
    //         Console.SetCursorPosition(left, top);
    //         if (right < 0) right = left + s.Length;
    //         while (Console.CursorLeft < right) Console.Write(s);
    //     }

    //     private Node<T> InnerInsert(T data, Node<T>? root)
    //     {
    //         if (root == null)
    //             return new Node<T>(data);

    //         if (root.Data.Strength > data.Strength)
    //         {
    //             root.NodeLeft = InnerInsert(data, root.NodeLeft);
    //         }
    //         else if (root.Data.Strength < data.Strength)
    //         {
    //             root.NodeRight = InnerInsert(data, root.NodeRight);
    //         }

    //         return root;
    //     }

    //     private Node<T>? RemoveInnerData(Node<T>? parent, T data)
    //     {
    //         if (parent == null) return parent;

    //         if (data.Strength < parent.Data.Strength)
    //             parent.NodeLeft = RemoveInnerData(parent.NodeLeft, data);
    //         else if (data.Strength > parent.Data.Strength)
    //             parent.NodeRight = RemoveInnerData(parent.NodeRight, data);
    //         else
    //         {
    //             if (parent.NodeLeft == null)
    //                 return parent.NodeRight;
    //             else if (parent.NodeRight == null)
    //                 return parent.NodeLeft;

    //             int minValueStrength;
    //             int minValueIndex;

    //             MinValue(parent.NodeRight, out minValueStrength, out minValueIndex);

    //             parent.Data.Strength = minValueStrength;
    //             parent.Index = minValueIndex;

    //             parent.NodeRight = RemoveInnerData(parent.NodeRight, parent.Data);
    //         }

    //         return parent;
    //     }

    //     private Node<T>? RemoveInnerIndex(Node<T>? parent, int index)
    //     {
    //         if (parent == null) return parent;

    //         if (index < parent.Index)
    //             parent.NodeLeft = RemoveInnerIndex(parent.NodeLeft, index);
    //         else if (index > parent.Index)
    //             parent.NodeRight = RemoveInnerIndex(parent.NodeRight, index);

    //         else
    //         {
    //             if (parent.NodeLeft == null)
    //                 return parent.NodeRight;
    //             else if (parent.NodeRight == null)
    //                 return parent.NodeLeft;

    //             int minValueStrength;
    //             int minValueIndex;

    //             MinValue(parent.NodeRight, out minValueStrength, out minValueIndex);

    //             parent.Data.Strength = minValueStrength;
    //             parent.Index = minValueIndex;

    //             parent.NodeRight = RemoveInnerIndex(parent.NodeRight, parent.Index);
    //         }

    //         return parent;
    //     }

    //     private void MinValue(Node<T> node, out int minValueStrength, out int minValueIndex)
    //     {

    //         minValueStrength = node.Data.Strength;
    //         minValueIndex = node.Index;

    //         while (node.NodeLeft != null)
    //         {
    //             minValueStrength = node.NodeLeft.Data.Strength;
    //             minValueIndex = node.NodeLeft.Index;
    //             node = node.NodeLeft;
    //         }
    //     }
    // }

    public class BNode
    {
        public int item;
        public BNode right;
        public BNode left;

        public BNode(int item)
        {
            this.item = item;
        }
    }

    public class BTree
    {
        private BNode _root;

        public BNode Root { get { return _root; } }
        private int _count;
        private IComparer<int> _comparer = Comparer<int>.Default;


        public BTree()
        {
            _root = null;
            _count = 0;
        }


        public bool Add(int Item)
        {
            if (_root == null)
            {
                _root = new BNode(Item);
                _count++;
                return true;
            }
            else
            {
                return Add_Sub(_root, Item);
            }
        }

        private bool Add_Sub(BNode Node, int Item)
        {
            if (_comparer.Compare(Node.item, Item) < 0)
            {
                if (Node.right == null)
                {
                    Node.right = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.right, Item);
                }
            }
            else if (_comparer.Compare(Node.item, Item) > 0)
            {
                if (Node.left == null)
                {
                    Node.left = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(Node.left, Item);
                }
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            Root.Print();
        }
    }


    public static class BTreePrinter
    {
        class NodeInfo
        {
            public BNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(this BNode root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.item.ToString(textFormat) };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }
}