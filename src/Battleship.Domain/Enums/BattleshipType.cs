namespace Battleship.Domain.Enums
{
    public enum BattleshipType
    {
        /// <summary>
        /// Default not valid value
        /// </summary>
        Empty = 0,

        /// <summary>
        /// PatrolBoat of size 2
        /// </summary>
        PatrolBoat = 1,

        /// <summary>
        /// Submarine of size 3
        /// </summary>
        Submarine = 2,

        /// <summary>
        /// OrDestroyer of Size 3
        /// </summary>
        Destroyer = 3,

        /// <summary>
        /// Battleship of Size 4
        /// </summary>
        Battleship = 4,

        /// <summary>
        ///  Carrier of size 5
        /// </summary>
        Carrier = 5,
    }
}
