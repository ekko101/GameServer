using System;

namespace GameServer
{
    public class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _cliendIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine(
                $"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if (_fromClient != _cliendIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong ID ({_cliendIdCheck})!");
                //TODO: sendPlayer into game
            }
        }
    }
}