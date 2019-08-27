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
    // public IEnumerable<VaultKeep> GetKeepsByVaultId()
    // {
    //   return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    // }

    public VaultKeep GetVaultKeepById(int id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaultkeeps WHERE id = @id", new { id });
    }

    public VaultKeep AddKeepToVault(VaultKeep vaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();
      ", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE vaultId = @vaultId AND vk.userId = @userId;", new { vaultId, userId });
    }

    // public IEnumerable<VaultKeep> GetVaultKeeps()
    // {
    //   return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    // }
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