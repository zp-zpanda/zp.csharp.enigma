using System;
using System.Linq;
using System.Numerics;
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
        public static TRotor Setup<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> rotor,
            int pos,
            int[] notch,
            params TRotorPair[] pairs)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            rotor.Pairs = pairs;
            if (!rotor.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            rotor.Position = pos % rotor.Pairs.Length;
            rotor.Notch = notch.Select(n => n % rotor.Pairs.Length).ToArray();
            return (TRotor) rotor;
        }
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.IsValid()" />
        */
        public static bool IsValid<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.IsValid();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.FromEntryWheel(TSingle)" />
        */
        public static TSingle FromEntryWheel<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r,
            TSingle c)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.FromEntryWheel(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.FromReflector(TSingle)" />
        */
        public static TSingle FromReflector<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r,
            TSingle c)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.FromReflector(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.Domain()" />
        */
        public static TSingle[] Domain<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.Domain();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.TransposeIn(TSingle)" />
        */
        public static TSingle TransposeIn<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r,
            TSingle c)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.TransposeIn(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair, TSingle}.TransposeOut(TSingle)" />
        */
        public static TSingle TransposeOut<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> r,
            TSingle c)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => r.TransposeOut(c);
        /**
        <summary>Steps the rotor with the double stepping mechanism.</summary>
        <param name="rotors">The rotors to step.</param>
        */
        public static void StepWithDoubleSteppingMechanism<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle>[] rotors)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
            => rotors
                .SkipLast(1)
                .Prepend(null)
                .Zip(rotors, (previous, current) => (Previous: previous, Current: current))
                .Select(rotors => (CanStep: rotors.Previous == null || rotors.Previous.AllowNextToStep() || rotors.Current.AllowNextToStep(), Rotor: rotors.Current))
                .ToList()
                .ForEach(data => {if (data.CanStep) data.Rotor.Step();});
    }
}