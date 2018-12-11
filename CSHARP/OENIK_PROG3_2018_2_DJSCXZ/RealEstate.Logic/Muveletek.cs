// <copyright file="Muveletek.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RealEstate.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using RealEstate.Data;
    using RealEstate.Repository;

    /// <summary>
    /// The operations available from console
    /// </summary>
    public class Muveletek : ILogic
    {
        private readonly IRepository<Ingatlan> ir;
        private readonly IRepository<Tulajdonos> tr;
        private readonly IRepository<Ugyfel> ur;
        private readonly IRepository<Szerzodes> szr;

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// Default Constructor
        /// </summary>
        public Muveletek()
        {
            this.ir = new IngatlanokRepo();
            this.tr = new TulajdonosokRepo();
            this.ur = new UgyfelekRepo();
            this.szr = new SzerzodesekRepo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// constructor
        /// </summary>
        /// <param name="repo">Repository</param>
        public Muveletek(IRepository<Ingatlan> repo)
        {
            this.ir = repo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// constructor
        /// </summary>
        /// <param name="repo">Repository</param>
        public Muveletek(IRepository<Tulajdonos> repo)
        {
            this.tr = repo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// constructor
        /// </summary>
        /// <param name="repo">Repository</param>
        public Muveletek(IRepository<Ugyfel> repo)
        {
            this.ur = repo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// constructor
        /// </summary>
        /// <param name="repo">Repository</param>
        public Muveletek(IRepository<Szerzodes> repo)
        {
            this.szr = repo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Muveletek"/> class.
        /// constructor
        /// </summary>
        /// <param name="ir">Real estate repo</param>
        /// <param name="tr">Owner repo</param>
        /// <param name="ur">Client repo</param>
        /// <param name="szr">Agreement repo</param>
        public Muveletek(IRepository<Ingatlan> ir, IRepository<Tulajdonos> tr, IRepository<Ugyfel> ur, IRepository<Szerzodes> szr)
            : this(ir)
        {
            this.tr = tr;
            this.ur = ur;
            this.szr = szr;
        }

        /// <inheritdoc/>
        public void DeleteIngatlan(int ing_Id)
        {
            // ir.Delete(ing_id);
            this.ir.Delete(
                new Ingatlan()
                {
                    Ing_ID = ing_Id,
                });
        }

        /// <inheritdoc/>
        public void DeleteTulajdonos(int tul_Id)
        {
            this.tr.Delete(
                new Tulajdonos()
                {
                    Tul_ID = tul_Id
                });
        }

        /// <inheritdoc/>
        public void DeleteUgyfel(int ugyfel_Id)
        {
            this.ur.Delete(
                new Ugyfel()
                {
                    Ugyfel_ID = ugyfel_Id
                });
        }

        /// <inheritdoc/>
        public void DeleteSzerzodes(int szerzodes_Id)
        {
            this.szr.Delete(
                new Szerzodes()
                {
                    Szerzodes_ID = szerzodes_Id
                });
        }

        /// <inheritdoc/>
        public void NewIngatlan(int ing_Id, string cim, string tipus, int alapterulet, int szobaDb)
        {
            this.ir.Create(
                new Ingatlan()
                {
                    Ing_ID = ing_Id,
                    Cim = cim,
                    Tipus = tipus,
                    Alapterulet = alapterulet,
                    SzobaDb = szobaDb
                });
        }

        /// <inheritdoc/>
        public void NewTulajdonos(int tul_Id, string nev, string cim, string mobilszam, string email)
        {
            this.tr.Create(
                new Tulajdonos()
                {
                    Tul_ID = tul_Id,
                    Nev = nev,
                    Cim = cim,
                    Mobilszam = mobilszam,
                    Email = email
                });
        }

        /// <inheritdoc/>
        public void NewUgyfel(int ugyfel_Id, string nev, string cim, string mobilszam, string email)
        {
            this.ur.Create(new Ugyfel()
            {
                Ugyfel_ID = ugyfel_Id,
                Nev = nev,
                Cim = cim,
                Mobilszam = mobilszam,
                Email = email
            });
        }

        /// <inheritdoc/>
        public void NewSzerzodes(int szerzodes_Id, int ing_Id, int ugyfel_Id, string tipus, int ar, DateTime datum)
        {
            this.szr.Create(new Szerzodes()
            {
                Szerzodes_ID = szerzodes_Id,
                Ing_ID = ing_Id,
                Ugyfel_ID = ugyfel_Id,
                Tipus = tipus,
                Ar = ar,
                Datum = datum
            });
        }

        /// <inheritdoc/>
        public IQueryable<Ingatlan> ReadIngatlanok()
        {
            return this.ir.ReadAll();
        }

        /// <inheritdoc/>
        public IQueryable<Tulajdonos> ReadTulajdonosok()
        {
            return this.tr.ReadAll();
        }

        /// <inheritdoc/>
        public IQueryable<Ugyfel> ReadUgyfelek()
        {
            return this.ur.ReadAll();
        }

        /// <inheritdoc/>
        public IQueryable<Szerzodes> ReadSzerzodesek()
        {
            return this.szr.ReadAll();
        }

        /// <inheritdoc/>
        public Ingatlan ReadIngatlanById(int id)
        {
            var ing = from e in this.ir.ReadAll()
                      where e.Ing_ID.Equals(id)
                      select e;
            return ing.FirstOrDefault();
        }

        /// <inheritdoc/>
        public Tulajdonos ReadTulajdonosById(int id)
        {
            var tul = from e in this.tr.ReadAll()
                      where e.Tul_ID.Equals(id)
                      select e;
            return tul.FirstOrDefault();
        }

        /// <inheritdoc/>
        public Ugyfel ReadUgyfelById(int id)
        {
            var ugyfel = from e in this.ur.ReadAll()
                        where e.Ugyfel_ID.Equals(id)
                        select e;
            return ugyfel.FirstOrDefault();
        }

        /// <inheritdoc/>
        public Szerzodes ReadSzerzodesById(int id)
        {
            var szerz = from e in this.szr.ReadAll()
                        where e.Szerzodes_ID.Equals(id)
                        select e;
            return szerz.FirstOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateIngatlan(int ing_Id, string ujcim, string ujtipus, int ujalapterulet, int ujszobadb)
        {
            this.ir.Update(new Ingatlan() { Ing_ID = ing_Id, Cim = ujcim, Alapterulet = ujalapterulet, SzobaDb = ujszobadb });
        }

        /// <inheritdoc/>
        public void UpdateTulajdonos(int tul_Id, string ujnev, string ujcim, string ujmobilszam, string ujemail)
        {
            this.tr.Update(new Tulajdonos() { Tul_ID = tul_Id, Nev = ujnev, Cim = ujcim, Mobilszam = ujmobilszam, Email = ujemail });
        }

        /// <inheritdoc/>
        public void UpdateUgyfel(int ugyfel_Id, string ujnev, string ujcim, string ujmobilszam, string ujemail)
        {
            this.ur.Update(new Ugyfel() { Ugyfel_ID = ugyfel_Id, Nev = ujnev, Cim = ujcim, Mobilszam = ujmobilszam, Email = ujemail });
        }

        /// <inheritdoc/>
        public void UpdateSzerzodes(int szerzodes_Id, int ujing_Id, int ujugyfel_Id, string ujtipus, int ujar, DateTime ujdatum)
        {
            this.szr.Update(new Szerzodes() { Szerzodes_ID = szerzodes_Id, Ing_ID = ujing_Id, Ugyfel_ID = ujugyfel_Id, Tipus = ujtipus, Ar = ujar, Datum = ujdatum });
        }

        /// <inheritdoc/>
        public int HanyIngatlanBerbe()
        {
            var ingatlanok = (from ingatlan in this.ir.ReadAll()
                              select ingatlan.Ing_ID).ToArray();

            var ingberbe = from szerzodes in this.szr.ReadAll()
                           join ingatlan in ingatlanok on szerzodes.Ing_ID equals ingatlan
                           where szerzodes.Tipus.Equals("bérlés")
                           select new { ingatlan };
            return ingberbe.Count();
        }

        /// <inheritdoc/>
        public List<Tulajdonos> NagyErtekuSzerzodestKotottKiadasraTulajdonosok()
        {
            var szerzodesekNagyErtek = (from sz in this.szr.ReadAll()
                                        where sz.Ar > 200000 && sz.Tipus.Equals("bérlés")
                                        select sz.Ing_ID).ToArray();

            var tulajSokPenz = from tulajd in this.tr.ReadAll()
                               join szerzodes in szerzodesekNagyErtek on tulajd.Tul_ID equals szerzodes
                               select tulajd;
            return tulajSokPenz.ToList();
        }

        /// <inheritdoc/>
        public List<Ugyfel> Ugyfelek2017ElottSzerzodott()
        {
            DateTime d = DateTime.Parse("2017-01-01");
            var szerzodesekMostanaban = (from sz in this.szr.ReadAll()
                                         where sz.Datum.Value.CompareTo(d).Equals(-1)
                                         select sz.Ugyfel_ID).ToArray();

            var ugyfelekKoran = from ugy in this.ur.ReadAll()
                                join szerzodes in szerzodesekMostanaban on ugy.Ugyfel_ID equals szerzodes
                                select new { Ugyfel_ID = szerzodes, ugy.Nev, ugy.Cim, ugy.Mobilszam, ugy.Email };

            List<Ugyfel> ugyfelek = new List<Ugyfel>();

            foreach (var i in ugyfelekKoran)
            {
                Ugyfel u = new Ugyfel
                {
                    Ugyfel_ID = i.Ugyfel_ID,
                    Nev = i.Nev,
                    Cim = i.Cim,
                    Mobilszam = i.Mobilszam,
                    Email = i.Email
                };
                ugyfelek.Add(u);
            }

            return ugyfelek;
        }

        /// <summary>
        /// Gives a price offer
        /// </summary>
        /// <param name="ingId">RealEstate ID</param>
        /// <returns>Returns an XML with 5 clients and prices</returns>
        public XDocument Arajanlatkeres(int ingId)
        {
            string addr = this.ReadIngatlanById(ingId).Cim;
            var arak = from p in this.szr.ReadAll()
                        where p.Ing_ID.Equals(ingId)
                        select p.Ar;
            int price = arak.FirstOrDefault().Value;
            string url = "http://localhost:8080/Realestate.Java/estate?Addr=" + addr + "&Price=" + price;
            return XDocument.Load(url);
        }

        /// <summary>
        /// disposing
        /// </summary>
        public void Dispose()
        {
        }
    }
}
