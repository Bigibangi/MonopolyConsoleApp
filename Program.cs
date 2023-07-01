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
        //var box = boxes.Select(x=>x.Id.Equals(connection.Box_id));
        //var pallete = pallets.Select(x=>x.Id.Equals(connection.Pallete_id));
    }
    var result = pallets.
        OrderBy(p => p.Weight).
        OrderBy(p => p.SuitDate).
        ToList();
    foreach (var p in result) {
        Console.WriteLine(p.ToString());
    }
}