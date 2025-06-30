using BlogEngine.Core.Contracts.Requests;
using BlogEngine.Core.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using BlogEngine.Commnads;
using BlogEngine.Queries;
using BlogEngine.Application.Common.Mediator;

namespace BlogEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IMediator sender) : ControllerBase
{
    private readonly IMediator _sender = sender;

    [HttpGet]
    public async Task<ActionResult<List<PostResponse>>> GetAll()
    {
        var query = new GetAllPostsQuery();
        var result = await _sender.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostResponse>> GetById(string id)
    {
        var query = new GetPostByIdQuery(id);
        var result = await _sender.Send(query);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] CreatePostRequest request)
    {
        var command = new CreatePostCommand(request);
        var result = await _sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(request);
        var success = await _sender.Send(command);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeletePostCommand(id);
        var success = await _sender.Send(command);
        return success ? NoContent() : NotFound();
    }
}
