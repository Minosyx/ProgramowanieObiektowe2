using System;
namespace Wielomian
{
    public class Wielomian : ICloneable
    {
        private float[] wspolczynniki;
        public int Stopien {
            get => wspolczynniki.Length - 1;
        }
        public Wielomian(){
            wspolczynniki = new float[] {1};
        }
        public Wielomian(float[] wspolczynniki){
            this.wspolczynniki = new float[wspolczynniki.Length];
            wspolczynniki.CopyTo(this.wspolczynniki, 0);
        }
        public Wielomian(Wielomian w){
            this.wspolczynniki = null;
            this.wspolczynniki = new float[w.Stopien + 1];
            w.wspolczynniki.CopyTo(this.wspolczynniki, 0);
        }
        public object Clone() => new Wielomian(wspolczynniki);
        public float this[int index]{
            get {
                if (index >= 0 && index <= Stopien)
                    return wspolczynniki[index];
                else
                    return 0;
            }
            set => wspolczynniki[index] = value;
        }
        public static Wielomian operator +(Wielomian w) => w;
        public static Wielomian operator -(Wielomian w){
            float[] nwsp = new float[w.Stopien + 1];
            int i = 0;
            foreach (float wsp in w.wspolczynniki){
                nwsp[i++] = -wsp;
            }
            return new Wielomian(nwsp);
        }
        public static Wielomian operator +(Wielomian w1, Wielomian w2){
            Wielomian dluzszy, krotszy;
            if (w1.Stopien > w2.Stopien){
                dluzszy = w1;
                krotszy = w2;
            }
            else {
                dluzszy = w2;
                krotszy = w1;
            }
            float[] sumaWspolczynnikow = new float[dluzszy.Stopien + 1];
            for (int i = 0; i <= dluzszy.Stopien; i++){
                if (i <= krotszy.Stopien)
                    sumaWspolczynnikow[i] = krotszy[i] + dluzszy[i];
                else
                    sumaWspolczynnikow[i] = dluzszy[i];
            }
            return new Wielomian(sumaWspolczynnikow);
        }
        public static Wielomian operator -(Wielomian w1, Wielomian w2) => w1 + (-w2);
        public float Wartosc(float num){
            float sum = 0;
            for (int i = 0; i <= Stopien; i++){
                sum += this[i] * (float)Math.Pow(num, i);
            }
            return sum;
        }
        public static explicit operator string(Wielomian w){
            string _wielomian = "";
            for (int i = w.Stopien; i >= 0; i--){
                if (i > 1 && w[i] > 0)
                    _wielomian += $"+{w[i]}x^{i}";
                else if (i > 1 && w[i] < 0)
                    _wielomian += $"{w[i]}x^{i}";
                else if (i == 1 && w[i] > 0)
                    _wielomian += $"+{w[i]}x";
                else if (i == 1 && w[i] < 0)
                    _wielomian += $"{w[i]}x";
                else if (i == 0 && w[i] > 0)
                    _wielomian += $"+{w[i]}";
                else if (i == 0 && w[i] < 0)
                    _wielomian += $"{w[i]}";
                else if (i == 0 && w.Stopien == 0)
                    _wielomian += 0;
                else
                    continue;
            }
            if (_wielomian == "")
                _wielomian = "0";
            else if (_wielomian[0] == '+'){
                _wielomian = _wielomian.Substring(1);
            }
            return _wielomian;
        }
        public static explicit operator float[](Wielomian w) {
            float[] wsp = new float[w.Stopien + 1];
            w.wspolczynniki.CopyTo(wsp, 0);
            return wsp;
        }
        public static explicit operator double[](Wielomian w){
            double[] wsp = new double[w.Stopien + 1];
            w.wspolczynniki.CopyTo(wsp, 0);
            return wsp;
        }
        public override string ToString() => (string)this;
    }
}