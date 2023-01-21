using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the enigma.</summary>
    */
    public interface IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
        where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TRotor : IRotor<TRotor, TRotorPair, TSingle>
        where TRotorPair : IRotorPair<TRotorPair, TSingle>
        where TReflector : IReflector<TReflector, TReflectorPair, TSingle>
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TMessage : IEnumerable<TSingle>
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
        public TMessage RunOn(TMessage m) => (TMessage) m.Select(c => this.RunOn(c));
        /**
        <summary>Steps the enigma.</summary>
        */
        public void Step();
    }
}