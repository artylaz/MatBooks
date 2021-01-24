using System;

namespace MatBooks
{
    class Formulas
    {
        public Formulas(double W, double tB, double d)
        {
            this.W = W;
            this.tB = tB;
            this.d = d;

            parameters = TemperatureDependenceOfParameters.GetParameters(tB);
        }

        public double W { get; set; }
        public double tB { get; set; }
        public double d { get; set; }

        Parameters parameters;

        public double Re()
        {

            return W * d / parameters.V * Math.Pow(10, 6);
        }

        public double NuKor
        {
            get => 0.21 * Math.Pow(Re(), 0.65);
        }

        public double NuShakh
        {
            get => 0.37 * Math.Pow(Re(), 0.6);
        }

        public double a3r(double Nu)
        {
            return Nu * parameters.Lambda * Math.Pow(10, -2) / d;
        }

    }
    
}
