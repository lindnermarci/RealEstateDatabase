// <copyright file="SzerzodesTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RealEstate.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using RealEstate.Data;
    using RealEstate.Repository;

    /// <summary>
    /// Aggrement repo tests
    /// </summary>
    [TestFixture]
    internal sealed class SzerzodesTest : IDisposable
    {
        private Mock<IRepository<Szerzodes>> m;
        private Muveletek muv;

        /// <summary>
        /// Setting up Mock repo
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.m = new Mock<IRepository<Szerzodes>>();
            List<Szerzodes> l = new List<Szerzodes>()
            {
                new Szerzodes() { Szerzodes_ID = 1, Ing_ID = 1, Ugyfel_ID = 1, Tipus = "vetel", Ar = 212321313 },
                new Szerzodes() { Szerzodes_ID = 2, Ing_ID = 2, Ugyfel_ID = 1, Tipus = "vetel", Ar = 2123223113 },
                new Szerzodes() { Szerzodes_ID = 3, Ing_ID = 5, Ugyfel_ID = 6, Tipus = "berles", Ar = 21233 },
                new Szerzodes() { Szerzodes_ID = 4, Ing_ID = 3, Ugyfel_ID = 2, Tipus = "vetel", Ar = 2123213213 },
                new Szerzodes() { Szerzodes_ID = 5, Ing_ID = 4, Ugyfel_ID = 4, Tipus = "berles", Ar = 21213 },
            };

            // az m Mock az l listát adja vissza a getAll hívásakor
            this.m.Setup(x => x.ReadAll()).Returns(l.AsQueryable());

            // Muveletek letrehozasa
            this.muv = new Muveletek(this.m.Object);
        }

        /// <summary>
        /// Testing the reading operation.
        /// </summary>
        [Test]
        public void WhenReadingSzerzodes_AllOfThemReturned()
        {
            Assert.That(this.muv.ReadSzerzodesek().Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// Testing reading by ID operation.
        /// </summary>
        /// <param name="id">Client ID</param>
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(2)]
        [TestCase(5)]
        public void WhenReadingByID_UgyfelReturned(int id)
        {
            Assert.That(this.muv.ReadSzerzodesById(id).Szerzodes_ID, Is.EqualTo(id));
        }

        /// <summary>
        /// Testing insertion operation.
        /// </summary>
        [Test]
        public void WhenNewUgyfelIsCalled_RepoVersionIsCalled()
        {
            this.muv.NewSzerzodes(6, 4, 3, "eladas", 50000000, new DateTime(2015, 11, 23));
            this.m.Verify(x => x.Create(It.IsAny<Szerzodes>()), Times.Once);
        }

        /// <summary>
        /// Testing delition operation
        /// </summary>
        [Test]
        public void WhenDeleteSzerzodesIsCalled_RepoVersionIsCalled()
        {
            this.muv.DeleteSzerzodes(2);
            this.m.Verify(x => x.Delete(It.IsAny<Szerzodes>()), Times.Once);
        }

        /// <summary>
        /// disposing operations
        /// </summary>
        public void Dispose()
        {
            this.muv.Dispose();
        }
    }
}
