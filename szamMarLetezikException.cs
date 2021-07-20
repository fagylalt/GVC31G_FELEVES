using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class szamMarLetezikException:Exception
    {
        public szamMarLetezikException(ZeneCsontvaz zene) : base(Uzenet(zene))
        {
            
        }
        private static string Uzenet(ZeneCsontvaz zene)
        {
            string msg = "";
            if (zene is KomolyZene)
            {
                msg = $"{(zene as KomolyZene).Zeneszerzo} {(zene as KomolyZene).Cim}-már rajta van a kártyán";
            }
            else if (zene is SajatZene)
            {
                msg = $"{(zene as SajatZene).Eloado} {(zene as SajatZene).Cim}-már rajta van a kártyán";
            }
            else if (zene is Konnyuzene)
            {
                msg = $"{(zene as Konnyuzene).Eloado} {(zene as Konnyuzene).Cim}-már rajta van a kártyán";
            }
            return msg;
        }
    }
}
