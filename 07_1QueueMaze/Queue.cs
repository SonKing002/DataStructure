using System;
using System.Reflection.Metadata;

/// <summary>
/// 큐(Queue) 자료구조 클래스 
/// 컨테이너 -> Enumerator
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T>
{
    /// <summary>
    /// 큐에서 사용할 데이터 컨테이너
    /// </summary>
    private T[] _data = null;

    /// <summary>
    /// 데이터를 추출할 때의 위치(앞)
    /// </summary>
    private int _front = 0;
    /// <summary>
    /// 데이터를 추출할 때의 위치(뒤)
    /// </summary>
    private int _rear = 0;

    /// <summary>
    /// 큐 컨테이너의 기본 크기 - 큐 생성시 크기를 지정하지 않은 경우 사용
    /// </summary>
    private const int _defaultCapacity = 100;

    /// <summary>
    /// 큐 저장소의 크기용량
    /// </summary>
    private int _capacity = 0;

    /// <summary>
    /// 큐에 저장된 요소의 갯수
    /// </summary>
    private int _size = 0;

    /// <summary>
    /// 큐에 저장된 요소의 갯수를 반환하는 프로퍼티
    /// </summary>
    public int Size { get { return _size; } }

    /// <summary>
    /// 큐가 비었는지 확인하는 프로퍼티
    /// </summary>
    public bool IsEmpty { get { return _front == _rear; } }

    /// <summary>
    /// 큐가 가득찼는지 확인하는 프로퍼티
    /// </summary>
    public bool IsFull { get { return ((_rear + 1) % _capacity) == _front; } }

    /// <summary>
    /// 기본 생성자
    /// </summary>
    public Queue()
    {
        // Todo : 완료 (리셋 함수 작성해서 호출해야함)
        Reset();

    }

    /// <summary>
    /// 크기를 지정하는 생성자
    /// </summary>
    /// <param name="newCapacity"></param>
    public Queue(int newCapacity)
    {
        _capacity = newCapacity;
        Reset();
        // Todo : 완료 (리셋 함수 작성했으면 여기에 호출해야 함)
    }

    /// <summary>
    /// 큐에 데이터를 추가하는 함수
    /// </summary>
    /// <param name="value">큐에 뒤Rear에 추가할 value </param>
    /// <returns></returns>
    public bool Enqueue(T value)
    {
        //예외처리
        if (IsFull)
        {
            Console.WriteLine("ERROR : 큐가 가득 차 있어 데이터를 추가하지 못했습니다. ");
            return false;
        }

        //데이터 삽입 위치를 구한 뒤 데이터 삽입
        _rear = (_rear + 1) % _capacity;
        _data[_rear] = value;

        return true;
    }

    /// <summary>
    /// 큐에서 앞에 있는 데이터를 추출하는 함수
    /// </summary>
    /// <param name="outValue">참조형 ref는 참조전달용. out은 출력용</param>
    /// <returns></returns>
    public bool Dequeue(ref T outValue)
    {
        //예외처리 : 큐가 비어있는지 확인
        if (IsEmpty)
        {
            Console.WriteLine("ERROR : 큐가 비어있어 추출할 데이터가 없습니다.");
            return false;
        }

        //데이터를 추출할 위치(front)를 구한 뒤 데이터 추출
        _front = (_front + 1) % _capacity;
        outValue = _data[_front];

        return true;
    }

    /// <summary>
    /// 큐에 저장된 데이터 출력
    /// </summary>
    public void Print()
    {
        if (IsEmpty)
        {
            Console.WriteLine("ERROR : 큐가 비어있어서 출력할 데이터가 없습니다.");
            return;
        }

        Console.Write("\n 큐내용 : \n");

        int _max = (_front < _rear) ? _rear : _rear + _capacity;

        for (int ix = 0; ix < _max; ix++)
        {
            Console.Write($"{_data[ix % _capacity]} ");
        }
    }


    /// <summary>
    /// 리셋 함수
    /// </summary>
    private void Reset()
    {
        //용량이 비었으면 크기값 조정
        _capacity = _capacity == 0 ? _defaultCapacity : _capacity;

        //저장소 새로 생성
        _data = new T[_capacity];

        //변수 초기화
        _size = 0;
        _front = 0;
        _rear = 0;
    }
}

#region
/*Queue
 * 
 * First In First Out (FiFO)
 * 수평으로 
 * 너비우선 탐색( BFS ) : 주변 전방향으로 넓혀감 (느림)
 * 사용자 입력처리 + 네트워크 버퍼 : 순서 목록을 Queue 목록에 넣고 처리
 * 
 * 명세서
 * CreateQueue : 생성
 * Enqueue : 맨 뒤 삽입
 * Dequeue : 맨 앞 삭제
 * Peek : 확인만 하기 (삭제x)
 * Size (cpp) == Count == Length : 갯수를 반환
 * IsEmpty
 * IsFull
 */

/* Queue<T> 제네릭 생각해야하는 것
  
 * CreateQueue(5)
 * Enqueue(3)
 * Enqueue(7)
 * Enqueue(6)
 * Enqueue(6)
 * Enqueue(6)
 * //가득 참 Enqueue(6)
 
 * CreateQueue(5)
 * Enqueue(6)
 * Enqueue(4)
 * Enqueue(2)
 * Dequeue(0)
 * //빈 공간 땡겨줘야 함
 
 */

/* 공간의 재활용
 
 * 배열 크기 5 (0~4)
 * rear 0
 * Enqueue -> 0 index
 * rear 4
 * Enqueue -> 4 index
 
 * 5 -> 0 돌리는 방법?
 * 9 -> 4 만드는 방법?
 
 * 나누기할 때: 몫 ... 나머지
 * 9 / 4 = 2...1
 * 나머지연산 % 을 이용한다.
 * 전광판 Loop 하는 것도 같은 로직이다.
 
ex 모듈러 연산 예시
 * 글자 = 폰트 
 * 그림으로 표현 (0 ~ 9)
 * 
 * 3843 을 자릿수로 나눈 몫 = 1000 값 3
 * 843 자릿수로 나눈 몫 = 100 값 8
 * 43 자릿수로 나눈 몫 = 10 값 4
 * 3 자릿수로 나눈 몫 = 1값 3
 * 이미지 사용
 
 *  원형 큐 : 한칸을 비워둬야 한다.
 *  상태 비교해야하기 때문이다.
 
-따라다니는 경우 (덮어쓰기가 되어버림)
 *  front 같은 곳을 가리키면 비어있음 
 *  한칸 뒤에 이어서 rear라면 가득참 (rear + 1) % capacity == front
 *  
 *  Grow()
 
 *  rear = (rear +1) % capacity;
 *  
 *  front = (front +1) % capacity; // 끝 도착하면 다시 앞으로 가야하므로 0123...front-1 나누었고, 다음 위치이기 때문에 +1
 *  
 *  일반적으로 rear > front 이다.
 *  int max = (front < rear) ? rear : rear + capacity;
 *  for (int i = front + 1 ; i < max; i++)
 *  {
 *     
 *  }
 */

/*C# 컨테이너 Enumerator가 들어있다.
 * 정렬 알고리즘도 잘 구현되어있다.
 * 근데 트리가 없다.
 */

//상수화 : const(컴파일때) //Readonly (런타임 때)
/*
 * 선언시에 초기화해야한다 =const 컴파일 타임에 결정
 * Readonly 생성자에서 바꿀 수 있다 (외부의 파라미터 자유도) = 런타임 타임에 결정
 */

/*
 * out 키워드 : 함수 안에서 반드시 초기화 되어야 한다. //출력용
 * ref 키워드 : 함수 호출 전에 초기화 되어야 한다. //참조 전달을 위함
 */
#endregion