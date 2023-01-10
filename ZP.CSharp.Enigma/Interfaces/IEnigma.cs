using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the enigma.</summary>
    */
    public interface IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
        where TEnigma : IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>
        where TRotor : IRotor<TRotor, TRotorPair>
        where TRotorPair : IRotorPair<TRotorPair>
        where TReflector : IReflector<TReflector, TReflectorPair>
        where TReflectorPair : IReflectorPair<TReflectorPair>
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
        public char RunOn(char c)
        {
            this.Step();
            return Enumerable.Empty<char>()
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
        <param name="s">The string to run on.</param>
        <returns>The encoded/decoded string.</returns>
        */
        public string RunOn(string s) => new(s.Select(c => this.RunOn(c)).ToArray());
        /**
        <summary>Steps the enigma.</summary>
        */
        public void Step();
    }
}