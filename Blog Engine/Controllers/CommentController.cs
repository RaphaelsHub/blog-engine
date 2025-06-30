using BlogEngine.Application.Common.Mediator;
using BlogEngine.Core.Contracts.Requests;
using BlogEngine.Core.Contracts.Responses;
using BlogEngine.Commnads;
using BlogEngine.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{postId}")]
    public async Task<ActionResult<List<CommentResponse>>> GetByPostId(string postId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPostCommentsQuery(postId), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCommentRequest request, CancellationToken cancellationToken)
    {
        var success = await mediator.Send(new AddCommentCommand(request), cancellationToken);
        return success ? Ok() : BadRequest("Failed to add comment.");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var success = await mediator.Send(new UpdateCommentCommand(request), cancellationToken);
        return success ? Ok() : NotFound("Comment not found.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var success = await mediator.Send(new DeleteCommentCommand(request), cancellationToken);
        return success ? Ok() : NotFound("Comment not found.");
    }
}
