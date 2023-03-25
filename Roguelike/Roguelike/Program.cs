using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace оброботка_клавиатуры
{
    public class Game
    {

    }

    internal class Program
    {
        bool quit = false;
        int X;
        int Y;

        int[,] GameField;
        int w = 40, h = 20;
        int lavel = 0;
        void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w + 10, h + 10);
            Console.SetBufferSize(w + 10, h + 10);
        }

        void Load(int level = 1)
        {

            X = w / 2;
            Y = h / 2;
            GameField = new int[w + 1, h + 1];
            GameField[X, Y] = 1;
            //Random random = new Random();
            for (int i = 0; i <= w; i++)
            {
                GameField[i, 0] = 9;
                GameField[i, h] = 9;
            }
            for (int i = 0; i < h; i++)
            {
                GameField[0, i] = 9;
                GameField[w, i] = 9;
            }

        }
        void moveGame(int d)
        {
            for (int i = 0; i <= w; i++)

                for (int j = 0; j < h; j++)
                {
                    if (GameField[i, j] == 1)
                    {
                        switch (d)
                        {
                            case 1:


                                if (GameField[i - 1, j] == 0)
                                {
                                    GameField[i, j] = 0;
                                    GameField[i - 1, j] = 1;
                                }
                                return;


                            case 2:


                                if (GameField[i + 1, j] == 0)
                                {
                                    GameField[i, j] = 0;
                                    GameField[i + 1, j] = 1;
                                }
                                return;

                            case 3:

                                if (GameField[i, j - 1] == 0)
                                {
                                    GameField[i, j] = 0;
                                    GameField[i, j - 1] = 1;
                                }
                                return;

                            case 4:

                                if (GameField[i, j + 1] == 0)
                                {
                                    GameField[i, j] = 0;
                                    GameField[i, j + 1] = 1;
                                }
                                return;




                        }
                    }

                }
        }
        void PrintGameField()
        {
            for (int y = 0; y <= h; y++)
                for (int x = 0; x <= w; x++)
                {
                    Console.SetCursorPosition(x, y + 1);

                    switch (GameField[x, y])
                    {
                        case 0:
                            Console.WriteLine(' ');
                            break;
                        case 1:
                            Console.WriteLine('@');
                            break;
                        case 10:
                            Console.WriteLine('/');
                            break;
                        default:
                            Console.WriteLine('#');
                            break;

                    }
                }
            Console.SetCursorPosition(10, 0);

        }
        int keybordUpdate()
        {
            while (true)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.S:
                        return 1;
                    case ConsoleKey.D:
                        return 2;
                    case ConsoleKey.W:
                        return 3;
                    case ConsoleKey.A:
                        return 4;
                    case ConsoleKey.Escape:
                        return 99;
                    default:
                        break;



                }

            }



        }
        public void Game()
        {
            Init();
            Load();
            PrintGameField();
            int d = 0;
            while (d != 99)
            {
                d = keybordUpdate();
                moveGame(d);
                PrintGameField();

                //Console.WriteLine("действие "+d);
            }






        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Game();
            Console.ReadKey();
        }
    }
}