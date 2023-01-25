using Xunit;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Models.Tests
{
    public class EnigmaZTests
    {
        public class WithStringTests
        {
            public static TheoryData<(string, string, string), (int, int, int, int), char> EnigmaWillNotReturnInputAsOutputData
                => new(){
                    {("II", "I", "III"), (0, 0, 0, 0), '0'},
                    {("III", "II", "I"), (0, 0, 0, 0), '1'},
                    {("II", "III", "I"), (0, 0, 0, 0), '2'},
                    {("III", "I", "II"), (0, 0, 0, 0), '3'}
                };
            public static TheoryData<(string, string, string), (int, int, int, int), string, string> EnigmaWillReturnCipheredOutputData
                => new(){
                    {("III", "II", "I"), (0, 0, 0, 0), "1234567890", "2465124249"},
                    {("II", "I", "III"), (0, 0, 0, 0), "1234567890", "4741159383"},
                    {("I", "III", "II"), (0, 0, 0, 0), "1234567890", "6726970923"},
                    {("I", "II", "III"), (0, 0, 0, 0), "1234567890", "9169900656"},
                    {("III", "I", "II"), (0, 0, 7, 5), "1234567890", "8876156526"},
                    {("II", "III", "I"), (8, 8, 8, 6), "1234567890", "3672029409"}
                };
            [Theory]
            [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
            public void EnigmaWillNotReturnInputAsOutput((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos, char c)
            {
                var enigma = EnigmaZ.WithStringChar.New(rotors, pos);
                var result = enigma.RunOn(c);
                Assert.NotEqual(c, result);
            }
            [Theory]
            [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
            public void EnigmaWillReturnCipheredOutput((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos, string plain, string cipher)
            {
                var enigma = EnigmaZ.WithStringChar.New(rotors, pos);
                var result = enigma.RunOn(plain);
                Assert.Equal(cipher, result);
            }
        }
        public class WithInt32Tests
        {
            public static TheoryData<(string, string, string), (int, int, int, int), int> EnigmaWillNotReturnInputAsOutputData
                => new(){
                    {("II", "I", "III"), (0, 0, 0, 0), 0},
                    {("III", "II", "I"), (0, 0, 0, 0), 1},
                    {("II", "III", "I"), (0, 0, 0, 0), 2},
                    {("III", "I", "II"), (0, 0, 0, 0), 3}
                };
            public static TheoryData<(string, string, string), (int, int, int, int), int[], int[]> EnigmaWillReturnCipheredOutputData
                => new(){
                    {("III", "II", "I"), (0 ,0, 0, 0), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{2, 4, 6, 5, 1, 2, 4, 2, 4, 9}},
                    {("II", "I", "III"), (0, 0, 0, 0), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{4, 7, 4, 1, 1, 5, 9, 3, 8, 3}},
                    {("I", "III", "II"), (0, 0, 0, 0), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{6, 7, 2, 6, 9, 7, 0, 9, 2, 3}},
                    {("I", "II", "III"), (0, 0, 0, 0), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{9, 1, 6, 9, 9, 0, 0, 6, 5, 6}},
                    {("III", "I", "II"), (0 ,0, 7, 5), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{8, 8, 7, 6, 1, 5, 6, 5, 2, 6}},
                    {("II", "III", "I"), (8, 8, 8, 6), new[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}, new[]{3, 6, 7, 2, 0, 2, 9, 4, 0, 9}}
                };
            [Theory]
            [MemberData(nameof(EnigmaWillNotReturnInputAsOutputData))]
            public void EnigmaWillNotReturnInputAsOutput((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos, int s)
            {
                var enigma = EnigmaZ.WithInt32.New(rotors, pos);
                var result = enigma.RunOn(s);
                Assert.NotEqual(s, result);
            }
            [Theory]
            [MemberData(nameof(EnigmaWillReturnCipheredOutputData))]
            public void EnigmaWillReturnCipheredOutput((string III, string II, string I) rotors, (int Reflector, int III, int II, int I) pos, int[] plain, int[] cipher)
            {
                var enigma = EnigmaZ.WithInt32.New(rotors, pos);
                var result = enigma.RunOn(plain);
                Assert.Equal(cipher, result);
            }
        }
    }
}