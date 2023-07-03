using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("AppSettings.json");
var config = builder.Build();
var connectionstring = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseNpgsql(connectionstring).Options;
using (var db = new ApplicationContext(options)) {
    var pallets = db.Pallets.ToList();
    var boxes = db.Boxes.ToList();
    var connections = db.Connections.ToList();
    foreach (var connection in connections) {
        foreach (var pallete in pallets) {
            if (pallete.Id.Equals(connection.Pallete_id)) {
                foreach (var box in boxes) {
                    if (box.Id.Equals(connection.Box_id)) {
                        pallete.TryAddContainer<Box>(box);
                    }
                }
            }
        }
    }
    var result = pallets.
        GroupBy(x => new {x.SuitDate , x.Weight, x.Id}).
        OrderBy(g => g.Key.Weight).
        OrderByDescending(g => g.Key.SuitDate).
        Select(x => new{
            x.Key.Weight,
            x.Key.SuitDate,
            x.Key.Id
        });
    foreach (var g in result) {
        Console.WriteLine($"Date: {g.SuitDate}\n" +
            $"Weight: {g.Weight} \t ID: {g.Id}"
            );
    }
}