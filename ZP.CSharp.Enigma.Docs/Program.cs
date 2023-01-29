using Microsoft.DocAsCode;
namespace ZP.CSharp.Enigma.Docs
{
    public class Program
    {
        public static async Task Main(string[] args) => await Docset.Build("ZP.CSharp.Enigma.Docs.json");
    }
}