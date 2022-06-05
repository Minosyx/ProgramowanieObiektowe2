namespace Punkt
{
    public class Punkt
    {
        private float x, y;
        public Punkt(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }
        public void Przesun(float a, float b)
        {
            x += a;
            y += b;
        }
        public void Przesun(Punkt p)
        {
            x = p.x;
            y = p.y;
        }
        public void Odbij()
        {
            x = (x == 0) ? 0 : -x;
            y = (y == 0) ? 0 : -y;
        }
        public float X
        {
            get => x;
            private set => x = value;
        }
        public float Y
        {
            get => y;
            private set => y = value;
        }
        public override string ToString() => $"({x}, {y})";
    }
}