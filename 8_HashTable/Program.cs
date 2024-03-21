using System;
using System.Runtime.InteropServices;
public class Program
{
    static void Main(string[] args)
    {
        HashTable<string, string> table = new HashTable<string, string>();

        table.Add("Ronnie", "010-1234-4567");
        table.Add("Ronnie", "010-1234-4567");
        table.Add("Roman", "010-1234-4567");
        table.Add("Nalson", "010-1234-4567");
        table.Add("PonyounJung", "010-1234-4567");
        table.Add("kowai", "010-1234-4567");
        //
        //고루 분포되어있어야 함 (몇개 겹치더라도 검색량이 줄어든다.)
        //어느정도 보완성

        //속도

        table.Print();
        Console.WriteLine();

        Pair<string, string> outPair = new Pair<string, string>();
        if (table.Find("Ronnie", ref outPair))
        {
            Console.WriteLine($"검색 결과 1: {outPair.key}, {outPair.value} ");
        }

        if (table.Find("Test", ref outPair) == true)
        {
            Console.WriteLine($"검색 결과 2 : {outPair.key}, {outPair.value}");
        }

        table.Delete("Roman");
        table.Delete("Nalson");
        table.Delete("Na");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n 최종 결과");
        table.Print();
        Console.ForegroundColor = ConsoleColor.White;
    }
}
