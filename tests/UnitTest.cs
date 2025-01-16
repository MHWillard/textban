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
            ListService.moveItemToTaskList(TaskItem, ReadyItems, ToDoItems);

            //Assert
            Assert.Contains(TaskItem, ReadyItems);
            Assert.DoesNotContain(TaskItem, ToDoItems);
        }

        [AvaloniaFact]
        public void ShouldDragDropTextBlock()
        {
            //Arrange
            //start simple: window, two boxes, text block in each box, the test is to drag one to the other to begin with
            // => TO HELP WITH TESTING: need a general WPF reference since Avaolinua builds off of that: use these when creating the code for these tests
            //use unit tests => solve simpler problems => build on top of that
            //the test is: can I drag an item from an Items control to another, and will it update the lists accordingly?
            //create itemcontrols, create your lists, add them to the controls, then put them in a box, build, verify
            //then set up a drag function to test

            var TextOne = new TextBlock { Text = "Foo" };
            var TextTwo = new TextBlock { Text = "Bar" };
            var BacklogItemsControl = new ItemsControl();
            var ReadyItemsControl = new ItemsControl();
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
                Content = ListBoxOne
            };

            //Act
            //-dragn text block to overall panel containing other list
            //-trip moveitemtoTaskList
            window.Show();

            //Assert
            //--assert that ready list ui and list contains added item
            //--assert that backlog ui and list does not have the added item
            Assert.Contains(TextOne, ListBoxOne.Items);
        }
    }
}