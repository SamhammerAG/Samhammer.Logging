using Ardalis.SmartEnum;

namespace Samhammer.Logging
{
    public abstract class BaseLogType: SmartEnum<BaseLogType>
    {
        protected BaseLogType(string name, int value) : base(name, value)
        {
        }
    }
}