// <copyright file="IngatlanTest.cs" company="PlaceholderCompany">
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
    /// Tests RealEstate repo
    /// </summary>
    [TestFixture]
    internal sealed class IngatlanTest : IDisposable
    {
        private Mock<IRepository<Ingatlan>> m;
        private Muveletek muv;

        /// <summary>
        /// setting up test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.m = new Mock<IRepository<Ingatlan>>();
            List<Ingatlan> l = new List<Ingatlan>()
            {
                new Ingatlan() { Ing_ID = 1, Cim = "1212 Budapest Edami utca 23.", Tipus = "haz", Alapterulet = 67, SzobaDb = 2 },
                new Ingatlan() { Ing_ID = 2, Cim = "4324 Kekes Edami Hello 3.", Tipus = "lakas", Alapterulet = 98, SzobaDb = 4 },
                new Ingatlan() { Ing_ID = 3, Cim = "5645 Debrecen Szia utca 543.", Tipus = "gazdasagi", Alapterulet = 112, SzobaDb = 3 },
                new Ingatlan() { Ing_ID = 4, Cim = "7565 Kecskemet Kalacs utca 33.", Tipus = "telek", Alapterulet = 56, SzobaDb = 1 },
                new Ingatlan() { Ing_ID = 5, Cim = "3424 Sopron Jozsef utca 2323.", Tipus = "haz", Alapterulet = 83, SzobaDb = 2 }
            };
            this.m.Setup(x => x.ReadAll()).Returns(l.AsQueryable());
            this.muv = new Muveletek(this.m.Object);
        }

        /// <summary>
        /// WhenReadingIngatlanok_AllOfThemReturned
        /// </summary>
        [Test]
        public void WhenReadingIngatlanok_AllOfThemReturned()
        {
            Assert.That(this.muv.ReadIngatlanok().Count(), Is.EqualTo(5));
        }

        /// <summary>
        /// WhenReadingByID_IngatlanReturned
        /// </summary>
        /// <param name="id">RealEstate ID</param>
        [TestCase(3)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(2)]
        [TestCase(5)]
        public void WhenReadingByID_IngatlanReturned(int id)
        {
            Assert.That(this.muv.ReadIngatlanById(id).Ing_ID, Is.EqualTo(id));
        }

        /// <summary>
        /// WhenNewIngatlanIsCalled_RepoVersionIsCalled
        /// </summary>
        [Test]
        public void WhenNewIngatlanIsCalled_RepoVersionIsCalled()
        {
            this.muv.NewIngatlan(15, "dswdqas", "dwq", 332, 2);
            this.m.Verify(x => x.Create(It.IsAny<Ingatlan>()), Times.Once);
        }

        /// <summary>
        /// WhenDeleteIngatlanIsCalled_RepoVersionIsCalled
        /// </summary>
        [Test]
        public void WhenDeleteIngatlanIsCalled_RepoVersionIsCalled()
        {
            this.muv.DeleteIngatlan(2);
            this.m.Verify(x => x.Delete(It.IsAny<Ingatlan>()), Times.Once);
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
