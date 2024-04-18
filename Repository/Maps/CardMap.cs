using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards"); 
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.IdPhoto).HasColumnName("id_photo").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Status).HasColumnName("status").IsRequired();

            builder.HasOne(x => x.Photo)
                   .WithMany()
                   .HasForeignKey(x => x.IdPhoto)
                   .IsRequired();
        }
    }
}
