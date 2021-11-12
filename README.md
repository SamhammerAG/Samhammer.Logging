# Samhammer.Logging

Logging abstraction for .NET Core

## Usage
### Custom logger:
```csharp
public abstract class BaseLogger : Samhammer.Logging.BaseLogger, ILog
```

```csharp
public class NLogLogger : BaseLogger
{
...
  public override void Log(string message, string logType, Samhammer.Logging.LogDetails details, Samhammer.Logging.LogLevel loglevel, Exception ex, string memberName, string sourceFilePath,
        int sourceLineNumber)
    {
    ...
    }
}
```

Create a class that inherits from this packages BaseLogger and implements the log method. This method needs to either call some other logging framework, or directly output the log.

### Setup & Use Logger
```csharp
Logger.Init(() => new SerilogLogger(), fallbackLogType);
```

```csharp
ILog log = Logger.Log();

log.Error("Example", LogType.SomeType);
```

## Packages
| Package |
| --- |
| [Samhammer.Logging](https://www.nuget.org/packages/Samhammer.Logging/) |
| [Samhammer.Logging.Serilog](https://www.nuget.org/packages/Samhammer.Logging.Serilog/) |

## Contribute
#### How to publish package
- How to publish package
- set package version in Samhammer.Logging.csproj
- add information to changelog
- create git tag ( v<semver> )
- the package will automatically be published via github actions
