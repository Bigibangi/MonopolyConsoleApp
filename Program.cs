using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("AppSettings.json");
var config = builder.Build();
var connectionstring = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseNpgsql(connectionstring).Options;
using (var db = new ApplicationContext(options)) {
    var pallets = db.Pallets.ToList();
    var result = pallets.
        OrderByDescending(p => p.SuitDate).
        OrderBy(p => p.Weight).ToList();
    foreach (var p in result) {
        Console.WriteLine(p.ToString());
    }
}