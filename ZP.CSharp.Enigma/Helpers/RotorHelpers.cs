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
        <summary>Sets up the rotor.</summary>
        <param name="rotor">The rotor to set up.</param>
        <param name="pos">The position.</param>
        <param name="notch">The turning notches.</param>
        <param name="pairs">The rotor pairs.</param>
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
            rotor.Position = pos % rotor.Pairs.Length;
            rotor.Notch = notch.Select(n => n % rotor.Pairs.Length).ToArray();
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
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Domain()" />
        */
        public static string Domain<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.Domain();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.Domain()" />
        */
        public static string Domain<TRotor, TRotorPair>(
            this IFixedDomainRotor<TRotor, TRotorPair> r)
            where TRotor : IFixedDomainRotor<TRotor, TRotorPair>, IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => TRotor.FixedDomain();
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
            => rotors
                .SkipLast(1)
                .Prepend(null)
                .Zip(rotors, (previous, current) => (Previous: previous, Current: current))
                .Select(rotors => (CanStep: rotors.Previous == null || rotors.Previous.AllowNextToStep() || rotors.Current.AllowNextToStep(), Rotor: rotors.Current))
                .ToList()
                .ForEach(data => {if (data.CanStep) data.Rotor.Step();});
    }
}