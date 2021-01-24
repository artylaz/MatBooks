using System;
using System.Collections.Generic;

namespace MatBooks
{

    public class TemperatureDependenceOfParameters
    {
        private static Dictionary<double, Parameters> TemperatureDependences = new Dictionary<double, Parameters>()
{
        {0,new Parameters(13.3,2.44,0.71) },
        {100,new Parameters(23.1,3.21,0.69) },
        {200,new Parameters(34.8,3.93,0.68) },
        {400,new Parameters(63.0,5.21,0.68) },
        {600,new Parameters(96.8,6.22,0.70) },
        {800,new Parameters(134.8,7.18,0.71) },
        {900,new Parameters(155.1,7.63,0.72) },
        {1000,new Parameters(177.1,8.07,0.72) },
};


        public static Parameters GetParameters(double temperature)
        {
            double[] temps = new List<double>(TemperatureDependences.Keys).ToArray();

            for (int i = 0; i < temps.Length - 1; i++)
            {
                if (temperature == temps[i]) return TemperatureDependences[i];

                if (temperature > temps[i] && temperature < temps[i + 1])
                {
                    double lerpStrength = (temperature - (temps[i + 1] - temps[i])) / (temps[i + 1] - temps[i]);

                    var newV = TemperatureDependences[temps[i]].V + (TemperatureDependences[temps[i + 1]].V - TemperatureDependences[temps[i]].V) * lerpStrength;
                    var newLambda = TemperatureDependences[temps[i]].Lambda + (TemperatureDependences[temps[i + 1]].Lambda - TemperatureDependences[temps[i]].Lambda) * lerpStrength;
                    var newPr = TemperatureDependences[temps[i]].Pr + (TemperatureDependences[temps[i + 1]].Pr - TemperatureDependences[temps[i]].Pr) * lerpStrength;

                    return new Parameters(newV, newLambda, newPr);
                }
            }
            return null;
        }
    }
    // 100 125 150 175 200

    public class Parameters
    {
        public Parameters(double _V, double _Lambda, double _Pr) { V = _V; Lambda = _Lambda; Pr = _Pr; }
        public double V, Lambda, Pr;
    }
}