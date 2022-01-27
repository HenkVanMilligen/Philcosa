using TestApi2.Application.Interfaces.Services;
using System;

namespace TestApi2.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}