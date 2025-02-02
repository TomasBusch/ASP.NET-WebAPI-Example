﻿namespace WebAPI.Models
{
    public class Tag
    {
        public required int Id { get; set; }
        public required string Lable { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
