using System.Collections.Generic;
using System.Linq;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the string enigma.</summary>
    */
    public interface IStringEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair> :
        IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>,
        IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>
        where TEnigma :
            IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>,
            IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>
        where TEntrywheel : IEntrywheel<TEntrywheel, TEntrywheelPair, char>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, char>
        where TRotor : IRotor<TRotor, TRotorPair, char>
        where TRotorPair : IRotorPair<TRotorPair, char>
        where TReflector : IReflector<TReflector, TReflectorPair, char>
        where TReflectorPair : IReflectorPair<TReflectorPair, char>
    {
        string IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, string, char>.RunOn(string s) => this.RunOn(s);
        public string RunOn(string s) => new(this.RunOn(s.AsEnumerable()).ToArray());
        IEnumerable<char> IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>.RunOn(IEnumerable<char> m) => this.RunOn(m);
        public IEnumerable<char> RunOn(IEnumerable<char> m) => m.Select(c => (this as IEnigma<TEnigma, TEntrywheel, TEntrywheelPair, TRotor, TRotorPair, TReflector, TReflectorPair, IEnumerable<char>, char>).RunOn(c));
    }
}