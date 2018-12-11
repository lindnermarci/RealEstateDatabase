// <copyright file="UgyfelekRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RealEstate.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RealEstate.Data;

    /// <summary>
    /// clients repository
    /// </summary>
    public sealed class UgyfelekRepo : IRepository<Ugyfel>, IDisposable
    {
        private RealEstateModel rm = new RealEstateModel();

        /// <summary>
        /// creates client
        /// </summary>
        /// <param name="obj">client obj</param>
        public void Create(Ugyfel obj)
        {
            this.rm.Ugyfelek.Add(obj);
            this.rm.SaveChanges();
        }

        /// <summary>
        /// deletes client
        /// </summary>
        /// <param name="obj">client obj</param>
        public void Delete(Ugyfel obj)
        {
            this.rm.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            this.rm.Ugyfelek.Remove(obj);
            this.rm.SaveChanges();
        }

        /// <summary>
        /// disposing realestateModel
        /// </summary>
        public void Dispose()
        {
            this.rm.Dispose();
        }

        /// <summary>
        /// reads all clients client
        /// </summary>
        /// <returns>all clients</returns>
        public IQueryable<Ugyfel> ReadAll()
        {
            return from e in this.rm.Ugyfelek
                   select e;
        }

        /// <summary>
        /// updates client
        /// </summary>
        /// <param name="uj">client obj</param>
        public void Update(Ugyfel uj)
        {
            Ugyfel ugyf = this.rm.Ugyfelek.Where(x => x.Ugyfel_ID.Equals(uj.Ugyfel_ID)).FirstOrDefault();
            ugyf.Nev = uj.Nev;
            ugyf.Cim = uj.Cim;
            ugyf.Mobilszam = uj.Mobilszam;
            ugyf.Email = uj.Email;
            this.rm.SaveChanges();
        }
    }
}
