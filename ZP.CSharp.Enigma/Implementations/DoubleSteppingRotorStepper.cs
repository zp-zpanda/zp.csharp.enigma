using System;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Implementations;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <inheritdoc cref="RotorStepper" />
    <summary>The rotor double-stepping machanism.</summary>
    */
    public class DoubleSteppingRotorStepper
    {
        /**
        <inheritdoc cref="RotorStepper.Step(Rotor[])" />
        */
        public void Step(Rotor[] rotors)
        {
            var length = rotors.Length;
            var canStep = Enumerable.Repeat(false, length).ToArray();
            canStep[0] = true;
            for (var i = 1; i < length; i++)
            {
                canStep[i] = rotors[i - 1].AllowNextToStep() || rotors[i].AllowNextToStep();
            }
            rotors[0].Step();
            for (var i = 1; i < length; i++)
            {
                if (canStep[i])
                {
                    rotors[i].Step();
                }
            }
        }
    }
}