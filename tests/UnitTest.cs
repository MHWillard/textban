using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Xunit;
using textban.Models;
using textban.ViewModels;
using textban.Services;
using Avalonia.Layout;

namespace tests
{
    public class UnitTest
    {
        [Fact]
         public void ShouldMoveTaskItem()
        {
            //moveItemToTaskList, given two task lists for Backlog and Ready, item moved from Backlog should remove it and then appear in the Ready list
            //Arrange
            ToDoItemViewModel TaskItem = new ToDoItemViewModel() { Content = "Walk dog" };

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
            ListService.moveItemToTaskList(TaskItem, ToDoItems, ReadyItems);

            //Assert
            Assert.Contains(TaskItem, ReadyItems);
            Assert.DoesNotContain(TaskItem, ToDoItems);
        }

        [AvaloniaFact]
        public void ShouldDragDropTextBlock()
        {
            //Arrange
            //start simple: window, two boxes, text block in each box, the test is to drag one to the other to begin with
            // => TO HELP WITH TESTING: need a general WPF reference since Avaolinua builds off of that
            //use unit tests => solve simpler problems => build on top of that

            var TextOne = new TextBlock { Text = "Foo" };
            var TextTwo = new TextBlock { Text = "Bar" };
            var ListBoxOne = new ListBox();
            var ListBoxTwo = new ListBox();
            List<TextBlock> items = new List<TextBlock>();
            List<TextBlock> itemsTwo = new List<TextBlock>();
            items.Add(TextOne);
            itemsTwo.Add(TextTwo);
            ListBoxOne.ItemsSource = items;
            ListBoxTwo.ItemsSource = itemsTwo;

            var window = new Window
            {
                Width = 200,
                Height = 300,
                Content = TextOne
            };

            //Act
            //-dragn text block to overall panel containing other list
            //-trip moveitemtoTaskList

            //Assert
            //--assert that ready list ui and list contains added item
            //--assert that backlog ui and list does not have the added item
        }
    }
}