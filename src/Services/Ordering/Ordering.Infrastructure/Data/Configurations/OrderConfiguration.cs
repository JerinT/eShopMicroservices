﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.ValueObjects;
using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(orderId => orderId.Value, dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId).IsRequired();
            builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(o => o.OrderId);

            builder.ComplexProperty(o=> o.OrderName, nameBuilder => 
            { 
                nameBuilder.Property(n => n.Value).HasColumnName("OrderName").HasMaxLength(100).IsRequired();
            });

            builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                addressBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50);
                addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
                addressBuilder.Property(a => a.State).HasMaxLength(100);
                addressBuilder.Property(a => a.Country).HasMaxLength(100);
                addressBuilder.Property(a => a.ZipCode).HasMaxLength(18).IsRequired();
            });

            builder.ComplexProperty(o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                addressBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50);
                addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
                addressBuilder.Property(a => a.State).HasMaxLength(100);
                addressBuilder.Property(a => a.Country).HasMaxLength(100);
                addressBuilder.Property(a => a.ZipCode).HasMaxLength(18).IsRequired();
            });

            builder.ComplexProperty(o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CardName).HasMaxLength(100);
                paymentBuilder.Property(p => p.CardNumber).HasMaxLength(25).IsRequired();
                paymentBuilder.Property(p => p.Expiration).HasMaxLength(5);
                paymentBuilder.Property(p => p.CVV).HasMaxLength(5);
                paymentBuilder.Property(p => p.PaymentMethod);
            });

            builder.Property(o => o.Status).HasDefaultValue(OrderStatus.Draft).HasConversion(s => s.ToString()
            , dbstatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbstatus));

            builder.Property(o => o.TotalPrice);
        }
    }
}
