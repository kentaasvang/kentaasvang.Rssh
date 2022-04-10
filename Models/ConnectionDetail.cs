using System;

namespace Kent.Cli.Rssh.Models;

internal record ConnectionDetail(
    Guid ConnectionDetailId,
    string? ConnectionName,
    string? Ip,
    string? Username,
    string? Password,
    Guid? GroupId
);
