using System;

/// <summary>
/// BinaryTree의 단위 Node
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    /// <summary>
    /// 넣는 자료
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// 부모
    /// </summary>
    public Node<T> Parent { get; set; }

    /// <summary>
    /// 왼쪽 노드
    /// </summary>
    public Node<T> Left { get; set; }

    /// <summary>
    /// 오른쪽 노드
    /// </summary>
    public Node<T> Right { get; set; }


    /// <summary>
    /// 기본 생성자
    /// </summary>
    public Node()
    {
        Data = default(T);
        Parent = null;
        Left = null;
        Right = null;
    }

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="data"></param>
    public Node(T data)
    {
        Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }

    /// <summary>
    /// 왼쪽 자식 추가
    /// </summary>
    /// <param name="data"></param>
    public void AddLeftChild(T data)
    {
        Node<T> newChild = new Node<T>(data);
        newChild.Parent = this;
        Left = newChild;
    }
    /// <summary>
    /// 왼쪽 자식 Node 추가
    /// </summary>
    /// <param name="child"></param>
    public void AddLeftChild(Node<T> child)
    {
        child.Parent = this;
        Left = child;
    }
    /// <summary>
    /// 오른쪽 자식 추가
    /// </summary>
    /// <param name="data"></param>
    public void AddRightChild(T data)
    {
        Node<T> newChild = new Node<T>(data);
        newChild.Parent = this;
        Right = newChild;
    }

    /// <summary>
    /// 오른쪽 자식 Node 추가
    /// </summary>
    /// <param name="child"></param>
    public void AddRightChild(Node<T> child)
    {
        child.Parent = this;
        Right = child;
    }
}