using System;
using System.Linq;
using System.Collections.Generic;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the rotor.</summary>
    */
    public static class RotorHelpers
    {
        public static void Setup<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            int pos,
            int[] notch,
            params TRotorPair[] pairs)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
        {
            r.Pairs = pairs;
            if (!r.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            r.Domain = r.ComputeDomain();
            r.Position = pos % r.Pairs.Length;
            r.Notch = notch.Select(n => n % r.Pairs.Length).ToArray();
        }
        public static TRotorPair[] GetPairsFrom<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> rotor,
            params string[] maps)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
        {
            if (!maps.All(map => map.Count() == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            return maps.Select(map => TRotorPair.New(map.First(), map.Last())).ToArray();
        }
        public static TRotorPair[] GetPairsFrom<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> rotor,
            string e,
            string r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
        {
            var length = 0;
            try
            {
                length = new string[]{e, r}.Select(s => s.Length).Distinct().Single();
            }
            catch
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            return Enumerable.Range(0, length).Select(i => TRotorPair.New(e[i], r[i])).ToArray();
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.IsValid()" />
        */
        public static bool IsValid<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.IsValid();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.FromEntryWheel(char)" />
        */
        public static char FromEntryWheel<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.FromEntryWheel(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.FromReflector(char)" />
        */
        public static char FromReflector<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.FromReflector(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.ComputeDomain()" />
        */
        public static string ComputeDomain<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.ComputeDomain();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.TransposeIn(char)" />
        */
        public static char TransposeIn<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.TransposeIn(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.TransposeOut(char)" />
        */
        public static char TransposeOut<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.TransposeOut(c);
        public static void StepWithDoubleSteppingMechanism<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair>[] rotors)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
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