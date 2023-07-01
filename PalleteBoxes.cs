using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model {

    [Table("palletes_boxes")]
    [PrimaryKey("Pallete_id", "Box_id")]
    public class PalleteBoxes {

        [Column("pallete_id")]
        public int Pallete_id { get; set; }

        [Column("box_id")]
        public int Box_id { get; set; }

        public override string ToString() {
            return string.Format($"{Box_id}" + " " + $"{Pallete_id}");
        }
    }
}