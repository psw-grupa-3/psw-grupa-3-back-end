INSERT INTO payments."Sales"(
    "Id", "JsonObject")
VALUES (-1,'{{"ToursOnSale": 0, "SaleStart": "2023-01-01", "SaleEnd" : "2023-01-31", "DiscountPercentage" : 10, "IsActive": false}}');
INSERT INTO payments."Sales"(
    "Id", "ToursOnSale", "SaleStart", "SaleEnd", "DiscountPercentage", "IsActive")
VALUES (-2,'{{"ToursOnSale": 0, "SaleStart": "2023-01-01", "SaleEnd" : "2023-01-31", "DiscountPercentage" : 10, "IsActive": true}}');