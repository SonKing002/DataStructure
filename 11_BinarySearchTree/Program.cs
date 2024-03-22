public class Program
{
    static void Main(string[] args)
    {
        //BST 생성
        BinarySearchTree tree = new BinarySearchTree();//빈 객체

        tree.InsertNode(67);
        tree.InsertNode(20);
        tree.InsertNode(5);
        tree.InsertNode(50);
        tree.InsertNode(23);
        tree.InsertNode(15);

        tree.InsertNode(50);//중복 여부

        //중위 순회 방식으로 트리요소 출력
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("트리 순회 결과");
        tree.InorderTraverse();

        Console.ReadKey();
        Console.WriteLine();

        if (tree.SearchNode(40) == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"트리에 {40} 값이 존재합니다");
        }
        else
        { 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"트리에 {40} 값이 없습니다");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();

        Console.WriteLine("\n삭제");
        int keyDelete = 50;

        Console.Write($"삭제할 노드 : {keyDelete}");
        tree.DeleteNode(keyDelete);


        Console.WriteLine();
        Console.WriteLine("트리 순회 결과");
        
        tree.InorderTraverse();
        Console.ReadKey();

    }
}

/* 이진 탐색/검색 트리  BST : BinarySearchTree
 * 균형이 맞으면  -> 빠르다. 
 *
 * 삽입은 : 재귀로 크기 비교 후 넣기
 * 삭제가 까다로움
 * 
 * 자가 균형화 기능 (모든 로드를 순회해야하는 단점)
 * AVL, Red Black Tree 검색 알고리즘 = (오라클) : 위 단점을 보완한 것(고난도, 성능이 우세)
*/

/* 성능 측정에 관한 이야기
 
 * 3가지 방법 : 최선, 평균, 최악
 * 개발은 앞으로 전진하는 게 먼저?
 

검은사막, 언리얼 조차 내부 코드를 보면 그렇다.
매직넘버 쓰지 말라는 것도 그렇다.
 * 지금 당장 성능이 안좋더라도 오늘 돌아가는 코드를 짜는 프로그램에
 * 시간 내서 성능개선을 하는 것이다.
 
 * 평균치를 오래 돌려서 평가한다.
 */


/*요청하는 구문은 따로 공부해야 함 
SQL
 * DB는 사용료를 지불하고 사용하는 것
 * SQL : Structual Query (요청) 
 * 무료 : MySQL -> 내분 MariaDB (유명)
 * SQLite : 임시로 DB를 복제를 뜸, 모바일 파일 기반의 SQL (서버로 DB 옮기기 포팅도 가능)
 * Redis : 인메모리 DB : 특정 시점 메모리를 요청할 때 있으면 올라가고 없으면 내려가고?

 * 유니티 내부적으로 PostgreSQL을 사용 (북유럽)
 
Json 
 * 파이어베이스 = 제이슨 기반 (최신 버전 버그 존재..)
 * 몽고DB (유명) 게임에서 많이 씀
 * 
 */

/* 1 솔루션 n 프로젝트
 
C#은 using 으로 dll만 들고오면 된다.
CPP는 헤더 명세를 알아야 한다.
 
 */