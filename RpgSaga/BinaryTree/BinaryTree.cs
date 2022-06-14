namespace BinaryTreePlayers
{
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

        public void Print(int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo<T>>();
            var next = Root;
            for (int level = 0; next != null; level++)
            {
                var element = new NodeInfo<T> { Node = next, Text = $"({next.Data.ClassName}) {next.Data.Name}" };
                if (level < last.Count)
                {
                    element.StartPos = last[level].EndPos + spacing;
                    last[level] = element;
                }
                else
                {
                    element.StartPos = leftMargin;
                    last.Add(element);
                }
                if (level > 0)
                {
                    element.Parent = last[level - 1];
                    if (next == element.Parent.Node.NodeLeft)
                    {
                        element.Parent.Left = element;
                        element.EndPos = Math.Max(element.EndPos, element.Parent.StartPos - 1);
                    }
                    else
                    {
                        element.Parent.Right = element;
                        element.StartPos = Math.Max(element.StartPos, element.Parent.EndPos + 1);
                    }
                }
                next = next.NodeLeft ?? next.NodeRight;
                for (; next == null; element = element.Parent)
                {
                    int top = rootTop + 2 * level;
                    PrintNode(element.Text, top, element.StartPos);
                    if (element.Left != null)
                    {
                        PrintNode("/", top + 1, element.Left.EndPos);
                        PrintNode("_", top, element.Left.EndPos + 1, element.StartPos);
                    }
                    if (element.Right != null)
                    {
                        PrintNode("_", top, element.EndPos, element.Right.StartPos - 1);
                        PrintNode("\\", top + 1, element.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (element == element.Parent.Left)
                    {
                        element.Parent.StartPos = element.EndPos + 1;
                        next = element.Parent.Node.NodeRight;
                    }
                    else
                    {
                        if (element.Parent.Left == null)
                            element.Parent.EndPos = element.StartPos - 1;
                        else
                            element.Parent.StartPos += (element.StartPos - 1 - element.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void PrintNode(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
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

                int minValueStrength;
                int minValueIndex;

                MinValue(parent.NodeRight, out minValueStrength, out minValueIndex);

                parent.Data.Strength = minValueStrength;
                parent.Index = minValueIndex;

                parent.NodeRight = RemoveInnerData(parent.NodeRight, parent.Data);
            }

            return parent;
        }

        private Node<T>? RemoveInnerIndex(Node<T>? parent, int index)
        {
            if (parent == null) return parent;

            if (index < parent.Index)
                parent.NodeLeft = RemoveInnerIndex(parent.NodeLeft, index);
            else if (index > parent.Index)
                parent.NodeRight = RemoveInnerIndex(parent.NodeRight, index);

            else
            {
                if (parent.NodeLeft == null)
                    return parent.NodeRight;
                else if (parent.NodeRight == null)
                    return parent.NodeLeft;

                int minValueStrength;
                int minValueIndex;

                MinValue(parent.NodeRight, out minValueStrength, out minValueIndex);

                parent.Data.Strength = minValueStrength;
                parent.Index = minValueIndex;

                parent.NodeRight = RemoveInnerIndex(parent.NodeRight, parent.Index);
            }

            return parent;
        }

        private void MinValue(Node<T> node, out int minValueStrength, out int minValueIndex)
        {

            minValueStrength = node.Data.Strength;
            minValueIndex = node.Index;

            while (node.NodeLeft != null)
            {
                minValueStrength = node.NodeLeft.Data.Strength;
                minValueIndex = node.NodeLeft.Index;
                node = node.NodeLeft;
            }
        }
    }
}
