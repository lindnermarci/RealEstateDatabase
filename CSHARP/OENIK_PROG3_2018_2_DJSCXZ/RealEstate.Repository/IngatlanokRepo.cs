// <copyright file="IngatlanokRepo.cs" company="PlaceholderCompany">
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
    /// Real estate repo class
    /// </summary>
    public sealed class IngatlanokRepo : IRepository<Ingatlan>, IDisposable
    {
        private readonly RealEstateModel rm = new RealEstateModel();

        /// <summary>
        /// creating new real estate
        /// </summary>
        /// <param name="obj">Ingatlan object</param>
        public void Create(Ingatlan obj)
        {
            this.rm.Ingatlanok.Add(obj);
            this.rm.SaveChanges();
        }

        /// <summary>
        /// deleting real estate
        /// </summary>
        /// <param name="obj">Ingatlan object</param>
        public void Delete(Ingatlan obj)
        {
            // Ingatlan torlendo = rm.Ingatlanok.Where(x => x.Ing_ID == obj.Ing_ID).FirstOrDefault();
            this.rm.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            this.rm.Ingatlanok.Remove(obj);
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
        /// reading all real estates
        /// </summary>
        /// <returns>all realestates</returns>
        public IQueryable<Ingatlan> ReadAll()
        {
            return from e in this.rm.Ingatlanok
                   select e;
        }

        /// <summary>
        /// creating new real estate
        /// </summary>
        /// <param name="uj">Ingatlan object</param>
        public void Update(Ingatlan uj)
        {
            Ingatlan ing = this.rm.Ingatlanok.Where(x => x.Ing_ID.Equals(uj.Ing_ID)).FirstOrDefault();
            ing.Cim = uj.Cim;
            ing.Tipus = uj.Tipus;
            ing.Alapterulet = uj.Alapterulet;
            ing.SzobaDb = uj.SzobaDb;
            this.rm.SaveChanges();
        }
    }
}
