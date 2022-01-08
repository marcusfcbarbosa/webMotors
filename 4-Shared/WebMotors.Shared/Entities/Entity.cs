using FluentValidator;
using System;
using WebMotors.Shared.Interfaces;

namespace WebMotors.Shared.Entities
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            this.CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
