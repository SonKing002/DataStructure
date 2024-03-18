using System;
public class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();

        for (int ix = 0; ix < 10; ix++) 
        {
            list.Add(ix + 1);
        }

        list.RemoveAt(5);//6번째 값 제거

        //출력
        for (int ix = 0; ix < list.Size; ix++)
        {
            Console.WriteLine(list[ix]);
        }

        //크기값 출력
        Console.WriteLine($"Size : {list.Size} | Capacity : {list.Capacity}");

        Console.ReadKey();

        foreach (int ix in list)
        { 
            //foreach 문을 사용한다면, 
            //Enumerator 필요, Movenext를 정의 : false를 만나면 loop가 끝남
        }
    }
}

/* 팁
 * 
 * VS 인텔리센스 : Ctrl + .  또는 Alt + Enter 
 * Ctrl - 전 화면으로 롤백
 * F12 정의 부분으로 넘어가기
 * Ctrl + Shift + A : 추가
 */

/*
 * 검색하는 일이 잦아짐에 따라 
 * HashTable Tree
 * 비선형 자료구조가 나왔다.
 * 보통 defaultCapacity = 4 매직넘버로 지정되어있다.
 * 복사 가능하면 Copy 아니면 순회
 * 
 */

/* For  Foreach 성능 차이
 * For문은 초기식 조건식 증감식 내용을 세팅해야한다. 불가피하면 사용
 * Foreach는 Enumerator만 있으면 돌릴 수 있다. (서버, DB 관리 접근 가능성) - 공간의 이점 
 * foreach는 Boxing Unboxing 가능성이 있다 - 거의 차이는 없다. (연산이 쌓이면 느려지기 때문)
 */