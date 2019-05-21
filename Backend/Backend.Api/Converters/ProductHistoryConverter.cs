using System.Collections.Generic;
using System.Linq;
using MusicStore.Backend.Api.Converters.Entities;
using MusicStore.Backend.Application.ExternalQuries.Dtos;

namespace MusicStore.Backend.Api.Converters
{
    public static class ProductHistoryConverter
    {
        public static ProductsHistory Convert( List<ProductHistoryDto> productHistoryDtos )
        {
            List<ProductsHistoryOrder> productsHistoryOrders = productHistoryDtos
                .GroupBy( p => p.TransactionId )
                .Select( g =>
                {
                    var grouped = g.ToList();
                    return new ProductsHistoryOrder
                    {
                        OccuredOnUtc = grouped.FirstOrDefault().OccuredOnUtc.ToString( "u" ),
                        Items = grouped.Select( gr => new ProductHistoryOrderItem
                        {
                            PricePerItem = gr.PricePerItem,
                            ProductName = gr.ProductName,
                            Quantity = gr.Quantity
                        } ).ToList()
                    };
                } ).ToList();

            return new ProductsHistory { Orders = productsHistoryOrders };
        }
    }
}
