using System.Numerics;
using Xunit;
namespace ZP.CSharp.Enigma.Helpers.Tests
{
    public class ReflectorMappingHelpersTests
    {
        public static TheoryData<char[], char[], char[]> ToOneTwoResolvesMappingCharData
            => new(){
                {"EJMZALYXVBWFCRQUONTSPIKHGD".ToCharArray(), "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), "AEBJCMDZFLGYHXIVKWNROQPUST".ToCharArray()},
                {"5079183642".ToCharArray(), "1234567890".ToCharArray(), "1520374968".ToCharArray()}
            };
        public static TheoryData<int[], int[], int[]> ToOneTwoResolvesMappingIntData
            => new(){
                {new[]{5, 0, 7, 9, 1, 8, 3, 6, 4, 2}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}}
                
            };
        public static TheoryData<char[], char[], char[]> ToDomainBasedResolvesMappingCharData
            => new(){
                {"AEBJCMDZFLGYHXIVKWNROQPUST".ToCharArray(), "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), "EJMZALYXVBWFCRQUONTSPIKHGD".ToCharArray()},
                {"1520374968".ToCharArray(), "1234567890".ToCharArray(), "5079183642".ToCharArray()}
            };
        public static TheoryData<int[], int[], int[]> ToDomainBasedResolvesMappingIntData
            => new(){
                {new[]{1, 5, 2, 0, 3, 7, 4, 9, 6, 8}, new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{5, 0, 7, 9, 1, 8, 3, 6, 4, 2}}
            };
        [Theory]
        [MemberData(nameof(ToOneTwoResolvesMappingCharData))]
        [MemberData(nameof(ToOneTwoResolvesMappingIntData))]
        public void ToOneTwoResolvesMapping<TSingle>(TSingle[] domainBasedMapping, TSingle[] domain, TSingle[] oneTwoMap)
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var result = ReflectorMappingHelpers.ToOneTwo(domainBasedMapping, domain);
            Assert.Equal(oneTwoMap, result);
        }
        [Theory]
        [MemberData(nameof(ToDomainBasedResolvesMappingCharData))]
        [MemberData(nameof(ToDomainBasedResolvesMappingIntData))]
        public void ToDomainBasedResolvesMapping<TSingle>(TSingle[] oneTwoMapping, TSingle[] domain, TSingle[] domainBasedMap)
            where TSingle : IEqualityOperators<TSingle, TSingle, bool>
        {
            var result = ReflectorMappingHelpers.ToDomainBased(oneTwoMapping, domain);
            Assert.Equal(domainBasedMap, result);
        }
    }
}