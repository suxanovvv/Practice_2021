using System;

namespace Aquarium.Fishes
{
    public class HerbFish : AbstractFish
    {
        public HerbFish(Cell cell)
        {
            Cell = cell;
            var rand = new Random();
            AgeBeginMature = 10;
            AgeEndMature = 60;
            AgeMax = 100;
            AgeCurrent = 0.1;
            IsMale = rand.Next(100) < 50;
            Death = DeathType.Null;
            FoodDecreaseAmount = 0.1;
            FoodMaxLevel = 100;
            FoodLevel = FoodMaxLevel;
        }


        protected override bool Trymove(int x, int y)
        {
            var newCell = Program.Aquarium.GetCell(x, y);
            if (newCell == null) return false;
            if (newCell.IsAviable(this))
            {
                newCell.MoveHerbFishHere(this);
                Cell.MoveHerbFish();
                Cell = newCell;
                return true;
            }

            return false;
        }

        public void Eat()
        {
            if (Cell.GetHerb() != null)
            {
                var herb = Cell.GetHerb();
                FoodLevel += herb.Eat(FoodMaxLevel - FoodLevel);
            }
        }

        public double Eated(double amount)
        {
            Death = DeathType.ByPredator;
            return Math.Min(amount, FoodLevel);
        }


        public override bool CheckDead()
        {
            if (!IsAlive())
            {
                Cell.RemoveHerbFish();
                Cell = null;
                return true;
            }

            return false;
        }

        public void Die()
        {
            Cell.RemoveHerbFish();
            Cell = null;
        }
    }
}