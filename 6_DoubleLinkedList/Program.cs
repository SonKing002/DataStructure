public class Program
{
    static void Main(string[] args)
    {
        
        //연결 리스트 데모
        LinkedList<int> list = new LinkedList<int>();

        //자료 추가
        int index = 0;
        while (index < 10)
        {
            list.PushFirst(index +1);//뒤에서부터
            //list.Insert(index + 1);//앞에서부터
            index++;
        }
        list.Delete(1);
        list.Delete(3);
        list.Delete(39);
        //출력
        list.Print();

        //대기
        Console.ReadKey();

        //bool isNumber = int.TryParse(Console.ReadLine(), out int number);// 파싱
        
    }
}
