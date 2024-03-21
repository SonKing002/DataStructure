namespace _9_Tree
{
    internal class Program
    {
        static void PrintNdoe<T>(Node<T> node)
        {
            Console.WriteLine($"{node.Data}");
        }

        static void Main(string[] args)
        {
            //트리 생성 
            Tree<string> tree = new Tree<string>("A"); //부모

            //자손 추가
            tree.AddChild("B");
            tree.Children[0].AddChild("E");
            tree.Children[0].AddChild("F");
            tree.Children[0].AddChild("G");

            Console.WriteLine(" -전위 순회 ");
            tree.PreorderTraverse(node => //콜백 함수의 길이가 길어지면, 오버헤드가 아니니, 함수 호출이 맞다
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{node.Data}");
                Console.ForegroundColor = ConsoleColor.White;
            });
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"트리 노드의 수 : {tree.Count}");//A
            Console.WriteLine($"트리 노드의 수 : {tree.Children[0].Count}");//B
            Console.WriteLine($"트리 노드의 수 : {tree.Children[0].Children[0].Count}");//E
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine(" -후위 순회 ");
            tree.PostorderTraverse(node => //콜백 함수의 길이가 길어지면, 오버헤드가 아니니, 함수 호출이 맞다
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{node.Data}");
                Console.ForegroundColor = ConsoleColor.White;
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"트리 노드의 수 : {tree.Count}");//A
            Console.WriteLine($"트리 노드의 수 : {tree.Children[0].Count}");//B
            Console.WriteLine($"트리 노드의 수 : {tree.Children[0].Children[0].Count}");//E
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

        }
    }
}
#region tree 거꾸로 매달음
/* 트리 구조 > 간단하게도 짤 수 있음 일반적으로 다중 트리
 
ex 기본 메커니즘 (트리)

   회사의 조직도
   Unity : 하이어라키 해당하는 계층 구조를 보여줌
   파일 탐색창 : 폴더 - 폴더 - 폴더 계층 구조
   바둑 인공지능의 결정 트리
   
   체스, 장기 게임 (AI 붙여놓으면 : 트리구조로 의사결정을 심어줘야 한다)
 
 * 검색한다면, 다중 트리를 사용 ( 구현은 복잡 )
 * 
 * 각각의 서브트리로 분기되어 있다
 * Node Class 내부 데이터 슬롯 단위 정의
 * 단말 노드 : 최하위의 파생된 노드
 * Sibling 형제 노드 = 같은 계층 레벨의 노드
 * 자식 노드 : 파생 노드
 * 
 * 전위 순회 :부모 - 왼쪽 자식1 -왼쪽 자식1-1 - 단말노드1-1-1    
 * 중위 순회 : 왼쪽 단말노드 - 왼쪽 자식 - 오른쪽 단말 노드 - 왼쪽 부모 -오른쪽 부모의 단말노드
 * 후위 순회 :
 */

/*
 * 이진 트리
 * parent Null 인지 
 * 아니면 node 부모 자식 구분
 * 
 * 이진 검색 : 반복해서 절반 잘라 범위 나눠서 찾아들어감
 * (정렬된 상태여야 한다)
 * 1. 소팅
 * 2. 이진 검색
 * 최악의 경우에도 확률 줄이기에 빠르다. ex. 업다운 게임
 * 
 * 릭이 남을 가능성이 있음
 * 하단에서부터 배열을 날려줘야 한다. (Destroy)구현 호출을 해준다.
 * 
 * 뿌리 노드 하나는 무조건 생성
 * 부모 지정 기본값은 널 (널이라면, 루트/부모노드)
 * AddChild 오버로드 데이터/ 노드 넣기
 * 이진 트리 3가지
 * Preorder(전위) : 미리 (부모)를 탐색하는 것 : 부모 왼쪽 오른쪽
 * 중위 : 부모를 중간에 둔다. : 왼쪽 부모 오른쪽
 * 후위 : 무보를 오른 쪽에 둔다. : 왼쪽 오른쪽 부모
 */

//재귀는 성능이 루프보다 좋지 않다. 종료조건을 먼저 작성하고 시작하길 권장
//하지만 쉽다. 병목이 걸리면, 루프로 바꾸는 시도를 할것
//지역변수가 쌓여서 stackOverFlow가 일어난다.

//Action Func 

/*디버그 : 메인 함수 - A호출 - B호출 ... -D
 * 
 * 처음 메인 함수를 찍어보고
 * 함수 타고  A - B - C - D  순차적으로 범위를 좁혀서 디버깅을 하는 것 
 */

//와인딩//스택 관리하는 방법들
//유니티는 콜스택을 볼 수 없다.

//private 함 저장하고 외부에서 참조하고 쓰는 것이 좋다.

//스택을 많이 쓰면, 하나밖에 프로그램을 돌릴 수 없다. 할당 요구하는 것

//리펙터링 일단 동작하는 프로그램을 만들고, 중복을 발견하면 -> 추상화
//모든 관리 툴 마찬가지로, Merge
#endregion
#region 이진 트리
/*
 * 좌우 대칭으로 완벽하게 균형이 모두 잘 채워져 있는 트리 = 포화상태
 
 * 상황에 따라서, 한쪽이 쏠리는 현상이 있을 수 있다. = 망함, 불균형 트리
 * 왼쪽, 오른쪽 선택에 따라 방향을 가는 것인데 배열과 같아지는 문제가 있을 수 있음

 */

/*중위 순회는 자식을 알 수 없으므로 중간 기점을 파악할 수 없다.
 * 
 */

/* 전위는 부모를 먼저 처리
 * 후위는 부모가 나중에 처리됨 : 수식 만들 때, 사용함
 * 용량 계산, 에셋 갯수,
 */

#endregion