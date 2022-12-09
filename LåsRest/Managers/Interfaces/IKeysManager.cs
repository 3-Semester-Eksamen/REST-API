using Class_Library;

namespace LåsRest.Managers.Interfaces;

public interface IKeysManager
{
    List<Key> GetKeys();
    Key GetKeyById(int id);
    Key CreateKey(Key newKey);
    Key DeleteUser(int id);
    Key UpdateUser(int id, Key updateKey);
}