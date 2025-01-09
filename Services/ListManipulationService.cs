using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textban.Models;
using textban.ViewModels;

namespace textban.Services
{
    public class ListManipulationService
    {
        public void moveItemToTaskList(ToDoItemViewModel TaskItem, ObservableCollection<ToDoItemViewModel> AddList, ObservableCollection<ToDoItemViewModel> RemoveList)
        {
            //add TaskItem to ReadyItems
            AddList.Add(TaskItem);
            
            //remove same item from ToDoItems
            RemoveList.Remove(TaskItem);
        
        }
    }
}
