public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //modelBuilder.Entity<>()
    }
    public DbSet<User> pj3_Users {get; set;}
}