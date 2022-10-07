﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            Assert.AreEqual(1, fleet.Ships.Count());


            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            Assert.AreEqual(2, fleet.Ships.Count());
        }
    }
}
