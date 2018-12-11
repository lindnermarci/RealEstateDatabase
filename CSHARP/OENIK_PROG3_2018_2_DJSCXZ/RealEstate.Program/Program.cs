// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RealEstate.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using RealEstate.Logic;

    /// <summary>
    /// main class
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Kerem a parancsot(súgo:99):\n");

                Muveletek m = new Muveletek();
                    int x = int.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 1:
                            var tul = m.ReadTulajdonosok();
                            foreach (var i in tul)
                            {
                                Console.WriteLine(i.Tul_ID.ToString() + " " + i.Nev.ToString() + " " + i.Cim.ToString() + " " + i.Mobilszam.ToString() + " " + i.Email.ToString());
                            }

                            break;
                        case 2:
                            var ing = m.ReadIngatlanok();
                            foreach (var i in ing)
                            {
                                Console.WriteLine(i.Ing_ID + " " + i.Cim.ToString() + " " + i.Tipus + " " + i.Alapterulet + " " + i.SzobaDb);
                            }

                            break;
                        case 3:
                            var ugyf = m.ReadUgyfelek();
                            foreach (var i in ugyf)
                            {
                                Console.WriteLine(i.Ugyfel_ID + " " + i.Nev + " " + i.Cim + " " + i.Mobilszam + " " + i.Email);
                            }

                            break;
                        case 4:
                            var szerz = m.ReadSzerzodesek();
                            foreach (var i in szerz)
                            {
                                Console.WriteLine(i.Szerzodes_ID + " " + i.Ing_ID + " " + i.Ugyfel_ID + " " + i.Tipus + " " + i.Ar + " " + i.Datum);
                            }

                            break;
                        case 5:
                            Console.WriteLine("Tul ID:");
                            int id = int.Parse(Console.ReadLine());
                            var tulaj = m.ReadTulajdonosById(id);
                            Console.WriteLine(tulaj.Tul_ID + " " + tulaj.Nev + " " + tulaj.Cim + " " + tulaj.Mobilszam + " " + tulaj.Email);
                            break;
                        case 6:
                            Console.WriteLine("Ingatlan ID:");
                            id = int.Parse(Console.ReadLine());
                            var ingatl = m.ReadIngatlanById(id);
                            Console.WriteLine(ingatl.Ing_ID + " " + ingatl.Cim + " " + ingatl.Tipus + " " + ingatl.Alapterulet + " " + ingatl.SzobaDb);
                            break;
                        case 7:
                            Console.WriteLine("Ugyfel ID:");
                            id = int.Parse(Console.ReadLine());
                            var ugyfel = m.ReadUgyfelById(id);
                            Console.WriteLine(ugyfel.Ugyfel_ID + " " + ugyfel.Nev + " " + ugyfel.Cim + " " + ugyfel.Mobilszam + " " + ugyfel.Email);
                            break;
                        case 8:
                            Console.WriteLine("Szerzodes ID:");
                            id = int.Parse(Console.ReadLine());
                            var szerzod = m.ReadSzerzodesById(id);
                            Console.WriteLine(szerzod.Szerzodes_ID + " " + szerzod.Ing_ID + " " + szerzod.Ugyfel_ID + " " + szerzod.Tipus + " " + szerzod.Ar + " " + szerzod.Datum);
                            break;
                        case 9:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: ID,Nev,Cim,Mobil(pl.:301234567),email");

                            id = int.Parse(Console.ReadLine());
                            string nev = Console.ReadLine();
                            string cim = Console.ReadLine();
                            string mobil = Console.ReadLine();
                            string email = Console.ReadLine();
                            m.NewTulajdonos(id, nev, cim, mobil, email);
                            break;
                        case 10:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: ID, Cim, tipus, alapterulet,szobak szama");
                            id = int.Parse(Console.ReadLine());
                            cim = Console.ReadLine();
                            string tipus = Console.ReadLine();
                            int alapter = int.Parse(Console.ReadLine());
                            int szobaDb = int.Parse(Console.ReadLine());
                            m.NewIngatlan(id, cim, tipus, alapter, szobaDb);
                            break;
                        case 11:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: ID, nev, cim, mobil(pl.:206542134), email");
                            id = int.Parse(Console.ReadLine());
                            nev = Console.ReadLine();
                            cim = Console.ReadLine();
                            mobil = Console.ReadLine();
                            email = Console.ReadLine();
                            m.NewUgyfel(id, nev, cim, mobil, email);
                            break;
                        case 12:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: Szerzodes ID, Ingatlan ID, Ugyfel ID, tipus, ar, datum(pl.:2018.11.10.)");
                            int szerzId = int.Parse(Console.ReadLine());
                            int ingId = int.Parse(Console.ReadLine());
                            int ugyfelId = int.Parse(Console.ReadLine());
                            tipus = Console.ReadLine();
                            int ar = int.Parse(Console.ReadLine());
                            string date = Console.ReadLine();
                            DateTime dateDateTime = DateTime.Parse(date);
                            m.NewSzerzodes(szerzId, ingId, ugyfelId, tipus, ar, dateDateTime);
                            break;
                        case 13:
                            Console.WriteLine("Kerem a tulajdonos ID-t: ");
                            id = int.Parse(Console.ReadLine());
                            m.DeleteTulajdonos(id);
                            break;
                        case 14:
                            Console.WriteLine("Kerem a ingatlan ID-t: ");
                            id = int.Parse(Console.ReadLine());
                            m.DeleteIngatlan(id);
                            break;
                        case 15:
                            Console.WriteLine("Kerem a ugyfel ID-t: ");
                            id = int.Parse(Console.ReadLine());
                            m.DeleteUgyfel(id);
                            break;
                        case 16:
                            Console.WriteLine("Kerem a szerzodes ID-t: ");
                            id = int.Parse(Console.ReadLine());
                            m.DeleteSzerzodes(id);
                            break;
                        case 17:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva:ID,Nev,Cim,Mobil(pl.:301234567),email");

                            id = int.Parse(Console.ReadLine());
                            nev = Console.ReadLine();
                            cim = Console.ReadLine();
                            mobil = Console.ReadLine();
                            email = Console.ReadLine();
                            m.UpdateTulajdonos(id, nev, cim, mobil, email);
                            break;
                        case 18:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: ID, Cim, tipus, alapterulet,szobak szama");
                            id = int.Parse(Console.ReadLine());
                            cim = Console.ReadLine();
                            tipus = Console.ReadLine();
                            alapter = int.Parse(Console.ReadLine());
                            szobaDb = int.Parse(Console.ReadLine());
                            m.UpdateIngatlan(id, cim, tipus, alapter, szobaDb);
                            break;
                        case 19:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: ID, nev, cim, mobil(pl.:206542134), email");
                            id = int.Parse(Console.ReadLine());
                            nev = Console.ReadLine();
                            cim = Console.ReadLine();
                            mobil = Console.ReadLine();
                            email = Console.ReadLine();
                            m.UpdateUgyfel(id, nev, cim, mobil, email);
                            break;
                        case 20:
                            Console.WriteLine("A következő adatokat kérem enterrel elválasztva: Szerzodes ID, Ingatlan ID, Ugyfel ID, tipus, ar, datum(pl.:2018.11.10.)");
                            szerzId = int.Parse(Console.ReadLine());
                            ingId = int.Parse(Console.ReadLine());
                            ugyfelId = int.Parse(Console.ReadLine());
                            tipus = Console.ReadLine();
                            ar = int.Parse(Console.ReadLine());
                            date = Console.ReadLine();
                            dateDateTime = DateTime.Parse(date);
                            m.UpdateSzerzodes(szerzId, ingId, ugyfelId, tipus, ar, dateDateTime);
                            break;
                        case 21:
                            Console.WriteLine(m.HanyIngatlanBerbe());

                            break;
                        case 22:
                            foreach (var i in m.NagyErtekuSzerzodestKotottKiadasraTulajdonosok())
                            {
                                Console.WriteLine(i.Tul_ID + " " + i.Nev + " " + i.Mobilszam + " " + i.Email);
                            }

                            break;
                        case 23:
                            foreach (var i in m.Ugyfelek2017ElottSzerzodott())
                            {
                                Console.WriteLine(i.Ugyfel_ID + " " + i.Nev + " " + i.Cim + " " + i.Mobilszam + " " + i.Email);
                            }

                            break;
                        case 24:
                            {
                                Console.WriteLine("Kerem az ingatlan ID-t: ");
                                id = int.Parse(Console.ReadLine());
                                Console.WriteLine(m.Arajanlatkeres(id));
                                break;
                            }

                        case 99:
                        {
                                Console.WriteLine(
                               "1-Mindegyik Tulajdonos listázása\n" +
                               "2-Mindegyik Ingatlan listázása\n" +
                               "3-Mindegyik Ugyfel listázása\n" +
                               "4-Mindegyik Szerzodes listázása\n" +
                               "5-Tulajdonos ID szerint\n" +
                               "6-Ingatlan ID szerint\n" +
                               "7-Ugyfel ID szerint\n" +
                               "8-Szerzodes ID szerint\n" +
                               "9-Tulajdonos hozzáadása\n" +
                               "10-Ingatlan hozzáadása\n" +
                               "11-Ugyfel hozzáadása\n" +
                               "12-Szerzodes hozzáadása\n" +
                               "13-Tulajdonos törlése\n" +
                               "14-Ingatlan törlése\n" +
                               "15-Ugyfel törlése\n" +
                               "16-Szerződés törlése\n" +
                               "17-Tulajdonos módosítása\n" +
                               "18-Ingatlan módosítása\n" +
                               "19-Tulajdonos módosítása\n" +
                               "20-Szerződés módosítása\n" +
                               "21-Hány ingatlanok lettek bérbe adva abc renben\n" +
                               "22-Hány ügyfél fizet 200000 Ft-nál többet az albérletért\n" +
                               "23-Mely ügyfelek kötöttek szerzodest 2017 előtt\n" +
                               "24-Árajánlat kérés Ingatlanra ID alapján\n" +
                               "100-kilépés");
                            break;
                        }

                    case 100:
                        {
                            end = true;
                            break;
                        }
                    }
            }
        }
    }
}
