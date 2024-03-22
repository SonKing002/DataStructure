using System;

// 이진 탐색 트리의 노드.
public class Node
{
    // 키 " 숫자 InstanceID ( 가려진 것은 GUID 내부 저장할 때) 자료 자체를 키로 사용

    /// <summary>
    /// 노드의 키 값.
    /// </summary>
    public int Data { get; set; } 

    /// <summary>
    /// 부모 노드 : 부모 접근이 필요한데 편하게 접근하기 위함
    /// </summary>
    public Node Parent { get; set; }

    /// <summary>
    /// 왼쪽 서브트리.
    /// </summary>
    public Node Left { get; set; }

    /// <summary>
    /// 오른쪽 서브트리.
    /// </summary>
    public Node Right { get; set; }

    /// <summary>
    /// 이진 트리에 데이터를 안넣는 경우는 없음 
    /// </summary>
    /// <param name="data"></param>
    public Node(int data)
    {
        Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }
}
/*
 * C# 동작 메커니즘 공부할것
 * 
 * //성능이 중요하면 알고리즘은 문자열이 안되는것은 아니나 크기 비교시 성능이 먹힌다.
 * 무조건 숫자범용 int float( 바이트로 두기도 한다.)
 */