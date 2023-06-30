using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class BoxConfiguration : IEntityTypeConfiguration<Box> {

        public void Configure(EntityTypeBuilder<Box> builder) {
            builder.Property("Id").HasField("_id");
            builder.Property("Id").HasColumnName("box_id");
            builder.Property("Depth").HasColumnName("depth");
            builder.Property("Width").HasColumnName("width");
            builder.Property("Height").HasColumnName("height");
        }
    }
}