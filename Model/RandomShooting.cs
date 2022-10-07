﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        public RandomShooting(EnemyGrid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        private EnemyGrid grid;
        private int shipLength;
        private Random random = new Random();
        public Square NextTarget()
        {
            var availablePlacements = grid.GetAvailablePlacements(shipLength);
            var all = availablePlacements.SelectMany(x => x);
            int index = random.Next(all.Count());
            return all.ElementAt(index);
        }
    }
}
