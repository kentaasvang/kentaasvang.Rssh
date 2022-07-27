using System;
using System.Collections.Generic;

namespace kentaasvang.Rssh.Models;

internal class Group
{
    public Guid Id { get; set; } = new();
    public string? Name { get; set; }
    public List<ConnectionDetail> ConnectionDetails { get; set; } = new();
}