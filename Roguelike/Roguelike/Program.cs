using System;



class Map
{
    private int width;
    private int height;
    private char[,] tiles;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.tiles = new char[width, height];
        Generate();
    }

    public void Generate()
    {
        Random rand = new Random();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (rand.Next(2) == 0)
                {
                    tiles[x, y] = '.';
                }
                else
                {
                    tiles[x, y] = '#';
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
class Player
{
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
}

class Program
{
    static void Main(string[] args)
    {
        Map map = new Map(20, 10);
        map.Draw();
        Player player = new Player(10, 5);

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
                    player.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    player.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    player.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    player.MoveRight();
                    break;
            }
        }
    }
}