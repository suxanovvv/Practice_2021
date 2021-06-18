using System;
using System.Collections.Generic;
using System.Text;
using Aquarium.Fishes;

namespace Aquarium
{   
    public class Aquarium
    {
        private List<List<Cell>> _cellList = new List<List<Cell>>();
        private int _height;
        private int _width;

        private void SpawnFishes()
        {
            var predators = 3;
            var herbFishes = 3;
            var fishchance = _height * _width / predators * herbFishes;
            if (fishchance == 0) fishchance = 1;
            var rand = new Random();
            var stoneSpawned = false;
            var herbSpawned = false;
            while (predators > 0 || herbFishes > 0)
            {
                for (var i = 0; i < _width; i++)
                for (var j = 0; j < _height; j++)
                {
                    var cell = _cellList[i][j];
                    if (cell.IsEmpty())
                    {
                        if (rand.Next(100) < 10 && !stoneSpawned)
                        {
                            var stone = new Stone();
                            cell.CreateStone(stone);
                        }
                        else if (rand.Next(100) < 15 && !herbSpawned)
                        {
                            var herb = new Herb(cell);
                            cell.CreateHerb(herb);
                        }
                        else
                        {
                            if (predators > 0 || herbFishes > 0)
                                if (rand.Next(100) < fishchance)
                                {
                                    if (herbFishes > 0)
                                    {
                                        var fish = new HerbFish(cell);
                                        cell.CreateHerbFish(fish);
                                        herbFishes -= 1;
                                    }
                                    else if (predators > 0)
                                    {
                                        var fish = new PredatorFish(cell);
                                        cell.CreatePredatorFish(fish);
                                        predators -= 1;
                                    }
                                }
                        }
                    }
                }

                stoneSpawned = true;
                herbSpawned = true;
            }
        }
        


        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    sb.Append(GetCell(i, j).ToString()).Append(" : ");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public void Init()
        {
            _width = 5;
            _height = 5;
            for (var i = 0; i < _width; i++)
            {
                var temp = new List<Cell>();
                for (var j = 0; j < _height; j++) temp.Add(new Cell(i, j));
                _cellList.Add(temp);
            }

            SpawnFishes();
        }

        public void NewIteration()
        {
            foreach (List<Cell> cells in _cellList)
            {
                foreach (Cell cell in cells)
                {
                    if (cell.GetHerbFish() != null)
                    {
                        HerbFish herbFish = cell.GetHerbFish();
                        if (!herbFish.CheckDead())
                        {
                            herbFish.Move();
                            herbFish.Eat();
                            herbFish.Validate();
                        }
                    }

                    if (cell.GetPredatorFish() != null)
                    {
                        PredatorFish predatorFish = cell.GetPredatorFish();
                        if (!predatorFish.CheckDead())
                        {
                            predatorFish.Move();
                            predatorFish.Eat();
                            predatorFish.Validate();
                        }
                    }

                    if (cell.GetHerb() != null)
                    {
                        Herb herb = cell.GetHerb();
                        if (herb.IsAlive())
                        {
                            herb.Grow();
                        }
                        else
                        {
                            cell.RemoveHerb();
                            herb.ClearCell();
                        }
                    }
                }
            }

            
                
        }

        public Cell GetCell(int x, int y)
        {
            try
            {
                return _cellList[x][y];
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}