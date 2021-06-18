using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.Fishes
{
    public abstract class AbstractFish
    {
        protected double AgeBeginMature = 0; //
        protected double AgeCurrent; //
        protected double AgeEndMature = 0; //
        protected double AgeMax = 0; //
        protected Cell Cell;
        protected DeathType Death = DeathType.Null; //

        protected List<int> Directions = new List<int> {1, 2, 3, 4, 6, 7, 8, 9};
        protected double FoodDecreaseAmount = 0; //
        protected double FoodLevel; //
        protected double FoodMaxLevel = 0; //
        protected bool IsMale = false; //

        public AbstractFish()
        {
        }

        public AbstractFish(Cell cell)
        {
            Cell = cell;
        }

        private bool IsDead()
        {
            return Death != DeathType.Null;
        }

        private DeathType GetDeathReason()
        {
            return Death;
        }

        public void Move()
        {
            var x = Cell.GetX();
            var y = Cell.GetY();
            var rand = new Random();
            var directions = new List<int>(this.Directions);
            var isMoved = false;
            var tempx = 0;
            var tempy = 0;
            while (directions.Count != 0 && !isMoved)
            {
                var dir = rand.Next(directions.Count);
                switch (directions[dir])
                {
                    case 1:
                        tempx = x - 1;
                        tempy = y - 1;
                        break;
                    case 2:
                        tempx = x;
                        tempy = y - 1;
                        break;
                    case 3:
                        tempx = x + 1;
                        tempy = y - 1;
                        break;
                    case 4:
                        tempx = x - 1;
                        tempy = y;
                        break;
                    case 6:
                        tempx = x + 1;
                        tempy = y;
                        break;
                    case 7:
                        tempx = x - 1;
                        tempy = y + 1;
                        break;
                    case 8:
                        tempx = x;
                        tempy = y + 1;
                        break;
                    case 9:
                        tempx = x + 1;
                        tempy = y + 1;
                        break;
                }

                if (Trymove(tempx, tempy))
                    isMoved = true;
                else
                    directions.Remove(directions[dir]);
            }
        }

        protected abstract bool Trymove(int x, int y);

        public abstract bool CheckDead();

        public bool GetisMale()
        {
            return IsMale;
        }

        public bool IsAlive()
        {
            if (FoodLevel <= 0) Death = DeathType.ByHunger;
            //System.out.println("Fish at "+Cell.getX()+", "+Cell.getY()+" Dead by Hunger!");
            if (AgeCurrent > AgeMax) Death = DeathType.ByAge;
            //System.out.println("Fish at "+Cell.getX()+", "+Cell.getY()+" Dead by Age!");
            if (Death != DeathType.Null)
                return false;
            return true;
        }

        public int GetHungry()
        {
            if (FoodLevel <= FoodMaxLevel * 0.3)
                return 0;
            if (FoodLevel <= FoodMaxLevel * 0.7)
                return 1;
            return 2;
        }

        public int GetAge()
        {
            if (AgeCurrent <= AgeBeginMature)
                return 0;
            if (AgeCurrent <= AgeEndMature)
                return 1;
            return 2;
        }
        

        public void Validate()
        {
            FoodLevel -= FoodDecreaseAmount;
            AgeCurrent += 0.1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetAge());
            if (GetHungry() == 2)
            {
                sb.Append("Nh");
            }
            else if (GetHungry() == 1)
            {
                sb.Append("Lh");
            }
            else
            {
                sb.Append("Wh");
            }

            return sb.ToString();
        }
    }
}