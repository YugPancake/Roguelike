﻿using System;
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

        public Enemy(int hp, int atk, int def, int classE)
        {
            if (classE == 1)
            {
                this.hp = hp * 3;
                this.atk = atk * 1;
                this.def = def * 1;
            }

            if (classE == 2)
            {
                this.hp = hp * 4;
                this.atk = atk * 2;
                this.def = def * 2;
            }
            if (classE == 3)
            {
                this.hp = hp * 7;
                this.atk = atk * 10;
                this.def = def * 1;
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

            while (true)
            {
                Console.Clear();

                map.Draw();

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
                }
            }
        }
    }
}
   