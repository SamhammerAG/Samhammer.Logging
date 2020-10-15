# Samhammer.Logging

Logging Interface that implements 

## Usage
```csharp
public abstract class BaseLogger : Samhammer.Logging.BaseLogger, ILog
```

```csharp
    public class NLogLogger : BaseLogger
    {
   ...
      public override void Log(string message, Samhammer.Logging.LogDetails details, Samhammer.Logging.LogLevel loglevel, Exception ex, string memberName, string sourceFilePath,
            int sourceLineNumber)
        {
        ...
        }
```

Create a class that inherits from this packages BaseLogger and implements the log method. This method needs to either call some other logging framework, or directly output the log.

## Contribute

#### How to publish package
How to publish package
set package version in Samhammer.Logging.csproj
add information to changelog
create git tag
dotnet pack -c Release
nuget push .\samhammer.logging\samhammer.logging\bin\Release\Samhammer.Logging.*.nupkg NUGET_API_KEY -src https://api.nuget.org/v3/index.json
(optional) nuget setapikey NUGET_API_KEY -source https://api.nuget.org/v3/index.json
