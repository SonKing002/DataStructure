using System;

/// <summary>
/// 트리 구조 내용의 단위요소 GUID / UUID
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{ 
    /// <summary>
    /// 데이터를 저장할 프로퍼티
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// 부모 노드 : 트리에 따라 필요없을 수도 있지만, 상황에 따라 넣음
    /// </summary>
    public Node<T> Parent { get; set; }

    /// <summary>
    /// 자식 노드 (리스트 배열)
    /// </summary>
    public List<Node<T>> Children { get; set; }

    /// <summary>
    /// 자식의 노드 수를 구하는 프로퍼티
    /// </summary>
    public int Count
    { 
        get
        {
            int count = 1;
            foreach (Node<T> child in Children)//자손이 있으면
            {
                count += child.Count;//추가해서
            }

            return count;//반환
        }
    }

    /// <summary>
    /// 생성자
    /// </summary>
    public Node() 
    {
        Data = default(T);
        Parent = null;
        Children = new List<Node<T>>();
        
    }

    public Node(T newData)
    {
        Data = newData;
        Parent = null;
        Children = new List<Node<T>>();
    }

    /// <summary>
    /// 자식 노드 추가 함수
    /// </summary>
    /// <param name="data">T 데이터</param>
    public void AddChild(T data)
    { 
        //전달 받은 데이터를 갖는 새로운 노드 생성
        Node<T> newChild = new Node<T>(data);

        //자식 목록에 새 노드 추가
        Children.Add(newChild);

        //나를 부모로 지정
        newChild.Parent = this;
    }

    /// <summary>
    /// 자식 노드 추가 함수2
    /// </summary>
    /// <param name="child"></param>
    public void AddChild(Node<T> child)
    {
        //자식 목록에 새 노드 추가
        Children.Add(child);

        child.Parent = this;
    }

    /// <summary>
    /// 노드 삭제 함수
    /// 컨셉마다 다름 :(부모폴더 지우면 하위폴더 다 날림), 살리는 경우도 있음
    /// </summary>
    public void Destroy()
    {
        //부모접근
        if (Parent != null)
        {
            Parent.Children.Remove(this);//List에서 나를 제거
        }

        /* 안해도 됨
        //부모 링크 제거
        Parent = null;

        //자식 배열 초기화
        Children = new List<Node<T>>();
        */
        //참조 입장에서 같은 객체인지 알 수 있는 방법?
        //Equals() -> 주소 값 비교 (고유 아이디가 존재)
    }
}

// 경우에 따라서
// struct class로 묶임  = 기능
// 구분해서 쓰자고 약속한 것. 차이는 없음
// 생산성 내는데 있어서 규칙임