using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class BoxConfiguration : IEntityTypeConfiguration<Box> {

        public void Configure(EntityTypeBuilder<Box> builder) {
            builder.Property("Id").HasField("_id");
        }
    }
}