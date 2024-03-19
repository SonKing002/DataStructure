using System;

public class Stack<T>
{
    /// <summary>
    /// 자료 저장의 자료형 : 배열, 리스트
    /// </summary>
    private T[] _data;

    /// <summary>
    /// 스택에 저장할 수 있는 최대 데이터 수
    /// </summary>
    private const int _maxCapacity = 100;

    /// <summary>
    /// 현재 스택에 저장된 데이터 수 
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// 스택이 비어있는지 확인하는 프로퍼티
    /// </summary>
    public bool IsEmpty { get { return Count == 0; } }//0 true 

    /// <summary>
    /// 기본 생성자
    /// </summary>
    public Stack()
    {
        //초기화
        Count = 0;
        _data = new T[_maxCapacity];
    }

    /// <summary>
    /// 크기를 전달 받은 생성자
    /// </summary>
    /// <param name="capacity">배열의 사이즈 </param>
    public Stack(int capacity)
    {
        Count = 0;
        _data = new T[capacity];
    }

    /// <summary>
    /// 전부 지우기
    /// </summary>
    public void Clear()
    {
        Count = 0;
    }

    /// <summary>
    /// 가득차면 실패할 수 있으므로 bool 반환형
    /// </summary>
    /// /// <param name="newData">T 새 데이터 정보 </param>

    public bool Push(T newData)
    {
        //새로운 데이터를 받아오기 전 가득 찼는지의 검수
        if (Count >= _data.Length)
        {
            return false;//추가 못하니까 false 반환
        }

        //데이터 추가후, Count ++ 
        _data[Count] = newData; //_data[Count++] = newData; 가독성 차이
        Count++;

        return true;//추가 성공 true 반환
    }

    /// <summary>
    /// 스택에서 저장된 데이터를 추출하는 Pop함수
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        //비었는지 확인하고,
        if (IsEmpty)
        { 
            return default(T);
        }

        //존재하면 해당 data 정보 반환
        Count--;

        return _data[Count];

        /* 참조 타입의 경우에는 문제가 일어날 수 있음
        T returnValue = _data[Count];
        _data[Count] = default(T);
        return returnValue;
        //공간을 재활용하면 됨
        */
    }

}
#region StackOfT

/* stack 설명
 * 최신기준 : 제일 늦게 Last In = 제일먼저 First Out (LIFO) 
 * Top Head = 수직구조 
 * 
 * 명령 기록 > 
 * 미로탐색 : DFS (한방향 막다른 길 후진-> 좌우)
 * 명령어 Undo 기록들,
 * Turn제 게임,
 * 추적,
 * 보드게임의 복기 역추적(또는 재귀),
 * UI(Depth Main과 PopUp순서 기록)
 * 
 * 생성자 CreateStack
 * public bool IsFull(stack) // maxStackSize true이면 List로 자동으로 크기가 늘어난다.
 * public bool IsEmpty
 * Push // 더하기, Pop // 빼기
 * 
 *
 */

/* 자료구조 스택 과 메모리구조 스택
 * 스택은 용량에 주의해야한다. 
 * (자료구조 스택은 메모리구조와 동일한 동작방식이지만, Stack이라고 스택영역에 쌓이는 것은 아니다.)
 * 
 * 자료구조 스택
 * 스택 배열을 고정크기로 가진다면, Stack OverFlow 가능성이 있다.
 * 동적 배열을 이용한다면, 어느정도 보완할 수 있다.
 * 
 * 메모리구조 스택 
 * 크기가 제한적이라 너무 많은 함수 호출, 큰 지역변수 사용 시 Stack OverFlow 가능성이 있다.
 * 
 * //메모리구조 Stack :  프로그램 실행 과정에서 함수의 호출과 반환을 관리하는 특정 목적을 위해 사용
 * 프로그램의 실행 흐름을 제어하는데 중요한 역할
 */

/*
 * 서버
 * 메니저 클릭,이벤트
 * 
 * 줄서기 : 수평 쌓기 
 
 * 한방향
 * Enqueue : 넣기
 * Dequeue : 빼기
 
 * 반대로 순회하고 싶은 경우의 Queue기능 추가
 * 덱 Deck :Duoble Queue 

 */

#endregion



#region 작성하면서...

/* 
 * 동적 배열의 기법을 차용
 * MaxLength 배열의 최대수치 지정
 * 
 * Stack 자료 구조에서
 * Pop 메서드에 데이터가 없는 경우와 0의 값을 구분해줘야한다.
 * 참조타입 :Null
 */

/* 값이 없는데 어떻게 구분할지에 대한 이야기
 * 
    public bool Pop(out T outValue)
    { 
        
    }
 * //데이터 반환에 대해 명확하게 구분
 * //void Bool : out 참조로 사용
 * 
 * 갑 타입에 Nullable을 사용하면 Boxing이 일어난다.
 */
#endregion

