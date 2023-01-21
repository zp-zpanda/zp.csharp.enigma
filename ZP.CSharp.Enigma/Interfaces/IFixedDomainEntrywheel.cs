using System.Numerics;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the fixed-domain entrywheel.</summary>
    */
    public interface IFixedDomainEntrywheel<TEntrywheel, TEntrywheelPair, TSingle> : IEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
        where TEntrywheel : IFixedDomainEntrywheel<TEntrywheel, TEntrywheelPair, TSingle>
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair, TSingle>
        where TSingle : IEqualityOperators<TSingle, TSingle, bool>
    {
        /**
        <summary>Gets the fixed domain.</summary>
        */
        public static abstract TSingle[] FixedDomain();
    }
}