﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.Model
{
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        [Key]
        public int BasketPositionId { get; set; }
        public int Amount { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId{ get; set; }
        public required virtual Product Product{ get; set; }

        [ForeignKey(nameof(UserId))]   
        public int UserId { get; set; }
        public required virtual User User { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder.HasOne(b => b.Product).WithMany(p => p.BasketPositions).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.User).WithMany(u => u.UserBasketPositions).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
