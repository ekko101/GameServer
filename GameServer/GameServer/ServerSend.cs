namespace GameServer
{
    public class ServerSend
    {

        public static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            // Server.clients
        }
        
        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);
                
                SendTCPData(_toClient, _packet);
            }
        }
    }
}