using System;
using System.ComponentModel;
using System.Linq.Expressions;

public static class Contants
{
    
    public static string duplicateMessage = "Error : 이미 중복된 값이 있어, 데이터를 추가하지 못했습니다.";
}

/// <summary>
/// 바이너리 검색 트리
/// </summary>
public class BinarySearchTree
{
    /// <summary>
    /// 루트
    /// </summary>
    private Node Root { get; set; } = null;//프로퍼티 성능 이슈도 옛말

    /// <summary>
    /// 기본 생성자
    /// </summary>
    public BinarySearchTree()
    {
        //생성이 아닌 널 : 보통 생성하지 않는 점이 다르다.
        Root = null;
    }

    //첫 추가되는 자료가 크기비교 기준이 되는 Root가 된다.

    // 삽입
    /*
     * 0. 선 조건 : 중복된 값은 허용하지 않음
     
     * 1. 시작 : 루트 비교 >
     *      루트가 비어있으면 새 노드를 루트로 지정한다
    
     * 2. 자식 비교 >
     *      새로 추가하는 값 < 비교하는 노드
     *         지정: 왼쪽 서브트리  == 하위 비교 기준
     *      새로 추가하는 값 > 비교하는 노드
     *         지정: 오른쪽 서브트리 == 하위 비교 기준
     */

    public bool InsertNode(int newData)
    {
        // Todo : 검색 함수 작성해서 이 곳으로 호출
        if (SearchNode(newData) == true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Contants.duplicateMessage);
            Console.ForegroundColor = ConsoleColor.White;
            
            return false;
        }

        // 중복 검사 
        // root 가 null인 경우
        if (Root == null)
        {
            Root = new Node(newData);
            return true;
        }

        // Todo : 2와 3의 경우를 위해 재귀 함수 작성 후 이 곳으로 호출
        Root = InsertNodeRecursive(Root, null, newData);

        // Todo : 코드 재작성 필요
        return true;
    }
    /// <summary>
    /// 재귀적으로 삽입을 처리하는 함수
    /// </summary>
    /// <param name="node">현재의 노드</param>
    /// <param name="parent"> 현재 노드의 부모 노드</param>
    /// <param name="newData">삽입하려는 데이터</param>
    /// <returns></returns>
    private Node InsertNodeRecursive(Node node, Node parent, int newData)
    {
        //node가 null이면 마지막 노드있는지 판별용: 새로 생성 후 생성한 노드를 반환 = 할당할 수 있게Node
        if (node == null)
        {
            Node newNode = new Node(newData);

            //새 노드의 부모 노드 지정
            newNode.Parent = parent;

            //노드 반환 
            return newNode;
        }

        //추가할 데이터 값을 비교
        //같은 경우는 이미 앞에서 처리

        if (node.Data > newData)
        {//추가하려는 노드가 작은 값 :왼쪽 탐색
            node.Left = InsertNodeRecursive(node.Left, node, newData);
        }
        else
        { //추가하려는 노드가 큰 값 :오른 쪽 탐색
            node.Right = InsertNodeRecursive(node.Right, node, newData);
        }

        return node;
    }

    // 삭제
    /* 개념설명
     *  ex >
     *              #30
     *       20           *35
     *   10     25             45
     *  1 15  23  27
     *   자식이 없는 경우 > 
     *   null 문제 없음
     *   
     *   자식 계층에 하나만 있는 경우 >
     *   35를 지우면, 30 - 45 연결고리가 필요
     *   부모 계층과 자식 계층을 (자리바꿈) 회전 한 다음
     *   
     *   왼쪽 자식은     -오른쪽회전
     *   오른쪽 자식은   -좌회전
     *   
     *   자식 계층에 값이 두개 있는 경우 >
     *   상황 1. 작은노드를 찾아서 : 이진 검색 트리 부모로 올라가야 하는 숫자를 결정해주고 + 회전
     *   상황 2. 예외 : 그냥 무엇을 넣어도 규칙이 깨지지 않는다. 
     *   
     *   자식-자식-자식... n계층 구조 경우 >
     *   재귀 호출해서 자식 빈공간을 채운다.
     *   오른 쪽 기준으로 재정렬해서 채워나간다. (왼쪽은 당연 최소값이기 때문)
     */
    public void DeleteNode(int deleteData)
    {
        //재귀로 삭제하는 함수를 호출
        //삭제 연산의 시작은 Root 노드
        Root = DeleteNodeRecursive(Root, deleteData);
    }
    /// <summary>
    /// 삭제 재귀함수
    /// </summary>
    /// <param name="node">현재 검색되는 노드</param>
    /// <param name="deleteData">삭제할 데이터</param>
    /// <returns></returns>
    private Node DeleteNodeRecursive(Node node, int deleteData)
    {
        //종료 조건 : 찾을 노드가 존재하지 않아서, 재귀루프 끝에 null까지 온 경우
        if (node == null)//node가 최하위의 자식이지만, 더이상 존재하지 않기 때문에 반환
        {
            return null;
        }

        //내려갈 자식으로 탐색 : 부모랑 바꾸는 작업


        if (deleteData > node.Data ) //삭제하려는 데이터 > 비교 데이터
        {
            node.Right = DeleteNodeRecursive(node.Right, deleteData);
        }
        else if (deleteData < node.Data  ) //삭제하려는 데이터 < 비교 데이터
        {
            node.Left = DeleteNodeRecursive(node.Left, deleteData);
        }
        else //삭제하려는 데이터 == 비교 데이터 : 찾음
        {
            if (node.Left == null && node.Right == null) // 양팔 둘다 없는 경우
            {
                //node.Parent.Left = null;//왼쪽
                return null;//오른쪽
            }

            if (node.Left != null && node.Right != null) // 양팔 있는 경우
            {
                //삭제되는 노드의 오른쪽 서브 트리에서
                //가장 작은 값을 검색해서 삭제하는 노드의 값을 업데이트
                node.Data = SearchMinValue(node.Right).Data;

                //위에서 구한 오른쪽 서브 트리에서 가장 작은 값을 가진 노드를 삭제
                node.Right = DeleteNodeRecursive(node.Right, node.Data);
            }
            else
            {
                //외팔인 경우
                if (node.Left == null)//오른팔로 노드 반환
                {
                    return node.Right;
                }
                else if (node.Right == null)//왼팔로 노드 반환
                {
                    return node.Left;
                }
            }

        }

        return node;


    }

    /// <summary>
    /// 최소값 검색 함수
    /// </summary>
    /// <param name="node">검색 대상 노드</param>
    /// <returns></returns>
    private Node SearchMinValue(Node node)
    {
        //왼쪽 자식 탐색
        while (node.Left != null)
        {
            //더 작은 node
            node = node.Left;
        }
        //해당 노드가 MinValue
        return node;
    }

    /// <summary>
    /// 검색
    /// </summary>
    /// <param name="data">찾을 데이터</param>
    /// <returns></returns>
    public bool SearchNode(int data)
    {
        //루트부터 재귀적으로 검색을 진행
        return SearchNodeRecursive(Root, data);
    }

    /// <summary>
    /// node 따라서 재귀함수
    /// 외부에 함수 존재를 알릴 필요없음 (사용자는 데이터 존재여부만 알고 싶음)
    /// </summary>
    /// <param name="node">검색 대상 노드</param>
    /// <param name="data">찾을 데이터</param>
    /// <returns></returns>
    private bool SearchNodeRecursive(Node node, int data)
    {
        //node가 존재하지 않으면 재귀 끝 : 선 조건이 보장되어야한다.
        if (node == null)
        {
            return false;//중첩으로 가독성을 해치는 경우를 방지하지 위함
        }

        //Node == 존재확인

        // 1. 같은 경우 : 해당 계층의 Node 찾음 (비교기준)
        if (node.Data.Equals(data) == true)
        {
            Console.WriteLine($" 찾은 값 : {data}");
            return true;
        }

        // 2. 작은 경우 : 왼쪽
        if (node.Data > data)
        {
            //쭉 들어감
            return SearchNodeRecursive(node.Left, data);
        }
        // 3. 큰 경우 : 오른쪽 
        else //if(node.Data < data) 일부 값 : 예외처리하는 것도 방법
        {
            return SearchNodeRecursive(node.Right, data);
        }
    }
    // 출력
    /*
     * 전위로 출력하면 30 10 20 40 50
     * 후위로 출력하면 30 50 40 20 10
     * 정렬된 것 -> 그래서 중위 10 20 30 40 50 로 한다.
     */
    /// <summary>
    /// 출력하는 함수
    /// </summary>
    public void InorderTraverse()
    {
        //출력을 위해 중위 순회 방식을 재귀 함수 호출
        //탐색 시작은 루트 노드 부터
        InorderTraverseRecursive(Root);
    }
    /// <summary>
    /// 출력을 위해 재귀하는 함수
    /// </summary>
    /// <param name="node">비교대상 node</param>
    private void InorderTraverseRecursive(Node node)
    {
        if (node == null)
        {
            return;//
        }

        //왼쪽 서브 트리
        InorderTraverseRecursive(node.Left);

        //출력할 노드 
        Console.Write($"{node.Data} "); //부모 노드

        //오른쪽 서브 트리
        InorderTraverseRecursive(node.Right);
    }
}

/* 구현
 
    // 삽입
    // 삭제
    // 검색
    // 출력
 */

/*
 * ECMA 국가 표준 : 윈도우 플랫폼과 자바
 * 
 * MS 표준을 하려면 구조를 공개해라 : .NET 은 표준을 받음
CLR에 대한 자료를 볼 수 있는데 규모가 크다..
 * 제프리 리처 - CLR via C# (김명신) 책에 위 내용을 요약한 내용이 기술되어있음
 */

/*
 * VB 메크로 시장 가치가 높음 
 * -> 테팔 글로벌 기업 등에서 엑셀 기반 작업함 (엑셀에서 돌릴 프로그램은 각 기업에서 지엽적이라 구매할 수 없다)
 *
 */

/*ZoomIt 프로그램 (화면에 낙서할 수 있는 프로그램)
 
 * MS에서 말단사원부터 모두가 사업 제안할 수 있음
 * 가비지 프로젝트 : 현실 돈이 안되는 쓸데없는 프로젝트중 하나
 
 */
