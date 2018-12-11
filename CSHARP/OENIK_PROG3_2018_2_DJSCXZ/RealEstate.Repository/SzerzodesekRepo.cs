// <copyright file="SzerzodesekRepo.cs" company="PlaceholderCompany">
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
    /// agreements repo
    /// </summary>
    public sealed class SzerzodesekRepo : IRepository<Szerzodes>, IDisposable
    {
        private readonly RealEstateModel rm = new RealEstateModel();

        /// <summary>
        /// creates agreement
        /// </summary>
        /// <param name="obj">agreement obj</param>
        public void Create(Szerzodes obj)
        {
            this.rm.Szerzodesek.Add(obj);
            this.rm.SaveChanges();
        }

        /// <summary>
        /// deletes agreement
        /// </summary>
        /// <param name="obj">agreement obj</param>
        public void Delete(Szerzodes obj)
        {
            this.rm.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            this.rm.Szerzodesek.Remove(obj);
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
        /// reads all agreements
        /// </summary>
        /// <returns>agreements</returns>
        public IQueryable<Szerzodes> ReadAll()
        {
            return from e in this.rm.Szerzodesek
                   select e;
        }

        /// <summary>
        /// updates agreement
        /// </summary>
        /// <param name="uj">agreement obj</param>
        public void Update(Szerzodes uj)
        {
            Szerzodes szer = this.rm.Szerzodesek.Where(x => x.Szerzodes_ID.Equals(uj.Szerzodes_ID)).FirstOrDefault();
            szer.Ing_ID = uj.Ing_ID;
            szer.Ugyfel_ID = uj.Ugyfel_ID;
            szer.Tipus = uj.Tipus;
            szer.Ar = uj.Ar;
            szer.Datum = uj.Datum;
            this.rm.SaveChanges();
        }
    }
}
