using System;
using System.IO;
using kentaasvang.Rssh.Entities;
using Microsoft.EntityFrameworkCore;

namespace kentaasvang.Rssh.Data;

public class RsshDbContext : DbContext
{
    private string DbPath { get; set; }
    public DbSet<ConnectionDetailEntity> ConnectionDetails => Set<ConnectionDetailEntity>();

    public RsshDbContext()
    {
#if DEBUG
        DbPath = Path.Join(Environment.CurrentDirectory, "test_db.db");
#else
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "rssh.db");    
#endif
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}