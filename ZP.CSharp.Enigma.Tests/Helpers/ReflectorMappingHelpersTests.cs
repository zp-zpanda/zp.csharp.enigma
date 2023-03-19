using System.Collections.Generic;
using System.Numerics;
using Xunit;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class ReflectorMappingHelpersTests
    {
        public static TheoryData<IEnumerable<char>, IEnumerable<char>, IEnumerable<char>> ToOneTwoResolvesMappingCharData
            => new(){
                {"EJMZALYXVBWFCRQUONTSPIKHGD", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "AEBJCMDZFLGYHXIVKWNROQPUST"},
                {"5079183642", "1234567890", "1520374968"}
            };
        public static TheoryData<IEnumerable<int>, IEnumerable<int>, IEnumerable<int>> ToOneTwoResolvesMappingIntData
            => new(){
                {new[]{5, 0, 7, 9, 1, 8, 3, 6, 4, 2}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}}
                
            };
        public static TheoryData<IEnumerable<char>, IEnumerable<char>, IEnumerable<char>> ToDomainBasedResolvesMappingCharData
            => new(){
                {"AEBJCMDZFLGYHXIVKWNROQPUST", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "EJMZALYXVBWFCRQUONTSPIKHGD"},
                {"1520374968", "1234567890", "5079183642"}
            };
        public static TheoryData<IEnumerable<int>, IEnumerable<int>, IEnumerable<int>> ToDomainBasedResolvesMappingIntData
            => new(){
                {new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{5, 0, 7, 9, 1, 8, 3, 6, 4, 2}}
            };
        [Theory]
        [MemberData(nameof(ToOneTwoResolvesMappingCharData))]
        [MemberData(nameof(ToOneTwoResolvesMappingIntData))]
        public void ToOneTwoResolvesMapping<TSingle>(IEnumerable<TSingle> domainBasedMapping, IEnumerable<TSingle> domain, IEnumerable<TSingle> oneTwoMap)
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var result = ReflectorMappingHelpers.ToOneTwo(domainBasedMapping, domain);
            Assert.Equal(oneTwoMap, result);
        }
        [Theory]
        [MemberData(nameof(ToDomainBasedResolvesMappingCharData))]
        [MemberData(nameof(ToDomainBasedResolvesMappingIntData))]
        public void ToDomainBasedResolvesMapping<TSingle>(IEnumerable<TSingle> oneTwoMapping, IEnumerable<TSingle> domain, IEnumerable<TSingle> domainBasedMap)
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var result = ReflectorMappingHelpers.ToDomainBased(oneTwoMapping, domain);
            Assert.Equal(domainBasedMap, result);
        }
    }
}