using Fieldlevel.Application.Common.Interfaces;

namespace Fieldlevel.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
