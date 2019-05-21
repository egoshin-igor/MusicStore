namespace MusicStore.Products.Application.AppServices.Entities
{
    public enum ProductBuyingResultType
    {
        IsSuccess = 0,
        ProductsNotFound = 1,
        PriceChanged = 2,
        NotEnoughProducts = 3,
        NotEnoughMoney = 4
    }
}
