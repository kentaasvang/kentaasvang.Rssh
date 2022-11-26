using static System.Console;

namespace kentaasvang.Rssh.UnitTests;

public class FakeOutput
{
  public static StringWriter Output = new();

  public FakeOutput()
  {
    Console.SetOut(Output);
  }

  public static void Clear()
    => Output.Flush();
}