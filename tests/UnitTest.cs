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
        public void ShouldDragDropItem()
        {
            //Arrange
            //--set up: window, drop downs, text blocks with to-dos, items lists

            //Act
            //-dragn text block to overall panel containing other list
            //-trip moveitemtoTaskList

            //Assert
            //--assert that ready list ui and list contains added item
            //--assert that backlog ui and list does not have the added item
        }
    }
}