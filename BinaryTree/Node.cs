namespace BinaryTree;

internal class Node<T>
{
    public T data { get; set; }

    public Node<T> NodeLeft { get; set; }
    public Node<T> NodeRight { get; set; }
    public Node<T> NodeParent { get; set; }
}
