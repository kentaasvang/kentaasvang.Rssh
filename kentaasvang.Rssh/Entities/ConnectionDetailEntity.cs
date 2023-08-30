using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace kentaasvang.Rssh.Entities;

[Table("connection_detail")]
public class ConnectionDetailEntity
{
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("name")]
    public required string Name { get; set; }

    [Column("ip")]
    public required string Ip { get; set; }

    [Column("username")]
    public required string Username { get; set;}

    [Column("password")]
    public required string Password { get; set; }
}
