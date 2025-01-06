namespace RobotFactory
{
    using System.Collections.Generic;
    using System.Text;
    public class Robot
    {
        public Robot(string model, double price, int interfaceStandard)
        {
            Model = model;
            Price = price;
            InterfaceStandard = interfaceStandard;
            this.Supplements = new List<Supplement>();
        }

        public string Model { get; set; }

        public double Price { get; set; }

        public int InterfaceStandard { get; set; }

        public List<Supplement> Supplements { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Robot model: {Model} IS: {InterfaceStandard}, Price: {Price:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
