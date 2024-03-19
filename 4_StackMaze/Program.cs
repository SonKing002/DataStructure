using System;
using System.Diagnostics;

public class StackMaze
{
    /// <summary>
    /// 화면에 맵을 출력(Draw)한 다음, 플레이어 위치를 보여주는 함수
    /// </summary>
    /// <param name="map">맵 (2차원 맵)</param>
    /// <param name="posX">x 위치</param>
    /// <param name="posY">y 위치</param>
    /// <param name="delay">화면 갱신할 지연의 시간 값 (밀리세컨드 단위1s == 1,000ms)</param>
    static void PrintLocation(Maze map, int posX, int posY, int delay)
    {
        //멈춰놓기
        Thread.Sleep(delay);

        //커서 안보이도록 설정
        Console.CursorVisible = false; //연출

        //커서의 위치를 초기화 (0,0)으로 설정
        Console.SetCursorPosition(0, 0);
        //맵을 계속 그릴것 : //지우고 그린다 == 깜빡임이 보임 //덮어서 그린다 == 깜빡이지 않음 ( 조건 : 데이터 크기가 동일해야한다 )

        //전체 순회한다.
        for (int ix = 0; ix < Maze.size; ix++)
        {
            for (int jx = 0; jx < Maze.size; jx++)
            {
                #region 순회 작성
                /* Todo : 
                 * 1.플레이어 위치 출력 
                 * 2.지나온 길을 빨간색으로 표기 
                 * 3.맵 문자 출력
                 * 4.색상 원래대로 복구
                 */
                #endregion

                //1.위치 확인 P
                if (ix == posX && jx == posY)
                {
                    //2. 색상 설정
                    Console.ForegroundColor = ConsoleColor.Green;

                    //3. 플래이어 위치 출력
                    Console.Write("P ");

                    //4. 색상을 원래대로 돌리놓기
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;//생략해도 되지만, 완료된 루프는 넘기기
                }

                // 지나온 길은 빨간색으로 표기
                if (map[ix, jx] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                //맵 문자 출력.
                Console.Write($"{map[ix, jx]} ");

                //색상 원래대로 복구
                Console.ForegroundColor = ConsoleColor.White;
            }

            //그 다음 줄로 이동
            Console.WriteLine();
            //Console.Write("\n"); //동일
        }

    }
    
    /// <summary>
    /// 미로 탐색을 진행
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        #region
        //1. 맵 생성 필요
        //시작지점 저장을 위한 변수
        //시작지점 검출

        //탐색 >
        //스택을 활용해서 상하좌우 순서로 다음 이동을 할 위치에 대한 탐색
        //조건부 무한 루프 (먼저 종료조건을 확인해야함)
        #endregion

        Maze maze = new Maze();//미로 생성
        Location2D startLocation = new Location2D();//맵 그리기

        //탐색
        for(int ix = 0; ix < Maze.size; ix++)
        {
            for (int jx = 0; jx < Maze.size; jx++)
            {
                //시작 지점인지 확인
                if (maze[ix, jx] == 'e')
                {
                    startLocation.row = ix;
                    startLocation.col = jx;
                    break;
                }
            }
        }

        //스택 생성
        Stack<Location2D> locationStack = new Stack<Location2D>();
        //스택에 시작 위치를 추가하고, 탐색 시작
        locationStack.Push(startLocation);
        
        while(locationStack.IsEmpty == false)//탐색
        {
            //현재 위치 반환
            Location2D currentLocation = locationStack.Pop();

            //맵 및 플레이어 정보 출력
            PrintLocation(maze, currentLocation.row, currentLocation.col, 50);

            //(출구에 도착했는지 * 미로 탈출했는지)
            if (maze[currentLocation.row, currentLocation.col] == 'x')
            {
                Console.WriteLine("\n\n 미로탐색 성공");
                Console.ReadKey();

                return;

            }
            //출구가 아니라면, 다음 탐색할 위치 추가(상하좌우)
            //탐색한 위치의 무자(character)를 '.'으로 변경
            maze[currentLocation.row, currentLocation.col] = '.';

            //다음 탐색할 위치를 스택에 추가
            // Todo : 로직 완성 :  탐색할 위치를 스택에 추가
            if (maze.IsValidLocation(currentLocation.row -1, currentLocation.col))//상
            {
                //움직일 수 있다면 Push 추가
                locationStack.Push(new Location2D(currentLocation.row - 1, currentLocation.col));
            }
            if (maze.IsValidLocation(currentLocation.row + 1, currentLocation.col))//하
            {
                locationStack.Push(new Location2D(currentLocation.row + 1, currentLocation.col));
            }
            if (maze.IsValidLocation(currentLocation.row , currentLocation.col - 1))//좌
            {
                locationStack.Push(new Location2D(currentLocation.row, currentLocation.col -1));
            }
            if (maze.IsValidLocation(currentLocation.row , currentLocation.col + 1))//우
            {
                locationStack.Push(new Location2D(currentLocation.row, currentLocation.col + 1));
            }
        }

        //탐색 실패
        Console.WriteLine("\n\n 미로 탐색 실패");
        Console.ReadKey();
    }
}

#region
/*Load JS 싱글 쓰레드 vs 멀티쓰레드 논쟁
 * 병목현상이 일어나는 것은 똑같은 현상이다 싱글!
 * 멀티가 훨씬 낫다. 멀티!
 */

/* 최고의 성능을 뽑을 수 있음에도 불구하고 sleep을 거는 이유
 * 안정성 구동이 목표 = 언제나 평균  fps 을 유지하기 위함
 */
#endregion

#region 코드규칙
/*
 * 함수명 : 파스칼 규칙 파스칼케이스ㄴ
 * 
 * 이름 짓기
 * Boolean 묻는 형식
 * 
 */
#endregion