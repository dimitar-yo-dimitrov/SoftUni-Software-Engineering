using System.Text;

namespace Cars
{
    public class Seat : Car, ICar
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine(this.Start());
            result.AppendLine(this.Stop());

            return result.ToString().TrimEnd();
        }
    }
}