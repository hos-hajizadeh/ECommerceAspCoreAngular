﻿namespace ECommerce.Catalog.Application.Dtos;

public class ProductOverviewDto
{
    public long Id { get; set; }
    
    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Currency { get; set; }

    public string? Description { get; set; }
}