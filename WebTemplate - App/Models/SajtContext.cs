namespace Models;

public class SajtContext : DbContext
{
    public DbSet<Biljka>? Biljke {get;set;}
    public DbSet<Lampa>? Lampe {get;set;}
    public DbSet<Sajt>? Sajt {get;set;}
    public DbSet<KomentarIOcena>? KomentarIOcena {get;set;}
    public DbSet<Saksija>? Saksije {get;set;}
    public SajtContext(DbContextOptions options) : base(options)
    {
        
    }
}
