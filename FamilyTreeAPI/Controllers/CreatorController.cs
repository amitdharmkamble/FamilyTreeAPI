using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeAPI.Controllers
{
    [ApiController]
    [Route("/creator")]
    public class CreatorController
    {
        private readonly ICreatorService _creatorService;
        public CreatorController(ICreatorService creatorService)
        {
            _creatorService = creatorService;
        }

        [HttpGet]
        [Route("/create")]
        public async Task<IActionResult> CreateCreator(CreateCreatorRequest createCreatorRequest)
        {
            Guid createdCreatorId = await _creatorService.AddCreatorAsync(createCreatorRequest);
            return new JsonResult(createdCreatorId);
        }
    }
}