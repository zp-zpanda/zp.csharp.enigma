using System;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>
    The base class for the enigma.
    </summary>
    */
    public abstract class Enigma
    {
        /**
        <summary>
            Runs the enigma on the specified character.
        </summary>
        <param name="c">The character to run on.</param>
        <returns>The resulting character.</returns>
        <remarks>
            <para>
                The enigma can perform encoding and decoding at the same time
                so there is only one method.
            </para>
        </remarks>
        */
        public abstract char RunOn(char c);
        /**
        <summary>
            Steps the enigma.
        </summary>
        */
        public abstract void Step();
    }
}