using System;
using System.Collections.Generic;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the reflector.</summary>
    */
    public interface IReflector<TReflector, TReflectorPair> 
        where TReflector : IReflector<TReflector, TReflectorPair>
        where TReflectorPair : IReflectorPair<TReflectorPair>
    {
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public TReflectorPair[] Pairs {get; set;}
        /**
        <summary>Creates a reflector with the reflector pairs provided.</summary>
        <param name="pairs">The reflector pairs.</param>
        */
        public static abstract TReflector New(params TReflectorPair[] pairs);
        /**
        <summary>Checks if the reflector is in a valid state, in which it is bijective (i.e. one-to-one, fully invertible).</summary>
        <returns><c>true</c> if valid, else <c>false</c>.</returns>
        */
        public bool IsValid()
        {
            var chars = new HashSet<char>();
            var isValid = true;
            this.Pairs.ToList().ForEach(pair => {
                if (!(chars.Add(pair.Map.One) && chars.Add(pair.Map.Two)))
                {
                    isValid = false;
                }});
            return isValid;
        }
        /**
        <summary>Reflects a character.</summary>
        <param name="c">The character to reflect.</param>
        <returns>The reflected character.</returns>
        */
        public char Reflect(char c)
        {
            try
            {
                var found = this.Pairs.Where(pair => new[]{pair.Map.One, pair.Map.Two}.Contains(c)).Single();
                return new[]{found.Map.One, found.Map.Two}.Except(new[]{c}).Single();
            }
            catch
            {
                throw new CharacterNotFoundException();
            }
        }
    }
}