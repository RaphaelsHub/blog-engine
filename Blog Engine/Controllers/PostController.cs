using BlogEngine.Contracts.Requests;
using BlogEngine.Contracts.Responses;
// using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    // private readonly IMediator _mediator;
    // public PostsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<PostResponse>>> GetAll()
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostResponse>> GetById(string id)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] CreatePostRequest request)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePostRequest request)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }
}
