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
        /// Tests the object was prepended
        /// </summary>
        [Test] 
        public void PrependingNodesToTheBeginningOfTheList()
        {
            //Arrange: linked list and intial data
            var firstUser = new User(5, "First Node", "first.node@gmail.com", "password456");

            //Act: Add the first node
            this.users.AddFirst(firstUser);

            //Assert: Verify the new node is the head node
            Assert.AreEqual(firstUser, this.users.Head.Data);
        }

        /// <summary>
        /// Tests the object was appended.
        /// </summary>
        [Test]
        public void AppendingNodesToTheEndOfTheList()
        {
            //Arrange: linked list and end data
            var lastUser = new User(0, "Last Node", "last.node@gmail.com", "password987");

            //Act: Add the last node
            this.users.AddLast(lastUser);

            //Assert: Verify the last node is the tail
            Assert.AreEqual(lastUser, this.users.Tail.Data);
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