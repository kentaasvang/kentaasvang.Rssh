using System;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Implementations;

public class InputProvider : IInputProvider
{
  public string GetInput()
  {
    return Console.ReadLine() ?? throw new NullReferenceException("Input can't be empty");
  }
}