using Microsoft.EntityFrameworkCore;
using NewProject.Domain.Models;


namespace NewProject.Domain;

public class NPDbContext : DbContext
{
    public NPDbContext()
    {

    }
    public NPDbContext(DbContextOptions<NPDbContext> options)
        : base(options) { }
    public virtual DbSet<Company> Companys { get; set; }
    public virtual DbSet<Campaign> Campaigns { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Log> Logs { get; set; }
    public virtual DbSet<Commission> Commissions { get; set; }
    public virtual DbSet<Marketer> Marketers { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
}
