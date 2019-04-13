using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockBoard.Domain.Models;

namespace StockBoard.Infra.Data.Mappings
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

        }
    }
}