using System;

public class Program
{
    static void Main(string[] args)
    {
        BinaryTree<string> tree = new BinaryTree<string>("1");
        tree.AddLeftChild("2");
        tree.Left.AddLeftChild("4");
        tree.Left.Left.AddLeftChild("8");
        tree.Left.Left.AddRightChild("9");

        tree.Left.AddRightChild("5");
        tree.Left.Right.AddLeftChild("10");
        tree.Left.Right.AddRightChild("11");

        tree.AddRightChild("3");
        tree.Right.AddLeftChild("6");
        tree.Right.Left.AddLeftChild("12");
        tree.Right.Left.AddRightChild("13");

        tree.Right.AddRightChild("7");
        tree.Right.Right.AddLeftChild("14");
        tree.Right.Right.AddRightChild("15");

        Console.WriteLine("전위 순회");
        tree.PreorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.WriteLine("\n중위 순회");
        tree.InorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.WriteLine("\n후위 순회");
        tree.PostorderTraverse(n => { Console.WriteLine($"{n.Data}"); });

        Console.ReadKey();
    }
}
#region 이진 검색트리
/*
 * BST : 이진 트리의 일종
 * 각 특정 노드를 기점으로 조건별로 좌우 정렬한다.
 
 * 검색 때문에 사용한다.
 * 삽입,  : 필수
 * 검색,  : 목표
 * 삭제,  : 하위를 살려야하는 삭제이므로 복잡
 * 중위 순회를 수행하지만, 전위 후위도 가능하다. 정렬순서로 출력
 * 
 * 평균적으로 O(log n) 
 * 
 * AVL 트리, 레드 블랙 트리 :고난도
 */
#endregion

#region
/*
 * big O : (방법이 없으므로, 현실적으로 n의 3승까지는 사용한다.) 측정이 제일 정확하다.
 * 기본적으로 알고리즘을 정할 수 없어서
 * 정렬을 위한 이진탐색트리
 */
#endregion