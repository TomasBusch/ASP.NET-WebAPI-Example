﻿namespace WebAPI.Models.DTO.Cart
{
    public class SetCartDTO
    {
        public int Id { get; set; }
        public IEnumerable<CartItem>? Items { get; set; }
    }
}
