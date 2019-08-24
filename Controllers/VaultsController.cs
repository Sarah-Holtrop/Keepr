using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
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
        return Ok(_repo.GetVaults());
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
      try
      {
        _repo.DeleteVault(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest("Delete failed");
      }
    }
  }
}