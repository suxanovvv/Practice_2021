using System;

namespace Aquarium.Fishes
{
    public class PredatorFish : AbstractFish
    {
        public PredatorFish(Cell cell)
        {
            Cell = cell;
            var rand = new Random();
            AgeBeginMature = 10;
            AgeEndMature = 70;
            AgeMax = 100;
            AgeCurrent = 0.1;
            IsMale = rand.Next() < 50;
            Death = DeathType.Null;
            FoodDecreaseAmount = 0.1;
            FoodMaxLevel = 100;
            FoodLevel = FoodMaxLevel;
        }

        public void Eat()
        {
            if (Cell.GetHerbFish() != null && FoodLevel < FoodMaxLevel * 0.6)
            {
                var fish = Cell.GetHerbFish();
                FoodLevel += fish.Eated(FoodMaxLevel - FoodLevel);
                fish.Die();
            }
        }

        protected override bool Trymove(int x, int y)
        {
            Cell newCell;
            try
            {
               newCell = Program.Aquarium.GetCell(x, y);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
             
            if (newCell == null) return false;
            if (newCell.IsAviable(this))
            {
                newCell.MovePredatorFishHere(this);
                Cell.MovePredatorFish();
                Cell = newCell;
                return true;
            }

            return false;
        }

        public override bool CheckDead()
        {
            if (!IsAlive())
            {
                Cell.RemovePredatorFish();
                Cell = null;
                return true;
            }

            return false;
        }
    }
}