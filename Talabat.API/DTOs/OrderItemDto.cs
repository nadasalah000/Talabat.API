﻿using Talabat.Core.Entites.Order_Aggregate;

namespace Talabat.API.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}