using System;
using System.Runtime.CompilerServices;

#region Array 예시 첫번쨰
/// <summary>
/// 구조체 ( struct ) = 값 타입 ( Value Type )
/// </summary>
public struct Array01
{
    /// <summary>
    /// 자료 저장공간
    /// </summary>
    private int[] _data;

    /// <summary>
    /// 기본 배열의 크기지정 = 5
    /// </summary>
    private const int _defaultLength = 5;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="size"></param>
    public Array01(int size)
    {
        _data = size == 0 ? new int[_defaultLength] : new int[size];//삼항연산자
    }

    /// <summary>
    /// 값을 읽는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int At(int index)
    {
        //안전장치로 감싸야한다.
        return _data[index];
    }

    /// <summary>
    /// 쓰는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <param name="newData"></param>
    public void SetData(int index, int newData)
    {
        _data[index] = newData;
    }

    /// <summary>
    /// 길이 프로퍼티
    /// </summary>
    public int Length
    {
        get
        {
            if (_data == null)//없을 때 조건
            { 
                _data = new int[_defaultLength];
            }

            return _data.Length;
        }
    }
}
#endregion 

#region Array Of T 예시
/// <summary>
/// Generic 형태로 여러 형태를 대입하기 위함
/// </summary>
/// <typeparam name="T"></typeparam>
public struct Array02<T>
{
    /// <summary>
    /// 자료 저장공간
    /// </summary>
    private T[] _data;

    /// <summary>
    /// 기본 배열의 크기지정 = 5
    /// </summary>
    private const int _defaultLength = 5;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="size"></param>
    public Array02(int size)
    {
        _data = size == 0 ? new T[_defaultLength] : new T[size];//삼항연산자
        //스택에서 힙을 참조하는 주소값을 가지고 있음
    }

    /// <summary>
    /// 값을 읽는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T At(int index)
    {
        //안전장치로 감싸야한다.
        return _data[index];
    }

    /// <summary>
    /// 쓰는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <param name="newData"></param>
    public void SetData(int index, T newData)
    {
        _data[index] = newData;
    }

    /// <summary>
    /// 길이 프로퍼티
    /// </summary>
    public int Length
    {
        get
        {
            if (_data == null)//없을 때 조건
            {
                _data = new T[_defaultLength];
            }

            return _data.Length;
        }
    }
}
#endregion  

#region Array Of T 인덱서 예시
/// <summary>
/// Generic 형태로 여러 형태를 대입하기 위함
/// </summary>
/// <typeparam name="T"></typeparam>
public struct Array<T>
{
    /// <summary>
    /// 자료 저장공간
    /// </summary>
    private T[] _data;

    /// <summary>
    /// 기본 배열의 크기지정 = 5
    /// </summary>
    private const int _defaultLength = 5;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="size"></param>
    public Array(int size)
    {
        _data = size == 0 ? new T[_defaultLength] : new T[size];//삼항연산자
        //스택에서 힙을 참조하는 주소값을 가지고 있음
    }

    /// <summary>
    /// GetSet 프로퍼티
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get { return _data[index]; }
        set { }
    }

    /// <summary>
    /// 길이 프로퍼티
    /// </summary>
    public int Length
    {
        get
        {
            if (_data == null)//없을 때 조건
            {
                _data = new T[_defaultLength];
            }

            return _data.Length;
        }
    }
}
#endregion  

public class Program
{
    //메서드 
    /// <summary>
    /// 진입점이며, Main 명칭은 바꿀 수 없다.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //Create();//Array01 예시
        Create02();
    }

    static void Create()
    {
        //배열 생성
        int length = 10;
        Array01 arr = new Array01(length);

        //데이터 쓰기 : 값 할당
        for (int ix = 0; ix < arr.Length; ix++)
        {
            arr.SetData(ix, ix + 1);
        }

        //데이터 읽기 : 출력
        for (int ix = 0; ix < arr.Length; ix++)
        {
            Console.WriteLine($"{ix}번째 : {arr.At(ix)}");
        }

        Console.ReadKey();//바로 종료되지 않도록 추가
    }

    /// <summary>
    /// 인덱서 + 제네릭
    /// </summary>
    static void Create02()
    {
        //배열 생성
        int length = 10;
        Array<int> arr = new Array<int>(length);

        //데이터 쓰기 : 값 할당
        for (int ix = 0; ix < arr.Length; ix++)
        {
            arr[ix] = ix + 1;
        }

        //데이터 읽기 : 출력
        for (int ix = 0; ix < arr.Length; ix++)
        {
            Console.WriteLine($"{ix}번째 : {arr[ix]}");
        }

        /*
        foreach (var element in arr)//Enumerator 구현해야 Foreach 문 사용할 수 있다.
        { 
        
        }
        */

        Console.ReadKey();//바로 종료되지 않도록 추가
    }
}

#region 추가 설명들

/* 폰노이만 진입점에 대한 이야기
  c , cpp : 클래스 안팎으로 함수가 존재한다. == 함수
 
  C# : Java 차이가 없다. == 메서드, 함수
원래 함수와 구분하기 위해 메서드라 불렸다.

폰노이만의 컴퓨터구조를 지금도 사용중 
-바꾼다면 양자컴퓨터 : 프로그램 작성방식이 다르다.

위에서부터 읽어내려간다.
*/

/* 컴파일러 동작과 환경이야기
 * 컴파일러 2가지 동작 방식이 있ㄷㅏ
 * 
 * 컴파일러 종류가 달라서 동작하는 환경에 제약이 따른다.
 * AOT ( Ahead Of Time )  
 * JIT ( Just In Time  ) : 자바/C#
 * 
 * C#에는 Reflection 기능이 있다. 
 * - 실행 중에 어떤 함수가 있는지, 변수 목록을 가져와서 네임을 가져올 수 있다.
 * - 성능적으로 좋지는 않다.
 * 
 * MAC계열은 미리 알려줘야 한다. 지원 x

 */

//GetSet 프로퍼티에 대한이야기
public class Test
{
    private int data;

    /// <summary>
    /// Getter 함수
    /// </summary>
    /// <returns></returns>
    public int GetData()
    { 
        return data;
    }

    /// <summary>
    /// Setter 함수
    /// </summary>
    /// <param name="data"></param>
    public void SetData(int data)
    {
        this.data = data;
    }
}
/* GetSet 함수
 * 변수를 하나 작성하고, 함수 2개로 감싸는 작업
 * Getter Setter -> 만들 바에는 프로퍼티로 미리 만들어보자
 * 
 * 프로퍼티는 내부적으로 함수이다.
 * Get, Set 함수를 만든다. 
 * 내부에 임시변수를 만든다. Type 클래스
 * CPP 함수 position.x 는 프로퍼티로 감싸져있어서 읽기전용이기 떄문에 하나씩 쓸 수 없다.
 */

/* 폰트 추천 소개
 * == !=
 * 환경 - 글꼴 및 색 변경가능
 * D2Coding
 * 젯브레인 모노
 */

/* Start Update 매번 지우기 귀찮을 때 수정 방법 소개
 * 
 */

/* 직렬화에 대한 이야기
 * 
 * Serialize
 * CS -> Json
 *일일이 추적해서 저장하기 어렵다 = 통으로 저장하기 위해 직렬화한다.
 *직렬화 : 저장하는 방법
 * 
 * Deserialize
 * Json -> CS 
 * 역직렬화 : 읽어오는 방법
 * 
 * Wab서버 에서는 제이슨은 Wraping 자동으로 된다.
 * 
 * 유니티에서의 직렬화 : 데이터 속성 생김새를 프로퍼티 별도로 저장한다.
 * 해당 시스템이 나온 이유 : play 전의 상태를 되돌리는 기법 == 스냅샷을 찍어낸다.
 */

/* 자료 저장에 대한 이야기
 * 자바 스크립트 : Json 
 * 페이스북 이후로 보급화와 편의성에 일조하게 된다.
 */


#endregion