using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dektoon.Services;
using Dektoon.Models;

namespace Dektoon.Controllers;

[ApiController]
[Route("[controller]")]
public class DektoonController : ControllerBase
{
    private readonly IDektoonServices dektoonServices;

    public DektoonController(IDektoonServices dektoonServices){
        this.dektoonServices = dektoonServices;
    }
    [HttpGet("DektoonGet")]
    public IActionResult GetDektoon()
    {
        var dektoon = dektoonServices.GetCartoon();
        return Ok(dektoon);
    }

    [HttpPost("DektoonAdd")]
    public IActionResult AddDektoon([FromBody] CartoonModel cartoonModel)
    {
        try
        {
            var data = dektoonServices.AddCartoon(cartoonModel);
                return Ok(data);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [HttpPut("DektoonUpdate")]
    public IActionResult UpdateDektoon([FromBody] CartoonModel cartoonModel)
    {
        try
        {
            var data = dektoonServices.UpdateCartoon(cartoonModel);
            return Ok(data);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [HttpDelete("DektoonDelete")]
    public IActionResult DeleteDektoon([FromQuery] int cartoonId)
    {
            var data = dektoonServices.DeleteCartoon(cartoonId);
            return Ok(data);
        }
}
