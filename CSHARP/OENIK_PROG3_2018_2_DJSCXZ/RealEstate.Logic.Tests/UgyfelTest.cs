// <copyright file="UgyfelTest.cs" company="PlaceholderCompany">
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
    /// Testing Client repo
    /// </summary>
    [TestFixture]
    internal sealed class UgyfelTest : IDisposable
    {
        private Mock<IRepository<Ugyfel>> m;
        private Muveletek muv;

        /// <summary>
        /// Setup of mock repo
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.m = new Mock<IRepository<Ugyfel>>();
            List<Ugyfel> l = new List<Ugyfel>()
            {
                new Ugyfel() { Ugyfel_ID = 1, Nev = "Horvat Mihaly", Cim = "23213 Cegled Berceli utca 43", Mobilszam = "7645376", Email = "ewqsd@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 2, Nev = "Ecseri Ilona", Cim = "23221 Bp Berceli utca 3", Mobilszam = "713176", Email = "grf@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 3, Nev = "Horvat Gabor", Cim = "23353 Debrecen Befdci utca 43", Mobilszam = "76423376", Email = "fdsc@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 4, Nev = "Hat Anna", Cim = "232413 Bp fdscvi utca 43", Mobilszam = "3425376", Email = "tgr@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 5, Nev = "Horvat Eszter", Cim = "23433 Cegled Berweli utca 43", Mobilszam = "6775376", Email = "asdx@gmail.com" },
            };

            // az m Mock az l listát adja vissza a getAll hívásakor
            this.m.Setup(x => x.ReadAll()).Returns(l.AsQueryable());

            // Muveletek letrehozasa
            this.muv = new Muveletek(this.m.Object);
        }

        /// <summary>
        /// testing read operation
        /// </summary>
        [Test]
        public void WhenReadingUgyfel_AllOfThemReturned()
        {
            Assert.That(this.muv.ReadUgyfelek().Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// testing read by id operation
        /// </summary>
        /// <param name="id">Client id</param>
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(2)]
        [TestCase(5)]
        public void WhenReadingByID_UgyfelReturned(int id)
        {
            Assert.That(this.muv.ReadUgyfelById(id).Ugyfel_ID, Is.EqualTo(id));
        }

        /// <summary>
        /// testing insert operation
        /// </summary>
        [Test]
        public void WhenNewUgyfelIsCalled_RepoVersionIsCalled()
        {
            this.muv.NewUgyfel(1, "dead dsa", "21334 red de 19", "067438765", "dqewd@yahoo.com");
            this.m.Verify(x => x.Create(It.IsAny<Ugyfel>()), Times.Once);
        }

        /// <summary>
        /// testing delete operation
        /// </summary>
        [Test]
        public void WhenDeleteUgyfelIsCalled_RepoVersionIsCalled()
        {
            this.muv.DeleteUgyfel(2);
            this.m.Verify(x => x.Delete(It.IsAny<Ugyfel>()), Times.Once);
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
