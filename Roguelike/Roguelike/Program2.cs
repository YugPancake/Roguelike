using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Character
    {
        public int hp;
        public int atk;
        public int def;
        public int gold;
    }

    public class Player : Character
    {
        public int classP;
        private int x;
        private int y;
        public Player(int x, int y, int hp, int atk, int def, int gold, int classP)
        {
            this.x = x;
            this.y = y;
            if (classP == 1)
            {
                this.hp = hp * 10;
                this.atk = atk * 2;
                this.def = def * 1;
                this.gold = gold * 100;
            }
            else if (classP == 2)
            {
                this.hp = hp * 15;
                this.atk = atk * 1;
                this.def = def * 1;
                this.gold = gold * 0;
            }
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

        public void Inventory()
        {
            List<Items> Inventory;
        }
    }

    public class Enemy : Character
    {
        public int classE;
        public string enemyPath;

        public int x;
        public int y;

        public int XMovementValue;
        public int YMovementValue;

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

        public Enemy(int hp, int atk, int def, int gold, int classE)
        {
            if (classE == 1)
            {
                this.hp = hp * 3;
                this.atk = atk * 1;
                this.def = def * 1;
                this.gold = 4;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob1.txt";
            }

            if (classE == 2)
            {
                this.hp = hp * 4;
                this.atk = atk * 2;
                this.def = def * 2;
                this.gold = 8;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob2.txt";
            }
            if (classE == 3)
            {
                this.hp = hp * 7;
                this.atk = atk * 10;
                this.def = def * 1;
                this.gold = 15;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob3.txt";
            }


        }
        public void EWander(int EnemyID)
        {
            Random rnde1 = new Random();
            Random rnde2 = new Random();
            Random rnde3 = new Random();

            int enw1 = rnde1.Next(1, 5);
            int enw2 = rnde2.Next(1, 5);
            int enw3 = rnde3.Next(1, 5);


            if (EnemyID == 1)
            {
                if (enw1 == 1)
                {
                    this.x += 1;
                    this.XMovementValue = 1;
                }
                if (enw1 == 2)
                {
                    this.x -= 1;
                    this.XMovementValue = -1;
                }
                if (enw1 == 3)
                {
                    this.y += 1;
                    this.YMovementValue = 1;
                }
                if (enw1 == 4)
                {
                    this.y -= 1;
                    this.YMovementValue = -1;
                }
            }
            if (EnemyID == 2)
            {
                if (enw2 == 1)
                {
                    this.x += 1;
                    this.XMovementValue = 1;
                }
                if (enw2 == 2)
                {
                    this.x -= 1;
                    this.XMovementValue = -1;
                }
                if (enw2 == 3)
                {
                    this.y += 1;
                    this.YMovementValue = 1;
                }
                if (enw2 == 4)
                {
                    this.y -= 1;
                    this.YMovementValue = -1;
                }
            }
            if (EnemyID == 3)
            {
                if (enw3 == 1)
                {
                    this.x += 1;
                    this.XMovementValue = 1;
                }
                if (enw3 == 2)
                {
                    this.x -= 1;
                    this.XMovementValue = -1;
                }
                if (enw3 == 3)
                {
                    this.y += 1;
                    this.YMovementValue = 1;
                }
                if (enw3 == 4)
                {
                    this.y -= 1;
                    this.YMovementValue = -1;
                }
            }

        }
    }

    public class Items
    {
        public char img;
        public string name;
        public string massage;
        public int id;
        public int x;
        public int y;
        public int stat;
        public Items(int id)
        {
            switch (id)
            {
                case 1:
                    this.img = '/'; // атк +2 на карте
                    this.name = "Палка";
                    this.massage = "Просто палка.";
                    this.x = 5;
                    this.y = 3;
                    this.stat = 2;
                    break;
                case 2:
                    this.img = 'Ô'; // дф +2 на карте
                    this.name = "Крышка от кастрюли";
                    this.massage = "А где сама кастрюля?";
                    this.x = 12;
                    this.y = 6;
                    this.stat = 2;
                    break;
                case 3:
                    this.img = '♥'; // хп +2 на карте
                    this.name = "Сердце";
                    this.massage = "Вы напоняетесь решимостью.";
                    break;
                case 4:
                    this.img = 'f'; // атк +4 продажа
                    this.name = "Палка с гвоздями";
                    this.massage = "Просто палка... Кто вбил в нее столько гроздей?";
                    break;
                case 5:
                    this.img = 'U'; // дф + 4 продажа
                    this.name = "Ведро";
                    this.massage = "Наконец-то! Ведро! Да, да, да! Обожаю это ведро.";
                    break;
                case 6:
                    this.img = '∫'; // атк + 6 продажа
                    this.name = "Труба";
                    this.massage = "Они прокладывают трубы до августа.";
                    break;
                case 7:
                    this.img = '◍'; // ничего не делает продажа
                    this.name = "Пчела";
                    this.massage = "Она бзикает.";
                    break;
            }
        }
    }

    public class Trader
    {
        public int x;
        public int y;
        public string[] tradeLines;
        private string tradePath;
        private string noGoldPath;
        public string[] noGoldLines;
        public int key = 0;
        int index = 1;

        List<Items> traideItem;

        public void createTradeItems()
        {
            for (int i = 4; i <= 7; i++)
            {
                var i1 = new Items(i);
                traideItem.Add(i1);
            }
        }

        public void tradeWindow(Player p1)
        {
            tradePath = $"C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\trader{index}.txt";
            tradeLines = File.ReadAllLines(tradePath);
            foreach (string s in tradeLines)
            {
                Console.WriteLine(s);
            }
            noGoldPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\nogold.txt";
            noGoldLines = File.ReadAllLines(noGoldPath);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.K && index < 5)
            {
                switch (index)
                {
                    case 1:
                        if (p1.gold >= 10)
                        {
                            index++;
                            p1.gold -= 10;
                            p1.atk += 4;
                            Console.WriteLine("Вы получили палку с гвоздями");
                            Console.WriteLine("- 10 золота");
                            Console.WriteLine("+ 4 атаки");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            foreach (string s in noGoldLines)
                            {
                                Console.WriteLine(s);
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if (p1.gold >= 25)
                        {
                            index++;
                            p1.gold -= 25;
                            p1.def += 2;
                            Console.WriteLine("Вы получили ведро");
                            Console.WriteLine("- 25 золота");
                            Console.WriteLine("+ 2 защиты");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            foreach (string s in noGoldLines)
                            {
                                Console.WriteLine(s);
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (p1.gold >= 50)
                        {
                            index++;
                            p1.gold -= 50;
                            p1.atk += 4;
                            Console.WriteLine("Вы получили трубу");
                            Console.WriteLine("- 50 золота");
                            Console.WriteLine("+ 4 атаки");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            foreach (string s in noGoldLines)
                            {
                                Console.WriteLine(s);
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        if (p1.gold >= 999)
                        {
                            index++;
                            p1.gold -= 999;
                            Console.WriteLine("Вы получили пчелу");
                            Console.WriteLine("- 999 золота");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            foreach (string s in noGoldLines)
                            {
                                Console.WriteLine(s);
                            }
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }

    public class Fight
    {
        public string[] lines1;
        public string[] gameOverLines;
        public string gameOverPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\gameover.txt";

        public int start(Player p1, Enemy e1)
        {
            Console.Clear();

            lines1 = File.ReadAllLines(e1.enemyPath);
            //lines2 = File.ReadAllLines(e1.enemyPath);
            int maxE1Xp = e1.hp;
            int maxP1Xp = p1.hp;


            foreach (string s in lines1)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine($"     Игрок: {maxP1Xp} / {maxP1Xp}                                          Монстр: {maxE1Xp} / {maxE1Xp} ");
            Console.ReadKey();

            while (e1.hp > 0 && p1.hp > 0)
            {

                Console.Clear();

                foreach (string s in lines1)
                {
                    Console.WriteLine(s);
                }
                e1.hp = e1.hp - (p1.atk - e1.def);
                Console.WriteLine($"     Игрок: {p1.hp} / {maxP1Xp}                                          Монстр: {e1.hp} / {maxE1Xp} ");
                Console.WriteLine("Герой бьет");

                Console.ReadKey();

                if (e1.hp > 0)
                {
                    Console.Clear();
                    foreach (string s in lines1)
                    {
                        Console.WriteLine(s);
                    }
                    p1.hp = p1.hp - (e1.atk - p1.def);
                    Console.WriteLine($"     Игрок: {p1.hp} / {maxP1Xp}                                          Монстр: {e1.hp} / {maxE1Xp} ");
                    Console.WriteLine("Героя бьют");
                    Console.ReadKey();
                }
                else if (e1.hp <= 0)
                {
                    break;
                }
                else { break; }

            }
            if (e1.hp <= 0)
            {
                Console.Clear();
                p1.gold += e1.gold;
                Console.WriteLine("Монстр повержен!!!");
                Console.WriteLine($"Вы поулчили + {e1.gold} золота");
                Console.ReadKey();
                return 1;
            }
            else
            {
                Console.Clear();
                gameOverLines = File.ReadAllLines(gameOverPath);
                foreach (string s in gameOverLines)
                {
                    Console.WriteLine(s);
                }
                Environment.Exit(1);
                return 0;
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
                var e1 = new Enemy(1, 1, 1, 1, classE);
                enemies.Add(e1);
            }
        }

        public void createPlayer(int classP)
        {
            var p1 = new Player(1, 1, 1, 1, 1, 1, classP);
        }

    }

    class Map
    {

        public int width;
        public int height;
        public char[,] tiles;

        Items stick = new Items(1);
        Items cap = new Items(2);

        public Map(int width, int height)
        {

            this.width = width;
            this.height = height;
            tiles = new char[width, height];
            Generate();
            GenerateLeft1();
            GenerateLeft2();
            GenerateRight1();

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
                    if (y == stick.y && x == stick.x)
                    {
                        tiles[x, y] = stick.img;
                    }
                    else if (y == cap.y && x == cap.x)
                    {
                        tiles[x, y] = cap.img;
                    }
                    else
                    {
                        tiles[x, y] = ' ';
                    }
                }
            }
        }

        public void GenerateLeft1()
        {
            for (int x = 1; x < width / 2; x++)
            {
                for (int y = 1; y < height / 2; y++)
                {
                    tiles[x, y] = '#';

                    if (x == width / 4)
                    {
                        tiles[x, y] = '-';
                    }
                    if (y == height / 4)
                    {
                        tiles[x, y] = '|';
                    }
                }
            }
            for (int x = 1; x < (width / 2) - 1; x++)
            {
                for (int y = 1; y < (height / 2) - 1; y++)
                {
                    if (y == stick.y && x == stick.x)
                    {
                        tiles[x, y] = stick.img;
                    }
                    else if (y == cap.y && x == cap.x)
                    {
                        tiles[x, y] = cap.img;
                    }
                    else
                    {
                        tiles[x, y] = ' ';
                    }
                }
            }
        }
        public void GenerateLeft2()
        {
            for (int x = 1; x < width / 2; x++)
            {
                for (int y = 10; y < height - 1; y++)
                {
                    tiles[x, y] = '#';

                    if (x == (width / 2) + 4)
                    {
                        tiles[x, y] = '-';
                    }
                    if (y == (height / 2) + 4)
                    {
                        tiles[x, y] = '|';
                    }
                }
            }
            for (int x = 1; x < (width / 2) - 1; x++)
            {
                for (int y = 10; y < (height - 1); y++)
                {
                    if (y == stick.y && x == stick.x)
                    {
                        tiles[x, y] = stick.img;
                    }
                    else if (y == cap.y && x == cap.x)
                    {
                        tiles[x, y] = cap.img;
                    }
                    else
                    {
                        tiles[x, y] = ' ';
                    }
                }
            }

        }
        public void GenerateRight1()
        {
            for (int x = 18; x < width - 1; x++)
            {
                for (int y = 9; y < height / 2; y++)
                {
                    tiles[x, y] = '#';

                    if (x == (width / 2) + 9)
                    {
                        tiles[x, y] = '-';
                    }
                    if (y == height)
                    {
                        tiles[x, y] = '|';
                    }
                }
            }

        }
        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
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

    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(39, 20);
            map.Draw();
            Player player = new Player(1, 1, 1, 1, 1, 1, 1);

            Enemy e1 = new Enemy(1);
            Enemy e2 = new Enemy(2);
            Enemy e3 = new Enemy(3);

            Enemy enemy = new Enemy(1, 1, 1, 1, 1);
            Trader trader = new Trader();
            Fight fight = new Fight();
            Items stick = new Items(1);
            Items cap = new Items(2);
            int a = 0;

            while (true)
            {
                Console.Clear();

                map.Draw();

                Console.WriteLine("s - перейти в магазин");

                Console.SetCursorPosition(player.GetX(), player.GetY());

                Console.Write('@');


                Console.SetCursorPosition(e1.GetEnemyX(), e1.GetEnemyY());
                Console.Write(e1.classE);

                Console.SetCursorPosition(e2.GetEnemyX(), e2.GetEnemyY());
                Console.Write(e2.classE);

                Console.SetCursorPosition(e3.GetEnemyX(), e3.GetEnemyY());
                Console.Write(e3.classE);

                Thread.Sleep(100);

                while (a < 1)
                {
                    Random rndXe1 = new Random();
                    Random rndYe1 = new Random();


                    Random rndXe2 = new Random();
                    Random rndYe2 = new Random();


                    Random rndXe3 = new Random();
                    Random rndYe3 = new Random();


                    int enx1 = rndXe1.Next(1, 38);
                    int eny1 = rndYe1.Next(1, 19);


                    int enx2 = rndXe2.Next(1, 38);
                    int eny2 = rndYe2.Next(1, 19);


                    int enx3 = rndXe3.Next(1, 38);
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
                            if (map.tiles[player.GetX(), player.GetY() - 1] == ' ' || map.tiles[player.GetX(), player.GetY() - 1] == '-' || map.tiles[player.GetX(), player.GetY() - 1] == stick.img || map.tiles[player.GetX(), player.GetY() - 1] == cap.img)
                            {
                                if (map.tiles[player.GetX(), player.GetY()] == stick.img)
                                {
                                    player.atk += stick.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }

                                if (map.tiles[player.GetX(), player.GetY()] == cap.img)
                                {
                                    player.def += cap.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }
                                player.MoveUp();


                                if (e1.x + e1.XMovementValue != 0 && e1.x + e1.XMovementValue != 38 && e1.y + e1.YMovementValue != 0 && e1.y + e1.YMovementValue != 19)
                                {
                                    e1.EWander(1);
                                }


                                else if (e1.x + e1.XMovementValue == 0)
                                {
                                    e1.x += 1;
                                }
                                else if (e1.x + e1.XMovementValue == 38)
                                {
                                    e1.x -= 1;
                                }
                                else if (e1.y + e1.YMovementValue == 0)
                                {
                                    e1.y += 1;
                                }
                                else if (e1.y + e1.YMovementValue == 19)
                                {
                                    e1.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                // прыжок через горизонтальную стену
                                if (e1.y + e1.YMovementValue == 9 && e1.y == 8)
                                {
                                    e1.y += 3;
                                }

                                if (e1.y + e1.YMovementValue == 9 && e1.y == 10)
                                {
                                    e1.y -= 3;
                                }*/










                                if (e2.x + e2.XMovementValue != 0 && e2.x + e1.XMovementValue != 38 && e2.y + e2.YMovementValue != 0 && e2.y + e2.YMovementValue != 19)
                                {
                                    e2.EWander(2);
                                }


                                else if (e2.x + e2.XMovementValue == 0)
                                {
                                    e2.x += 1;
                                }
                                else if (e2.x + e2.XMovementValue == 38)
                                {
                                    e2.x -= 1;
                                }
                                else if (e2.y + e2.YMovementValue == 0)
                                {
                                    e2.y += 1;
                                }
                                else if (e2.y + e2.YMovementValue == 19)
                                {
                                    e2.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }


                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                // прыжок через горизонтальную стену
                                if (e2.y + e2.YMovementValue == 9 && e2.y == 8)
                                {
                                    e2.y += 3;
                                }

                                if (e2.y + e2.YMovementValue == 9 && e2.y == 10)
                                {
                                    e2.y -= 3;
                                }*/


                                if (e3.x + e3.XMovementValue != 0 && e3.x + e3.XMovementValue != 38 && e3.y + e3.YMovementValue != 0 && e3.y + e3.YMovementValue != 19)
                                {
                                    e3.EWander(3);
                                }



                                else if (e3.x + e3.XMovementValue == 0)
                                {
                                    e3.x += 1;
                                }
                                else if (e3.x + e3.XMovementValue == 38)
                                {
                                    e3.x -= 1;
                                }
                                else if (e3.y + e3.YMovementValue == 0)
                                {
                                    e3.y += 1;
                                }
                                else if (e3.y + e3.YMovementValue == 19)
                                {
                                    e3.y -= 1;
                                }
                            }


                            /*// прыжок через вертикальную стену
                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }


                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            // прыжок через горизонтальную стену
                            if (e3.y + e3.YMovementValue == 9 && e3.y == 8)
                            {
                                e3.y += 3;
                            }

                            if (e3.y + e3.YMovementValue == 9 && e3.y == 10)
                            {
                                e3.y -= 3;
                            }*/
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (map.tiles[player.GetX(), player.GetY() + 1] == ' ' || map.tiles[player.GetX(), player.GetY() + 1] == '-' || map.tiles[player.GetX(), player.GetY() + 1] == stick.img || map.tiles[player.GetX(), player.GetY() + 1] == cap.img)
                            {
                                if (map.tiles[player.GetX(), player.GetY()] == stick.img)
                                {
                                    player.atk += stick.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }

                                if (map.tiles[player.GetX(), player.GetY()] == cap.img)
                                {
                                    player.def += cap.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }
                                player.MoveDown();


                                if (e1.x + e1.XMovementValue != 0 && e1.x + e1.XMovementValue != 38 && e1.y + e1.YMovementValue != 0 && e1.y + e1.YMovementValue != 19)
                                {
                                    e1.EWander(1);
                                }


                                else if (e1.x + e1.XMovementValue == 0)
                                {
                                    e1.x += 1;
                                }
                                else if (e1.x + e1.XMovementValue == 38)
                                {
                                    e1.x -= 1;
                                }
                                else if (e1.y + e1.YMovementValue == 0)
                                {
                                    e1.y += 1;
                                }
                                else if (e1.y + e1.YMovementValue == 19)
                                {
                                    e1.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                // прыжок через горизонтальную стену
                                if (e1.y + e1.YMovementValue == 9 && e1.y == 8)
                                {
                                    e1.y += 3;
                                }

                                if (e1.y + e1.YMovementValue == 9 && e1.y == 10)
                                {
                                    e1.y -= 3;
                                }*/










                                if (e2.x + e2.XMovementValue != 0 && e2.x + e1.XMovementValue != 38 && e2.y + e2.YMovementValue != 0 && e2.y + e2.YMovementValue != 19)
                                {
                                    e2.EWander(2);
                                }


                                else if (e2.x + e2.XMovementValue == 0)
                                {
                                    e2.x += 1;
                                }
                                else if (e2.x + e2.XMovementValue == 38)
                                {
                                    e2.x -= 1;
                                }
                                else if (e2.y + e2.YMovementValue == 0)
                                {
                                    e2.y += 1;
                                }
                                else if (e2.y + e2.YMovementValue == 19)
                                {
                                    e2.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }


                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                // прыжок через горизонтальную стену
                                if (e2.y + e2.YMovementValue == 9 && e2.y == 8)
                                {
                                    e2.y += 3;
                                }

                                if (e2.y + e2.YMovementValue == 9 && e2.y == 10)
                                {
                                    e2.y -= 3;
                                }*/


                                if (e3.x + e3.XMovementValue != 0 && e3.x + e3.XMovementValue != 38 && e3.y + e3.YMovementValue != 0 && e3.y + e3.YMovementValue != 19)
                                {
                                    e3.EWander(3);
                                }



                                else if (e3.x + e3.XMovementValue == 0)
                                {
                                    e3.x += 1;
                                }
                                else if (e3.x + e3.XMovementValue == 38)
                                {
                                    e3.x -= 1;
                                }
                                else if (e3.y + e3.YMovementValue == 0)
                                {
                                    e3.y += 1;
                                }
                                else if (e3.y + e3.YMovementValue == 19)
                                {
                                    e3.y -= 1;
                                }
                            }


                            /*// прыжок через вертикальную стену
                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }


                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            // прыжок через горизонтальную стену
                            if (e3.y + e3.YMovementValue == 9 && e3.y == 8)
                            {
                                e3.y += 3;
                            }

                            if (e3.y + e3.YMovementValue == 9 && e3.y == 10)
                            {
                                e3.y -= 3;
                            }*/
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (map.tiles[player.GetX() - 1, player.GetY()] == ' ' || map.tiles[player.GetX() - 1, player.GetY()] == '|' || map.tiles[player.GetX() - 1, player.GetY()] == stick.img || map.tiles[player.GetX() - 1, player.GetY()] == cap.img)
                            {
                                if (map.tiles[player.GetX(), player.GetY()] == stick.img)
                                {
                                    player.atk += stick.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }

                                if (map.tiles[player.GetX(), player.GetY()] == cap.img)
                                {
                                    player.def += cap.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }
                                player.MoveLeft();

                                if (e1.x + e1.XMovementValue != 0 && e1.x + e1.XMovementValue != 38 && e1.y + e1.YMovementValue != 0 && e1.y + e1.YMovementValue != 19)
                                {
                                    e1.EWander(1);
                                }


                                else if (e1.x + e1.XMovementValue == 0)
                                {
                                    e1.x += 1;
                                }
                                else if (e1.x + e1.XMovementValue == 38)
                                {
                                    e1.x -= 1;
                                }
                                else if (e1.y + e1.YMovementValue == 0)
                                {
                                    e1.y += 1;
                                }
                                else if (e1.y + e1.YMovementValue == 19)
                                {
                                    e1.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                // прыжок через горизонтальную стену
                                if (e1.y + e1.YMovementValue == 9 && e1.y == 8)
                                {
                                    e1.y += 3;
                                }

                                if (e1.y + e1.YMovementValue == 9 && e1.y == 10)
                                {
                                    e1.y -= 3;
                                }*/










                                if (e2.x + e2.XMovementValue != 0 && e2.x + e1.XMovementValue != 38 && e2.y + e2.YMovementValue != 0 && e2.y + e2.YMovementValue != 19)
                                {
                                    e2.EWander(2);
                                }


                                else if (e2.x + e2.XMovementValue == 0)
                                {
                                    e2.x += 1;
                                }
                                else if (e2.x + e2.XMovementValue == 38)
                                {
                                    e2.x -= 1;
                                }
                                else if (e2.y + e2.YMovementValue == 0)
                                {
                                    e2.y += 1;
                                }
                                else if (e2.y + e2.YMovementValue == 19)
                                {
                                    e2.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }


                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                // прыжок через горизонтальную стену
                                if (e2.y + e2.YMovementValue == 9 && e2.y == 8)
                                {
                                    e2.y += 3;
                                }

                                if (e2.y + e2.YMovementValue == 9 && e2.y == 10)
                                {
                                    e2.y -= 3;
                                }*/


                                if (e3.x + e3.XMovementValue != 0 && e3.x + e3.XMovementValue != 38 && e3.y + e3.YMovementValue != 0 && e3.y + e3.YMovementValue != 19)
                                {
                                    e3.EWander(3);
                                }



                                else if (e3.x + e3.XMovementValue == 0)
                                {
                                    e3.x += 1;
                                }
                                else if (e3.x + e3.XMovementValue == 38)
                                {
                                    e3.x -= 1;
                                }
                                else if (e3.y + e3.YMovementValue == 0)
                                {
                                    e3.y += 1;
                                }
                                else if (e3.y + e3.YMovementValue == 19)
                                {
                                    e3.y -= 1;
                                }
                            }


                            /*// прыжок через вертикальную стену
                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }


                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            // прыжок через горизонтальную стену
                            if (e3.y + e3.YMovementValue == 9 && e3.y == 8)
                            {
                                e3.y += 3;
                            }

                            if (e3.y + e3.YMovementValue == 9 && e3.y == 10)
                            {
                                e3.y -= 3;
                            }*/
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (map.tiles[player.GetX() + 1, player.GetY()] == ' ' || map.tiles[player.GetX() + 1, player.GetY()] == '|' || map.tiles[player.GetX() + 1, player.GetY()] == stick.img || map.tiles[player.GetX() + 1, player.GetY()] == cap.img)
                            {
                                if (map.tiles[player.GetX(), player.GetY()] == stick.img)
                                {
                                    player.atk += stick.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }

                                if (map.tiles[player.GetX(), player.GetY()] == cap.img)
                                {
                                    player.def += cap.stat;
                                    map.tiles[player.GetX(), player.GetY()] = ' ';
                                    stick.stat = 0;
                                }
                                player.MoveRight();
                                if (e1.x + e1.XMovementValue != 0 && e1.x + e1.XMovementValue != 38 && e1.y + e1.YMovementValue != 0 && e1.y + e1.YMovementValue != 19)
                                {
                                    e1.EWander(1);
                                }


                                else if (e1.x + e1.XMovementValue == 0)
                                {
                                    e1.x += 1;
                                }
                                else if (e1.x + e1.XMovementValue == 38)
                                {
                                    e1.x -= 1;
                                }
                                else if (e1.y + e1.YMovementValue == 0)
                                {
                                    e1.y += 1;
                                }
                                else if (e1.y + e1.YMovementValue == 19)
                                {
                                    e1.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 4 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 13 && e1.y + e1.YMovementValue >= 6 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 17)
                                {
                                    e1.x += 3;
                                }

                                if (e1.x + e1.XMovementValue == 18 && e1.y + e1.YMovementValue <= 18 && e1.y + e1.YMovementValue >= 15 && e1.x == 19)
                                {
                                    e1.x -= 3;
                                }


                                // прыжок через горизонтальную стену
                                if (e1.y + e1.YMovementValue == 9 && e1.y == 8)
                                {
                                    e1.y += 3;
                                }

                                if (e1.y + e1.YMovementValue == 9 && e1.y == 10)
                                {
                                    e1.y -= 3;
                                }*/










                                if (e2.x + e2.XMovementValue != 0 && e2.x + e1.XMovementValue != 38 && e2.y + e2.YMovementValue != 0 && e2.y + e2.YMovementValue != 19)
                                {
                                    e2.EWander(2);
                                }


                                else if (e2.x + e2.XMovementValue == 0)
                                {
                                    e2.x += 1;
                                }
                                else if (e2.x + e2.XMovementValue == 38)
                                {
                                    e2.x -= 1;
                                }
                                else if (e2.y + e2.YMovementValue == 0)
                                {
                                    e2.y += 1;
                                }
                                else if (e2.y + e2.YMovementValue == 19)
                                {
                                    e2.y -= 1;
                                }


                                /*// прыжок через вертикальную стену
                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 4 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }


                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 13 && e2.y + e2.YMovementValue >= 6 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 17)
                                {
                                    e2.x += 3;
                                }

                                if (e2.x + e2.XMovementValue == 18 && e2.y + e2.YMovementValue <= 18 && e2.y + e2.YMovementValue >= 15 && e2.x == 19)
                                {
                                    e2.x -= 3;
                                }

                                // прыжок через горизонтальную стену
                                if (e2.y + e2.YMovementValue == 9 && e2.y == 8)
                                {
                                    e2.y += 3;
                                }

                                if (e2.y + e2.YMovementValue == 9 && e2.y == 10)
                                {
                                    e2.y -= 3;
                                }*/


                                if (e3.x + e3.XMovementValue != 0 && e3.x + e3.XMovementValue != 38 && e3.y + e3.YMovementValue != 0 && e3.y + e3.YMovementValue != 19)
                                {
                                    e3.EWander(3);
                                }



                                else if (e3.x + e3.XMovementValue == 0)
                                {
                                    e3.x += 1;
                                }
                                else if (e3.x + e3.XMovementValue == 38)
                                {
                                    e3.x -= 1;
                                }
                                else if (e3.y + e3.YMovementValue == 0)
                                {
                                    e3.y += 1;
                                }
                                else if (e3.y + e3.YMovementValue == 19)
                                {
                                    e3.y -= 1;
                                }
                            }


                            /*// прыжок через вертикальную стену
                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 4 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }


                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 13 && e3.y + e3.YMovementValue >= 6 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 17)
                            {
                                e3.x += 3;
                            }

                            if (e3.x + e3.XMovementValue == 18 && e3.y + e3.YMovementValue <= 18 && e3.y + e3.YMovementValue >= 15 && e3.x == 19)
                            {
                                e3.x -= 3;
                            }

                            // прыжок через горизонтальную стену
                            if (e3.y + e3.YMovementValue == 9 && e3.y == 8)
                            {
                                e3.y += 3;
                            }

                            if (e3.y + e3.YMovementValue == 9 && e3.y == 10)
                            {
                                e3.y -= 3;
                            }*/
                            break;
                        }
               
                    case ConsoleKey.S:
                        {
                            Console.Clear();
                            trader.tradeWindow(player);
                            break;
                        }
                    case ConsoleKey.F:
                        {
                            fight.start(player, enemy);
                            break;
                        }
                }
            }
        }
    }
}
