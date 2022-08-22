using System;
using Xunit;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Models;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class RotorTests
    {
        [Fact]
        public void RotorDefaultsToZeroRotorPairs()
        {
            var rotor = new Rotor();
            Assert.Empty(rotor.Pairs);
        }
        [Fact]
        public void RotorPairsCanBeAddedToRotor()
        {
            var pair1 = new RotorPair('a', 'z');
            var pair2 = new RotorPair('z', 'a');
            var rotor = new Rotor(pair1, pair2);
            Assert.Contains(pair1, rotor.Pairs);
            Assert.Contains(pair2, rotor.Pairs);
        }
    }
}