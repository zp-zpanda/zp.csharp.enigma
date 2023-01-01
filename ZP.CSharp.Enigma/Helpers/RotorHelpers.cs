using System;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the rotor.</summary>
    */
    public static class RotorHelpers
    {
        /**
        <summary>Sets up the reflector.</summary>
        <param name="rotor">The reflector to set up.</param>
        <param name="pos">The position.</param>
        <param name="notch">The turning notches.</param>
        <param name="pairs">The reflector pairs.</param>
        */
        public static void Setup<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> rotor,
            int pos,
            int[] notch,
            params TRotorPair[] pairs)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
        {
            rotor.Pairs = pairs;
            if (!rotor.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            rotor.Domain = rotor.ComputeDomain();
            rotor.Position = pos % rotor.Pairs.Length;
            rotor.Notch = notch.Select(n => n % rotor.Pairs.Length).ToArray();
        }
        /**
        <summary>Gets pairs from multiple string maps.</summary>
        <param name="rotor">The rotor to get pairs for.</param>
        <param name="maps">The maps.</param>
        */
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
        /**
        <summary>Gets pairs from two mappings.</summary>
        <param name="rotor">The rotor to get pairs for.</param>
        <param name="e">The entrywheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
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
        /**
        <summary>Steps the rotor with the double stepping mechanism.</summary>
        <param name="rotors">The rotors to step.</param>
        */
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