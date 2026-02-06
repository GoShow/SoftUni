using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }

        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount { get => Servers.Count; }

        public void AddServer(Server server)
        {
            if (Servers.Count < Slots && !Servers.Any(s => s.SerialNumber == server.SerialNumber))
            {
                Servers.Add(server);
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            Server server = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);

            bool result = Servers.Remove(server);

            return result;
        }

        public string GetHighestPowerUsage()
        {
            Server server = Servers.MaxBy(s => s.PowerUsage);

            return server.ToString();
        }

        public int GetTotalCapacity()
            => Servers.Sum(s => s.Capacity);

        public string DeviceManager()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{GetCount} servers operating:");

            foreach (Server server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
