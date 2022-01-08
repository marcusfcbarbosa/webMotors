using FluentValidator;
using WebMotors.Shared.Interfaces;

namespace WebMotors.Shared.Entities
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
        }
        public int Id { get; set; }
    }
}
