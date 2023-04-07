using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Character
    {
        public int hp;
        public int atk;
        public int def;
    }

    public class Player : Character
    {
        public int classP;
        private int x;
        private int y;
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void MoveUp()
        {
            y--;
        }

        public void MoveDown()
        {
            y++;
        }

        public void MoveLeft()
        {
            x--;
        }

        public void MoveRight()
        {
            x++;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public Player(int hp, int atk, int def, int classP)
        {
            if (classP == 1)
            {
                this.hp = hp * 10;
                this.atk = atk * 2;
                this.def = def * 1;
            }
            else if (classP == 2)
            {
                this.hp = hp * 15;
                this.atk = atk * 1;
                this.def = def * 1;
            }
        }

    }

    public class Enemy : Character
    {
        public int classE;
        private int x;
        private int y;

        public Enemy(int EnemyID)
        {

            Random ranE1 = new Random();
            Random ranE2 = new Random();
            Random ranE3 = new Random();

            int RandE1 = ranE1.Next(1, 4);
            int RandE2 = ranE2.Next(1, 4);
            int RandE3 = ranE3.Next(1, 4);


            if (EnemyID == 1)
            {
                this.classE = RandE1;
            }
            if (EnemyID == 2)
            {
                this.classE = RandE2;
            }
            if (EnemyID == 3)
            {
                this.classE = RandE3;
            }

        }
        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetEnemyX()
        {
            return x;
        }

        public int GetEnemyY()
        {
            return y;
        }





        public Enemy(int hp, int atk, int def, int classE)
        {


            //            e1.classE = RandE1;
            //            e2.classE = RandE2;
            //            e3.classE = RandE3;



            if (classE == 1)
            {
                this.hp = hp * 3;
                this.atk = atk * 1;
                this.def = def * 1;
 //               Console.SetCursorPosition(1, 22);
                //               Console.Write(e1.hp);
            }

            if (classE == 2)
            {
                this.hp = hp * 4;
                this.atk = atk * 2;
                this.def = def * 2;
//                Console.SetCursorPosition(1, 22);
                //                Console.Write(e1.hp);
            }
            if (classE == 3)
            {
                this.hp = hp * 7;
                this.atk = atk * 10;
                this.def = def * 1;
//                Console.SetCursorPosition(1, 22);
                //                Console.Write(e1.hp);
            }



        }

        public class Items
        {
            public char img;
            public string name;
            public string massage;
            public int id;
            public Items(int id)
            {
                switch (id)
                {
                    case 1:
                        this.img = '/'; // атк +2 на карте
                        this.name = "Палка";
                        this.massage = "Просто палка.";
                        break;
                    case 2:
                        this.img = 'f'; // атк +4 на карте
                        this.name = "Палка с гвоздями";
                        this.massage = "Просто палка... Кто вбил в нее столько гроздей?";
                        break;
                    case 3:
                        this.img = 'Ô'; // дф +2 на карте
                        this.name = "Крышка от кастрюли";
                        this.massage = "А где сама кастрюля?";
                        break;
                    case 4:
                        this.img = '♥'; // хп +2 на карте и продажа
                        this.name = "Сердце";
                        this.massage = "Вы напоняетесь решимостью.";
                        break;
                    case 5:
                        this.img = '∫'; // атк + 6 продажа
                        this.name = "Труба";
                        this.massage = "Они прокладывают трубы до августа.";
                        break;
                    case 6:
                        this.img = 'U'; // дф + 4 продажа
                        this.name = "Ведро";
                        this.massage = "Наконец-то! Ведро! Да, да, да! Обожаю это ведро.";
                        break;
                    case 7:
                        this.img = ' '; // что-нибудь еще я не знаю продажа
                        this.name = "";
                        this.massage = "Наконец-то! Ведро! Да, да, да! Обожаю это ведро.";
                        break;
                }
            }
        }

        public class Traider
        {
            public int x;
            public int y;
            List<Items> traideItem;

            //    public void traideWindow() {
            //    public string line;
            //    public var textFile = new StreamReader("C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\traider.txt");
            //        while ((line = textFile.ReadLine()) != null)
            //        {
            //            Console.WriteLine(line);
            //        }
            //textFile.Close();
            //    Console.ReadLine();
            //    }
            public void createTraideItems()
            {
                for (int i = 4; i <= 7; i++)
                {
                    var i1 = new Items(i);
                    traideItem.Add(i1);
                }
            }
        }


        public class Game
        {
            Character p1;
            List<Character> enemies;

            class Rooms
            {
                public double[,] data;
            }
            List<Rooms> rooms;

            public void createEnemies(int classE)
            {
                for (int i = 1; i <= 5; i++)
                {
                    var e1 = new Enemy(1, 1, 1, classE);
                    enemies.Add(e1);
                }
            }

            public void createPlayer(int classP)
            {
                var p1 = new Player(1, 1, 1, classP);
            }

        }

        class Map
        {
            public int width;
            public int height;
            public char[,] tiles;

            public Map(int width, int height)
            {
                this.width = width;
                this.height = height;
                tiles = new char[width, height];
                Generate();
            }

            public void Generate()
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        tiles[x, y] = '#';
                    }
                }
                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        tiles[x, y] = ' ';
                    }
                }
            }

            public void Draw()
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Console.Write(tiles[x, y]);
                    }
                    Console.WriteLine();
                }
            }
        }

        //public void keyEvent()
        //{

        //}

        //public void startGame()
        //{
        //    draw();
        //    keyEvent();
        //    foreach(var e in enemies)
        //    {
        //        if(e.cord == p1.cord)
        //        {
        //            Fight.start(p1, e);
        //        }
        //    }

        //}

        public static class Fight
        {
            public static void start(Character p1, Enemy e1)
            {
                p1.hp -= 10;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Map map = new Map(20, 20);
                map.Draw();
                Player player = new Player(1, 1);
                int a = 0;






                //                int ecount = 0;
                //                Random rnd = new Random();
                //                int n = rnd.Next(2, 5);

                while (true)
                {
                    Console.Clear();

                    map.Draw();

                    Console.SetCursorPosition(player.GetX(), player.GetY());

                    Console.Write('@');

                    while(a < 1)
                    {
                    

                    Enemy e1 = new Enemy(1);
                    Enemy e2 = new Enemy(2);
                    Enemy e3 = new Enemy(3);

                    Random rndXe1 = new Random();
                    Random rndYe1 = new Random();


                    Random rndXe2 = new Random();
                    Random rndYe2 = new Random();


                    Random rndXe3 = new Random();
                    Random rndYe3 = new Random();


                    int enx1 = rndXe1.Next(1, 19);
                    int eny1 = rndYe1.Next(1, 19);


                    int enx2 = rndXe2.Next(1, 19);
                    int eny2 = rndYe2.Next(1, 19);


                    int enx3 = rndXe3.Next(1, 19);
                    int eny3 = rndYe3.Next(1, 19);

                    e1.x = enx1;
                    e1.y = eny1;
                    e2.x = enx2;
                    e2.y = eny2;
                    e3.x = enx3;
                    e3.y = eny3;

                    Console.SetCursorPosition(enx1, eny1);
                    Console.Write(e1.classE);

                    Console.SetCursorPosition(enx2, eny2);
                    Console.Write(e2.classE);

                    Console.SetCursorPosition(enx3, eny3);
                    Console.Write(e3.classE);

                        a += 1;
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (map.tiles[player.GetX(), player.GetY() - 1] == ' ')
                                {
                                    player.MoveUp();
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (map.tiles[player.GetX(), player.GetY() + 1] == ' ')
                                {
                                    player.MoveDown();
                                }
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                if (map.tiles[player.GetX() - 1, player.GetY()] == ' ')
                                {
                                    player.MoveLeft();
                                }
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (map.tiles[player.GetX() + 1, player.GetY()] == ' ')
                                {
                                    player.MoveRight();
                                }
                                break;
                            }
                    }

                }
            }
        }
    }
}