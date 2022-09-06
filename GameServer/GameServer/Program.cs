using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GameServer";

            Server.Start(50, 26950);
            Console.ReadKey();
        }
    }
}