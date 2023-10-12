using System;

namespace ValueConverterFormatStrings;

class Product {
    private readonly decimal _price;
    private readonly string _imagePath;

    public Product() {
        Random rand = new();
        int price = rand.Next(1, 2000);
        _price = price;
        _imagePath = "APPLOGo.png";
    }

    public decimal Price => _price;
    public string ImagePath => _imagePath;
}
