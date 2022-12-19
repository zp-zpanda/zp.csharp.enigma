using System;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for the rotor.</summary>
    */
    public static class RotorHelpers
    {
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.IsValid()" />
        */
        public static bool IsValid<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.IsValid();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.FromEntryWheel(char)" />
        */
        public static char FromEntryWheel<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.FromEntryWheel(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.FromReflector(char)" />
        */
        public static char FromReflector<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.FromReflector(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.ComputeDomain()" />
        */
        public static string ComputeDomain<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.ComputeDomain();
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.TransposeIn(char)" />
        */
        public static char TransposeIn<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.TransposeIn(c);
        /**
        <inheritdoc cref="IRotor{TRotor, TRotorPair}.TransposeOut(char)" />
        */
        public static char TransposeOut<TRotor, TRotorPair>(
            this IRotor<TRotor, TRotorPair> r,
            char c)
            where TRotor : IRotor<TRotor, TRotorPair>
            where TRotorPair : IRotorPair<TRotorPair>
            => r.TransposeOut(c);
    }
}