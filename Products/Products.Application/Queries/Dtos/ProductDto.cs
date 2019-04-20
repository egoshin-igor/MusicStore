﻿namespace MusicStore.Products.Application.Queries.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
