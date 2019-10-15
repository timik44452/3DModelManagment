using System;
using MiddlewareAPI;
using ModelImporter;
using Manager.Service;
using System.Windows;
using System.Windows.Input;
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

        public ICommand SelectModelCommand
        {
            get;
            set;
        }

        private FileSender fileSender;

        public WorkSpaceViewModel()
        {
            fileSender = new FileSender(new ManagerLogger());
            fileSender.Connect("127.0.0.1", 67);

            var selectModelCommand = new RelayCommand<Model>();
            selectModelCommand.RegisterCallback(x => OnSelectModel(x as Model));
            SelectModelCommand = selectModelCommand;

            Models = new ObservableCollection<Model>();
            Models.CollectionChanged += (sender, e) => { PropertyChange(nameof(Models)); };

            
            Models.Add(new Model("3D Example 0"));
            Models.Add(new Model("Human"));
            Models.Add(new Model("Компрессор модель 2"));
            Models.Add(new Model("Хрен пойми что за модель"));
        }

        public override void OnDropDown(DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach(string file in files)
            {
                if (ModelImporter.ModelImporter.IsModel(file))
                {
                    Model3D model3D = ModelImporter.ModelImporter.ImportModel(file, 
                        ModelParserFactory.CreateParser(file));

                    Model model = new Model(model3D);
                    model.Date = DateTime.Now;

                    Models.Add(model);

                    fileSender.Send(file);
                }
            }
        }

        private void OnSelectModel(Model model)
        {

        }

    }
}