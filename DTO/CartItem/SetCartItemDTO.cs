﻿using WebAPI.DTO.Cart;
using WebAPI.DTO.Product;

namespace WebAPI.DTO.CartItem
{
    public class SetCartItemDTO
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
    }
}
