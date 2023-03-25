using System;
using System.CodeDom;
using System.Collections.Generic;
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
        public int cord = 10;
    }
    public class Player: Character 
    {
        public int classP;

        public Player(int hp, int atk, int def, int classP)
        {
            if(classP == 1)
            {
                this.hp = hp * 10;
                this.atk = atk * 2;
                this.def = def * 1;
            }
            else if(classP == 2)
            {
                this.hp = hp * 15;
                this.atk= atk * 1;
                this.def = def * 1;
            }
        }

    }


    public class Enemy : Character 
    {
        public int classE;

        public Enemy(int hp,int atk, int def, int classE)
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
            for(int i = 1; i <= 5; i++)
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
    public void draw()
    {

    }
    public void keyEvent()
    {

    }

    public void startGame()
    {
        draw();
        keyEvent();
        foreach(var e in enemies)
        {
            if(e.cord == p1.cord)
            {
                Fight.start(p1, e);
            }
        }
       
    }
    public static class Fight
    {
        public static void start(Character p1, Enemy e1 )
        {
            p1.hp -= 10;
        }
    }