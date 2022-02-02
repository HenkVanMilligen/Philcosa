﻿using Philcosa.Application.Interfaces.Services;
using System;

namespace Philcosa.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}