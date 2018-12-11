// <copyright file="TulajdonosokRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RealEstate.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RealEstate.Data;

    /// <summary>
    /// Tulajdonosok Entity's repository.
    /// </summary>
    public sealed class TulajdonosokRepo : IRepository<Tulajdonos>, IDisposable
    {
        private RealEstateModel rm = new RealEstateModel();

        /// <summary>
        /// creates owner
        /// </summary>
        /// <param name="obj">owner obj</param>
        public void Create(Tulajdonos obj)
        {
                this.rm.Tulajdonosok.Add(obj);
                this.rm.SaveChanges();
        }

        /// <summary>
        /// removes owner
        /// </summary>
        /// <param name="obj">owner obj</param>
        public void Delete(Tulajdonos obj)
        {
            this.rm.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            this.rm.Tulajdonosok.Remove(obj);
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
        /// returns all owners
        /// </summary>
        /// <returns>owners</returns>
        public IQueryable<Tulajdonos> ReadAll()
        {
            return from e in this.rm.Tulajdonosok
                   select e;
        }

        /// <summary>
        /// updates owner
        /// </summary>
        /// <param name="uj">owner obj</param>
        public void Update(Tulajdonos uj)
        {
            Tulajdonos tul = this.rm.Tulajdonosok.Where(x => x.Tul_ID.Equals(uj.Tul_ID)).FirstOrDefault();
            tul.Nev = uj.Nev;
            tul.Cim = uj.Cim;
            tul.Mobilszam = uj.Mobilszam;
            tul.Email = uj.Email;
            this.rm.SaveChanges();
        }
    }
}
