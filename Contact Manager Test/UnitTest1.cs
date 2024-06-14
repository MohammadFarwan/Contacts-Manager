
using Contact_Manager;


namespace Contact_Manager_Test
{
    public class UnitTest1
    {

        [Fact]
        public void AddContact_ValidContact_ReturnsUpdatedList()
        {
            // Arrange
            ContactManager.AddContact("John Doe");

            // Act
            var result = ContactManager.AddContact("Jane Smith");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("John Doe", result);
            Assert.Contains("Jane Smith", result);
        }

        [Fact]
        public void AddContact_DuplicateContact_ThrowsException()
        {
            // Arrange
            ContactManager.AddContact("John Doe");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => ContactManager.AddContact("John Doe"));
        }

        [Fact]
        public void AddContact_EmptyContactName_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => ContactManager.AddContact(""));
        }

        [Fact]
        public void RemoveContact_ExistingContact_ReturnsUpdatedList()
        {
            // Arrange
            ContactManager.AddContact("John Doe");
            ContactManager.AddContact("Jane Smith");

            // Act
            var result = ContactManager.RemoveContact("John Doe");

            // Assert
            Assert.Single(result);
            Assert.Contains("Jane Smith", result);
        }

        [Fact]
        public void RemoveContact_NonExistingContact_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<InvalidOperationException>(() => ContactManager.RemoveContact("Non Existing Contact"));
        }

        [Fact]
        public void ViewAllContacts_ReturnsAllContacts()
        {
            // Arrange
            ContactManager.AddContact("John Doe");
            ContactManager.AddContact("Jane Smith");

            // Act
            var result = ContactManager.ViewAllContacts();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("John Doe", result);
            Assert.Contains("Jane Smith", result);
        }

    }
}