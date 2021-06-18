using System;

namespace Aquarium
{
    public class Herb
    {
        private static double _energyIncreaseOnIteration;
        private Cell _cell;
        private double _energyCurrent;
        private readonly double _energyMax;

        public Herb(Cell cell)
        {
            this._cell = cell;
            _energyMax = 100;
            _energyCurrent = new Random().Next((int) _energyMax);
        }

        public void Grow()
        {
            _energyCurrent += _energyIncreaseOnIteration;
            if (_energyCurrent > _energyMax)
                _energyCurrent = _energyMax;
        }

        public double Eat(double amount)
        {
            return Math.Min(_energyCurrent, amount);
        }

        public bool IsAlive()
        {
            return _energyCurrent != 0;
        }

        public void ClearCell()
        {
            _cell = null;
        }
    }
}