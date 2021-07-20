using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class SajatZene : ZeneCsontvaz
    {
        string eloado = "Jómagam";
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
        public SajatZene(string hossz, string _cim, double fajlmeret) : base(hossz, 5, fajlmeret)
        {
            cim = _cim;
        }
    }
}
