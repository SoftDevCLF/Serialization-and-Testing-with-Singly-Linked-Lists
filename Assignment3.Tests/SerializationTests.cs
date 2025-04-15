using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the linked list was empty.
        /// </summary>
        [Test]
        public void CheckIfTheLinkedListIsEmpty()
        {
            //Act: Clear the list
            this.users.Clear();

            //Assert: Verify the list is empty
            Assert.IsTrue(this.users.IsEmpty());
        }
        /// <summary>
        /// Tests the item was prepended
        /// </summary>
        [Test] 
        public void PrependingItemsToTheBeginningOfTheList()
        {
            //Arrange: linked list and intial data
            var firstUser = new User(5, "First Node", "first.node@gmail.com", "password456");

            //Act: Add the first node
            this.users.AddFirst(firstUser);

            //Assert: Verify the new node is the head node
            Assert.AreEqual(firstUser, this.users.Head.Data);
        }

        /// <summary>
        /// Tests the item was appended.
        /// </summary>
        [Test]
        public void AppendingItemsToTheEndOfTheList()
        {
            //Arrange: linked list and end data
            var lastUser = new User(0, "Last Node", "last.node@gmail.com", "password987");

            //Act: Add the last node
            this.users.AddLast(lastUser);

            //Assert: Verify the last node is the tail
            Assert.AreEqual(lastUser, this.users.Tail.Data);
        }
        /// <summary>
        /// Tests the item was inserted at index
        /// </summary>
        [Test]
        public void InsertingAnItemAtAnIndexInTheList()
        {
            //Arrange: linked list and index data
            var randomUser = new User(2, "Inserted Index", "inserted.node@gmail.com", "password21");

            //Act: Add the random node at index 2
            this.users.Add(randomUser, 2);

            //Assert: Verify the new node is at index 2
            Assert.AreEqual(randomUser, this.users.GetValue(2));
        }
        /// <summary>
        /// Tests the item was replaced at index
        /// </summary>
        [Test]
        public void ReplacingAnItemAtAnIndexInTheList()
        {
            //Arrange: linked list and new user data
            var newUser = new User(3, "NewUser", "newuser@hotmail.com", "passwordnewuseristhebest");
           
           //Act: Replace the value at index 1
            this.users.Replace(newUser, 1);

            //Assert: Verify the new node is at index 1
            Assert.AreEqual(newUser, this.users.GetValue(1));
        }
        /// <summary>
        /// Tests the item was deleted from the beginning of the list
        /// </summary>
        [Test]
        public void DeleteItemFromBeginningOfList()
        {
            //Act: Remove the first node
            this.users.RemoveFirst();

            //Assert: Verify the new head node is the second node
            Assert.AreEqual(users.GetValue(0).Id, 2); // Assert that the Id of the user at index 0 in the list is equal to 2.

        }
        /// <summary>
        /// Tests the item was deleted from the end of the list
        /// </summary>
        [Test]
        public void DeleteItemFromTheEndOfList()
        {
            //Act: Remove the last node
            this.users.RemoveLast();

            //Assert: Verify the new tail node is the second last node
            Assert.AreEqual(users.GetValue(users.Count() - 1).Id, 3); // Assert that the Id of the user at index users.Count() - 1 in the list is equal to 3.
        }
        /// <summary>
        /// Tests the item was deleted from the middle of the list
        /// </summary>
        [Test]
        public void DeletingItemFromMiddleOfList()
        {
            //Act: Remove the node at the middle of the list
            this.users.Remove(2);

            //Assert: Verify the new node at index 2 is the last node
            Assert.AreEqual(users.GetValue(2).Id, 4); // Assert that the Id of the user at index 2 in the list is equal to 4.
        }
        /// <summary>
        /// Tests the item was found and retrieved. 
        /// </summary>
        [Test]
        public void ItemIsFoundAndRetrieved()
        {
            //Act: Get the node at index 1
            var user = this.users.GetValue(1);

            //Assert: Verify the new node is at index 1
            Assert.AreEqual(user.Id, 2); // Assert that the Id of the user at index 1 in the list is equal to 2.
        }
        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            
            Assert.IsTrue(users.Count() == deserializedUsers.Count());
            
            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
    }
}