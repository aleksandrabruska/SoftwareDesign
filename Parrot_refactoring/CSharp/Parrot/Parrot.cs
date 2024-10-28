using System;

namespace Parrot
{
    public abstract class Parrot
    {
        public static Parrot CreateParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(voltage, isNailed);
            }
            throw new Exception("Should be unreachable");
        }

        public abstract double GetSpeed();
        
        protected double GetBaseSpeed()
        {
            return 12.0;
        }
    }

    public class EuropeanParrot : Parrot
    {
        public override double GetSpeed() => GetBaseSpeed();
    }

    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;

        public AfricanParrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }

        public override double GetSpeed() => Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly bool _isNailed;
        private readonly double _voltage;

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            _isNailed = isNailed;
            _voltage = voltage;
        }

        private  double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        public override double GetSpeed() => _isNailed ? 0 : GetBaseSpeed(_voltage);
    }
}