using System;
using System.Collections.Generic;
using System.Text;

namespace SOI
{
    public interface IOcenialny
    {
        float SredniaOcen { get; }
        float NajlepszaOcena { get; }
        float NajgorszaOcena { get; }
        void DodajOcene(float ocena, int amount);
        void DodajOcene(float[] oceny);
        void UsunOcene(float ocena, int amount);
    }
}
