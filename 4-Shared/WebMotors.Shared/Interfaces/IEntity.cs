using System;

namespace WebMotors.Shared.Interfaces
{
    interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
