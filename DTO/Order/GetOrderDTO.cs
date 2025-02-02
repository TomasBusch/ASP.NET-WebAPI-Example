﻿using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.DTO.OrderItem;

namespace WebAPI.DTO.Order
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public required IEnumerable<GetOrderItemDTO> Items { get; set; }
    }
}
