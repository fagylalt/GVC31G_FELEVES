using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ZeneCsontvaz> zenek = new List<ZeneCsontvaz>();
            ZeneCsontvaz elsoZene = new KomolyZene("Mozart", "Holdfény szonáta", "12:00", 4.5, 1);
            ZeneCsontvaz masodikZene = new Konnyuzene("Solefald", "Chanel no 2", "3:42", 5, 1);
            ZeneCsontvaz HarmadikZene = new SajatZene("4:12", "Éndal", 1);
            ZeneCsontvaz negyedikZene = new Konnyuzene("Jonathan Coulton", "Presidents Song", "3:12", 2.7, 1);
            ZeneCsontvaz otodikzene = new Konnyuzene("Versus Them", "Dont Eat The Captain", "12:00", 2.2, 1);
            ZeneCsontvaz hatodikzene = new Konnyuzene("Katatonia", "Criminals", "12:00", 2.4, 1);
            zenek.Add(elsoZene);
            zenek.Add(masodikZene);
            zenek.Add(HarmadikZene);
            zenek.Add(negyedikZene);
            zenek.Add(otodikzene);
            zenek.Add(hatodikzene);
            Console.WriteLine("Beszúrás ellenőrzés");
            BeszurasTry(zenek);
            Console.WriteLine("Tárhely ellenőrzés");
            TarhelyTry(zenek);
            Console.WriteLine("Lejátszás ellenőrzés"); 
            LejatszasTry(zenek);
            Console.WriteLine("Duplikált zene ellenőrzés");
            UgyanAzBeszurasaTry(zenek);
            Console.ReadLine();
        }
        static void BeszurasTry(List<ZeneCsontvaz> zenek)
        {
            BinarisFa fa = new BinarisFa(100, Console.WriteLine, Console.ReadLine);
            foreach (ZeneCsontvaz item in zenek)
            {
                fa.Beszuras(item);
            }
        }
        static void TarhelyTry(List<ZeneCsontvaz> zenek)
        {
            BinarisFa fa = new BinarisFa(5, Console.WriteLine, Console.ReadLine);
            foreach  (ZeneCsontvaz item in zenek)
            {
                fa.Beszuras(item);
            }
        }
        static void LejatszasTry(List<ZeneCsontvaz> zenek)
        {
            BinarisFa fa = new BinarisFa(10, Console.WriteLine, Console.ReadLine);
            foreach (ZeneCsontvaz item in zenek)
            {
                fa.Beszuras(item);
            }
            fa.Lejatszas(zenek[0]);
            fa.Lejatszas(zenek[1]);
            fa.Lejatszas(zenek[2]);
        }
        static void UgyanAzBeszurasaTry(List<ZeneCsontvaz> zenek)
        {
            BinarisFa fa = new BinarisFa(10, Console.WriteLine, Console.ReadLine);
            foreach (ZeneCsontvaz item in zenek)
            {
                fa.Beszuras(item);
            }
            fa.Beszuras(zenek[0]);
        }
    }
}
