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
    var groupBySuitDateAndWeight = pallets.
        GroupBy(x => new {x.SuitDate , x.Weight, x.Id}).
        OrderBy(g => g.Key.Weight).
        OrderByDescending(g => g.Key.SuitDate).
        Select(x => new{
            x.Key.Weight,
            x.Key.SuitDate,
            x.Key.Id
        });
    foreach (var g in groupBySuitDateAndWeight) {
        Console.WriteLine($"Date: {g.SuitDate}\n" +
            $"Weight: {g.Weight} \t ID: {g.Id}"
            );
    }
    var result = from pal in pallets
                 join con in connections
                 on pal.Id equals con.Pallete_id
                 join box in boxes
                 on con.Box_id equals box.Id
                 orderby box.SuitDate descending
                 select new {
                     Id = pal.Id,
                     Volume = pal.Volume,
                     Date = pal.SuitDate
                 };
    foreach (var box in result) {
        Console.WriteLine(box);
    }
}
/*
 * select distinct * from palletes
full join palletes_boxes on palletes.pallete_id = palletes_boxes.pallete_id
full join boxes on palletes_boxes.box_id = boxes.box_id
order by suitdate desc
*/