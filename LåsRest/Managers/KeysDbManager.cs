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
            //InitializeDatabase();
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

        public void InitializeDatabase()
        {
            List<Key> keys = new List<Key>()
            {
                new Key() {Id = 0, Name = "Martin", Email = "martin@gmail.com", Phone = "88991041"},
                new Key() {Id = 0, Name = "Frederik", Email = "frederik@gmail.com", Phone = "10203040"},
                new Key() {Id = 0, Name = "Andreas", Email = "andreas@gmail.com", Phone = "68102769"},
                new Key() {Id = 0, Name = "Victor", Email = "victor@gmail.com", Phone = "59275921"},
                new Key() {Id = 0, Name = "Henrik", Email = "henrik@gmail.com", Phone = "98451234"},
                new Key() {Id = 0, Name = "Mads", Email = "mads@gmail.com", Phone = "12375982"},
                new Key() {Id = 0, Name = "Jacob", Email = "jacob@gmail.com", Phone = "23465412"},
                new Key() {Id = 0, Name = "Jens", Email = "jens@gmail.com", Phone = "46583648"},
                new Key() {Id = 0, Name = "Hans", Email = "hans@gmail.com", Phone = "87347645"},
                new Key() {Id = 0, Name = "Karl", Email = "karl@gmail.com", Phone = "67564728"}
            };
            foreach (var k in keys)
            {
                var Key = _dbManager.Add(k).Result;
            }
        }
    }
}
