using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationGateway.Core;

namespace NotificationGateway.DataStore.Configurations;

public class EmailEntityTypeConfiguration: IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.HasKey(n => n.Id);
    }
}