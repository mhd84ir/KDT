using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{


    public DbSet<Document> Documents { get; set; }
    public DbSet<Sherkat> sherkats { get; set; }
    public DbSet<Mahsol> mahsols { get; set; }
    public DbSet<MahsolSa> mahsolSas { get; set; }

    public DbSet<Hesab> hesabs { get; set; }
    public DbSet<KharidarDolar> kharidarDolars { get; set; }
    public DbSet<DolarDoc> dolarDocs { get; set; }

    public DbSet<LCKh> lCKhs { get; set; }
        public DbSet<LcRequest> lcRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder db)
    {
        db.UseSqlServer("Data Source=.;initial Catalog=KDTORG;USER ID=SA;PASSWORD=SM1384@@mh;MultipleActiveResultSets=true");
    }
}