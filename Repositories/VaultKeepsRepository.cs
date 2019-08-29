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
      INSERT INTO vaultkeeps (keepId, userId, vaultId)
      VALUES (@KeepId, @UserId, @VaultId);
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

    public IEnumerable<VaultKeep> GetVaultKeeps(string userId)
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps WHERE userId=@UserId", new { userId });
    }
    public void DeleteVaultKeep(VaultKeep vaultKeep)
    {
      try
      {
        int vaultId = vaultKeep.VaultId;
        int keepId = vaultKeep.KeepId;
        string userId = vaultKeep.UserId;
        var success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, keepId, userId });

      }
      catch (Exception e)
      {

        throw e;
      }
      // vaultKeep.Id = ;
      // if (success != 1)
      // {
      //   throw new Exception();
      // }
    }
    // public IEnumerable<Keep> GetKeepsByUserId(string userId)
    // {
    //   return _db.Query<Keep>("SELECT * FROM vaultkeeps WHERE userId = @userId", new { userId });
    // }
  }
}