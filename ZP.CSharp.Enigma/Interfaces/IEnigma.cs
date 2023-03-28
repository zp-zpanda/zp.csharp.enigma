using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the enigma.</summary>
    */
    public interface IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>
        where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TSingle>, new()
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>, new()
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TRotor : IRotor<TRotor, TRotorPair, TSingle>, new()
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>The entrywheel this enigma has.</summary>
        */
        public TEntrywheel Entrywheel {get; set;}
        /**
        <summary>The rotors this enigma has.</summary>
        */
        public TRotor[] Rotors {get; set;}
        /**
        <summary>The reflector this enigma has.</summary>
        */
        public TReflector Reflector {get; set;}
        /**
        <summary>Creates a enigma with the rotors and the reflector provided.</summary>
        <param name="entrywheel">The entrywheel.</param>
        <param name="rotors">The rotors.</param>
        <param name="reflector">The reflector.</param>
        */
        public static abstract TEnigma New(TEntrywheel entrywheel, IEnumerable<TRotor> rotors, TReflector reflector);
        /**
        <summary>Runs the enigma on a character.</summary>
        <param name="c">The character to run on.</param>
        <returns>The encoded/decoded character.</returns>
        */
        public TSingle RunOn(TSingle c)
        {
            this.Step();
            return Enumerable.Empty<TSingle>()
            .Append(c)
            .Select(c => this.Entrywheel.FromPlugboard(c))
            .Select(c => this.Rotors.Aggregate(c, (c, rotor) => rotor.FromEntryWheel(c)))
            .Select(c => this.Reflector.Reflect(c))
            .Select(c => this.Rotors.Reverse().Aggregate(c, (c, rotor) => rotor.FromReflector(c)))
            .Select(c => this.Entrywheel.FromReflector(c))
            .Single();
        }
        /**
        <summary>Runs the enigma on a string.</summary>
        <param name="m">The string to run on.</param>
        <returns>The encoded/decoded string.</returns>
        */
        public IEnumerable<TSingle> RunOn(IEnumerable<TSingle> m) => m.Select(c => this.RunOn(c));
        /**
        <summary>Steps the enigma.</summary>
        */
        public void Step();
    }
}