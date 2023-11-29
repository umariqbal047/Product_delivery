using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProduceDeliveryApp.Domain;

namespace ProduceDeliveryApp.Persistence.Configurations
{
    public class UserInfoConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> entity)
        {
            entity.ToTable("UserInfo");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .IsRequired();

            entity.Property(e => e.FirstName)
                .IsRequired().HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired().HasMaxLength(100);

            entity.Property(e => e.PhoneNumber)
                .IsRequired().HasMaxLength(15);

            entity.Property(e => e.Email)
                .IsRequired().HasMaxLength(50);

            entity.Property(e => e.IsActive);

            entity.Property(e => e.UserId)
                .IsRequired();

            entity.Property(e => e.CreatedBy)
                .IsRequired();

            entity.Property(e => e.CreatedOn)
                .IsRequired();

            entity.Property(e => e.ModifiedOn);
            entity.Property(e => e.ModifiedBy);
        }
    }

}
