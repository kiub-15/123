using System;

class Program
{
    static void Main()
    {

        Console.Write("플레이어 이름을 입력하세요: ");
        string playerName = Console.ReadLine();

        string[] job = { "검사", "마법사", "궁수", "도적", "해적" };
        int selectedJob = -1;

        while (selectedJob < 1 || selectedJob > 5)
        {
            Console.Clear();
            Console.WriteLine("직업을 선택하세요:");
            for (int i = 0; i < job.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {job[i]}");
            }

            Console.Write("\n번호를 입력하세요 (1~5): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out selectedJob) && selectedJob >= 1 && selectedJob <= 5)
            {
                break;
            }

            Console.WriteLine("1번부터 5번중에 골라주세요.");
            Console.ReadKey();
        }

        string playerJob = job[selectedJob - 1];

        // 3. 스탯 종류와 총합 (찍을 수 있는 스탯)
        string[] statNames = { "공격력", "방어력", "체력", "스피드" };
        int[] playerStats = new int[4];
        int totalPoints = 15;
        int cursor = 0;

        // 4. 스탯 분배 (총합 15의 스텟을 가지고 원하는대로 찍기, 포인트를 다써야함)
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"↓↑ 스탯 선택 / ←→ 포인트 분배 / Enter: 완료\n");

            for (int i = 0; i < statNames.Length; i++)
            {
                if (i == cursor)
                    Console.Write(">> ");
                else
                    Console.Write("   ");

                Console.WriteLine($"{statNames[i]}: {playerStats[i]}");
            }

            Console.WriteLine($"\n남은 포인트: {totalPoints}");

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    cursor = (cursor - 1 + statNames.Length) % statNames.Length;
                    break;
                case ConsoleKey.DownArrow:
                    cursor = (cursor + 1) % statNames.Length;
                    break;
                case ConsoleKey.RightArrow:
                    if (totalPoints > 0)
                    {
                        playerStats[cursor]++;
                        totalPoints--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerStats[cursor] > 0)
                    {
                        playerStats[cursor]--;
                        totalPoints++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (totalPoints == 0)
                    {
                        ShowMainScreen(playerName, playerJob, statNames, playerStats);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n모든 포인트를 분배해야 합니다. 아무 키나 누르세요.");
                        Console.ReadKey(true);
                    }
                    break;
            }
        }
    }

    static void ShowMainScreen(string name, string job, string[] statNames, int[] stats)
    {
        Console.Clear();
        Console.WriteLine("======최종 정보======\n");
        Console.WriteLine($"이름: {name}");
        Console.WriteLine($"직업: {job}");
        Console.WriteLine("\n[스탯 정보]");
        for (int i = 0; i < statNames.Length; i++)
        {
            Console.WriteLine($"{statNames[i]}: {stats[i]}");
        }

        Console.WriteLine("\n게임을 시작하려면 아무 키나 누르세요...");
        Console.ReadKey(true);
    }
}
