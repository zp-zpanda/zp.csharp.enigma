using System;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    public class RotorPair
    {
        public char EntryWheelSide;
        public char ReflectorSide;
        public RotorPair(char eSide, char rSide)
        {
            this.EntryWheelSide = eSide;
            this.ReflectorSide = rSide;
        }
        public RotorPair(string map)
        {
            if (map.Length != 2)
            {
                throw new ArgumentException("Mapping is not two characters long. Expected mapping: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            this.EntryWheelSide = map[0];
            this.ReflectorSide = map[1];
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (obj is RotorPair pair)
            {
                return pair == this;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (new char[]{this.EntryWheelSide, this.ReflectorSide}).GetHashCode();
        }
        public static bool operator ==(RotorPair pair1, RotorPair pair2)
        {
            return (pair1.EntryWheelSide == pair2.EntryWheelSide) && (pair1.ReflectorSide == pair2.ReflectorSide);
        }
        public static bool operator !=(RotorPair pair1, RotorPair pair2)
        {
            return !(pair1 == pair2);
        }
    }
}