using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQlSample.Controllers
{
    [ApiController]
    public class GraphQlController : ControllerBase
    {
        private GraphQlService _graphQlService;
        public GraphQlController(GraphQlService graphQlService)
        {
            _graphQlService = graphQlService;
        }

        [HttpPost]
        [Route("api/graphql")]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            try
            {
                var result = await _graphQlService.ExecuteAsync(query);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/schema")]
        public async Task<IActionResult> Post1([FromBody] GraphQlQuery query)
        {
            try
            {
                var result = await _graphQlService.ExecuteSchema(query);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}