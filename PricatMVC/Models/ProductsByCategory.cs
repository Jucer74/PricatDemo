﻿namespace PricatMVC.Models;

public class ProductsByCategory
{
    public Category CategoryInfo { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}