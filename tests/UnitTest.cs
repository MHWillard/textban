using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Xunit;
using textban.Models;
using textban.ViewModels;
using textban.Services;

namespace tests
{
    public class UnitTest
    {
        [Fact]
        public void PassingTest()
        {
            int Add(int x, int y)
            {
                return x + y;
            }

            Assert.Equal(4, Add(2, 2));
        }

        [AvaloniaFact]
        public void Should_Type_Text_Into_TextBox()
        {
            // Setup controls:
            var textBox = new TextBox();
            var window = new Window { Content = textBox };

            // Open window:
            window.Show();

            // Focus text box:
            textBox.Focus();

            // Simulate text input:
            window.KeyTextInput("Hello World");

            // Assert:
            Assert.Equal("Hello World", textBox.Text);
        }

        [Fact]
         public void ShouldMoveTaskItem()
        {
            //moveItemToTaskList, given two task lists for Backlog and Ready, item moved from Backlog should remove it and then appear in the Ready list
            //Arrange
            string TaskContent = "Walk dog";

            var ToDoItems = new ObservableCollection<ToDoItemViewModel>(new[]
            {
            new ToDoItemViewModel() { Content = "Walk dog" }, new ToDoItemViewModel() { Content = "Mow lawn"}, new ToDoItemViewModel() { Content = "Mail package"}
            });
            
            var ReadyItems = new ObservableCollection<ToDoItemViewModel>(new[]
            {
            new ToDoItemViewModel() { Content = "Floss teeth" }
            });

            ListManipulationService ListService = new ListManipulationService();

            //Act
            ListService.moveItemToTaskList(TaskContent, ToDoItems, ReadyItems);

            //Assert
            Assert.Contains(TaskContent, ReadyItems);
            Assert.DoesNotContain(TaskContent, ToDoItems);
        }
    }
}