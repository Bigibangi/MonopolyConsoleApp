using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model {

    internal class PalleteConfiguration : IEntityTypeConfiguration<Pallete> {

        public void Configure(EntityTypeBuilder<Pallete> builder) {
            builder.Property("Id").HasField("_id");
        }
    }
}