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
