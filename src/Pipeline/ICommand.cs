using System;

namespace Pipeline
{
    public interface ICommand
    {
        Guid RiskId { get; set; }
    }
}
