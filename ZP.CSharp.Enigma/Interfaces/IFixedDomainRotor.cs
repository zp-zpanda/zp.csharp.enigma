namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the fixed-domain rotor.</summary>
    */
    public interface IFixedDomainRotor<TRotor, TRotorPair> : IRotor<TRotor, TRotorPair>
        where TRotor : IFixedDomainRotor<TRotor, TRotorPair>
        where TRotorPair : IRotorPair<TRotorPair>
    {
        /**
        <summary>Gets the fixed domain.</summary>
        */
        public static abstract string FixedDomain();
    }
}