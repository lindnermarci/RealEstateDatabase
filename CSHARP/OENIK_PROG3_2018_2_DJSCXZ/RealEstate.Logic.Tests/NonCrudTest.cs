// <copyright file="NonCrudTest.cs" company="PlaceholderCompany">
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
    /// Non-CRUD operation tests
    /// </summary>
    [TestFixture]
    internal class NonCrudTest : IDisposable
    {
        private Mock<IRepository<Ingatlan>> m1;
        private Mock<IRepository<Szerzodes>> m2;
        private Mock<IRepository<Tulajdonos>> m3;
        private Mock<IRepository<Ugyfel>> m4;
        private Muveletek muv;

        /// <summary>
        /// setting up test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.m1 = new Mock<IRepository<Ingatlan>>();
            List<Ingatlan> ing = new List<Ingatlan>()
            {
                new Ingatlan() { Ing_ID = 1, Cim = "1212 Budapest Edami utca 23.", Tipus = "haz", Alapterulet = 67, SzobaDb = 2 },
                new Ingatlan() { Ing_ID = 2, Cim = "4324 Kekes Edami Hello 3.", Tipus = "lakas", Alapterulet = 98, SzobaDb = 4 },
                new Ingatlan() { Ing_ID = 3, Cim = "5645 Debrecen Szia utca 543.", Tipus = "gazdasagi", Alapterulet = 112, SzobaDb = 3 },
                new Ingatlan() { Ing_ID = 4, Cim = "7565 Kecskemet Kalacs utca 33.", Tipus = "telek", Alapterulet = 56, SzobaDb = 1 },
                new Ingatlan() { Ing_ID = 5, Cim = "3424 Sopron Jozsef utca 2323.", Tipus = "haz", Alapterulet = 83, SzobaDb = 2 }
            };
            this.m1.Setup(x => x.ReadAll()).Returns(ing.AsQueryable());

            this.m2 = new Mock<IRepository<Szerzodes>>();
            List<Szerzodes> szer = new List<Szerzodes>()
            {
                new Szerzodes() { Szerzodes_ID = 1, Ing_ID = 1, Ugyfel_ID = 1, Tipus = "vetel", Ar = 212321313, Datum = DateTime.Parse("2017.03.21.") },
                new Szerzodes() { Szerzodes_ID = 2, Ing_ID = 2, Ugyfel_ID = 2, Tipus = "vetel", Ar = 2123223113, Datum = DateTime.Parse("2016.01.21.") },
                new Szerzodes() { Szerzodes_ID = 3, Ing_ID = 5, Ugyfel_ID = 3, Tipus = "bérlés", Ar = 220000, Datum = DateTime.Parse("2017.06.21.") },
                new Szerzodes() { Szerzodes_ID = 4, Ing_ID = 3, Ugyfel_ID = 4, Tipus = "vetel", Ar = 2123213213, Datum = DateTime.Parse("2012.03.21.") },
                new Szerzodes() { Szerzodes_ID = 5, Ing_ID = 4, Ugyfel_ID = 5, Tipus = "bérlés", Ar = 230000, Datum = DateTime.Parse("2017.03.22.") },
            };

            this.m2.Setup(x => x.ReadAll()).Returns(szer.AsQueryable());

            this.m3 = new Mock<IRepository<Tulajdonos>>();
            List<Tulajdonos> tul = new List<Tulajdonos>()
            {
                new Tulajdonos() { Tul_ID = 1, Cim = "1212 Budapest Edami utca 23.", Nev = "Hello Botond", Mobilszam = "067125432", Email = "dweds@gmail.com" },
                new Tulajdonos() { Tul_ID = 2, Cim = "1212 Budapest Dozsa utca 13.", Nev = "Nagy Botond", Mobilszam = "06765732", Email = "rfew@gmail.com" },
                new Tulajdonos() { Tul_ID = 3, Cim = "1212 Budapest Endrodi utca 653.", Nev = "Kis Botond", Mobilszam = "067789432", Email = "hzgf@gmail.com" },
                new Tulajdonos() { Tul_ID = 4, Cim = "1212 Budapest Jozsef utca 123.", Nev = "Kovacs Botond", Mobilszam = "067123432", Email = "hgf@gmail.com" },
                new Tulajdonos() { Tul_ID = 5, Cim = "1432 Budapest Kakas utca 233.", Nev = "Lindner Botond", Mobilszam = "067178932", Email = "fesd@gmail.com" },
            };

            // az m Mock az l listát adja vissza a getAll hívásakor
            this.m3.Setup(x => x.ReadAll()).Returns(tul.AsQueryable());

            this.m4 = new Mock<IRepository<Ugyfel>>();
            List<Ugyfel> ugy = new List<Ugyfel>()
            {
                new Ugyfel() { Ugyfel_ID = 1, Nev = "Horvat Mihaly", Cim = "23213 Cegled Berceli utca 43", Mobilszam = "7645376", Email = "ewqsd@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 2, Nev = "Ecseri Ilona", Cim = "23221 Bp Berceli utca 3", Mobilszam = "713176", Email = "grf@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 3, Nev = "Horvat Gabor", Cim = "23353 Debrecen Befdci utca 43", Mobilszam = "76423376", Email = "fdsc@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 4, Nev = "Hat Anna", Cim = "232413 Bp fdscvi utca 43", Mobilszam = "3425376", Email = "tgr@gmail.com" },
                new Ugyfel() { Ugyfel_ID = 5, Nev = "Horvat Eszter", Cim = "23433 Cegled Berweli utca 43", Mobilszam = "6775376", Email = "asdx@gmail.com" },
            };

            // az m Mock az l listát adja vissza a getAll hívásakor
            this.m4.Setup(x => x.ReadAll()).Returns(ugy.AsQueryable());

            this.muv = new Muveletek(this.m1.Object, this.m3.Object, this.m4.Object, this.m2.Object);
        }

        /// <summary>
        /// WhenReadingHighValueAggreementOwners_GivesBackCorrectNumOfThem
        /// </summary>
        [Test]
        public void WhenReadingHighValueAggreementOwners_GivesBackCorrectNumOfThem()
        {
            Assert.That(this.muv.NagyErtekuSzerzodestKotottKiadasraTulajdonosok().Count(), Is.EqualTo(2));
        }

        /// <summary>
        /// When emptyRepo ReturnsNo Owners who have agreement above 200000
        /// </summary>
        [Test]
        public void WhenemptyRepo_ReturnsNoOwners()
        {
            this.m1 = new Mock<IRepository<Ingatlan>>();

            this.m2 = new Mock<IRepository<Szerzodes>>();

            this.m3 = new Mock<IRepository<Tulajdonos>>();

            this.m4 = new Mock<IRepository<Ugyfel>>();

            this.muv = new Muveletek(this.m1.Object, this.m3.Object, this.m4.Object, this.m2.Object);
            Assert.That(this.muv.NagyErtekuSzerzodestKotottKiadasraTulajdonosok().Count(), Is.EqualTo(0));
        }

        /// <summary>
        /// WhenReadingClientsWithContractionBefore2017_GivesBackCorrectNumOfThem
        /// </summary>
        [Test]
        public void WhenReadingClientsWithContractionBefore2017_GivesBackCorrectNumOfThem()
        {
            Assert.That(this.muv.Ugyfelek2017ElottSzerzodott().Count(), Is.EqualTo(2));
        }

        /// <summary>
        /// Whenempty Repo Returns No Clients who have contract pre 2017
        /// </summary>
        [Test]
        public void WhenemptyRepo_ReturnsNoClients()
        {
            this.m1 = new Mock<IRepository<Ingatlan>>();

            this.m2 = new Mock<IRepository<Szerzodes>>();

            this.m3 = new Mock<IRepository<Tulajdonos>>();

            this.m4 = new Mock<IRepository<Ugyfel>>();

            this.muv = new Muveletek(this.m1.Object, this.m3.Object, this.m4.Object, this.m2.Object);
            Assert.That(this.muv.Ugyfelek2017ElottSzerzodott().Count(), Is.EqualTo(0));
        }

        /// <summary>
        /// WhenReadingHowManyEstatesRented_GivesBackCorrectNumOfThem
        /// </summary>
        [Test]
        public void WhenReadingHowManyEstatesRented_GivesBackCorrectNumOfThem()
        {
            Assert.That(this.muv.HanyIngatlanBerbe(), Is.EqualTo(2));
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
