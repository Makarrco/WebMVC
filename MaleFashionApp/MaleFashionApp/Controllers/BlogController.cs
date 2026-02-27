using MaleFashionApp.DB;
using MaleFashionApp.Entities;
using MaleFashionApp.Models;
using MaleFashionApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.Controllers;

public class BlogController : Controller
{
    private ClothingShopDbContext _clothingDbContext;
    private TagModel _tagModel;
    private CategoryModel _categoryModel;
    private PostModel _postModel;
    
    public BlogController(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _tagModel = new TagModel(clothingDbContext);
        _categoryModel = new CategoryModel(clothingDbContext);
        _postModel = new PostModel(clothingDbContext);
    }
    [HttpGet]
    public IActionResult Index(string? category, string? tag, string? search, int page = 1)
    {
        int pageSize = 6;
        int offset = (page - 1) * pageSize;

        BlogViewModel viewModel = new BlogViewModel();
        viewModel.Tags = _tagModel.GetNotEmptytagList();
        viewModel.Categories = _categoryModel.GetCategoryTree();

        int totalPosts = 0;

        if (category != null)
        {
            viewModel.Posts = _postModel.GetPostsByCategorySlug(category)
                .Skip(offset)
                .Take(pageSize)
                .ToList();

            totalPosts = _postModel.GetTotalByCategory(category);
        }
        else if (tag != null)
        {
            viewModel.Posts = _postModel.GetPostsByTagSlug(tag)
                .Skip(offset)
                .Take(pageSize)
                .ToList();

            totalPosts = _postModel.GetTotalByTag(tag);
        }
        else if (search != null)
        {
            viewModel.Posts = _postModel.SearchPosts(search)
                .Skip(offset)
                .Take(pageSize)
                .ToList();

            totalPosts = _postModel.GetTotalBySearch(search);
        }
        else
        {
            viewModel.Posts = _postModel.GetPosts(pageSize, offset);
            totalPosts = _postModel.GetTotalPostCount();
        }

        viewModel.CurrentPage = page;
        viewModel.TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult GetOnePost(string? slug)
    {

        if (slug != null)
        {
            Post? postInfo = _postModel.GetPostInfo(slug);
            if (postInfo != null)
            {
                return View(postInfo);
            }
        } 
        return RedirectToAction("Error", "PageNotFound");
    }
}