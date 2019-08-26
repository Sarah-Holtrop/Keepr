using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }
    // Get all, for testing but probably won't actually need
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetVaults(userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    // Get by Id
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_repo.GetVaultById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // post, might need to refactor for posting with userId?
    [HttpPost]
    public ActionResult<Vault> Post([FromBody]Vault vault)
    {
      try
      {
        vault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.CreateVault(vault));
      }
      catch (Exception e)
      {
        return BadRequest("Bad Request");
      }
    }
    // delete, might need to refactor to use userId
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      if (userId.Contains(userId))
      {
        try
        {
          _repo.DeleteVault(id);
        }
        catch (Exception e)
        {
          return BadRequest("Delete failed");
        }
      }
      return Ok("Successfully Deleted");
    }
  }
}