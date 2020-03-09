using System;

namespace PSM_1_sinus
{

    class sinEstimator
    {
        private bool isRad;
        private double sinDegree;
        private double sinRadians;
        private double sinFinalNum;
        private double recentEstim = -2;
        private bool changeSign = false;
        public sinEstimator(double i, bool isRad)
        {
            if (isRad)
            {
                this.sinRadians = i;
                this.isRad = true;
            }
            else{
                this.sinDegree = i;
                this.sinRadians = (sinDegree * Math.PI) / 180;
                this.isRad = false;
            }
            this.sinFinalNum = sinRadians % (Math.PI * 2);

            if(Math.PI/2 < sinFinalNum && sinFinalNum <= Math.PI)
            {
                sinFinalNum = (Math.PI - sinFinalNum);
            }else if(Math.PI < sinFinalNum && sinFinalNum <= (3 / 2) * Math.PI)
            {
                sinFinalNum = (sinFinalNum - Math.PI);
                changeSign = true;
            }else if((3 / 2) * Math.PI < sinFinalNum && sinFinalNum < 2 * Math.PI)
            {
                sinFinalNum = (2 * Math.PI - sinFinalNum);
                changeSign = true;
            }
        }

        static double factorial(int fac)
        {
            double result = 1;
            while (fac > 1) result *= fac--;
            return result;
        }

        public void estimate(int eD)
        {
            int count = 0;
            int x = 1;
            double currEst = 0.0;

            while(count < eD)
            {
                if(count%2 == 0)
                {
                    currEst = currEst + (Math.Pow(sinFinalNum, x) / factorial(x));
                    x += 2;
                }
                else
                {
                    currEst = currEst - (Math.Pow(sinFinalNum, x) / factorial(x));
                    x += 2;
                }
                count++;
            }

            if (changeSign)
            {
                currEst = currEst * (-1);
            }

            recentEstim = currEst;
        }

        public void showEstim()
        {
            if (recentEstim == -2)
            {
                this.estimate(5);
            }
            double libSinEstim = Math.Sin(sinRadians);

            double diff;

            if (libSinEstim > recentEstim)
            {
                diff = libSinEstim - recentEstim;
            }
            else
            {
                diff = recentEstim - libSinEstim;
            }

            if (isRad)
            {
                Console.WriteLine("Sin(" + sinRadians + ") ~= " + recentEstim + " Roznica miedzy funkcja z biblioteki matematycznej wynosi: " + diff);
            }
            else {
                Console.WriteLine("Sin(" + sinDegree + " stopni) ~= " + recentEstim + " Roznica miedzy funkcja z biblioteki matematycznej wynosi: " + diff);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("======================");
            var sineDeg = new sinEstimator(30, false);
            sineDeg.estimate(1);
            sineDeg.showEstim();
            sineDeg.estimate(2);
            sineDeg.showEstim();
            sineDeg.estimate(3);
            sineDeg.showEstim();
            sineDeg.estimate(4);
            sineDeg.showEstim();
            sineDeg.estimate(5);
            sineDeg.showEstim();
            sineDeg.estimate(6);
            sineDeg.showEstim();
            sineDeg.estimate(7);
            sineDeg.showEstim();
            sineDeg.estimate(8);
            sineDeg.showEstim();
            sineDeg.estimate(9);
            sineDeg.showEstim();
            sineDeg.estimate(10);
            sineDeg.showEstim();

            Console.WriteLine("");

            var sineRad = new sinEstimator(Math.PI/2, true);
            sineRad.estimate(1);
            sineRad.showEstim();
            sineRad.estimate(2);
            sineRad.showEstim();
            sineRad.estimate(3);
            sineRad.showEstim();
            sineRad.estimate(4);
            sineRad.showEstim();
            sineRad.estimate(5);
            sineRad.showEstim();
            sineRad.estimate(6);
            sineRad.showEstim();
            sineRad.estimate(7);
            sineRad.showEstim();
            sineRad.estimate(8);
            sineRad.showEstim();
            sineRad.estimate(9);
            sineRad.showEstim();
            sineRad.estimate(10);
            sineRad.showEstim();
            Console.WriteLine("======================");
        }
    }
}
