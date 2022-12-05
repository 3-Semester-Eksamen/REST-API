using Microsoft.VisualStudio.TestTools.UnitTesting;
using LåsRest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Library;

namespace LåsRest.Managers.Tests
{
    [TestClass()]
    public class KeysManagersTests
    {
        public static readonly KeysManager manager = new();

        [TestMethod()]
        public void GetKeysTest()
        {
            //Arrange
            List<Key> list;
            int expectedCount = 5;
            int actualCount = 0;
            

            var expectedType = typeof(List<Key>);


            //Act
            list = manager.GetKeys();
            var actualType = list.GetType();
            actualCount = list.Count();


            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsNotNull(list);
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod()]
        public void CreateKeyTest()
        {
            // Arrange
            var newKey = new Key() {Id = 7};
            var expectedId = 7;
            var actualId = 0;
            var initLength = manager.GetKeys().Count();
            var actualLength = 0;
            string expectedName = null;
            string actualName = "";

            // Act
            var result = manager.CreateKey(newKey);
            actualId = result.Id;
            actualLength = manager.GetKeys().Count();
            actualName = result.Name;


            // Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreNotEqual(initLength, actualLength);
            Assert.AreEqual(expectedName, actualName);

        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            //Arrange
            int idKeyToBeDeleted = 1;
            string initName = manager.GetKeyById(idKeyToBeDeleted).Name;
            string actualName = "";
            string expectedName = null;

            //Act
            var deletedKey = manager.DeleteUser(idKeyToBeDeleted);
            actualName = manager.GetKeyById(idKeyToBeDeleted).Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreNotEqual(expectedName, initName);

        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            //Arrange
            var keyToBeUpdatedId = 1;
            Key actualKey = manager.GetKeyById(keyToBeUpdatedId);
            var actualKeyName = "";
            var actualKeyEmail = "";
            var actualKeyPhone = "";

            var expectedKeyName = "Morten";
            var expectedKeyEmail = "Morten@gmail.com";
            var expectedKeyPhone = "88888888";
            Key updates = new Key()
                {Id = actualKey.Id, Email = expectedKeyEmail, Phone = expectedKeyPhone, Name = expectedKeyName};


            //Act
            Key updatedKey = manager.UpdateUser(keyToBeUpdatedId, updates);
            actualKeyName = updatedKey.Name;
            actualKeyEmail = updatedKey.Email;
            actualKeyPhone = updatedKey.Phone;

            //Assert
            Assert.AreEqual(expectedKeyName, actualKeyName);
            Assert.AreEqual(expectedKeyEmail, actualKeyEmail);
            Assert.AreEqual(expectedKeyPhone, actualKeyPhone);



        }
    }
}