# Unity Logger
My Unity Logger provides convenient and readable wrapper on default Unity logs.
## Feature
- Automated context included (class and method names)
- Helper method for values comparasion 
## Quick Start
Use the class `UnityLogger` in the Namespace `Kiranchy.UnityLogger` instead of the default `UnityEngine.Debug.Log`.
## Example
### Input
```csharp
UnityLogger.AutoLog(this, "Message");
UnityLogger.AutoCompare(this, a, a);   
```
### Output
![Formatting example](./.images/formatting_example.png)