using System;

/// <summary>
/// 더블 연결 리스트 : 데이터 필드와 이전/다음 노드를 가리킬 수 있는 링크 필드를 지원하는 리스트
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedList<T>
{
    /// <summary>
    /// 노드 클래스에 대한 정의
    /// </summary>
    public class Node
    {
        public T data;               //데이터 필드
        public Node next = null;     //다음 노드를 가리키는 링크 필드
        public Node previous = null; //이전 노드를 가리키는 링크 필드

        /// <summary>
        /// 기본생성자 모든 값 초기화
        /// </summary>
        public Node()
        {
            data = default(T);
            next = null;
            previous = null;
        }

        /// <summary>
        /// 전달 받은 데이터를 데이터 필드에 저장하는 생성자
        /// </summary>
        /// <param name="newData">전달 받은 데이터</param>
        public Node(T newData)
        {
            data = newData;
            next = null;
            previous = null;
        }
    }//노드 클래스 정의

    /// <summary>
    /// 연결 리스트의 시작 노드
    /// </summary>
    private Node _first = null;

    /// <summary>
    /// 연결 리스트의 마지막 노드
    /// </summary>
    private Node _last = null;

    /// <summary>
    /// 연결 리스트에 저장된 요소의 수
    /// </summary>
    private int _count = 0;

    /// <summary>
    /// 리스트가 비어있는지 확인하는 프로퍼티 count 0일때 true
    /// </summary>
    public bool IsEmpty { get { return _count == 0; } }

    /// <summary>
    /// 첫번째 노드가 가진 데이터를 반환하는 프로퍼티
    /// </summary>
    public T First
    {
        get
        {
            if (IsEmpty)
            {
                Console.WriteLine("ERROR : 리스트가 비어있음");
                return default(T);
            }
            return _first.next.data;
        }
    }

    /// <summary>
    /// 마지막 노드가 가진 데이터를 반환하는 프로퍼티
    /// </summary>
    public T Last
    {
        get 
        {
            if (IsEmpty)
            {
                Console.WriteLine("ERROR : 라스트가 비어있음");
                return default(T);
            }
            return _last.previous.data;
        }
    }

    /// <summary>
    /// 생성자.
    /// </summary>
    public LinkedList()
    {
        //시작-끝 노드를 생성
        _first = new Node();
        _last = new Node();

        //시작-끝 노드를 서로 연결
        _first.next = _last;
        _last.previous = _first;

        //값 초기화
        _count = 0;
    }


    /// <summary>
    /// 리셋함수
    /// </summary>
    public void Clear()
    {
        _first.next = _last;
        _first.previous = null;//연결하지 않음

        _last.next = _first;
        _last.next = null;//연결하지 않음

        _count = 0;
    }

    /// <summary>
    /// 노드 추가함수 (메인)
    /// </summary>
    /// <param name="newData">넣어줄 T 새 데이터</param>
    public void Insert(T newData)//PushLast
    {
        //전달받은 데이터를 가지는 새로운 노드를 생성하고,
        Node newNode = new Node(newData);

        //리스트의 포인터를 설정
        //last.previous 공간에 -> next 참조할 것
        //previous <- newNode ->next  중간에 newNode 가 삽입
        //previous <- last
        _last.previous.next = newNode;
        newNode.previous = _last.previous;

        newNode.next = _last;
        _last.previous = newNode;

        _count++;
    }
    // Todo: 완료 (PushFirst 함수 작성해보기)
    public void PushFirst(T newData)
    {
        Node tempNode = new Node(newData);

        //tempNode - first.next
        _first.next.previous = tempNode;
        tempNode.next = _first.next;//반대 방향도 연결

        //first - tempNode
        tempNode.previous = _first;
        _first.next = tempNode;

        _count++;
    }

    /// <summary>
    /// 지정한 데이터를 가진 노드 삭제 함수 (메인) 
    /// </summary>
    /// <param name="deleteData"></param>
    /// <returns></returns>
    public bool Delete(T deleteData)
    {
        //Boolean 사람 이름 : 불린
        if (IsEmpty)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR : 리스트가 비어서 삭제 실패");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        //삭제 대상 노드 : 처음부터
        Node deleteNode = _first.next;

        //순방향 검색
        while(deleteNode != _last && deleteNode != null)
        {
            //Equals : 같은지
            if (deleteNode.data.Equals(deleteData))
            {
                break;
            }

            //그 다음 노드로 이동
            deleteNode = deleteNode.next;
        }//루프 끝남

        //경우 1. 검색 성공
        if (deleteNode != null && deleteNode != _last)// null아닌 경우와 마지막이 아닌 경우
        {
            //포인터 연산 처리 
            deleteNode.previous.next = deleteNode.next; 
            deleteNode.next.previous = deleteNode.previous;

            _count--;
            return true;
        }
        //경우 2. 검색 실패
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR : 삭제하려는 데이터를 찾지 못함");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }
    // 자료 출력 함수 (메인)
    public void Print()
    {
        Node current = _first.next;
        while(current != null && current != _last)
        {
            Console.Write($"{current.data} ");
            current = current.next;
        }

        Console.WriteLine();
    }
    // 첫 번째 노드 삭제 함수 (읽고 날려버림)

    // 마지막 노드 삭제 함수

    //System.Collections.Generic.LinkedList<>
}
#region
/* 기본
 *C# 작성 규칙 : 구조체 -> 변수 -> 함수 순서 작성 
 *cpp는 함수를 위로 변수 데이터를 아래로 
 */

/* 이슈 : 필요할 때 선언하자
 * 
 * 
 */
#endregion

