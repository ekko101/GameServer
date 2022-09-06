using System;
using System.Net.Sockets;

namespace GameServer
{
    public class Client
    {
        public static int dataBufferSize = 4096;
        
        public int id;
        public Tcp tcp;

        public Client(int _clientID)
        {
            id = _clientID;
            tcp = new Tcp(id);
        }
        
        public class Tcp
        {
            public TcpClient socket;

            private readonly int id;
            private NetworkStream stream;
            private byte[] recieveBuffer;
            public Tcp(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                recieveBuffer = new byte[dataBufferSize];

                stream.BeginRead(recieveBuffer, 0, dataBufferSize, ReceiveCallBack, null);
                
                //TODO: send welcome packet
                
            }

            private void ReceiveCallBack(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        //TODO:disconnect
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(recieveBuffer, _data, _byteLength);
                    
                    //TODO: handle data
                    stream.BeginRead(recieveBuffer, 0, dataBufferSize, ReceiveCallBack, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error receiving TCP data: {e}");
                    //TODO: disconnect
                }
            }
        }
        
    }
}