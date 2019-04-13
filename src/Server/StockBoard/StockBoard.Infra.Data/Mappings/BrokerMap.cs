using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockBoard.Domain.Models;

namespace StockBoard.Infra.Data.Mappings
{
    public class BrokerMap : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

        }
    }
}