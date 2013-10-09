A simple framework for comparing the performance and running bench marks of methods.

For me information please see the following link:

http://www.contentedcoder.com/2012/02/benchmarking-methods-in-c-made-easier.html


##INSTRUCTIONS


1. Create a new class library, typically I use the naming convention of <MyProject>.Benchmarks however, this is not mandatory.

2. Download the package from NuGet or add a reference of pUnit.dll to the benchmarks project. NuGet package name is: pUnit

3. Create a new class in your benchmarks project and import pUnit. Add the attribute ProfileClass to your class. Add a method and add the ProfileMethod attribute. You can pass an optional parameter indicating how many times this method should be executed. The default is 1000 iterations.

  Examples below:

## C# Example

```csharp
using pUnit;

namespace Examples
{
    [ProfileClass]
    public class ForEachBenchmarks
    {
        [ProfileMethod(100)]
        public void SlowerMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                // do something
            }
        }

        [ProfileMethod(100)]
        public void FasterMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                // do something
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
```

## VB.Net Example

```vb
Imports pUnit

<ProfileClass(100)> _
Public Class ForEachBenchmarks

    <ProfileMethod()> _
    Public Sub SlowerMethod()

        For i As Integer = 0 To 10
            ' do something
        Next

    End Sub

    <ProfileMethod(100)> _
    Public Sub FasterMethod()

        For i As Integer = 0 To 10
            ' do something
            System.Threading.Thread.Sleep(1)
        Next

    End Sub

End Class
```

# RUNNING THE BENCHMARKS

1. Add a new Console application to your solution. I usually call this ProfilerRunner but this is not mandatory.
2. Add a reference to pUnit either from the binary or via NuGet as we did previously.
3. Add a reference to your benchmark project(s).
4. Paste in the below Main method of the console application. This calls the profile runner which will scan the referenced assemblies and execute the required methods by reading the attributes associated with pUnit  aspreviously described.

## C# Example

```csharp
    class Program
    {
        static void Main(string[] args)
        {
            ProfileRunner runner = new ProfileRunner();
            runner.Run();
        }
    }
 ```
  
## VB.Net Example
 
 ```vb
 Class Program
	Private Shared Sub Main(args As String())
		Dim runner As New ProfileRunner()
		runner.Run()
	End Sub
End Class
```
 
# VIEWING RESULTS

Run the console application and the execution time in ms will be output to the console window.
