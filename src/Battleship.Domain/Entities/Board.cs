using System;
using System.Collections.Generic;

namespace Battleship.Domain.Entities
{
    public class Board : EntityBase
    {
        public virtual ICollection<Battleship> Battleships { get; set; }

        public bool IsBattleshipsDestyroyed { get; set; }

        public ICollection<Field> Shots { get; set; }

    }
}
