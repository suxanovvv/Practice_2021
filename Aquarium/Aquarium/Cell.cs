using System.Text;
using Aquarium.Fishes;

namespace Aquarium
{
    public class Cell
    {
        private Herb _herb;
        private HerbFish _herbFish;
        private PredatorFish _predatorFish;
        private Stone _stone;
        private readonly int _x;
        private readonly int _y;

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
            _herb = null;
            _stone = null;
            _herbFish = null;
            _predatorFish = null;
        }

        public void CreateStone(Stone stone)
        {
            this._stone = stone;
        }

        public void CreateHerb(Herb herb)
        {
            this._herb = herb;
        }

        public void CreateHerbFish(HerbFish fish)
        {
            _herbFish = fish;
        }

        public void CreatePredatorFish(PredatorFish fish)
        {
            _predatorFish = fish;
        }

        public void RemoveHerb()
        {
            this._herb = null;
        }

        public void RemoveHerbFish()
        {
            _herbFish = null;
        }

        public void RemovePredatorFish()
        {
            _predatorFish = null;
        }

        public Herb GetHerb()
        {
            return _herb;
        }

        public Stone GetStone()
        {
            return _stone;
        }

        public HerbFish GetHerbFish()
        {
            return _herbFish;
        }

        public PredatorFish GetPredatorFish()
        {
            return _predatorFish;
        }

        public bool IsEmpty()
        {
            return _stone == null && _herbFish == null && _predatorFish == null && _herb == null;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public bool IsAviable(HerbFish fish)
        {
            return _predatorFish == null && _herbFish == null && _stone == null;
        }

        public bool IsAviable(PredatorFish fish)
        {
            return _predatorFish == null && _stone == null;
        }

        public void MoveHerbFish()
        {
            _herbFish = null;
        }

        public void MovePredatorFish()
        {
            _predatorFish = null;
        }

        public void MoveHerbFishHere(HerbFish fish)
        {
            _herbFish = fish;
        }

        public void MovePredatorFishHere(PredatorFish fish)
        {
            _predatorFish = fish;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_stone != null)
            {
                sb.Append("S");
            }
            else
            {
                sb.Append(" ");
            }

            if (_herb != null)
            {
                sb.Append("H");
            }
            else
            {
                sb.Append(" ");
            }

            if (_herbFish != null)
            {
                if (_herbFish.GetisMale())
                {
                    sb.Append("F");
                }
                else
                {
                    sb.Append("f");
                }

                sb.Append("[");
                sb.Append(_herbFish.ToString());
                sb.Append("]");
            }
            else
            {
                sb.Append("      ");
            }
            if (_predatorFish != null)
            {
                if (_predatorFish.GetisMale())
                {
                    sb.Append("P");
                }
                else
                {
                    sb.Append("p");
                }

                sb.Append("[");
                sb.Append(_predatorFish.ToString());
                sb.Append("]");
            }
            else
            {
                sb.Append("      ");
            }

            return sb.ToString();
        }
    }
}