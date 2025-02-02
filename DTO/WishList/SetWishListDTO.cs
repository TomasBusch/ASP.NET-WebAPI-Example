﻿namespace WebAPI.DTO.WishList
{
    public class SetWishListDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public IEnumerable<int>? ProductIds { get; set; }
    }
}
