using EShop.Catalog.Api.Models;
using MongoDB.Driver;

namespace EShop.Catalog.Api.Data;

public static class CatalogContextSeedData
{
    public static void SeedData(this IMongoCollection<Product> productCollection)
    {

        var existsProduct = productCollection.Find(p => true).Any();

        if (!existsProduct) {
            var prods = getProducts();
            productCollection.InsertManyAsync(prods).Wait();
        }

    }

    private static IEnumerable<Product> getProducts() => new List<Product> {
            new Product { 
                Id = "641db1e77413f55e6ecc2818", 
                Name = "IPhone X", 
                Image = "product-1.jpg",
                Price = 950.00M,
                Category = "SmartPhone",
                Description = "At ultrices mi tempus imperdiet nulla malesuada pellentesque elit. Amet commodo nulla facilisi nullam vehicula ipsum a arcu. Facilisi cras fermentum odio eu feugiat pretium. Integer vitae justo eget magna fermentum iaculis eu non diam. Quam elementum pulvinar etiam non quam lacus. Tristique magna sit amet purus gravida quis blandit. Lectus nulla at volutpat diam ut venenatis tellus in. Auctor neque vitae tempus quam pellentesque nec nam aliquam. In fermentum posuere urna nec tincidunt praesent semper feugiat nibh. Donec pretium vulputate sapien nec sagittis aliquam. At imperdiet dui accumsan sit amet nulla facilisi morbi tempus. Eros in cursus turpis massa tincidunt. Enim neque volutpat ac tincidunt vitae semper. Eget nullam non nisi est sit amet facilisis magna etiam. Neque convallis a cras semper auctor neque vitae tempus. Nunc lobortis mattis aliquam faucibus purus in massa tempor nec. Viverra ipsum nunc aliquet bibendum. Pellentesque nec nam aliquam sem et tortor consequat id porta."
            },
            new Product { 
                Id = "641db1e77413f55e6ecc2819", 
                Name = "IPhone XI", 
                Image = "product-2.jpg",
                Price = 1950.00M,
                Category = "SmartPhone",
                Description = "Massa tincidunt dui ut ornare lectus sit amet est placerat. Accumsan sit amet nulla facilisi morbi tempus iaculis urna id. Interdum varius sit amet mattis vulputate. Donec et odio pellentesque diam volutpat commodo sed egestas egestas. Orci a scelerisque purus semper eget duis at tellus. Sed euismod nisi porta lorem. Commodo sed egestas egestas fringilla phasellus faucibus scelerisque eleifend. Non pulvinar neque laoreet suspendisse interdum consectetur libero. Arcu dictum varius duis at consectetur lorem donec. Mattis enim ut tellus elementum sagittis vitae et leo. Cursus in hac habitasse platea dictumst quisque sagittis purus. Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Dignissim cras tincidunt lobortis feugiat vivamus at augue. Eget felis eget nunc lobortis mattis aliquam faucibus purus. Eget nunc scelerisque viverra mauris in aliquam sem. Velit euismod in pellentesque massa placerat duis. Amet consectetur adipiscing elit ut aliquam purus."
            },
            new Product { 
                Id = "641db1e77413f55e6ecc2820", 
                Name = "IPhone XII", 
                Image = "product-3.jpg",
                Price = 2950.00M,
                Category = "SmartPhone",
                Description = "Vestibulum lectus mauris ultrices eros in. Elementum tempus egestas sed sed risus pretium. Aliquet bibendum enim facilisis gravida neque convallis a cras semper. Nisl suscipit adipiscing bibendum est ultricies integer quis auctor elit. Diam donec adipiscing tristique risus nec feugiat in fermentum posuere. Maecenas accumsan lacus vel facilisis volutpat est. Eget mi proin sed libero enim. Vestibulum sed arcu non odio euismod. Massa tincidunt dui ut ornare lectus sit amet est placerat. Mus mauris vitae ultricies leo integer. Sed sed risus pretium quam vulputate dignissim suspendisse in est. Sagittis vitae et leo duis ut diam quam nulla. Pulvinar mattis nunc sed blandit. Tristique senectus et netus et malesuada. Tortor condimentum lacinia quis vel. Sed id semper risus in hendrerit gravida rutrum. Sapien pellentesque habitant morbi tristique senectus et netus et. At tellus at urna condimentum mattis pellentesque."
            },
            new Product { 
                Id = "641db1e77413f55e6ecc2821", 
                Name = "IPhone SW", 
                Image = "product-4.jpg",
                Price = 350.00M,
                Category = "SmartPhone",
                Description = "In eu mi bibendum neque egestas congue quisque egestas diam. Bibendum ut tristique et egestas quis. Feugiat pretium nibh ipsum consequat nisl vel pretium lectus. Nisi porta lorem mollis aliquam ut. Accumsan tortor posuere ac ut consequat semper viverra. Magna ac placerat vestibulum lectus. Ornare quam viverra orci sagittis eu volutpat odio. Etiam tempor orci eu lobortis elementum nibh tellus molestie. Varius sit amet mattis vulputate. Amet facilisis magna etiam tempor orci eu lobortis elementum. In aliquam sem fringilla ut morbi. Et ultrices neque ornare aenean euismod elementum nisi quis. Sed euismod nisi porta lorem mollis aliquam ut porttitor. Purus sit amet volutpat consequat mauris nunc congue. Tellus integer feugiat scelerisque varius morbi enim nunc. Sollicitudin aliquam ultrices sagittis orci a scelerisque purus semper. Enim sit amet venenatis urna cursus eget. Euismod elementum nisi quis eleifend quam."
            },

        };
}