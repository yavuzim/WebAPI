using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public class APIContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("connection.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Chef> Chefs {  get; set; }
        public DbSet<Contact> Contacts {  get; set; }
        public DbSet<Feature> Features {  get; set; }
        public DbSet<Image> Images {  get; set; }
        public DbSet<Message> Messages {  get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services {  get; set; }
        public DbSet<Testimonial> Testimonials {  get; set; }
    }
}
