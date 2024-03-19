using System;
using System.Net;

public class LinkedList<T>
{
    #region 노드 클래스 구현
    /// <summary>
    /// 연결리스트가 저장할 노드 클래스
    /// </summary>
    class Node
    {
        /// <summary>
        /// 데이터 필드
        /// </summary>
        public T data;

        /// <summary>
        /// 링크 필드
        /// </summary>
        public Node next = null;

        /*기본생성자 주석 처리
        /// <summary>
        /// 기본 생성자 : 아무것도 없는 헤드
        /// </summary>
        public Node()
        {
            data = default(T);
            next = null;
        }*/

        /// <summary>
        /// 데이터를 집어넣는 경우 생성자
        /// </summary>
        /// <param name="newData"></param>
        public Node(T newData)
        {
            data = newData;
            next = null;
        }
    }
    #endregion

    /// <summary>
    /// 헤드 필드 : 편의 목적
    /// </summary>
    private Node head = null;

    /// <summary>
    /// 연결 리스트에 저장된 요소의 갯수 : (순회 n번하는 대신, 갯수만 알고 싶다면)
    /// </summary>
    private int count = 0;

    /// <summary>
    /// 노드 추가함수
    /// </summary>
    /// <param name="newData">전달받은 T 새 데이터</param>
    public void Insert(T newData)
    { 
        //새로 추가할 노드를 생성, 생성할 때 전달받은 데이터를 저장
        Node newNode = new Node(newData);

        //헤드 데이터를 쓰기 위해서, 분기
        
        if(head == null)//헤드가 빈 경우
        {
            head = newNode;
            count++;
            return;
        }

        //헤드가 비어있지 않은 경우.
        //preNode와 nextNode 연결
        Node current = head;
        Node trail = null;

        while(current != null) //next가 비어있을 때까지 순회
        {
            //현재 노드를 이전(꼬랑지) 노드에 저장
            trail = current;

            //현재 노드에는 그 다음 노드를 저장
            current = current.next;
        }
        //널인 경우 == 마지막 그 다음에
        trail.next = newNode; //추가
    }

    /// <summary>
    /// 노드 삭제함수 : 링크드 함수 (중복데이터 허용여부 컨셉에 따라 다르게 구현)
    /// </summary>
    /// <param name="deleteData"></param>
    public void DeleteNode(T deleteData)
    {
        //type1. 같은 값 :유일 값//

        //type2. 어느 위치 값 : 중복 값//
        /*
        //통으로 넘기기//제일 빠른 검색 값 넘기기
        //해당하는 중복 값 모두 삭제할 지, 해당 단일 값만 삭제할 지

        //검색 Hashtable , 특정시점 삽입 삭제LinkedList
        //GetInstanceId 고유아이디
        */

        #region Typ1의 경우의 수 4가지
        //1 > 빈 리스트일 때
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("리스트가 비어있어 삭제를 실패했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        // 데이터가 들어있다면
        //순회
        Node current = head;
        Node trail = null;

        while(current != null) 
        {
            //삭제할 노드를 찾는다
            if (current.data.Equals(deleteData) == true)
            {
                break;
            }

            //이어서 다음 노드 진행
            trail = current;
            current = current.next;

            //루프 진행이 끝나는 경우 : 1. 찾은 경우, 2. 못 찾은 경우
        }

        //2 > 찾았지만, 검색을 실패한 경우
        if (current == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[5_LinkedList] error : 값{deleteData}를 가진 노드를 찾지 못했습니다");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        //3 > 찾았지만, 삭제할 노드가 head인 경우
        if (current == head)
        {
            head = head.next;
            count--;
            return; 
        }
        //4 > 찾았지만, 삭제할 노드가 head가 아닌 경우
        trail.next = current.next;//Current 참조를 하지 않으므로, GC가 검토하고 삭제한다.
        count--;

        #endregion
    }

    /// <summary>
    /// 출력 함수
    /// </summary>
    public void Print()
    {
        //System.Collections.Generic.LinkedList<> 기본 기능만 설명한것 보완 개선된 List는 직접 정의 찾기
        Node current = head;
        while(current != null) 
        {
            Console.WriteLine($"{current.data} ");
            current = current.next;
        }
        Console.WriteLine();
    }

    //검색 함수

}

#region

/* Linked List 연결리스트 설명
 * 
 * Linked List : 연결리스트 (비선형 자료구조 해시테이블 공부할 때도 사용)
 * 넣고 빼는데 용이
 * 데이터를 노드라고 하는 곳에 분산하여 저장
 * 다음항목을 가르키는 주소도 함께 저장
 * 노드는 데이터 필드와 링크필드가 존재
    - 데이터 필드 : 리스트의 데이터를 저장
    - 링크 필드   : 다음 노드의 주소값을 저장(포인터)
 * 메모리 안에서 노드의 물리적 순서가 리스의 논리적 순서와 일치할 필요 없음
 * 넣고 뺴는 것이 편하다.
 * 검색이 느리다.
*/

/* 
 * 파편화가 심해서 기다리는 경우가 생기고, 간혹 할당이 늦는 현상이 발생
 * 
 * CreateList()
 * Insert(pos, item)
 * Delete(pos)
 * GetEntry(pos)
 * Find(item) 있는지 찾는 것 = 순차 탐색
 * Replace(pos, item) 새 요소로 바꾸기
 * Size() : 요소 개수
 * Display() : 출력
*/

//헤드가 List 빈 껍데기인 경우 = 바꿔치기
//링크 필드를 수정해서 추가하고 뺄 수 있다.
//시간 최적화 vs 공간 최적화 타협점이 필요하다.

/*GC 동작
 * 레퍼런스 사용 횟수 == count0 이 된 경우 삭제 
 * -> 이 기능이 재대로 작동되지 않으니 세대를 걸쳐서 검증 후 삭제
 * 힌번에 처리하지 않는다. GC.Collect(); 그러면 끊긴다.
 * 
 * 게임분야에서는 왕창 잡아놓고 해제하지 않는다. 언젠가 사용할 것까지 모두 잡아둔다. == 재사용을 최대한 한다.
 * 렉이 걸리면 안되기 때문이다.
 */
#endregion