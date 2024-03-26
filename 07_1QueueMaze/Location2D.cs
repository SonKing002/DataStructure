
using System;
/// <summary>
/// 행열 2Demension
/// </summary>
public class Location2D
{
    /// <summary>
    /// 행 가로
    /// </summary>
    public int row;

    /// <summary>
    /// 열 세로
    /// </summary>
    public int col;

    /// <summary>
    /// 기본 생성자
    /// </summary>
    /// <param name="row"> 가로 </param>
    /// <param name="col"> 세로 </param>
    public Location2D(int row = 0, int col = 0)
    {
        this.row = row;
        this.col = col;
    }
}

/// <summary>
/// 미로를 나타내는 클래스
/// </summary>
public class Maze
{
    /// <summary>
    /// 맵의 가로 세로 크기
    /// </summary>
    public static int size = 0;

    /// <summary>
    /// 맵 데이터 배열: 행과 열 
    /// </summary>
    private char[,] _mapCharSlots;

    /// <summary>
    /// 맵 접근을 더 편하게 하기 위해서 인덱서 프로퍼티활용
    /// </summary>
    /// <param name="row">행</param>
    /// <param name="col">영</param>
    /// <returns></returns>
    public char this[int row, int col]
    {
        get { return _mapCharSlots[row, col]; }
        set { _mapCharSlots[row, col] = value; }
    }

    /// <summary>
    /// 생성자 파일에서 맵읽기
    /// </summary>
    public Maze()
    {
        #region 구현 기록 
        //작성자 : 손재혁 (2024.03.19)
        /* Todo : 완료 (Read Map from Map.Txt) 
         * 파싱 (Parcing) - 해석하다 == 역직렬화하기 맥락과 같음
        */
        ReadMap("Map.txt");
        #endregion
    }

    /// <summary>
    /// 출력
    /// </summary>
    public void Print()
    {
        //미로 출력
        for (int ix = 0; ix < Maze.size; ix++)
        {
            for (int jx = 0; jx < Maze.size; jx++)
            {
                Console.Write($"{_mapCharSlots[ix, jx]} ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 전달된 위치가 이동 가능한 위치인지 판별하는 함수
    /// </summary>
    /// <param name="row">맵에서 탐색할 행 번호</param>
    /// <param name="col">맵에서 탐색할 열 번호</param>
    /// <returns></returns>
    public bool IsValidLocation(int row, int col)
    {
        //이동 불가능한 판단 : 크기를 벗어나면
        if ((row < 0 || col < 0) || (row >= size) || col >= size)
        {
            return false;
        }
        //이동 가능한 판단
        return _mapCharSlots[row, col] == '0' || _mapCharSlots[row, col] == 'x';
    }

    /// <summary>
    /// 맵 읽기
    /// </summary>
    /// <param name="path">해당경로</param>
    private void ReadMap(string path)
    {

        //텍스트 파일을 라인으로 분리해서 읽어오기
        string[] lines = File.ReadAllLines(path);

        int lineIndex = 0;

        // Todo : 완료 (Create Array with Size)
        //파일의 라인 (줄) 수를 사용하여, 2차원의 배열 맵을 생성
        _mapCharSlots = new char[lines.Length, lines.Length];

        //크기 설정
        Maze.size = lines.Length;

        //라인 별로, 파싱을 위해 루프 처리
        foreach (string line in lines)
        {
            //해당 라인에서 (,)콤마 기준으로 파싱
            string[] chars = line.Split(',');

            //파싱한 맵의 문자를 맵 배열에 저장
            for (int ix = 0; ix < chars.Length; ix++)
            {
                //2차원 맵 공간에 할당
                _mapCharSlots[lineIndex, ix] = chars[ix][0];
            }

            //라인 인덱스 증가
            ++lineIndex;
        }

    }
}

//실제 컴퓨터에는 다차원의 개념이 없다.
//행렬 구할 때, float로 행렬 구하는 코드로 사용한다.

#region 라인에 대한 이야기
/*File.ReadAllBytes
 * Byte 로그인 정보 웹에 보낼 때 이후 ~ 아이디 패스워드가 DB에서 매칭되기 전
 * 
 * 버퍼를 통해 보낼 때 File.ReadAllBytes
 */
//\n 개행 기준 :  개행 문자 기준으로 잘라줌
/* : File.ReadAllLines() 라인 잘라서 string[] 배열로 반환한다.
 * 
 * Csv 콤마 세퍼레이티드 벨류  = 엑셀 테이블 ,콤마 사용은 우회해야한다.
 * Json
 * 
 */

#endregion