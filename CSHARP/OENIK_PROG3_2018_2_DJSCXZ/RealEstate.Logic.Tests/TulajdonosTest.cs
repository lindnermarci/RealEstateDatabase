// <copyright file="TulajdonosTest.cs" company="PlaceholderCompany">
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
    /// Testing owners
    /// </summary>
    [TestFixture]
    internal sealed class TulajdonosTest : IDisposable
    {
        private Mock<IRepository<Tulajdonos>> m;
        private Muveletek muv;

        /// <summary>
        /// setting up tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.m = new Mock<IRepository<Tulajdonos>>();
            List<Tulajdonos> l = new List<Tulajdonos>()
            {
                new Tulajdonos() { Tul_ID = 1, Cim = "1212 Budapest Edami utca 23.", Nev = "Hello Botond", Mobilszam = "067125432", Email = "dweds@gmail.com" },
                new Tulajdonos() { Tul_ID = 2, Cim = "1212 Budapest Dozsa utca 13.", Nev = "Nagy Botond", Mobilszam = "06765732", Email = "rfew@gmail.com" },
                new Tulajdonos() { Tul_ID = 3, Cim = "1212 Budapest Endrodi utca 653.", Nev = "Kis Botond", Mobilszam = "067789432", Email = "hzgf@gmail.com" },
                new Tulajdonos() { Tul_ID = 4, Cim = "1212 Budapest Jozsef utca 123.", Nev = "Kovacs Botond", Mobilszam = "067123432", Email = "hgf@gmail.com" },
                new Tulajdonos() { Tul_ID = 5, Cim = "1432 Budapest Kakas utca 233.", Nev = "Lindner Botond", Mobilszam = "067178932", Email = "fesd@gmail.com" },
            };

            // az m Mock az l listát adja vissza a getAll hívásakor
            this.m.Setup(x => x.ReadAll()).Returns(l.AsQueryable());

            // Muveletek letrehozasa
            this.muv = new Muveletek(this.m.Object);
        }

        /// <summary>
        /// WhenReadingIngatlanok_AllOfThemReturned
        /// </summary>
        [Test]
        public void WhenReadingIngatlanok_AllOfThemReturned()
        {
            Assert.That(this.muv.ReadTulajdonosok().Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// WhenReadingByID_TulajdonosReturned
        /// </summary>
        /// <param name="id">Owner ID</param>
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(2)]
        [TestCase(5)]
        public void WhenReadingByID_TulajdonosReturned(int id)
        {
            Assert.That(this.muv.ReadTulajdonosById(id).Tul_ID, Is.EqualTo(id));
        }

        /// <summary>
        /// WhenNewTulajdonosIsCalled_RepoVersionIsCalled
        /// </summary>
        [Test]
        public void WhenNewTulajdonosIsCalled_RepoVersionIsCalled()
        {
            this.muv.NewTulajdonos(1, "dead dsa", "21334 red de 19", "067438765", "dqewd@yahoo.com");
            this.m.Verify(x => x.Create(It.IsAny<Tulajdonos>()), Times.Once);
        }

        /// <summary>
        /// WhenDeleteTulajdonosIsCalled_RepoVersionIsCalled
        /// </summary>
        [Test]
        public void WhenDeleteTulajdonosIsCalled_RepoVersionIsCalled()
        {
            this.muv.DeleteTulajdonos(1);
            this.m.Verify(x => x.Delete(It.IsAny<Tulajdonos>()), Times.Once);
        }

        /// <summary>
        /// disposing realestateModel
        /// </summary>
        public void Dispose()
        {
            this.muv.Dispose();
        }
    }
}