using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The rotateable reflector.</summary>
    */
    public class RotateableReflector<TReflector, TReflectorPair, TInterface, TInterfacePair, TSingle>
        : IReflector<RotateableReflector<TReflector, TReflectorPair, TInterface, TInterfacePair, TSingle>, TReflectorPair, TSingle> 
        where TReflector : IReflector<TReflector, TReflectorPair, TSingle>, new()
        where TReflectorPair : IReflectorPair<TReflectorPair, TSingle>
        where TInterface : IRotor<TInterface, TInterfacePair, TSingle>, new()
        where TInterfacePair : IRotorPair<TInterfacePair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        private TReflector _Reflector;
        /**
        <summary>The actual reflector this moveable reflector delegates to.</summary>
        */
        public required TReflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        private TInterface _Interface;
        /**
        <summary>The rotor that intercepts data for this reflector.</summary>
        */
        public required TInterface Interface {get => this._Interface; set => this._Interface = value;}
        /**
        <summary>The position of this reflector.</summary>
        */
        public required int Position {get => this.Interface.Position; set => this.Interface.Position = value;}
        /**
        <summary>The turning notches of this reflector.</summary>
        */
        public required int[] Notch {get => this.Interface.Notch; set => this.Interface.Notch = value;}
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Pairs" />
        */
        public TReflectorPair[] Pairs {get => this.Reflector.Pairs; set => this.Reflector.Pairs = value;}
        /**
        <inheritdoc cref="New(int, int[], TReflector, IEnumerable{TSingle})"/>
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        public RotateableReflector()
        #pragma warning restore CS8618
        {}
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.New(IEnumerable{TReflectorPair})" />
        */
        public static RotateableReflector<TReflector, TReflectorPair, TInterface, TInterfacePair, TSingle> New(IEnumerable<TReflectorPair> pairs)
            => throw new NotSupportedException();
        /**
        <summary>Creates a moveable reflector with the actual reflector provided.</summary>
        <param name="pos">The position.</param>
        <param name="notch">The turning notch.</param>
        <param name="reflector">The actual reflector.</param>
        <param name="domain">The domain.</param>
        */
        public static RotateableReflector<TReflector, TReflectorPair, TInterface, TInterfacePair, TSingle> New(int pos, int[] notch, TReflector reflector, IEnumerable<TSingle> domain)
            => new()
            {
                Reflector = reflector,
                Interface = TInterface.New(pos, notch, RotorPairHelpers.GetPairsFrom<TInterfacePair, TSingle>(domain, domain))
            };
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair, TSingle}.Reflect(TSingle)" />
        */
        public TSingle Reflect(TSingle s)
            => Enumerable.Empty<TSingle>()
                .Append(s)
                .Select(s => this.Interface.TransposeIn(s))
                .Select(s => this.Reflector.Reflect(s))
                .Select(s => this.Interface.TransposeOut(s))
                .Single();
    }
}