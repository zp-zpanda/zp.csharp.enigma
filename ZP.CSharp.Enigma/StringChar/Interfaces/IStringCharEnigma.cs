using System.Collections.Generic;
using System.Linq;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the string-char enigma.</summary>
    */
    public interface IStringCharEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> :
        IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>,
        IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>
        where TEnigma :
            IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>,
            IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>,
            new()
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>, new()
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
        where TRotor : IRotor<TRotor, TRotorPair, char>, new()
        where TRotorPair : IRotorPair<TRotorPair, char>
        where TReflector : IReflector<TReflector, TReflectorPair, char>
        where TReflectorPair : IReflectorPair<TReflectorPair, char>
    {
        string IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>.RunOn(string s) => this.RunOn(s);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TMessage)" />
        */
        public new string RunOn(string s) => new(this.RunOn(s.AsEnumerable()).ToArray());
        IEnumerable<char> IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>.RunOn(IEnumerable<char> m) => this.RunOn(m);
        /**
        <inheritdoc cref="IEnigma{TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, TMessage, TSingle}.RunOn(TMessage)" />
        */
        public new IEnumerable<char> RunOn(IEnumerable<char> m) => m.Select(c => (this as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>).RunOn(c));
    }
}