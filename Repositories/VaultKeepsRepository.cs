using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
  // [Authorize]
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // SECTION CRUD methods
    public IEnumerable<VaultKeep> GetVaultKeeps()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    }

    public VaultKeep GetVaultKeepById(int id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaultkeeps WHERE id = @id", new { id });
    }

    public VaultKeep CreateVaultKeep(VaultKeep vaultKeep)
    {
      var id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps (vaultid, keepid)
      VALUES (@VaultId, @KeepId);
      SELECT LAST_INSERT_ID();
      ", vaultKeep);
      // vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      vaultKeep.Id = id;
      return vaultKeep;
    }
    public void DeleteVaultKeep(int id)
    {
      var success = _db.Execute("DELETE FROM vaultkeepss WHERE id = @id", new { id });
      if (success != 1)
      {
        throw new Exception("Delete failed");
      }
    }

  }
}