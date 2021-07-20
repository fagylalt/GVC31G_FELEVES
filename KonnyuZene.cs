using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class Konnyuzene : ZeneCsontvaz
    {
        private string eloado;
        public string Eloado
        {
            get
            {
                return eloado;
            }
        }
        public string Cim
        {
            get
            {
                return cim;
            }
        }
        private string cim;
        public Konnyuzene(string _eloado, string _cim, string hossz, double ertekeles, int fajlmeret) : base(hossz, ertekeles, fajlmeret)
        {
            eloado = _eloado;
            cim = _cim;
        }
    }
}
