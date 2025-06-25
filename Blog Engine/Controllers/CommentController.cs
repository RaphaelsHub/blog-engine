using BlogEngine.Contracts.Requests;
using BlogEngine.Contracts.Responses;
// using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    // private readonly IMediator _mediator;
    // public CommentsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{postId}")]
    public async Task<ActionResult<List<CommentResponse>>> GetByPostId(string postId)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCommentRequest request)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommentRequest request)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCommentRequest request)
    {
        // TODO: реализовать
        throw new NotImplementedException();
    }
}
