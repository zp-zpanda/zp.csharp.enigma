using System;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the reflector.</summary>
    */
    public static class ReflectorHelpers
    {
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.IsValid()" />
        */
        public static bool IsValid<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> r)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => r.IsValid();
            /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.Reflect(char)" />
        */
        public static char Reflect<TReflector, TReflectorPair>(
            this IReflector<TReflector, TReflectorPair> r,
            char c)
            where TReflector : IReflector<TReflector, TReflectorPair>
            where TReflectorPair : IReflectorPair<TReflectorPair>
            => r.Reflect(c);
    }
}