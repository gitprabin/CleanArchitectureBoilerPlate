using BoilerPlate.Application.TestTables.Commands.CreateTestTable;
using BoilerPlate.Application.TestTables.Commands.DeleteTestTable;
using BoilerPlate.Application.TestTables.Commands.UpdateTestTable;
using BoilerPlate.Application.TestTables.Queries.GetTestTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BoilerPlate.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetTestTablesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTestTableCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, UpdateTestTableCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTestTableCommand { Id = id });

            return NoContent();
        }
    }
}
