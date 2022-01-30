using System.Collections.Generic;

namespace Battleship.Domain.Entities
{
    public class Battleship : EntityBase
    {
        public string Name { get; set; }

        public bool IsDestroyed { get; set; }

        public ICollection<Field> Area { get; set; }
    }
}
