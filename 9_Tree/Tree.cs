using System;

/// <summary>
///  트리 클래스
/// </summary>
/// <typeparam name="T"></typeparam>
public class Tree<T>
{
    /// <summary>
    /// 루트 노드
    /// </summary>
    private Node<T> root;

    /// <summary>
    /// 자신 노드 배열 ( 루트 노드의 자식 배열을 반환 )
    /// </summary>
    public List<Node<T>> Children { get { return root.Children; } }

    /// <summary>
    /// 트리 노드 갯수를 반환하는 프로퍼티(Tree갯수)
    /// </summary>
    public int Count { get { return root.Count; } }
    //생성자
    public Tree()
        : this(default(T))
    { 
    
    }
    public Tree(T newData)
    {
        root = new Node<T>(newData);//새로운 Node
    }

    /// <summary>
    /// 자식 노드 추가함수
    /// </summary>
    /// <param name="data">추가로 받을 데이터 </param>
    /// <param name="parent">부모 지정</param>
    public void AddChild(T data, Node<T> parent = null)
    { 
        //자식 노드 생성
        Node<T> newChild = new Node<T>(data);

        //생성한 자식 노드의 부모 지정 (위에 부모 없으면 해당 부모가 뿌리) :Null 이면 자식 노드 추가 할 수 없어서
        newChild.Parent = parent == null ? root : parent;

        //자식 노드 배열에 새 노드 추가
        newChild.Parent.AddChild(newChild);
    }

    /// <summary>
    /// 자식 노드 추가함수 2
    /// </summary>
    /// <param name="newChild"> 추가 받을 자식 Node </param>
    /// <param name="parent">부모 지정</param>
    public void AddChild(Node<T> newChild, Node<T> parent = null)
    {
        //생성한 자식 노드의 부모 지정 (위에 부모 없으면 해당 부모가 뿌리)
        newChild.Parent = parent == null ? root : parent;

        //자식 노드 배열에 새 노드 추가
        newChild.Parent.AddChild(newChild);
    }

    /// <summary>
    /// 순회 전위탐색 : 순서(부모를 먼저 -> 왼 -> 오)
    /// </summary>
    /// <param name="action">순회하면서 실행할 메소드를 받는 델리게이트(delegate) </param>
    /// <param name="depth">트리에서 계층을 보여주기 위한 변수(들여쓰기 위함) </param>
    public void PreorderTraverse(Action<Node<T>> action, int depth = 0 )
    {
        //재귀를 할 함수 호출.
        PreorderTraverseRecursive(root, action, depth);
    }

    /// <summary>
    /// 재귀 호출
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    /// <param name="depth"></param>
    private void PreorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        

        //시도 끝에 없으면 돌아가는 형식을 반복 : 재귀
        if (node == null)//데이터가 널이 아닌 경우가 있을 수 있지만
        {
            return;
        }

        //depth 표현을 위한 출력
        for (int i = 0; i < depth; i++) 
        {
            Console.Write("\t");
        }

        //노드 처리
        action(node);

        //나 처리 -> 자식
        foreach (Node<T> child in node.Children)//Enumerator C#의 컨테이너는 보장받지 못한다.
        {
            //(인덱스 순번으로) 직접 정의 : 부 -> 자 -> (왼 -> 오)MoveNext ++
            PreorderTraverseRecursive(child, action, depth + 1);
        }
    }//PreorderTraverseRecursive

    /// <summary>
    /// 순회 전위탐색 : 순서(부모를 먼저 -> 왼 -> 오)
    /// </summary>
    /// <param name="action">순회하면서 실행할 메소드를 받는 델리게이트(delegate) </param>
    /// <param name="depth">트리에서 계층을 보여주기 위한 변수(들여쓰기 위함) </param>
    public void PostorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        //재귀를 할 함수 호출.
        PostorderTraverseRecursive(root, action, depth);
    }

    /// <summary>
    /// 재귀 호출
    /// </summary>
    /// <param name="node"></param>
    /// <param name="action"></param>
    /// <param name="depth"></param>
    private void PostorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        

        //시도 끝에 없으면 돌아가는 형식을 반복 : 재귀
        if (node == null)//데이터가 널이 아닌 경우가 있을 수 있지만
        {
            return;
        }

        // 자식처리
        foreach (Node<T> child in node.Children)//Enumerator C#의 컨테이너는 보장받지 못한다.
        {
            PostorderTraverseRecursive(child, action, depth + 1);
        }

        //depth 표현을 위한 출력
        for (int i = 0; i < depth; i++)
        {
            Console.Write("\t");
        }

        //내 노드 처리
        action(node);

    }//PostorderTraverseRecursive
}

/* 델리게이트 구문
 * Delegate : 함수 포인터 
 * 콜백 함수 때문에 나옴, 상황 발생할 때, 내가 호출할 함수를 대상으로
 * (내가 일일이 여기저기 뿌리지 말고) 받고 싶은 애들은 너네가 구독해라
 * 보통의 네트워크 통신 방식
 */

/* 이진 트리
 * 자손의 갯수를 제한한 트리 L,R
 */

