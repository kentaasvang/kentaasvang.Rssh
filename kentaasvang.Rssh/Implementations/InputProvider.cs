using System;

namespace kentaasvang.Rssh.Implementations;

public class InputProvider
{
  public string GetInput()
  {
    return Console.ReadLine() ?? throw new NullReferenceException("Input can't be empty");
  }
}