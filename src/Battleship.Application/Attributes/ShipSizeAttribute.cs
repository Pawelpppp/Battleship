using System;

namespace Battleship.Application.Attributes
{
    /// <summary>
    /// Extend ship type by size
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ShipSizeAttribute : Attribute
    {
        public ShipSizeAttribute(int size)
        {
            Size = size;
        }
        public int Size { get; set; }
    }
}
