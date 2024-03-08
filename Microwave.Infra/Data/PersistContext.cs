using Microsoft.EntityFrameworkCore;
using MicrowaveSystem.Core.Entities;

namespace Microwave.Infra.Data;

public class PersistContext : DbContext
{
    public PersistContext(DbContextOptions<PersistContext> options)
        : base(options)
    { }

    public DbSet<RegistrationTemplate> ProgramRegistrations { get; set; }

    public string DbPath { get; }

    public PersistContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "microwave.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}