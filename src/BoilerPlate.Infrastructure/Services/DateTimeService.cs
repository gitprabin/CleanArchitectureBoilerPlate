using BoilerPlate.Application.Common.Interfaces;
using System;

namespace BoilerPlate.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
