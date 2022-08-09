namespace Cars
{
    public class Car : ICar
    {
        private string model;
        private string color;

        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
