using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class televanaTarhelyException:Exception
    {
        public televanaTarhelyException(ZeneCsontvaz zene):base(Uzenet(zene))
        {
            
        }
        private static string Uzenet(ZeneCsontvaz zene)
        {
            string msg = "";
            if (zene is KomolyZene)
            {
                msg = $"{(zene as KomolyZene).Zeneszerzo} {(zene as KomolyZene).Cim}-nak már nem jutott hely a tárhelyen";
            }
            else if (zene is SajatZene)
            {
                msg = $"{(zene as SajatZene).Eloado} {(zene as SajatZene).Cim}-nak már nem jutott hely a tárhelyen";
            }
            else if (zene is Konnyuzene)
            {
                msg = $"{(zene as Konnyuzene).Eloado} {(zene as Konnyuzene).Cim}-nak már nem jutott hely a tárhelyen";
            }
            return msg;
        }
    }
}
