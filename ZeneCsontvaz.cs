 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
   abstract class ZeneCsontvaz:IZene
    {
        private string idotartam;
        public string Idotartam
        {
            get 
            {
                return idotartam;
            }
            
        }
        private double ertekeles;
        public double Ertekeles
        {
            get
            {
                return ertekeles;
            }
            set
            {
                ertekeles = value;
            }
        }



        private double tarhely;
        public double Tarhely
        {
            get
            {
                return tarhely;
            }
        }


        public ZeneCsontvaz(string hossz, double mennyireTetszik, double fajlMeret)
        {;
            idotartam = hossz;
            ertekeles = mennyireTetszik;
            tarhely = fajlMeret;
        }


    }
}
