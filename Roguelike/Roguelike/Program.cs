using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
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
                this.gold = gold * 0;
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

        public Enemy(int hp, int atk, int def, int classE)
        {
            if (classE == 1)
            {
                this.hp = hp * 3;
                this.atk = atk * 1;
                this.def = def * 1;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob1.txt";
            }

            if (classE == 2)
            {
                this.hp = hp * 4;
                this.atk = atk * 2;
                this.def = def * 2;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob2.txt";
            }
            if (classE == 3)
            {
                this.hp = hp * 7;
                this.atk = atk * 10;
                this.def = def * 1;
                this.enemyPath = "C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\mob3.txt";
            }


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
                    this.img = 'Ô'; // дф +2 на карте
                    this.name = "Крышка от кастрюли";
                    this.massage = "А где сама кастрюля?";
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
                        if(p1.gold >= 10)
                        {
                            index++;
                            p1.gold -= 10;
                            p1.atk += 4;
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
                Console.WriteLine("Монстр повержен!!!");
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
                var e1 = new Enemy(1, 1, 1, classE);
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

    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(20, 20);
            map.Draw();
            Player player = new Player(1, 1, 1, 1, 1, 1, 1);
            Enemy enemy = new Enemy(1, 1, 1, 2);
            Trader trader = new Trader();
            Fight fight = new Fight();

            while (true)
            {
                Console.Clear();

                map.Draw();

                Console.WriteLine("s - перейти в магазин");

                Console.SetCursorPosition(player.GetX(), player.GetY());

                Console.Write('@');

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
   