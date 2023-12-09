using Sockets;
using SocketS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSourceFileCopy.Remote_IP_System
{
    public static class Types
    {
        public static SocketServer socketServer { get; set; } = new SocketServer();
        public static SocketClient socketClient { get; set; } = new SocketClient();
    }
}
