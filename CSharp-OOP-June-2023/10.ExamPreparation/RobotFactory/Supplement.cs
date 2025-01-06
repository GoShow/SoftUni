namespace RobotFactory
{
    using System.Text;
    public class Supplement
    {
        public Supplement(string name, int interfaceStandard)
        {
            Name = name;
            InterfaceStandard = interfaceStandard;
        }

        public string Name { get; set; }

        public int InterfaceStandard { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Supplement: {this.Name} IS: {this.InterfaceStandard}");
            return sb.ToString().TrimEnd();
        }
    }
}
