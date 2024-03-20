
using System;

/// <summary>
/// 저장할 공간
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class Pair<TKey, TValue>
{
    /// <summary>
    /// 키를 저장하는 변수
    /// </summary>
    public TKey key;

    /// <summary>
    /// 값을 저장하는 변수
    /// </summary>
    public TValue value;

    /// <summary>
    /// 기본 생성자
    /// </summary>
    public Pair()
    { 
        key = default(TKey);
        value = default(TValue);
    }

    /// <summary>
    /// 받아올 자료 기준의 생성자
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public Pair(TKey key, TValue value)
    { 
        this.key = key;
        this.value = value;
    }
}