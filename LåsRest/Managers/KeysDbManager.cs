using Class_Library;
using LåsRest.Managers.Interfaces;
using System.Xml.Linq;
using LåsRest.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace LåsRest.Managers
{
    public class KeysDbManager : DbManager<Key>, IKeysManager
    {
        private static readonly DbManager<Key> _dbManager = new();
        private static List<Key> _keys;

        public KeysDbManager()
        {
            GetKeys();
            //var createdKey = CreateKey(new Key() {Email = "Constructor", Name = "sasd", Phone = "1231"}).Result;
        }

        public List<Key> GetKeys()
        {
            var list = _dbManager.GetObjects().Result;
            _keys = list;
            return list;
        }

        public Key GetKeyById(int id)
        {
            var foundKey = _dbManager.GetObjects().Result.Find(k => k.Id == id);
            if (foundKey == null) throw new BadSearch("No Key with that ID found");
            return foundKey;
        }

        public Key CreateKey(Key newKey)
        {
            if (!_keys.Exists(k => k.Id == newKey.Id))
            {
                newKey.Id = 0;
                newKey.Name = "Unassigned";
                newKey.Phone = null;
                newKey.Email = null;
                var createdKey = _dbManager.Add(newKey).Result;
  
                return createdKey;
            }

            throw new AlreadyExists("A key with the ID already exists");

        }

        public Key DeleteUser(int id)
        {
            var foundKey = GetKeyById(id);
            foundKey.Name = "Unassigned";
            foundKey.Phone = null;
            foundKey.Email = null;
            var deletedKey = _dbManager.Update(foundKey).Result;
            return deletedKey;

        }

        public Key UpdateUser(int id, Key updateKey)
        {
            var foundKey = GetKeyById(id);
            foundKey.Email = updateKey.Email;
            foundKey.Phone = updateKey.Phone;
            foundKey.Name = updateKey.Name;
            foundKey.Validate();
            var updatedKey = _dbManager.Update(foundKey).Result;
            return updatedKey;
        }
    }
}
