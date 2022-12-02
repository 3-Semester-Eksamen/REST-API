using Eksamen_ClassLibrary;

namespace LåsRest.Managers
{
    public class KeysManager
    {
        private static bool _isInitialized = false;
        protected static int _nextId = 1;

        private static Dictionary<int, Key> _data = new Dictionary<int, Key>();
        private static readonly List<Key> _list = new List<Key>()
        {
            new Key() {Id = 0, Name = "Martin", Email = "martin@gmail.com", Phone = "88991041"},
            new Key() {Id = 0, Name = "Frederik", Email = "frederik@gmail.com", Phone = "10203040"},
            new Key() {Id = 0, Name = "Andreas", Email = "andreas@gmail.com", Phone = "68102769"},
            new Key() {Id = 0, Name = "Victor", Email = "victor@gmail.com", Phone = "59275921"},
            new Key() {Id = 0, Name = "Mads", Email = "mads@gmail.com", Phone = "98451234"}
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
            return _data[id];
        }

        public Key CreateKey(Key newKey)
        {
            newKey.Validate();
            if (!_data.ContainsKey(newKey.Id))
            {
                newKey.Name = null;
                newKey.Phone = null;
                newKey.Email = null;
                _data.Add(newKey.Id, newKey);

            }

            return _data[newKey.Id];

        }


        public Key DeleteUser(int id)
        {

            if (_data.ContainsKey(id))
            {
                Key deletedKey = _data[id];
                deletedKey.Name = null;
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
                return _data[id];
            }
            
            throw new ArgumentOutOfRangeException("Provided ID does not exist");
           

        }


    }
}
