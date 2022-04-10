using System;

namespace Kent.Cli.Rssh.Models;

internal record ConnectionDetail(
    Guid ConnectionDetailId,
    string? Ip,
    string? Password,
    string? Username,
    Guid GroupId
);
