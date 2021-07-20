using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class KomolyZene:ZeneCsontvaz
    {
        string zeneszerzo;
        public string Zeneszerzo
        {
            get
            {
                return zeneszerzo;
            }
        }
        string cim;
        public string Cim
        {
            get
            {
                return cim;
            }
        }
        public KomolyZene(string _zeneszerzo,string _cim, string ido, double ertekelese, double filemeret):base(ido, ertekelese, filemeret)
        {
            zeneszerzo = _zeneszerzo;
            cim = _cim;
        }
       
    }
}
