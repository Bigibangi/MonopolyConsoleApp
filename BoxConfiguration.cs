using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class BoxConfiguration : IEntityTypeConfiguration<Box> {

        public void Configure(EntityTypeBuilder<Box> builder) {
            builder.Property(p => p.Id).HasField("_id");
            builder.Property(p => p.Id).HasColumnName("box_id");
            builder.Property(p => p.Depth).HasColumnName("depth");
            builder.Property(p => p.Width).HasColumnName("width");
            builder.Property(p => p.Height).HasColumnName("height");
            builder.Property(p => p.SuitDate).HasColumnType("date");
        }
    }
}