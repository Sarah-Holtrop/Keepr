using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _repo;

    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }
    // Get all, for testing but probably won't actually need
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {

      try
      {
        return Ok(_repo.GetKeeps());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    // Get by Id
    // [HttpGet("{id}")]
    // public ActionResult<Keep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetKeepById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    [Authorize]
    // post, might need to refactor for posting with userId?
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep keep)
    {
      try
      {
        keep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.CreateKeep(keep));
      }
      catch (Exception e)
      {
        return BadRequest("Bad Request");
      }
    }
    [Authorize]
    // delete, might need to refactor to use userId
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      if (userId.Contains(userId))
      {

        try
        {
          _repo.DeleteKeep(id);
        }
        catch (Exception e)
        {
          return BadRequest("Delete failed");
        }
      }
      return Ok("Successfully Deleted");
    }

    // Need getKeepsByVaultId or something, but need to figure out table join first
  }
}