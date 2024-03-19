public class StackExample
{
    static void Main(string[] args)
    {
        //스택 생성
        Stack<float> stack = new Stack<float>();

        //스택에 데이터 추가
        stack.Push(123.54f);
        stack.Push(3232.54f);
        stack.Push(432.21f);

        int count = stack.Count;
        for (int i = 0; i < count; i++) 
        {
            Console.WriteLine($"{i}번째, stack 값 : {stack.Pop()}");
        }

        Console.ReadKey();
    }
}
