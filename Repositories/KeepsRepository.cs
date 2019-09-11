using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetNotPrivateKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }
    public Keep GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id", new { id });
    }
    public IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }


    public Keep CreateKeep(Keep keep)
    {
      var id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, description, img, isPrivate, userId)
      VALUES (@Name, @Description, @Img, @IsPrivate, @UserId);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;
    }
    // messing around with counting views on a keep, has not been tested, just an idea
    public Keep ViewKeep(int id)
    {
      Keep viewedkeep = GetKeepById(id);
      if (viewedkeep is null) throw new Exception("Couldn't find a keep with this id: " + id);
      viewedkeep.Views += 1;
      // will have to add views into keep.cs model
      viewedkeep = _db.ExecuteScalar<Keep>(@"
      UPDATE keeps SET 
      views = @Views 
      WHERE id = @Id", viewedkeep);
      return viewedkeep;
      // not sure if line 43 i can just insert a new keep into this table slot like this, might need to do like age: instead of 81, use a variable that increments up by 1?
      // -- UPDATE cats SET
      // -- name = "Sylvester Sr.",
      // --age = 81
      // -- WHERE ID = 4;
    }

    // Also to make things more simplistic once a keep is marked public it can no longer be deleted.
    // do deletingkeep = GetKeepById first, then if (deletingkeep.isPrivate), then carry on with delete

    public void EditKeep(Keep keep)
    {
      // name, description, image, private
      var success = _db.Execute("UPDATE keeps SET name = @Name, description = @Description, img = @Img, isPrivate = @IsPrivate");
      if (success == 0)
      {
        throw new Exception("Update failed");
      }
    }
    public void DeleteKeep(int id)
    {
      var success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      if (success != 1)
      {
        throw new Exception("Delete failed");
      }
    }

  }
}