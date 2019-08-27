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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    // Get all, for testing but probably won't actually need
    // [HttpGet]
    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   try
    //   {
    //     return Ok(_repo.GetVaultKeeps());
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e.Message);
    //   }
    // }
    // Get by Id
    // [HttpGet("{id}")]
    // public ActionResult<VaultKeep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetVaultKeepById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    // [Authorize]
    // [HttpGet]
    // public ActionResult<Keep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetKeepsByVaultId(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest("Bad Request");
    //   }
    // }

    // post, might need to refactor for posting with userId?
    // [HttpPost]
    // public ActionResult<VaultKeep> Post([FromBody]VaultKeep vaultKeep)
    // {
    //   try
    //   {
    //     return Ok(_repo.AddKeepToVault(vaultKeep));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest("Bad Request");
    //   }
    // }
    [HttpPost]
    public ActionResult<int> AddKeep([FromBody] VaultKeep vaultkeep)
    {
      vaultkeep.UserId = HttpContext.User.FindFirstValue("Id");
      try
      {
        return Ok(_repo.AddKeepToVault(vaultkeep));
      }
      catch (Exception e)
      {
        return BadRequest("Cannot add keep to vault");
      }
    }
    // delete, might need to refactor to use userId
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _repo.DeleteVaultKeep(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest("Delete failed");
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetVaultKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/keeps")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      try
      {
        return Ok(_repo.GetKeepsByVaultId(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}

// [HttpGet] getKeepsByVaultId
// [HttpPost] addKeepToVault
// [HttpDelete] deleteVaultKeep
