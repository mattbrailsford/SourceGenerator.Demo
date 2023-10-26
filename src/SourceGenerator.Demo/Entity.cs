using System;

namespace SourceGenerator.Demo
{
    public interface IEntity
    {
        public Guid Id { get; }
    }

    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}