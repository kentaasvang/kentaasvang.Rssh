using System;
using System.IO;
using kentaasvang.Rssh.Models;
using Microsoft.EntityFrameworkCore;

namespace kentaasvang.Rssh.Data;

public class DatabaseContext : DbContext
{
    private string DbPath { get; set; }
    internal DbSet<ConnectionDetail> ConnectionDetails => Set<ConnectionDetail>();

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");    
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}