
# Chronos ApiResponse

Chronos.ApiResponse is a package designed to simplify the process of creating custom API responses by providing basic implementations.
This package helps developers quickly set up and manage their API responses, reducing the time and effort required for this task.




## Requirements

 - [.NET SDK](https://awesomeopensource.com/project/elangosundar/awesome-README-templates)
 - [Entity Framework Core](https://github.com/matiassingers/awesome-readme)
 - [.NET 8](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)


## Authors

- [Souvik Kundu](https://github.com/souvikk27)


## Usage/Examples

Here is an Example for returning a paginated response: 

```c#
public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameter productParameter)
{
        var query = new GetAllProductsQuery(productParameter);
        var pagedList = await _mediator.Send(query);
        return ApiResponseExtension.ToPaginatedApiResult(pagedList, "products", "200", pagedList.MetaData.CurrentPage,
        pagedList.MetaData.TotalPages);
}

```



Example for using individual responses: 

```c#
public async Task<IActionResult> GetProductByName([FromQuery] string productName)
{
        var query = new GetProductByNameQuery(productName);
        var product = await _mediator.Send(query);
        if (product == null)
        {
            return ApiResponseExtension.ToErrorApiResult("Not Found", $"Product with name {productName} not found",
                "404");
        }
        return ApiResponseExtension.ToSuccessApiResult(product, "Product");
}
```







## License

[MIT](https://choosealicense.com/licenses/mit/)

