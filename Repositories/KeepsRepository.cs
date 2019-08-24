using System;
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
    public IEnumerable<Keep> GetKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }
    public Keep GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id", new { id });
    }
    public Keep CreateKeep(Keep keep)
    {
      var id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, description, img)
      VALUES (@Name, @Description, @Img);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;
    }
    // messing around with counting views on a keep, has not been tested, just an idea
    // public Keep ViewKeep(int id)
    // {
    //   Keep viewedkeep = GetKeepById(id);

    //   viewedkeep.Views += 1;
    //   // will have to add views into keep.cs model
    //   viewedkeep = _db.ExecuteScalar<Keep>(@"
    //   UPDATE keeps SET 
    //   viewedkeep 
    //   WHERE id = @id", new { id });
    //   return viewedkeep;
    //   // not sure if line 43 i can just insert a new keep into this table slot like this, might need to do like age: instead of 81, use a variable that increments up by 1?
    //   // -- UPDATE cats SET
    //   // -- name = "Sylvester Sr.",
    //   // --age = 81
    //   // -- WHERE ID = 4;
    // }

    // Also to make things more simplistic once a keep is marked public it can no longer be deleted.
    // do deletingkeep = GetKeepById first, then if (deletingkeep.isPrivate), then carry on with delete
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