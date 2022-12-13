using Class_Library;
using LåsRest.CustomExceptions;
using LåsRest.Managers.Interfaces;

namespace LåsRest.Managers
{
    public class KeysManager : IKeysManager
    {
        private static bool _isInitialized = false;
        protected static int _nextId = 1;

        private static Dictionary<int, Key> _data = new Dictionary<int, Key>();
        private static readonly List<Key> _list = new List<Key>()
        {
            new Key() {Name = "Martin", Email = "martin@gmail.com", Phone = "88991041"},
            new Key() {Name = "Frederik", Email = "frederik@gmail.com", Phone = "10203040"},
            new Key() {Name = "Andreas", Email = "andreas@gmail.com", Phone = "68102769"},
            new Key() {Name = "Victor", Email = "victor@gmail.com", Phone = "59275921"},
            new Key() {Name = "Henrik", Email = "henrik@gmail.com", Phone = "98451234"},
            new Key() {Name = "Mads", Email = "mads@gmail.com", Phone = "12375982"},
            new Key() {Name = "Jacob", Email = "jacob@gmail.com", Phone = "23465412"},
            new Key() {Name = "Jens", Email = "jens@gmail.com", Phone = "46583648"},
            new Key() {Name = "Hans", Email = "hans@gmail.com", Phone = "87347645"},
            new Key() {Name = "Karl", Email = "karl@gmail.com", Phone = "67564728"}
        };

        public KeysManager()
        {
            if (!_isInitialized)
            {
                _data = new Dictionary<int, Key>();
                foreach (var item in _list)
                {
                    item.Id = _nextId++;
                    _data.Add(item.Id, item);
                }

                _isInitialized = true;
            }
        }
        public List<Key> GetKeys()
        {
            return _data.Values.ToList();
        }

        public Key GetKeyById(int id)
        {
            var foundkey= _data[id];
            if (foundkey == null) throw new BadSearch("No Key with that ID  was found");
            return foundkey;
        }

        public Key CreateKey(Key newKey)
        {
            if (!_data.ContainsKey(newKey.Id))
            {
                newKey.Id = _nextId++;
                newKey.Name = "Unassigned";
                newKey.Phone = null;
                newKey.Email = null;
                _data.Add(newKey.Id, newKey);

            }

            return _data[_nextId++-1];

        }


        public Key DeleteUser(int id)
        {

            if (_data.ContainsKey(id))
            {
                Key deletedKey = _data[id];
                deletedKey.Name = "Unassigned";
                deletedKey.Email = null;
                deletedKey.Phone = null;
                return deletedKey;
            }
           
            throw new ArgumentOutOfRangeException("Provided ID does not exist");
            

        }

        public Key UpdateUser(int id, Key updateKey)
        {

            if (_data.ContainsKey(id))
            {
                _data[id] = updateKey;
                updateKey.Validate();
                return _data[id];
            }
            
            throw new ArgumentOutOfRangeException("Provided ID does not exist");
           

        }

        


    }
}
