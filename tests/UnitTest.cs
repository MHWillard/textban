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
        public void ItemsControlsShouldAppear()
        {
            //Arrange
            //start simple: window, two boxes, text block in each box, the test is to drag one to the other to begin with

            StackPanel stackPanel = new StackPanel();
            var BacklogItemsControl = new ItemsControl();
            var ReadyItemsControl = new ItemsControl();
            List<TextBlock> itemsOne = new List<TextBlock>
            {
                new TextBlock { Text = "Item 1.1" },
                new TextBlock { Text = "Item 1.2" },
                new TextBlock { Text = "Item 1.3" }
            };
            List<TextBlock> itemsTwo = new List<TextBlock>
            {
                new TextBlock { Text = "Item 2.1" },
                new TextBlock { Text = "Item 2.2" },
                new TextBlock { Text = "Item 2.3" }
            };
            BacklogItemsControl.ItemsSource = itemsOne;
            ReadyItemsControl.ItemsSource = itemsTwo;

            stackPanel.Children.Add(BacklogItemsControl);
            stackPanel.Children.Add(ReadyItemsControl);

            var window = new Window
            {
                Width = 200,
                Height = 300,
                Content = stackPanel
            };

            //Act
            //-dragn text block to overall panel containing other list
            //-trip moveitemtoTaskList
            window.Show();

            //Assert
            //--assert that ready list ui and list contains added item
            //--assert that backlog ui and list does not have the added item
            var findStackPanel = window.FindControl<StackPanel>;
            Assert.NotNull(findStackPanel);
        }

        [AvaloniaFact]
        public void ItemsShouldDragBetweenControls()
        {
            //Arrange
            //start simple: window, two boxes, text block in each box, the test is to drag one to the other to begin with
            // => TO HELP WITH TESTING: need a general WPF reference since Avaolinua builds off of that: use these when creating the code for these tests
            //use unit tests => solve simpler problems => build on top of that
            //the test is: can I drag an item from an Items control to another, and will it update the lists accordingly?
            //create itemcontrols, create your lists, add them to the controls, then put them in a box, build, verify
            //then set up a drag function to test

            StackPanel stackPanel = new StackPanel();
            var BacklogItemsControl = new ItemsControl();
            var ReadyItemsControl = new ItemsControl();
            List<TextBlock> itemsOne = new List<TextBlock>
            {
                new TextBlock { Text = "Item 1.1" },
                new TextBlock { Text = "Item 1.2" },
                new TextBlock { Text = "Item 1.3" }
            };
            List<TextBlock> itemsTwo = new List<TextBlock>
            {
                new TextBlock { Text = "Item 2.1" },
                new TextBlock { Text = "Item 2.2" },
                new TextBlock { Text = "Item 2.3" }
            };
            BacklogItemsControl.ItemsSource = itemsOne;
            ReadyItemsControl.ItemsSource = itemsTwo;

            stackPanel.Children.Add(BacklogItemsControl);
            stackPanel.Children.Add(ReadyItemsControl);

            var window = new Window
            {
                Width = 200,
                Height = 300,
                Content = stackPanel
            };

            //Act
            window.Show();
            //mouse down on item 2.1
            //drag it to itemsOne
            //release

            //Assert
            //--assert that ready list ui and list contains added item
            //--assert that backlog ui and list does not have the added item
            var findStackPanel = window.FindControl<StackPanel>;
            Assert.NotNull(findStackPanel);
        }
    }
}