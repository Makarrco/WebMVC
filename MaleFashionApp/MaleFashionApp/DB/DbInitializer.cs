using MaleFashionApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaleFashionApp.DB;

public class DbInitializer
{
    public static void Initialize(ClothingShopDbContext context)
    {
        if (!context.Database.CanConnect())
        {
            context.Database.EnsureCreated();
        }

        SeedClientMessages(context);
        SeedNavigates(context);
        SeedOptions(context);

        SeedCategories(context);
        SeedTags(context);
        SeedPosts(context);          
        SeedPostCategories(context);
        SeedPostTags(context);       
    }

    private static void SeedPosts(ClothingShopDbContext context)
    {
        if (!context.Posts.Any())
        {
            context.Database.OpenConnection();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Posts ON");

            var blog = new List<Post>
            {
                new Post { Id = 1, Title = "Men's Spring Collection", Content = "Latest trends in men's fashion for spring.", Slogan = "Refresh Your Style", Slug = "mens-spring-collection", ImgSrc = "img/blog/post-1.jpg", ImgAlt = "Men Spring Collection", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-30), Published = DateTime.UtcNow.AddDays(-28) },
                new Post { Id = 2, Title = "Top Women's Dresses", Content = "Explore the most popular dresses this season.", Slogan = "Elegance Redefined", Slug = "top-womens-dresses", ImgSrc = "img/blog/post-2.jpg", ImgAlt = "Women's Dresses", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-29), Published = DateTime.UtcNow.AddDays(-27) },
                new Post { Id = 3, Title = "Accessory Trends 2026", Content = "Belts, watches, hats – what's in fashion now.", Slogan = "Accessorize Your Life", Slug = "accessory-trends-2026", ImgSrc = "img/blog/post-3.jpg", ImgAlt = "Accessories", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-25), Published = DateTime.UtcNow.AddDays(-23) },
                new Post { Id = 4, Title = "Sneakers Must-Have", Content = "Casual and stylish sneakers for all occasions.", Slogan = "Step Up Your Game", Slug = "sneakers-must-have", ImgSrc = "img/blog/post-4.jpg", ImgAlt = "Sneakers", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-22), Published = DateTime.UtcNow.AddDays(-20) },
                new Post { Id = 5, Title = "Luxury Streetwear Guide", Content = "How to combine streetwear and luxury pieces.", Slogan = "Luxury Meets Street", Slug = "luxury-streetwear-guide", ImgSrc = "img/blog/post-5.jpg", ImgAlt = "Streetwear", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-20), Published = DateTime.UtcNow.AddDays(-18) },
                new Post { Id = 6, Title = "Summer Sale Highlights", Content = "Best deals on summer clothing.", Slogan = "Hot Deals for Hot Days", Slug = "summer-sale-highlights", ImgSrc = "img/blog/post-6.jpg", ImgAlt = "Summer Sale", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-18), Published = DateTime.UtcNow.AddDays(-16) },
                new Post { Id = 7, Title = "Men's Jackets Collection", Content = "Stay warm with style this winter.", Slogan = "Cozy & Cool", Slug = "mens-jackets-collection", ImgSrc = "img/blog/post-7.jpg", ImgAlt = "Men Jackets", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-15), Published = DateTime.UtcNow.AddDays(-14) },
                new Post { Id = 8, Title = "Women's Skirt Trends", Content = "Skirts that define this year's fashion.", Slogan = "Twirl in Style", Slug = "womens-skirt-trends", ImgSrc = "img/blog/post-8.jpg", ImgAlt = "Women Skirts", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-13), Published = DateTime.UtcNow.AddDays(-12) },
                new Post { Id = 9, Title = "Boots You Need", Content = "Leather and casual boots for every outfit.", Slogan = "Step in Style", Slug = "boots-you-need", ImgSrc = "img/blog/post-9.jpg", ImgAlt = "Boots", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-11), Published = DateTime.UtcNow.AddDays(-10) },
                new Post { Id = 10, Title = "Men Sale Picks", Content = "Top discounted items for men.", Slogan = "Save & Style", Slug = "men-sale-picks", ImgSrc = "img/blog/post-8.jpg", ImgAlt = "Men Sale", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-9), Published = DateTime.UtcNow.AddDays(-8) },
                new Post { Id = 11, Title = "Women Sale Picks", Content = "Top discounted items for women.", Slogan = "Stylish Savings", Slug = "women-sale-picks", ImgSrc = "img/blog/post-8.jpg", ImgAlt = "Women Sale", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-7), Published = DateTime.UtcNow.AddDays(-6) },
                new Post { Id = 12, Title = "Spring Fashion Essentials", Content = "Must-have items for spring.", Slogan = "Fresh Looks", Slug = "spring-fashion-essentials", ImgSrc = "img/blog/post-8.jpg", ImgAlt = "Spring Fashion", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-6), Published = DateTime.UtcNow.AddDays(-5) },
                new Post { Id = 13, Title = "Autumn Streetwear", Content = "Urban fashion for cooler months.", Slogan = "Fall in Style", Slug = "autumn-streetwear", ImgSrc = "img/blog/post-9.jpg", ImgAlt = "Streetwear", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-5), Published = DateTime.UtcNow.AddDays(-4) },
                new Post { Id = 14, Title = "Winter Coats Guide", Content = "Warm and stylish coats.", Slogan = "Bundle Up Fashionably", Slug = "winter-coats-guide", ImgSrc = "img/blog/post-9.jpg", ImgAlt = "Winter Coats", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-4), Published = DateTime.UtcNow.AddDays(-3) },
                new Post { Id = 15, Title = "Luxury Accessories", Content = "Exclusive watches and belts.", Slogan = "Accessorize Luxuriously", Slug = "luxury-accessories", ImgSrc = "img/blog/post-9.jpg", ImgAlt = "Luxury Accessories", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-3), Published = DateTime.UtcNow.AddDays(-2) },
                new Post { Id = 16, Title = "Trending T-Shirts", Content = "Casual T-Shirts everyone loves.", Slogan = "Cool & Casual", Slug = "trending-tshirts", ImgSrc = "img/blog/post-7.jpg", ImgAlt = "T-Shirts", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-2), Published = DateTime.UtcNow.AddDays(-1) },
                new Post { Id = 17, Title = "Minimalist Fashion", Content = "Clean, simple, and stylish looks.", Slogan = "Less is More", Slug = "minimalist-fashion", ImgSrc = "img/blog/post-6.jpg", ImgAlt = "Minimal Fashion", Status = PostStatuses.Published, Created = DateTime.UtcNow.AddDays(-1), Published = DateTime.UtcNow },
                new Post { Id = 18, Title = "New Collection Launch", Content = "Check out our latest collection.", Slogan = "Be First, Be Stylish", Slug = "new-collection-launch", ImgSrc = "img/blog/post-5.jpg", ImgAlt = "New Collection", Status = PostStatuses.Published, Created = DateTime.UtcNow, Published = DateTime.UtcNow },
                new Post { Id = 19, Title = "Streetwear Must-Haves", Content = "Complete your urban look.", Slogan = "Urban Essentials", Slug = "streetwear-must-haves", ImgSrc = "img/blog/post-4.jpg", ImgAlt = "Streetwear", Status = PostStatuses.Published },
                new Post { Id = 20, Title = "Luxury Jackets", Content = "Premium jackets for elite style.", Slogan = "Exclusive & Elegant", Slug = "luxury-jackets", ImgSrc = "img/blog/post-3.jpg", ImgAlt = "Luxury Jackets", Status = PostStatuses.Published },
                new Post { Id = 21, Title = "Fashion Tips for Men", Content = "Styling advice for men’s fashion.", Slogan = "Look Sharp", Slug = "fashion-tips-men", ImgSrc = "img/blog/post-2.jpg", ImgAlt = "Fashion Tips", Status = PostStatuses.Published }
            };

            context.Posts.AddRange(blog);
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Posts OFF");
            context.Database.CloseConnection();
        }
    }

    private static void SeedPostCategories(ClothingShopDbContext context)
    {
        if (!context.PostCategories.Any())
        {
            var postCategories = new List<PostCategories>()
            {
                // Пост 1
                new PostCategories { PostId = 1, CategoryId = 1 },
                new PostCategories { PostId = 1, CategoryId = 2 },
            
                // Пост 2
                new PostCategories { PostId = 2, CategoryId = 10 },
                new PostCategories { PostId = 2, CategoryId = 11 },
            
                // Пост 3
                new PostCategories { PostId = 3, CategoryId = 20 },
                new PostCategories { PostId = 3, CategoryId = 21 },
            
                // Пост 4
                new PostCategories { PostId = 4, CategoryId = 30 },
                new PostCategories { PostId = 4, CategoryId = 31 },

                // Пост 5
                new PostCategories { PostId = 5, CategoryId = 40 },
                new PostCategories { PostId = 5, CategoryId = 41 },

                // Пост 6
                new PostCategories { PostId = 6, CategoryId = 50 },
                new PostCategories { PostId = 6, CategoryId = 51 },

                // І так далі — додай стільки, скільки потрібно
            };
            
            context.PostCategories.AddRange(postCategories);
            context.SaveChanges();
        }
    }

    private static void SeedOptions(ClothingShopDbContext context)
    {
        if (!context.Options.Any())
        {
            var options = new List<Option>()
            {

                new Option()
                {
                    IsSystem = true,
                    Name = "title",
                    Value = "Male Fashion",
                    Order = 1,
                },
                new Option()
                {
                    IsSystem = true,
                    Name = "logo",
                    Value = "img/logo.png"
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "description",
                    Relation = "header",
                    Value = "Free shipping, 30-day return or refund guarantee.",
                },
                new Option()
                {
                    IsSystem = true,
                    Name = "Sign-in",
                    Relation = "header__top__links",
                    Value = "Sign In"
                },
                new Option()
                {
                    IsSystem = true,
                    Name = "FAQ",
                    Relation = "header__top__links",
                    Value = "FAQ",
                },
                new Option()
                {
                    IsSystem = true,
                    Name = "Currency",
                    Value = "Currency",
                },
                new Option
                {
                    Name = "USD",
                    Value = "USD",
                    Relation = "currency",
                    Order = 1,
                    IsSystem = true
                },
                new Option
                {
                    Name = "EUR",
                    Value = "EUR",
                    Relation = "currency",
                    Order = 2,
                    IsSystem = true
                },
                new Option
                {
                    Name = "GBP",
                    Value = "GBP",
                    Relation = "currency",
                    Order = 3,
                    IsSystem = true
                },
                new Option()
                {
                    IsSystem = true,
                    Relation = "payment",
                    Name = "payImage",
                    Value  = "img/payment.png"
                },
                new Option()
                {
                    IsSystem = false,
                    Relation = "payment",
                    Name = "payment_links",
                    Value = "The customer is at the heart of our unique business model, which includes design."
                },
                new Option
                {
                    Name = "Copyright",
                    Value = "All rights reserved | My Fashion Store",
                    Relation = "footer",
                    Order = 1,
                    IsSystem = true
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "shopping_title",
                    Value = "Shopping",
                    Relation = "shopping",
                    Order = 1
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Clothing Store",
                    Value = "Clothing Store",
                    Relation = "shopping_menu",
                    Order = 1
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Trending Shoes",
                    Value = "Trending Shoes",
                    Relation = "shopping_menu",
                    Order = 2
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Accessories",
                    Value = "Accessories",
                    Relation = "shopping_menu",
                    Order = 3
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Sale",
                    Value = "Sale",
                    Relation = "shopping_menu",
                    Order = 4
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Contact Us",
                    Value = "Contact Us",
                    Relation = "shopping_support_menu",
                    Order = 1
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Payment Methods",
                    Value = "Payment Methods",
                    Relation = "shopping_support_menu",
                    Order = 2
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Delivery",
                    Value = "Delivery",
                    Relation = "shopping_support_menu",
                    Order = 3
                },
                new Option()
                {
                    IsSystem = false,
                    Name = "Return & Exchanges",
                    Value = "Return & Exchanges",
                    Relation = "shopping_support_menu",
                    Order = 4
                }
                
            };
            
            context.Options.AddRange(options);
            context.SaveChanges();
        }
    }


    private static void SeedClientMessages(ClothingShopDbContext context)
    {
        if (!context.Forms.Any())
        {
            var Forms = new List<Form>
            {
                new Form
                {
                    Title = "Order delivery delay",
                    Email = "andrii.petrenko@gmail.com",
                    Message = "Hello I have not received my order yet. Could you please check the delivery status",
                    DateOfCreation = DateTime.UtcNow.AddDays(-3),
                    Status = ClientMessageStatuses.New
                },

                new Form
                {
                    Title = "Size exchange request",
                    Email = "olena.koval@gmail.com",
                    Message =
                        "I received the jacket but the size is too small. I would like to exchange it for a larger size",
                    DateOfCreation = DateTime.UtcNow.AddDays(-5),
                    Status = ClientMessageStatuses.Read
                },

                new Form
                {
                    Title = "Question about fabric material",
                    Email = "maksym.shevchenko@gmail.com",
                    Message = "Could you please tell me what material is used for the slim fit trousers",
                    DateOfCreation = DateTime.UtcNow.AddDays(-2),
                    Status = ClientMessageStatuses.Answered
                },

                new Form
                {
                    Title = "Refund request",
                    Email = "iryna.melnyk@gmail.com",
                    Message = "I would like to request a refund for my last purchase because the item arrived damaged",
                    DateOfCreation = DateTime.UtcNow.AddDays(-7),
                    Status = ClientMessageStatuses.Archived
                },

                new Form
                {
                    Title = "Discount availability",
                    Email = "dmytro.bondarenko@gmail.com",
                    Message = "Do you currently have any discounts for regular customers or promo codes available",
                    DateOfCreation = DateTime.UtcNow.AddDays(-1),
                    Status = ClientMessageStatuses.New
                }
            };

        context.Forms.AddRange(Forms);
        context.SaveChanges();
        }
    }

    private static void SeedNavigates(ClothingShopDbContext context)
    {
        if (!context.Navigations.Any())
        {
            context.Database.OpenConnection();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Navigations ON");

            var navigates = new List<Navigate>();
            navigates.Add(new Navigate()
            {
                Id = 1,
                Title = "Home",
                Href = "/",
                Order = 1,
                ParentId = null
            });
            navigates.Add(new Navigate()
            {
                Id = 2,
                Title = "Shop",
                Href = "/shop",
                Order = 2,
                ParentId = null
            });
            navigates.Add(new Navigate()
            {
                Id = 3,
                Title = "Pages",
                Href = "/pages",
                Order = 3,
                ParentId = null
            });
            navigates.Add(new Navigate()
            {
                Id = 4,
                Title = "Blog",
                Href = "/blog",
                Order = 4,
                ParentId = null
            });
            navigates.Add(new Navigate()
            {
                Id = 5,
                Title = "Contacts",
                Href = "/About/ContactUs",
                Order = 5,
                ParentId = null
            });
            navigates[2].Childs.Add(new Navigate()
            {
                Id = 6,
                Title = "About Us",
                Href = "/About",
                Order = 1,
                ParentId = 3
            });
            navigates[2].Childs.Add(new Navigate()
            {
                Id = 7,
                Title = "Shop Details",
                Href = "/blog/shopdetails",
                Order = 2,
                ParentId = 3
            });
            navigates[2].Childs.Add(new Navigate()
            {
                Id = 8,
                Title = "Shopping Cart",
                Href = "/blog/shopcart",
                Order = 3,
                ParentId = 3
            });
            navigates[2].Childs.Add(new Navigate()
            {
                Id = 9,
                Title = "Check out",
                Href = "/blog/checkout",
                Order = 4,
                ParentId = 3
            });
            navigates[2].Childs.Add(new Navigate()
            {
                Id = 10,
                Title = "Blog Details",
                Href = "/blog/blogdetails",
                Order = 5,
                ParentId = 3
            });
            
            context.Navigations.AddRange(navigates);

            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Navigations OFF");
            
            context.Database.CloseConnection();
        }
    }
    private static void SeedCategories(ClothingShopDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Database.OpenConnection();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories ON");

            var categories = new List<Category>
            {
                // ===== 1. Men =====
                new Category { Id = 1, Title = "Men", Slug = "men", ParentId = null, ImgSrc = "img/categories/men.jpg", ImgAlt = "Men Fashion", Description = "Men clothing collection" },
                new Category { Id = 2, Title = "T-Shirts", Slug = "men-tshirts", ParentId = 1, ImgSrc = "img/categories/men-tshirts.jpg", ImgAlt = "Men T-Shirts", Description = "Men T-Shirts" },
                new Category { Id = 3, Title = "Jackets", Slug = "men-jackets", ParentId = 1, ImgSrc = "img/categories/men-jackets.jpg", ImgAlt = "Men Jackets", Description = "Men Jackets" },
                new Category { Id = 4, Title = "Jeans", Slug = "men-jeans", ParentId = 1, ImgSrc = "img/categories/men-jeans.jpg", ImgAlt = "Men Jeans", Description = "Men Jeans" },
                new Category { Id = 5, Title = "Shoes", Slug = "men-shoes", ParentId = 1, ImgSrc = "img/categories/men-shoes.jpg", ImgAlt = "Men Shoes", Description = "Men Shoes" },

                // ===== 2. Women =====
                new Category { Id = 10, Title = "Women", Slug = "women", ParentId = null, ImgSrc = "img/categories/women.jpg", ImgAlt = "Women Fashion", Description = "Women clothing collection" },
                new Category { Id = 11, Title = "Dresses", Slug = "women-dresses", ParentId = 10, ImgSrc = "img/categories/women-dresses.jpg", ImgAlt = "Women Dresses", Description = "Women Dresses" },
                new Category { Id = 12, Title = "Skirts", Slug = "women-skirts", ParentId = 10, ImgSrc = "img/categories/women-skirts.jpg", ImgAlt = "Women Skirts", Description = "Women Skirts" },
                new Category { Id = 13, Title = "Blouses", Slug = "women-blouses", ParentId = 10, ImgSrc = "img/categories/women-blouses.jpg", ImgAlt = "Women Blouses", Description = "Women Blouses" },

                // ===== 3. Accessories =====
                new Category { Id = 20, Title = "Accessories", Slug = "accessories", ParentId = null, ImgSrc = "img/categories/accessories.jpg", ImgAlt = "Accessories", Description = "Fashion accessories" },
                new Category { Id = 21, Title = "Belts", Slug = "belts", ParentId = 20, ImgSrc = "img/categories/belts.jpg", ImgAlt = "Belts", Description = "Fashion belts" },
                new Category { Id = 22, Title = "Hats", Slug = "hats", ParentId = 20, ImgSrc = "img/categories/hats.jpg", ImgAlt = "Hats", Description = "Stylish hats" },
                new Category { Id = 23, Title = "Watches", Slug = "watches", ParentId = 20, ImgSrc = "img/categories/watches.jpg", ImgAlt = "Watches", Description = "Luxury watches" },

                // ===== 4. Shoes =====
                new Category { Id = 30, Title = "Shoes", Slug = "shoes", ParentId = null, ImgSrc = "img/categories/shoes.jpg", ImgAlt = "Shoes", Description = "All types of shoes" },
                new Category { Id = 31, Title = "Sneakers", Slug = "sneakers", ParentId = 30, ImgSrc = "img/categories/sneakers.jpg", ImgAlt = "Sneakers", Description = "Casual sneakers" },
                new Category { Id = 32, Title = "Boots", Slug = "boots", ParentId = 30, ImgSrc = "img/categories/boots.jpg", ImgAlt = "Boots", Description = "Leather boots" },

                // ===== 5. Sale =====
                new Category { Id = 40, Title = "Sale", Slug = "sale", ParentId = null, ImgSrc = "img/categories/sale.jpg", ImgAlt = "Sale", Description = "Discounted products" },
                new Category { Id = 41, Title = "Men Sale", Slug = "men-sale", ParentId = 40, ImgSrc = "img/categories/men-sale.jpg", ImgAlt = "Men Sale", Description = "Discounted men's products" },
                new Category { Id = 42, Title = "Women Sale", Slug = "women-sale", ParentId = 40, ImgSrc = "img/categories/women-sale.jpg", ImgAlt = "Women Sale", Description = "Discounted women's products" },

                // ===== 6. Trends =====
                new Category { Id = 50, Title = "Trends", Slug = "trends", ParentId = null, ImgSrc = "img/categories/trends.jpg", ImgAlt = "Trends", Description = "Latest fashion trends" },
                new Category { Id = 51, Title = "Streetwear", Slug = "streetwear", ParentId = 50, ImgSrc = "img/categories/streetwear.jpg", ImgAlt = "Streetwear", Description = "Urban fashion" },
                new Category { Id = 52, Title = "Luxury", Slug = "luxury", ParentId = 50, ImgSrc = "img/categories/luxury.jpg", ImgAlt = "Luxury", Description = "Luxury fashion" }
            };
            
            
            context.Categories.AddRange(categories);

            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories OFF");
            
            context.Database.CloseConnection();
        }
    }
    
    private static void SeedTags(ClothingShopDbContext context)
    {
        if (!context.Tags.Any())
        {
            var tags = new List<Tag>
            {
                new Tag { Title = "Fashion", Slug = "fashion" },
                new Tag { Title = "Style", Slug = "style" },
                new Tag { Title = "Summer", Slug = "summer" },
                new Tag { Title = "Winter", Slug = "winter" },
                new Tag { Title = "Spring", Slug = "spring" },
                new Tag { Title = "Autumn", Slug = "autumn" },
                new Tag { Title = "Streetwear", Slug = "streetwear" },
                new Tag { Title = "Minimal", Slug = "minimal" },
                new Tag { Title = "Luxury", Slug = "luxury" },
                new Tag { Title = "New Collection", Slug = "new-collection" },
                new Tag { Title = "Sale", Slug = "sale" },                    
                new Tag { Title = "Accessories", Slug = "accessories" }, 
            };

            context.Tags.AddRange(tags);
            context.SaveChanges();
        }
    }
    private static void SeedPostTags(ClothingShopDbContext context)
    {
        if (!context.PostTags.Any())
        {

            var postTags = new List<PostTags>()
            {
                // Пост 1
                new PostTags { PostId = 1, TagId = 1 },
                new PostTags { PostId = 1, TagId = 9 },
                new PostTags { PostId = 1, TagId = 10 },

                // Пост 2
                new PostTags { PostId = 2, TagId = 2 },
                new PostTags { PostId = 2, TagId = 10 },
                new PostTags { PostId = 2, TagId = 12 },

                // Пост 3
                new PostTags { PostId = 3, TagId = 3 },
                new PostTags { PostId = 3, TagId = 11 },
                new PostTags { PostId = 3, TagId = 9 },

                // Пост 4
                new PostTags { PostId = 4, TagId = 4 },
                new PostTags { PostId = 4, TagId = 6 },
                new PostTags { PostId = 4, TagId = 10 },

                // Пост 5
                new PostTags { PostId = 5, TagId = 5 },
                new PostTags { PostId = 5, TagId = 9 },
                new PostTags { PostId = 5, TagId = 12 },

                // Пост 6
                new PostTags { PostId = 6, TagId = 7 },
                new PostTags { PostId = 6, TagId = 11 },
                new PostTags { PostId = 6, TagId = 12 },

                // Пост 7
                new PostTags { PostId = 7, TagId = 8 },
                new PostTags { PostId = 7, TagId = 9 },
                new PostTags { PostId = 7, TagId = 10 },

                // Пост 8
                new PostTags { PostId = 8, TagId = 1 },
                new PostTags { PostId = 8, TagId = 6 },
                new PostTags { PostId = 8, TagId = 11 },
            };
            context.PostTags.AddRange(postTags);

            context.SaveChanges();
            
            
        }
    }
    
    
}
// private static void SeedOptions(ClothingShopDbContext context)
// {
//     void AddOptionIfMissing(Option option)
//     {
//         if (!context.Options.Any(o => o.Name == option.Name))
//         {
//             context.Options.Add(option);
//         }
//     }
//
//     // ================= CORE =================
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "title", 
//         Value = "Male Fashion", 
//         Order = 1, 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "logo", 
//         Value = "img/logo.png", 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "description", 
//         Relation = "header", 
//         Value = "Free shipping, 30-day return or refund guarantee.", 
//         IsSystem = false 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "Sign-in", 
//         Relation = "header__top__links", 
//         Value = "Sign In", 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "FAQ", 
//         Relation = "header__top__links", 
//         Value = "FAQ", 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "Currency", 
//         Value = "Currency", 
//         IsSystem = true 
//     });
//
//     // ================= CURRENCY =================
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "USD", 
//         Value = "USD", 
//         Relation = "currency", 
//         Order = 1, 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "EUR", 
//         Value = "EUR", 
//         Relation = "currency", 
//         Order = 2, 
//         IsSystem = true 
//     });
//
//     AddOptionIfMissing(new Option 
//     { 
//         Name = "GBP", 
//         Value = "GBP", 
//         Relation = "currency", 
//         Order = 3, 
//         IsSystem = true 
//     });
//
//     // ================= PAYMENT =================
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "payImage",
//         Relation = "payment",
//         Value = "img/payment.png",
//         IsSystem = true
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "payment_links",
//         Relation = "payment",
//         Value = "The customer is at the heart of our unique business model, which includes design.",
//         IsSystem = false
//     });
//
//     // ================= SHOPPING BLOCK 1 =================
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Shopping",
//         Value = "Shopping",
//         Relation = "shopping",
//         Order = 1,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Clothing Store",
//         Value = "Clothing Store",
//         Relation = "shopping_menu",
//         Order = 1,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Trending Shoes",
//         Value = "Trending Shoes",
//         Relation = "shopping_menu",
//         Order = 2,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Accessories",
//         Value = "Accessories",
//         Relation = "shopping_menu",
//         Order = 3,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Sale",
//         Value = "Sale",
//         Relation = "shopping_menu",
//         Order = 4,
//         IsSystem = false
//     });
//
//     // ================= SHOPPING BLOCK 2 =================
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Contact Us",
//         Value = "Contact Us",
//         Relation = "shopping_support_menu",
//         Order = 1,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Payment Methods",
//         Value = "Payment Methods",
//         Relation = "shopping_support_menu",
//         Order = 2,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Delivery",
//         Value = "Delivery",
//         Relation = "shopping_support_menu",
//         Order = 3,
//         IsSystem = false
//     });
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Return & Exchanges",
//         Value = "Return & Exchanges",
//         Relation = "shopping_support_menu",
//         Order = 4,
//         IsSystem = false
//     });
//
//     // ================= FOOTER =================
//
//     AddOptionIfMissing(new Option
//     {
//         Name = "Copyright",
//         Value = "All rights reserved | My Fashion Store",
//         Relation = "footer",
//         Order = 1,
//         IsSystem = true
//     });
//
//     context.SaveChanges();
// }     