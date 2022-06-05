using System;

namespace Zespolona
{
    public class Zespolona
    {
        private float re;
        private float im;
        public float Re {
            get => re;
        }
        public float Im {
            get => im;
        }
        public Zespolona(float re = 0, float im = 0){
            this.re = re;
            this.im = im;
        }
        public Zespolona(Zespolona z){
            this.re = z.re;
            this.im = z.im;
        }
        public static Zespolona operator +(Zespolona z) => z;
        public static Zespolona operator -(Zespolona z) => new Zespolona(-z.re, -z.im);
        public static Zespolona operator +(Zespolona z1, Zespolona z2) => new Zespolona(z1.re + z2.re, z1.im + z2.im);
        public static Zespolona operator +(Zespolona z1, int num) => new Zespolona(z1.re + num, z1.im);
        public static Zespolona operator +(int num, Zespolona z) => z + num;
        public static Zespolona operator -(Zespolona z1, Zespolona z2) => z1 + (-z2);
        public static Zespolona operator -(Zespolona z, int num) => z + (-num);
        public static Zespolona operator -(int num, Zespolona z) => num + (-z);
        public static Zespolona operator *(Zespolona z1, Zespolona z2) => new Zespolona((z1.re * z2.re) - (z1.im * z2.im), (z1.im * z2.re) + (z1.re * z2.im));
        public static Zespolona operator *(Zespolona z, int num) => new Zespolona(z.re * num, z.im * num);
        public static Zespolona operator *(int num, Zespolona z) => z * num;
        public static Zespolona operator /(Zespolona z1, Zespolona z2){
            Zespolona z = new Zespolona();
            float mian = z2.re * z2.re + z2.im * z2.im;
            if (mian == 0)
                throw new ArgumentOutOfRangeException("mian", "Dzielenie przez zero!");
            z.re = (z1.re * z2.re + z1.im * z2.im) / mian;
            z.im = (z1.im * z2.re - z1.re * z2.im) / mian;
            return z;
        }
        public static Zespolona operator /(Zespolona z1, int num){
            if(num == 0)
                throw new ArgumentOutOfRangeException("num", "Dzielenie przez zero!");
            return new Zespolona(z1.re / (float)num, z1.im / (float)num);
        }
        public static Zespolona operator /(int num, Zespolona z1){
            if(z1.re == 0 && z1.im == 0)
                throw new ArgumentOutOfRangeException("num", "Dzielenie przez zero!");
            Zespolona tmp = new Zespolona(z1.re, - z1.im);
            Zespolona licznik = num * tmp;
            Zespolona mian = z1 * tmp;
            return new Zespolona(licznik.re / mian.re, licznik.im / mian.re);
        }
        public static bool operator ==(Zespolona z1, Zespolona z2) => z1.re == z2.re && z1.im == z2.im;
        public static bool operator !=(Zespolona z1, Zespolona z2) => z1.re != z2.re || z1.im != z2.im;
        public static bool operator <(Zespolona z1, Zespolona z2){
            if (z1.im != 0 || z2.im != 0){
                throw new ArgumentException("Liczby zespolone nie posiadają relacji porządku!", "z1.im, z2.im");
            }
            return z1.re < z2.re;
        }
        public static bool operator >(Zespolona z1, Zespolona z2){
            if (z1.im != 0 || z2.im != 0){
                throw new ArgumentException("Liczby zespolone nie posiadają relacji porządku!", "z1.im, z2.im");
            }
            return z1.re > z2.re;
        }
        public static Zespolona operator ++(Zespolona z){
            z.re++;
            return z;
        }
        public static Zespolona operator --(Zespolona z){
            z.re--;
            return z;
        }
        public static explicit operator int(Zespolona z) => (int)Math.Sqrt(z.re * z.re + z.im * z.im);
        public static explicit operator double(Zespolona z) => Math.Sqrt(z.re * z.re + z.im * z.im);
        public override bool Equals(Object obj){
            if (obj == null || !this.GetType().Equals(obj.GetType()))
                return false;
            else{
                Zespolona z = (Zespolona) obj;
                return (re == z.re) && (im == z.im);
            }
        }
        public override int GetHashCode() => Tuple.Create(re, im).GetHashCode();
        public override string ToString() => $"z = ({re}; {im}i)";
    }
}