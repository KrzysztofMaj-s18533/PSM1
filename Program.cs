using System;

namespace PSM_1_sinus
{

    class sinEstimator
    {
        private int sinDegree;
        private double sinRadians;
        private double sinFinalNum;
        private double recentEstim = -2;
        private bool changeSign = false;
        public sinEstimator(int i)
        {
            this.sinDegree = i;
            this.sinRadians = (sinDegree * Math.PI) / 180;
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

        static int factorial(int fac)
        {
            int result = 1;
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

            Console.WriteLine("Sin(" + sinDegree + ") ~= " + recentEstim);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("======================");
            var sine = new sinEstimator(450);
            sine.estimate(15);
            sine.showEstim();
            Console.WriteLine("======================");
        }
    }
}
