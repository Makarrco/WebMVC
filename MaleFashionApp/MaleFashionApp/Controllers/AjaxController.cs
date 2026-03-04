using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using MaleFashionApp.DB;
using MaleFashionApp.Dto;
using MaleFashionApp.Entities;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MaleFashionApp.Controllers;

public class AjaxController : Controller
{
    private ClothingShopDbContext _clothingDbContext;
    private PostModel _postModel;
    private CommentModel _commentModel;

    public AjaxController(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _postModel = new PostModel(clothingDbContext);
        _commentModel = new CommentModel(clothingDbContext);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public string GetAllComments(int postId)
    {
        var jsonResponse = new JsonResponse
        {
            Code = 200,
            Status = StatusResponse.Error
        };

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        try
        {
            if (postId <= 0)
            {
                jsonResponse.Message = "Post id => no valid data";
            }
            else
            {
                var post = _postModel.GetPostById(postId);
                if (post == null)
                {
                    jsonResponse.Message = "Post id => not found";
                }
                else
                {
                    var commentsDto = CommentDtoHelper.Convert(_commentModel.GetCommentsTree(post.Id));
                    jsonResponse.Data = commentsDto;
                    jsonResponse.Status = StatusResponse.Success;
                }
            }
        }
        catch
        {
            jsonResponse.Status = StatusResponse.Error;
            jsonResponse.Message = "Server Error";
        }

        return JsonSerializer.Serialize(jsonResponse, options);
    }

    [HttpPost]
    public string SaveComment(int postId, string login, string email, string message, int? parentId)
    {
        JsonResponse jsonResponse = new JsonResponse()
        {
            Code = 200,
        };
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
        jsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        
        if (_commentModel.SaveComment(new Comment()
        {
            PostId = postId,
            Login = login,
            Email = email,
            Message = message,
            ParentId = parentId
        }) == true)
        {
            jsonResponse.Status = StatusResponse.Success;
            jsonResponse.Message = "Comment saved";
            return JsonSerializer.Serialize(jsonResponse, jsonSerializerOptions);
            
        }
        else
        {
            jsonResponse.Status = StatusResponse.Success;
            jsonResponse.Message = "Comment NOT saved";
            return JsonSerializer.Serialize(jsonResponse, jsonSerializerOptions);
        }
    }
}



