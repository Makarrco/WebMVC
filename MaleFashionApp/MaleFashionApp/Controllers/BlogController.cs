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
    public IActionResult Index(string? category, string? tag, string? search)
    {
        BlogViewModel viewModel = new BlogViewModel();
        viewModel.Tags = _tagModel.GetNotEmptytagList();
        viewModel.Categories = _categoryModel.GetCategoryTree();
        if (category != null)
        {
            viewModel.Posts = _postModel.GetPostsByCategorySlug(category);
        } else if (tag != null)
        {
            viewModel.Posts = _postModel.GetPostsByTagSlug(tag);
        }else if (search != null)
        {
            viewModel.Posts = _postModel.SearchPosts(search);
        }
        else
        {
            viewModel.Posts = _postModel.GetPosts(6, 0);
        }
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