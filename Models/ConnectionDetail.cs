using System;

namespace kentaasvang.Rssh.Models;

internal record ConnectionDetail(
    Guid ConnectionDetailId,
    string? ConnectionName,
    string? Ip,
    string? Username,
    string? Password,
    Guid? GroupId
);
