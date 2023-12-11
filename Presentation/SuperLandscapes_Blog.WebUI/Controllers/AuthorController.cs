using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperLandscapes_Blog.Application.Features.Authors.Commands.InsertAuthor;
using SuperLandscapes_Blog.Domain.Entities;
using SuperLandscapes_Blog.Shared.ResultResponse;

namespace API.Controllers
{
    [ApiController]
    [Route("api/author")]

    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// To create an author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPost]
        public async Task<ActionResult<Result<Author>>> InsertAuthorAsync([FromBody] InsertAuthorCommand command)
        {
            var validator = new InsertAuthorValidator();

            var result = validator.Validate(command);
            if (!result.IsValid) { return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList()); }

            return await _mediator.Send(command);
        }
       /* /// <summary>
        ///  All informations about authors 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetAuthorDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var response = await _authorService.GetAllAuthorsAsync();
            return Ok(response);
        }
        /// <summary>
        ///  All shart informations about authors 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetTopAuthorDTO</returns>
        [AllowAnonymous]
        [HttpGet("get-short-all")]
        public async Task<IActionResult> GetAllTopAuthorsAsync()
        {
            var response = await _authorService.GetAllTopAuthorsAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
        {
            var response = await _authorService.GetAuthorByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To update an author by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDTO authorDTO)
        {
            var response = await _authorService.UpdateAuthorAsync(authorDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an author by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorById(Guid id)
        {
            var response = await _authorService.DeleteAuthorByIdAsync(id);
            return Ok(response);
        }*/
    }
}
