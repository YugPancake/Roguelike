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
        public int x;
        public int y;
    }

    public class Player : Character
    {
        public int classP;

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

    //public void draw()
    //{

    //}

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
        static void Main(String[] args)
        {
            Items stick = new Items(1);
            Items betterStick = new Items(2);
            Items heal = new Items(3);
            Items shield = new Items(4);


            string line;
            var textFile = new StreamReader("C:\\Users\\yugbl\\source\\repos\\Roguelike\\Roguelike\\traider.txt");
            while ((line = textFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            textFile.Close();
            Console.ReadLine();
        }
    }
}
   