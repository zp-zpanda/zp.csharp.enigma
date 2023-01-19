namespace ZP.CSharp.Enigma
{
    /**
    <summary>The interface for the entrywheel pair.</summary>
    */
    public interface IEntrywheelPair
    {
        /**
        <summary>The mapping.</summary>
        */
        public (char PlugboardSide, char ReflectorSide) Map {get; set;}
    }
    /**
    <summary>The generic interface for the entrywheels pair.</summary>
    */
    public interface IEntrywheelPair<TEntrywheelPair> : IEntrywheelPair
        where TEntrywheelPair : IEntrywheelPair<TEntrywheelPair>, IEntrywheelPair
    {
        /**
        <summary>Creates a entrywheel pair with two characters.</summary>
        <param name="pSide">The character on the plugboard side.</param>
        <param name="rSide">The character on the reflector side.</param>
        */
        public static abstract TEntrywheelPair New(char pSide, char rSide);
    }
}