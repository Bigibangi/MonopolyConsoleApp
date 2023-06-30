using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class PalleteConfiguration : IEntityTypeConfiguration<Pallete> {

        public void Configure(EntityTypeBuilder<Pallete> builder) {
            builder.Property("Id").HasField("_id");
            builder.Property("Id").HasColumnName("pallete_id");
            builder.Property("Depth").HasColumnName("depth");
            builder.Property("Width").HasColumnName("width");
            builder.Property("Height").HasColumnName("height");
        }
    }
}