using System;

namespace WebMotors.Shared.Interfaces
{
   public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
