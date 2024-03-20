using System;
public class Program
{
    /// <summary>
    /// 난수 발생 객체 생성
    /// </summary>
    static Random random = new Random();

    /// <summary>
    /// 범위를 지정해서 난수를  발생시키는 함수 
    /// </summary>
    /// <param name="min">최솟값</param>
    /// <param name="max">최댓값</param>
    /// <returns></returns>
    static float GetRandomInRange(float min, float max)
    { 
        // 시간 1000ms / systemclock cpu 10억 가지수 중에 뽑기 

        //0.0에서 1.0 사이의 난수를 생성한 뒤, min - max 범위로 지정
        float randomNumber = random.NextSingle();

        //범위 뻥튀기
        randomNumber *= (max - min);//
        randomNumber += min;        //최소 범위

        //음영 판단을 내적으로 한다.
        //A 내적 B = A * B * cos 라디안 각도

        //노멀값 : 노멀 맵을 택스쳐로 구워서 하이폴처럼 보이게 한다.
        //범위(distance) 방향(내적) 방해물(레이케스트)
        //cos 10-10
        //Sin 010-10  -1 ~ 0 ~ 1 

        //생성한 난수 변환
        return randomNumber;
    }

    static void Main(string[] args)
    {
        //큐 객체 생성
        Queue<float> queue = new Queue<float>();

        
        //난수 데이터 삽입
        for (int ix = 0; ix < 10; ix++)
        {
            queue.Enqueue(GetRandomInRange(100f, 150f));
        }

        //큐 데이터 출력
        queue.Print();

        //큐 데이터를 받을 변수 선언 
        float outValue = 0f;
        
        //out 은 함수 안에서 초기화하기 떄문에, 초기화 하지 않아도 됨
        //ref 는 이 곳에서 최적화해야 넘길 수 있다.

        // 큐에서 데이터 추출
        Console.Write("\n 큐에서 추출된 데이터 : \n");
        for (int ix = 0; ix < 20; ix++)
        {
            if (queue.Dequeue(ref outValue))//성공
            { 
                Console.Write($"{outValue} ");
            }
        }

        //남은 큐 데이터 출력
        queue.Print();

        Console.ReadKey();


    }
}

#region
/*
 * key를 기준으로 value를 뽑아 낼 수 있도록 함
 * key값이 고유하게 1개만 존재해야 한다.
 * GUI 겹치는 값이 없다.
 
 */

/*hash function 알아보지 못하도록 뭉개기 (해쉬브라운 = 으깬감자)
 * key를 넣으면, 항상 같은 bucket으로 바꿔준다.
 * bucket으로 key를 바꿀 수 없다.
 
 * DB는 헤시 펑션같은 걸로 수치를 바꿔서, 알아보기 힘든 문자로 만들어준다.
 * DB 업체도 몰라서 반대로 우리에게 알려줄 방법이 없다.
 
 * DB업체는 bucket을 암호화해서 저장한다.
 * 똑같은 hash key -> 넣으면 같은 bucket 값이 나와야한다. (데이터를 묶는 과정을 해싱)
 * 해쉬충돌이 일어날 수 있다. 
 *  - 오픈 어드레싱 
 *  - 체이닝 : 이어서 저장한다. 배열 하나당 리스트가 존재.
-> 하다가 문제충돌을 일어나서 체이닝을 하면 On 순차검색을 한다.
->레드블랙트리를 사용한다.

 * 빠른 탐색, 삽입, 삭제 속도를 가지기 때문에 여러 항목 간의 관계를 저장하는데 유용하게 사용됨
 * 
 * 자료를 저장하는 공간을 버킷 (테이블) 의 크기는 소수(Prime Number)로 하는 것이 좋다.
 * 모듈러를 사용하는데, 다른 수와 충돌할 확률이 줄어드는 것. (권장 31)
 */

/* 자료구조 /알고리즘 P vs NP 문제
 
세계 7대 수학 난제

밀레니엄 문제
 * P_NP 문제 : hash function 뭉갠 것을 복구 시킬 수 있다면, 암호 체계가 모두 깨짐
 * 호지 추측 
 * 
 * 
 */
/* buckets
 * 
 * 
 */
#endregion

