using System;

/// <summary>
/// key value 받는 제네릭 헤쉬테이블
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class HashTable <TKey, TValue>
{
    /// <summary>
    /// 나눠지지 않는 소수 : 19 31 37
    /// 소수를 이용한 암호화 기법이 많다. (시간이 많이 걸리기 때문)
    /// </summary>
    private const int bucketCount = 19;

    /// <summary>
    /// 버킷(테이블) : 헤시테이블의 저장소
    /// 연결 리스트가 배열 -> 체이닝 방식으로 해시 충돌을 해결하기 위함 요소마다 리스트)
    /// </summary>
    private LinkedList<Pair<TKey, TValue>>[] table;

    //헤시 테이블이 비엇는지 확인하는 프로퍼티
    public bool IsEmpty
    {
        get
        {
            //각 연결리스트에 접근하여, 연결 리스트에 저장된 요소의 수를 합산한다
            for (int i = 0; i < bucketCount; i++)
            {
                //Count 수가 0이라면, 빈 상태 아니라면 데이터가 있는 상태
                if (table[i].Count > 0)
                    return false;
            }

            return true; 
        }
    }
    //생성자 
    public HashTable()
    {
        //해시 테이블의 저장소 생성
        table = new LinkedList<Pair<TKey, TValue>>[bucketCount];

        //배열 내부의 각 연결 리스트 객체 생성
        for (int i = 0; i < bucketCount; ++i)
        {
            table[i] = new LinkedList<Pair<TKey, TValue>>();
        }
    }

    /// <summary>
    /// 데이터 추가 함수
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(TKey key, TValue value) 
    {
        //1. 저장할 버킷의 인덱스 구하기
        //-key를 기반으로 해시를 구한 뒤 나머지 연산을 통해 인덱스를 구한다.
        int bucketIndex = GenerateKey(key) % bucketCount;

        //데이터를 추가할 연결리스트 참고 값 저장 (임시, 편의상)
        //LinkedList<Pair <TKey,TValue>> bucketList = table[bucketIndex];  //타입이름이 너무 길기 때문에 var 사용
        //var (성능 : 실행하는 순간 비교) 컴파일 타임에 유츄하기 때문에 성능의 패널티가 없다.
        var bucketList = table[bucketIndex];

        //해시테이블의 전제 조건 : 동일한 키는 저장할 수 없음 !
        for (int i = 0; i < bucketList.Count; ++i) 
        {
            //동일한 키가 존재하는 지 확인
            if (bucketList[i].data.key.Equals(key))//참조 타입 -> 을 .으로 줄임
            {
                Console.WriteLine("ERROR : 이미 동일한 키의 데이터가 저장되어 있습니다.");
                return;
            }
        }

        //문제가 없으면, 추가
        bucketList.PushLast(new Pair<TKey, TValue>(key, value));
    }

    // 삭제 함수
    public void Delete(TKey key)
    {
        #region 설명
        //1. 키를 기반으로 저장되어 있는 경결리스트의 인덱스를 찾는다.

        //-key를 기반으로 해시를 구한 뒤 나머지 연산을 통해 인덱스를 구한다.
        int bucketIndex = GenerateKey(key) % bucketCount;

        //데이터를 추가할 연결리스트 참고 값 저장 (임시, 편의상)
        //LinkedList<Pair <TKey,TValue>> bucketList = table[bucketIndex];  //타입이름이 너무 길기 때문에 var 사용
        var bucketList = table[bucketIndex];

        //충돌할 가능성이 있기 때문에
        //2. 1에서 찾은 연결리스트에서 동일한 키를 가진 데이터가 있는지 찾는다.

        //해시테이블의 전제 조건 : 동일한 키는 저장할 수 없음 !
        for (int i = 0; i < bucketList.Count; ++i)
        {
            //동일한 키가 있으면 삭제
            if (bucketList[i].data.key.Equals(key))//참조 타입 -> 을 .으로 줄임
            {
                bucketList.Delete(bucketList[i].data);//삭제
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"키 {key} 항목이 삭제되었습니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //검수
        //3. 있으면 삭제, 없으면 삭제 실패
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("삭제할 키 데이터를 찾지 못했습니다.");
        Console.ForegroundColor = ConsoleColor.White;
        #endregion
    }

    /// <summary>
    /// 검색함수 1 ->Value 값만 반환
    /// </summary>
    /// <param name="key"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    public bool Find(TKey key, ref TValue outValue)//검색함수는 보통 Boolean 성공여부를 반환하는 게 일반적임
    {
        //키를 기반으로 인덱스 찾기
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 검색한 인덱스로 연결 리스트 참조 저장 ( 편의상 )
        var bucketList = table[bucketIndex];

        //연결 리스트 안에서 키를 가진 데이터를 검색 후 검색이 되면 해당 데이터 복원 (검색 성공)
        for (int i = 0; i < bucketList.Count; i++)
        {
            if (bucketList[i].data.key.Equals(key) == true)
            {
                outValue = bucketList[i].data.value;
                return true;
            }
        }

        // Todo : 반환 값 재대로 처리해야 함
        return false;
    }

    /// <summary>
    /// 검색함수 2 ->Pair<Key, Value> 쌍을 반환
    /// </summary>
    /// <param name="key"></param>
    /// <param name="outPair"></param>
    /// <returns></returns>
    public bool Find(TKey key ,ref Pair <TKey,TValue> outPair)//검색함수는 보통 Boolean 성공여부를 반환하는 게 일반적임
    {
        //키를 기반으로 인덱스 찾기
        int bucketIndex = GenerateKey(key) % bucketCount;

        // 검색한 인덱스로 연결 리스트 참조 저장 ( 편의상 )
        var bucketList = table[bucketIndex];

        //연결 리스트 안에서 키를 가진 데이터를 검색 후 검색이 되면 해당 데이터 복원 (검색 성공)
        for (int i = 0; i < bucketList.Count; i++)
        {
            if (bucketList[i].data.key.Equals(key) == true)
            {
                outPair = bucketList[i].data;
                return true;
            }
        }

        // Todo : 반환 값 재대로 처리해야 함
        return false;
    }


    /// <summary>
    /// 출력함수
    /// </summary>
    public void Print()
    {
        //이중 루프
        for (int i = 0; i < bucketCount; i++)
        {
            //예외 처리
            //연결 리스트 순회하면서 데이터 출력
            for (int j = 0; j < table[i].Count; j++)
            {
                Console.WriteLine($"키 : {table[i][j].data.key} 값 : {table[i][j].data.value}");
            }
        }
    }
    // Todo : 완료 (해시 함수 만들기)
    /// <summary>
    /// 해시 생성 함수,키를 전달 받아서, 문자열을 변환한 뒤, 이를 활용해서 해시 값을 구함
    /// //어떤 데이터를 들어와도, int로 반환
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int GenerateKey(TKey key)
    {
        //최종 반환할 해시 값
        int hash = 0;

        //C#의 모든 자료형은 ToString를 가지고 있으므로, 문자열로 변환한 뒤 Character 문자배열로 생성
        char[] chars = key.ToString().ToCharArray();

        //해시 생성
        for (int i = 0; i < chars.Length; i++)
        {
            //가장 기본 (단순함)
            //hash += chars[i];

            //조금 변환 //무언가 하는 방식
            //hash += chars[i] * (i + 1);

            //많이 알려지고, 추천된 방식
            hash = hash * 31 + chars[i];
        }

        //해시 값 변환 :절대값을 씌움 -값이 나올리 없음 // integer 크기가 크지만 key 값에 따라 오버플로우 가능성이 있음 
        return Math.Abs(hash);
    }
}