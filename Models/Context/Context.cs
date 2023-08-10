using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{

    
    public DbSet<Document> Documents { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder db)
    {
        db.UseSqlServer("Data Source=.;initial Catalog=KDTORG;USER ID=SA;PASSWORD=SM1384@@mh;MultipleActiveResultSets=true");
    }
}