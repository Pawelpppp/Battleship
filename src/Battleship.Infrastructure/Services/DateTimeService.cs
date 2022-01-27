using Battleship.Application.Common.Interfaces;
using System;

namespace Battleship.Infrastructure.Services
{
    internal class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
