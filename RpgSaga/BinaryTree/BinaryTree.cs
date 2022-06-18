namespace BinaryTreePlayers
{
    using Players;

    public class BinaryTree<T> where T: IPlayer
    {
        public Node<T>? Root { get; set; } = null;

        public int? RootIndex { get; set; }

        public List<Node<T>> IndexList { get; set; } = new List<Node<T>>();

        public int Index { get; set; } = 0;

        public bool Empty { get; set; }

        public BinaryTree(T? zero, int height = 0, bool empty = false)
        {
            RootIndex = (int)Math.Pow(2, height) / 2;
            Empty = empty;

            if (Empty)
            {
                for (int i = 0; i < (Math.Pow(2, height) - 1); i++)
                {

                    Add(zero);
                }
            }
        }

        public void Add(T? data)
        {
            Node<T> newItem = new Node<T>(data);

            if (Empty)
            {
                newItem.Index = Index++;
            }


            if (Root == null)
            {
                Root = newItem;
            }
            else
            {
                if (!Empty)
                {
                    Root = RecursiveInsert(Root, newItem);
                }
                else
                {
                    Root = RecursiveInsertEmpty(Root, newItem);
                }
            }

            AcrossIndex();
        }

        private Node<T> RecursiveInsert(Node<T> current, Node<T> n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Data.Strength < current.Data.Strength)
            {
                current.NodeLeft = RecursiveInsert(current.NodeLeft, n);
                current = balance_tree(current);
            }
            else if (n.Data.Strength > current.Data.Strength)
            {
                current.NodeRight = RecursiveInsert(current.NodeRight, n);
                current = balance_tree(current);
            }

            return current;
        }

        private Node<T> RecursiveInsertEmpty(Node<T> current, Node<T> n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Index < current.Index)
            {
                current.NodeLeft = RecursiveInsertEmpty(current.NodeLeft, n);
                current = balance_tree(current);
            }
            else if (n.Index > current.Index)
            {
                current.NodeRight = RecursiveInsertEmpty(current.NodeRight, n);
                current = balance_tree(current);
            }

            return current;
        }

        private Node<T> balance_tree(Node<T> current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.NodeLeft) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.NodeRight) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public void DeleteData(T target)
        {
            Root = Delete(Root, target);
            AcrossIndex();
        }

        public void DeleteIndex(int index)
        {
            Root = Delete(Root, IndexList[index-1].Data);
            AcrossIndex();
        }

        private void AcrossIndex()
        {
            IndexList.Clear();
            var queue = new Queue<Node<T>>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                if (queue.Peek().NodeLeft != null)
                {

                    queue.Enqueue(queue.Peek().NodeLeft);
                }
                if (queue.Peek().NodeRight != null)
                {

                    queue.Enqueue(queue.Peek().NodeRight);
                }

                Node<T> newIndex = queue.Dequeue();

                ref Node<T> index = ref newIndex;

                IndexList.Add(index);
            }

        } 

        private Node<T> Delete(Node<T> current, T target)
        {
            Node<T> parent;

            if (current == null)
                return null;
            else
            {
                if (target.Strength < current.Data.Strength)
                {
                    current.NodeLeft = Delete(current.NodeLeft, target);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.NodeRight) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (target.Strength > current.Data.Strength)
                {
                    current.NodeRight = Delete(current.NodeRight, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.NodeLeft) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    if (current.NodeRight != null)
                    {
                        parent = current.NodeRight;
                        while (parent.NodeLeft != null)
                        {
                            parent = parent.NodeLeft;
                        }
                        current.Data = parent.Data;
                        current.NodeRight = Delete(current.NodeRight, parent.Data);
                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.NodeLeft) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {
                        return current.NodeLeft;
                    }
                }
            }
            return current;
        }

        public Node<T> Get(int index)
        {
            return IndexList[index-1];
        }

        public void Print()
        {
            PrintConsole();
            PrintFile();
        }

        private async void PrintFile()
        {
            string path = "PlayersFile.txt";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                string text;

                foreach (var player in IndexList)
                {
                    if (player.Data == null)
                    {
                        text = "( )";
                    }
                    else
                    {
                        text = $"({player.Data.ClassName}) {player.Data.Name}";
                    }

                    await writer.WriteLineAsync(text);
                }
            }
        }

        private void PrintConsole()
        {
            int spacing = 1;
            int topMargin = 2;
            int leftMargin = 2;
            if (Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo<T>>();
            var next = Root;
            string text;

            for (int level = 0; next != null; level++)
            {
                if (next.Data == null)
                {
                    text = "( )";
                }
                else
                {
                    text = $"({next.Data.ClassName}) {next.Data.Name}";
                }

                var element = new NodeInfo<T> { Node = next, Text = text };
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

        private int balance_factor(Node<T> current)
        {
            int l = getHeight(current.NodeLeft);
            int r = getHeight(current.NodeRight);
            int b_factor = l - r;
            return b_factor;
        }

        private int getHeight(Node<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.NodeLeft);
                int r = getHeight(current.NodeRight);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }

        private Node<T> RotateRR(Node<T> parent)
        {
            Node<T> pivot = parent.NodeRight;
            parent.NodeRight = pivot.NodeLeft;
            pivot.NodeLeft = parent;
            return pivot;
        }
        private Node<T> RotateLL(Node<T> parent)
        {
            Node<T> pivot = parent.NodeLeft;
            parent.NodeLeft = pivot.NodeRight;
            pivot.NodeRight = parent;
            return pivot;
        }
        private Node<T> RotateLR(Node<T> parent)
        {
            Node<T> pivot = parent.NodeLeft;
            parent.NodeLeft = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node<T> RotateRL(Node<T> parent)
        {
            Node<T> pivot = parent.NodeRight;
            parent.NodeRight = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}