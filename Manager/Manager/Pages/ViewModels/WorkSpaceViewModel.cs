using System;
using System.Collections.ObjectModel;

namespace Manager.Pages.ViewModels
{
    public class WorkSpaceViewModel : PageViewModel
    {
        public ObservableCollection<Model> Models
        {
            get;
            set;
        }

        public WorkSpaceViewModel()
        {
            Models = new ObservableCollection<Model>();
            Models.CollectionChanged += (sender, e) => { PropertyChange(nameof(Models)); };

            
            Models.Add(new Model("3D Example 0"));
            Models.Add(new Model("Human"));
            Models.Add(new Model("Компрессор модель 2"));
            Models.Add(new Model("Хрен пойми что за модель"));
        }
    }
}
