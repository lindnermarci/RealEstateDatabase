// <copyright file="Irepository.cs" company="PlaceholderCompany">
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
    /// basic CRUD operations defined
    /// </summary>
    /// <typeparam name="T">general param</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// creating new obj
        /// </summary>
        /// <param name="obj">T obj</param>
        void Create(T obj);

        /// <summary>
        /// reading all
        /// </summary>
        /// <returns>returns all</returns>
        IQueryable<T> ReadAll();

        /// <summary>
        /// updating
        /// </summary>
        /// <param name="uj">T obj</param>
        void Update(T uj);

        /// <summary>
        /// deleting
        /// </summary>
        /// <param name="obj">T obj</param>
        void Delete(T obj);
    }
}
