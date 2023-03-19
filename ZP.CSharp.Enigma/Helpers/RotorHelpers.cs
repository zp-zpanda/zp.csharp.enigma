using System;
using System.Collections.Generic;
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
            IEnumerable<TRotorPair> pairs)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            rotor.Pairs = pairs.ToArray();
            if (!rotor.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            rotor.Position = pos % rotor.Pairs.Length;
            rotor.Notch = notch.Select(n => n % rotor.Pairs.Length).ToArray();
            return (TRotor) rotor;
        }
        /**
        <summary>Modifies the rotor to be with the provided position, notches, and rotor pairs.</summary>
        <param name="rotor">The rotor to modify.</param>
        <param name="pos">The position.</param>
        <param name="notch">The turning notches.</param>
        <param name="pairs">The rotor pairs.</param>
        */
        public static TRotor With<TRotor, TRotorPair, TSingle>(
            this IRotor<TRotor, TRotorPair, TSingle> rotor,
            int pos,
            int[] notch,
            IEnumerable<TRotorPair> pairs)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var newRotor = TRotor.New(pos, notch, pairs);
            if (!newRotor.IsValid())
            {
                throw new ArgumentException("Rotor pairs are not valid. They must be bijective (i.e. one-to-one, fully invertible).");
            }
            return newRotor;
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
        public static IEnumerable<TSingle> Domain<TRotor, TRotorPair, TSingle>(
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
            this IEnumerable<IRotor<TRotor, TRotorPair, TSingle>> rotors)
            where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
            where TRotorPair : IRotorPair<TRotorPair, TSingle>
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var previousRotors = rotors.SkipLast(1).Prepend(null);
            var nextRotors = rotors.Skip(1).Append(null);
            rotors.Zip(previousRotors, (current, previous) => (Current: current, Previous: previous))
                .Zip(nextRotors, (rotors, next) => (Current: rotors.Current, Previous: rotors.Previous, Next: next))
                .Select(rotors => (CanStep: rotors.Previous is null || rotors.Previous.AllowNextToStep() || rotors.Current.AllowNextToStep() && rotors.Next is not null, Rotor: rotors.Current))
                .ToList()
                .ForEach(data => {if (data.CanStep) data.Rotor.Step();});
        }
    }
}