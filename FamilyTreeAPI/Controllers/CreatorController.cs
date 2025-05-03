using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeAPI.Controllers
{
    [ApiController]
    [Route("/createcreator")]
    public class CreatorController
    {
        [HttpGet]
        public object CreateCreator(string firstName, string LastName, DateTime DateOfBirth)
        {
            var creatorExist = new
            {
                creatorExists = false
            };
            return creatorExist;
        }
    }
}
