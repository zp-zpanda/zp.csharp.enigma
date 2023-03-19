using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace ZP.CSharp.Enigma.Helpers
{
    /**
    <summary>Helpers for reflector mappings.</summary>
    */
    public static class ReflectorMappingHelpers
    {
        /**
        <summary>Converts a one-two mapping to a domain-based mapping with a domain.</summary>
        <param name="oneTwoMapping">The one-two mapping.</param>
        <param name="domain">The domain.</param>
        <returns>The domain-based mapping.</returns>
        */
        public static IEnumerable<TSingle> ToDomainBased<TSingle>(IEnumerable<TSingle> oneTwoMapping, IEnumerable<TSingle> domain)
        {
            var maps = new TSingle[oneTwoMapping.Count()];
            oneTwoMapping
                .Select((item, index) => (Index: Math.DivRem(index, 2, out int _), Item: item))
                .GroupBy(data => data.Index)
                .Select(group => group.Select(data => data.Item))
                .Select(data => new[]{(Item: data.First(), Index: Array.IndexOf(domain.ToArray(), data.Last())), (Item: data.Last(), Index: Array.IndexOf(domain.ToArray(), data.First()))})
                .SelectMany(m => m)
                .ToList()
                .ForEach(data => maps[data.Index] = data.Item);
            return maps;
        }
        /**
        <summary>Converts a domain-based mapping to a one-two mapping with a domain.</summary>
        <param name="domainBasedMapping">The domain-based mapping.</param>
        <param name="domain">The domain.</param>
        <returns>The one-two mapping.</returns>
        */
        public static IEnumerable<TSingle> ToOneTwo<TSingle>(IEnumerable<TSingle> domainBasedMapping, IEnumerable<TSingle> domain)
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var mapsWithIndexes = domainBasedMapping
                .Select((item, index) => (SelfIndex: index, DomainIndex: Array.IndexOf(domain.ToArray(), item)))
                .Zip(domainBasedMapping, (idxes, item) => (Indexes: idxes, Item: item));
            var maps = mapsWithIndexes.Join(
                mapsWithIndexes,
                map => (map.Indexes.SelfIndex, map.Indexes.DomainIndex),
                map => (map.Indexes.DomainIndex, map.Indexes.SelfIndex),
                (map1, map2) => (First: map1, Second: map2));
            return maps.Join(
                maps,
                map => (map.First.Indexes.SelfIndex, map.First.Indexes.DomainIndex, map.First.Item, map.Second.Item),
                map => (map.Second.Indexes.SelfIndex, map.Second.Indexes.DomainIndex, map.Second.Item, map.First.Item),
                (map1, map2) => new[]{map1, map2}.OrderBy(m => Array.IndexOf(domain.ToArray(), m.First.Item)).First())
                .DistinctBy(m => (m.First.Item, m.Second.Item))
                .Select(m => new[]{m.First.Item, m.Second.Item})
                .SelectMany(m => m);
        }
    }
}