// <copyright file="ILogic.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Business logic operations.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Creates new Real Estate.
        /// </summary>
        /// <param name="ing_Id">Real Estate ID</param>
        /// <param name="cim">Real Estate address</param>
        /// <param name="tipus">Real Estate type</param>
        /// <param name="alapterulet">Real Estate size</param>
        /// <param name="szobaDb">Real Estate room count</param>
        void NewIngatlan(int ing_Id, string cim, string tipus, int alapterulet, int szobaDb);

        /// <summary>
        /// Creates new Owner
        /// </summary>
        /// <param name="tul_Id">ID</param>
        /// <param name="nev">Name</param>
        /// <param name="cim">Address</param>
        /// <param name="mobilszam">Phone num</param>
        /// <param name="email">Email</param>
        void NewTulajdonos(int tul_Id, string nev, string cim, string mobilszam, string email);

        /// <summary>
        /// Creates new Clent
        /// </summary>
        /// <param name="ugyfel_Id">ID</param>
        /// <param name="nev">Name</param>
        /// <param name="cim">Address</param>
        /// <param name="mobilszam">Phone num</param>
        /// <param name="email">Email</param>
        void NewUgyfel(int ugyfel_Id, string nev, string cim, string mobilszam, string email);

        /// <summary>
        /// Creates new Agreement
        /// </summary>
        /// <param name="szerzodes_Id">Szerzodes's ID</param>
        /// <param name="ing_Id">Real Estate's ID</param>
        /// <param name="ugyfel_Id">Ugyfel's ID</param>
        /// <param name="tipus">Type</param>
        /// <param name="ar">Price</param>
        /// <param name="datum">Date</param>
        void NewSzerzodes(int szerzodes_Id, int ing_Id, int ugyfel_Id, string tipus, int ar, DateTime datum);

        /// <summary>
        /// Reads allReal Estates
        /// </summary>
        /// <returns>All Real Estates</returns>
        IQueryable<Ingatlan> ReadIngatlanok();

        /// <summary>
        /// Reads all Owners
        /// </summary>
        /// <returns>All Owners</returns>
        IQueryable<Tulajdonos> ReadTulajdonosok();

        /// <summary>
        /// Reads all Clents
        /// </summary>
        /// <returns>All Clients</returns>
        IQueryable<Ugyfel> ReadUgyfelek();

        /// <summary>
        /// Reads all Agreementes
        /// </summary>
        /// <returns>All Agreementes</returns>
        IQueryable<Szerzodes> ReadSzerzodesek();

        /// <summary>
        /// Selects Real Estate by ID
        /// </summary>
        /// <param name="id">Real Estate ID</param>
        /// <returns>Selected Real Estate</returns>
        Ingatlan ReadIngatlanById(int id);

        /// <summary>
        /// Selects Clent by ID
        /// </summary>
        /// <param name="id">Ugyfel ID</param>
        /// <returns>Selected Client</returns>
        Ugyfel ReadUgyfelById(int id);

        /// <summary>
        /// Selects Owner by ID
        /// </summary>
        /// <param name="id">Owner ID</param>
        /// <returns>Selected Owner</returns>
        Tulajdonos ReadTulajdonosById(int id);

        /// <summary>
        /// Selects Agreement by ID
        /// </summary>
        /// <param name="id">Szerzodes ID</param>
        /// <returns>Selected Real Estate</returns>
        Szerzodes ReadSzerzodesById(int id);

        /// <summary>
        /// Updates Real Estate
        /// </summary>
        /// <param name="ing_Id">ID</param>
        /// <param name="ujcim">Addr</param>
        /// <param name="ujtipus">Type</param>
        /// <param name="ujalapterulet">Size</param>
        /// <param name="ujszobadb">RoomCount</param>
        void UpdateIngatlan(int ing_Id, string ujcim, string ujtipus, int ujalapterulet, int ujszobadb);

        /// <summary>
        /// Updates Owner
        /// </summary>
        /// <param name="tul_Id">ID</param>
        /// <param name="ujnev">Name</param>
        /// <param name="ujcim">Addr</param>
        /// <param name="ujmobilszam">Mobile num</param>
        /// <param name="ujemail">Email</param>
        void UpdateTulajdonos(int tul_Id, string ujnev, string ujcim, string ujmobilszam, string ujemail);

        /// <summary>
        /// Updates Client
        /// </summary>
        /// <param name="ugyfel_Id">ID</param>
        /// <param name="ujnev">Name</param>
        /// <param name="ujcim">Addr</param>
        /// <param name="ujmobilszam">Mobile</param>
        /// <param name="ujemail">Email</param>
        void UpdateUgyfel(int ugyfel_Id, string ujnev, string ujcim, string ujmobilszam, string ujemail);

        /// <summary>
        /// Updates Agreement
        /// </summary>
        /// <param name="szerzodes_Id">Szerzodes ID</param>
        /// <param name="ujing_Id">new Real Estate ID</param>
        /// <param name="ujugyfel_Id">new Client ID</param>
        /// <param name="ujtipus">new type</param>
        /// <param name="ujar">new price</param>
        /// <param name="ujdatum">new date</param>
        void UpdateSzerzodes(int szerzodes_Id, int ujing_Id, int ujugyfel_Id, string ujtipus, int ujar, DateTime ujdatum);

        /// <summary>
        /// Deletes a select Real Estate
        /// </summary>
        /// <param name="ing_Id">ID</param>
        void DeleteIngatlan(int ing_Id);

        /// <summary>
        /// Deletes a select Tulakdonos
        /// </summary>
        /// <param name="tul_Id">Owner ID</param>
        void DeleteTulajdonos(int tul_Id);

        /// <summary>
        /// Deletes a select Client
        /// </summary>
        /// <param name="ugyfel_Id">Ugyfel ID</param>
        void DeleteUgyfel(int ugyfel_Id);

        /// <summary>
        /// Deletes a select Agreement
        /// </summary>
        /// <param name="szerzodes_Id">Szerzodes ID</param>
        void DeleteSzerzodes(int szerzodes_Id);

        /// <summary>
        /// number of Real estates rented
        /// </summary>
        /// <returns>returns number of Real estates rented</returns>
        int HanyIngatlanBerbe();

        /// <summary>
        /// big deals
        /// </summary>
        /// <returns>big value deals</returns>
        List<Tulajdonos> NagyErtekuSzerzodestKotottKiadasraTulajdonosok();

        /// <summary>
        /// after 2017 agreement
        /// </summary>
        /// <returns>clients after 2017</returns>
        List<Ugyfel> Ugyfelek2017ElottSzerzodott();

        /// <summary>
        /// Gives a price offer
        /// </summary>
        /// <param name="ingId">RealEstate ID</param>
        /// <returns>Returns an XML with 5 clients and prices</returns>
        XDocument Arajanlatkeres(int ingId);
    }
}
