using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EnigmaTests
    {
        public Enigma BasicEnigma = new Enigma(new Reflector(new ReflectorPair("ab"), new ReflectorPair("cd")), new Rotor(new RotorPair("ac"), new RotorPair("ba"), new RotorPair("cd"), new RotorPair("db")));
        [Fact]
        public void EnigmaWillNotReturnInputAsOutput()
        {
            Assert.All(new char[]{'a', 'b', 'c', 'd'}, c => Assert.NotEqual(c, this.BasicEnigma.RunOn(c)));
        }
    }
}