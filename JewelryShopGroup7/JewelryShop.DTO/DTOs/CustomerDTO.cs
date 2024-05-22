﻿using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class CustomerDTO
{
    public Guid? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal? AmountSpent { get; set; }

    public List<OrderDTO> Orders { get; } = new List<OrderDTO>();
}
