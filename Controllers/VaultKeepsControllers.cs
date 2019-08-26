using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
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
    [HttpGet]
    public ActionResult<IEnumerable<VaultKeep>> Get()
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
    // Get by Id
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      try
      {
        return Ok(_repo.GetVaultKeepById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // post, might need to refactor for posting with userId?
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody]VaultKeep vaultKeep)
    {
      try
      {
        return Ok(_repo.CreateVaultKeep(vaultKeep));
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
        _repo.DeleteVaultKeep(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest("Delete failed");
      }
    }
  }
}