using Ardalis.SmartEnum;

namespace Samhammer.Logging
{
    // This solution based on this idea: https://docs.microsoft.com/de-de/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    // To not self implement this, we are using a lib because their solution is going in the same direction.
    public abstract class BaseLogType: SmartEnum<BaseLogType>
    {
        protected BaseLogType(string name, int value) : base(name, value)
        {
        }

        /// <summary>
        /// Fallback LogType which is used when no other LogType is provided.
        /// </summary>
        public abstract BaseLogType FallbackLogType { get; }
    }
}