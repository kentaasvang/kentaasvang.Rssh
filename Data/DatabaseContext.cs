using System;
using System.IO;
using kentaasvang.Rssh.Models;
using Microsoft.EntityFrameworkCore;

namespace kentaasvang.Rssh.Data;

internal class DatabaseContext : DbContext
{
    internal DbSet<ConnectionDetail> ConnectionDetails { get; set; } = null!;
    internal DbSet<Group> Groups { get; set; } = null!;
    private string DbPath { get; set; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");    
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}