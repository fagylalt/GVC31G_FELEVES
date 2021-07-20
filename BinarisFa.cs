using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC31G_FELEVES
{
    class BinarisFa
    {
        public delegate void Kiiratas(string msg);
        public delegate string Bekeres();
        Kiiratas KiiratasHandler;
        Bekeres BekeroHandler;
        public class FaElem
        {
            public List<ZeneCsontvaz> eltaroltSzamok;
            public double Kulcs;
            public FaElem jobb;
            public FaElem bal;
        }
        private FaElem gyoker;
        double tarhely;
        public BinarisFa(double _tarhely, Kiiratas _kiiratasHandler, Bekeres _bekeroHandler)
        {
            tarhely = _tarhely;
            KiiratasHandler = _kiiratasHandler;
            BekeroHandler = _bekeroHandler;
        }
        public void Beszuras(ZeneCsontvaz zene)
        {
            try
            {
                _Beszuras(ref gyoker, zene, zene.Ertekeles);
            }
            catch (televanaTarhelyException ex)
            {
                KiiratasHandler?.Invoke(ex.Message);
                ;
                _Beszuras(ref gyoker, zene, zene.Ertekeles);
            }
            catch (szamMarLetezikException ex)
            {
                KiiratasHandler?.Invoke(ex.Message);
            }

        }
        private void _Beszuras(ref FaElem p, ZeneCsontvaz zene, double _kulcs)
        {
            if(tarhely-zene.Tarhely < 0)
            {
                double igenyeltTarhely = Math.Abs(tarhely - zene.Tarhely);
                SzamTorles(igenyeltTarhely);
                throw new televanaTarhelyException(zene);
            }
            if (p == null)
            {
                p = new FaElem();
                p.eltaroltSzamok = new List<ZeneCsontvaz>();
                p.eltaroltSzamok.Add(zene);
                p.Kulcs = _kulcs;
                tarhely -= zene.Tarhely;
                if (zene is KomolyZene)
                {
                    KiiratasHandler.Invoke($"{(zene as KomolyZene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }
                else if (zene is Konnyuzene)
                {
                    KiiratasHandler.Invoke($"{(zene as Konnyuzene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }
                else
                {
                    KiiratasHandler.Invoke($"{(zene as SajatZene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }

            }
            else if (p.Kulcs.CompareTo(zene.Ertekeles) < 0)
            {
                _Beszuras(ref p.jobb, zene, _kulcs);
            }
            else if (p.Kulcs.CompareTo(zene.Ertekeles) > 0)
            {
                _Beszuras(ref p.bal, zene, _kulcs);
            }
            else
            {
                foreach (var dalok in p.eltaroltSzamok)
                {
                    if (dalok.Equals(zene))
                    {
                        throw new szamMarLetezikException(zene);
                    }
                }
                if (zene is KomolyZene)
                {
                    KiiratasHandler.Invoke($"{(zene as KomolyZene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }
                else if (zene is Konnyuzene)
                {
                    KiiratasHandler.Invoke($"{(zene as Konnyuzene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }
                else
                {
                    KiiratasHandler.Invoke($"{(zene as SajatZene).Cim} beszúrásra került {zene.Ertekeles} értékeléssel");
                }
                tarhely -= zene.Tarhely;
                p.eltaroltSzamok.Add(zene);
            }
        }
        private List<ZeneCsontvaz> TombKereses(double keresettKulcs, ref FaElem vizsgaltElem)
        {

            if (vizsgaltElem == null)
            {
                return null;
            }
            else
            {
                if (vizsgaltElem.Kulcs == keresettKulcs)
                {
                    return vizsgaltElem.eltaroltSzamok;
                }
                else if (vizsgaltElem.Kulcs < keresettKulcs)
                {
                    return TombKereses(keresettKulcs, ref vizsgaltElem.jobb);
                }
                else
                {
                    return TombKereses(keresettKulcs, ref vizsgaltElem.bal);
                }
            }

        }
        private  FaElem LegalacsonyabbFaElem(FaElem _elem)
        {
            FaElem jelenlegi = _elem;
            while (jelenlegi.bal != null)
            {
                jelenlegi = jelenlegi.bal;
            }
            ;
            return  jelenlegi;
        }
        public void SzamTorles(double IgenyeltHely)
        {
            FaElem elem = LegalacsonyabbFaElem(gyoker);
            List<ZeneCsontvaz> ideiglenesTomb = TombKereses(elem.Kulcs, ref elem);
            while(tarhely < IgenyeltHely)
            {
                if(ideiglenesTomb.Count > 0)
                {
                    tarhely += ideiglenesTomb[0].Tarhely;
                    if (ideiglenesTomb[0] is KomolyZene)
                    {
                        KiiratasHandler.Invoke($"{(ideiglenesTomb[0] as KomolyZene).Cim} törlésre került");
                    }else if(ideiglenesTomb[0] is Konnyuzene)
                    {
                        KiiratasHandler.Invoke($"{(ideiglenesTomb[0] as Konnyuzene).Cim} törlésre került");
                    }
                    else if(ideiglenesTomb[0] is SajatZene)
                    {
                        KiiratasHandler.Invoke($"{(ideiglenesTomb[0] as SajatZene).Cim} törlésre került");
                    }
                    ideiglenesTomb.RemoveAt(0);
                    if(ideiglenesTomb.Count == 0)
                    {
                      FaElemTorles(ref gyoker, elem.Kulcs);
                      elem = LegalacsonyabbFaElem(gyoker);
                      ideiglenesTomb = TombKereses(elem.Kulcs, ref elem);

                    }
                }
            }
           
            if(ideiglenesTomb.Count == 0)
            {
                FaElemTorles(ref gyoker, elem.Kulcs);
            }
            
        }
        public void Szamtorles(ZeneCsontvaz zene)
        {
            List<ZeneCsontvaz> list = TombKereses(zene.Ertekeles, ref gyoker);
            KiiratasHandler?.Invoke($"A zene törlésre került a {zene.Ertekeles} helyről");
            TombKereses(zene.Ertekeles, ref gyoker).Remove(zene);
            if(list.Count == 0)
            {
                FaElemTorles(ref gyoker, zene.Ertekeles);
            }
            ;
        }
        public void Lejatszas(ZeneCsontvaz zene)
        {
            if (zene is KomolyZene)
            {
                KiiratasHandler.Invoke($"{(zene as KomolyZene).Zeneszerzo} {(zene as KomolyZene).Cim} lejátszása");
            }
            else if (zene is Konnyuzene)
            {
                KiiratasHandler.Invoke($"{(zene as Konnyuzene).Eloado} {(zene as Konnyuzene).Cim} lejátszása");
            }
            else
            {
                KiiratasHandler.Invoke($"{(zene as SajatZene).Eloado} {(zene as SajatZene).Cim} lejátszása");
            }
            TetszettE(zene);
        }
        private void TetszettE(ZeneCsontvaz zene)
        {
            KiiratasHandler?.Invoke($"Tetszett a lejátszott szám? Y vagy N");
            string bekertString = BekeroHandler?.Invoke().ToUpper();
            if(bekertString == "Y")
            {
                
                if(zene.Ertekeles + 0.1 > 5)
                {
                    KiiratasHandler?.Invoke($"A zene értékelése nem lehet több mint 5!");
                }
                else
                {
                    Szamtorles(zene);
                    zene.Ertekeles += 0.1;
                    KiiratasHandler?.Invoke($"A lejátszott szám értékelését növeltem");
                    Beszuras(zene);
                }
            }else if(bekertString == "N")
            {
                
                if(zene.Ertekeles - 0.1 < 1)
                {
                    KiiratasHandler?.Invoke($"A zene értékelése nem lehet kevesebb mint 1!");
                }
                else
                {
                    Szamtorles(zene);
                    zene.Ertekeles -= 0.1;
                    KiiratasHandler?.Invoke($"A lejátszott szám értékelését csökkentettem");
                    Beszuras(zene);
                }
            }
            else
            {
                TetszettE(zene);
            }

        }

        private void FaElemTorles(ref FaElem p, double kulcs)
        {
            if (p != null)
            {

                if (p.Kulcs > kulcs)
                {
                    FaElemTorles(ref p.bal,kulcs);
                }
                else
                {
                    if (p.Kulcs < kulcs)
                        FaElemTorles(ref p.jobb, kulcs);
                    else
                    {
                        if (p.bal == null)
                        {
                            p = p.jobb;
                        }
                        else
                        {
                            if (p.jobb == null)
                            {
                                p = p.bal;
                            }
                            else
                            {
                                KetGyermekTorlese(ref p, ref p.bal);
                            }
                        }
                    }
                }
            }
        }
        private void KetGyermekTorlese(ref FaElem e, ref FaElem r)
        {
            if (r.jobb != null)
                KetGyermekTorlese(ref e, ref r.jobb);
            else
            {
                e.eltaroltSzamok = r.eltaroltSzamok;
                e.Kulcs = r.Kulcs;
                r = null;
            }
        }
    }
}
