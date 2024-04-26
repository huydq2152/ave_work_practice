using System;

namespace Common
{
    [Serializable]
    public class SocketMessage
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime TimeSent { get; set; }

        public DateTime TimeReceived { get; set; }

        public int ThreadId { get; set; }

    }
}
