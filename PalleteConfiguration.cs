using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class PalleteConfiguration : IEntityTypeConfiguration<Pallete> {

        public void Configure(EntityTypeBuilder<Pallete> builder) {
            builder.Property(p => p.Id).HasField("_id");
            builder.Property(p => p.Id).HasColumnName("pallete_id");
            builder.Property(p => p.Depth).HasColumnName("depth");
            builder.Property(p => p.Width).HasColumnName("width");
            builder.Property(p => p.Height).HasColumnName("height");
        }
    }
}