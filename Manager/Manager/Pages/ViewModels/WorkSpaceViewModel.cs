﻿using System.Windows;
using Manager.Service;
using Manager.Objects;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace Manager.Pages.ViewModels
{
    public class WorkSpaceViewModel : PageViewModel
    {
        public ObservableCollection<IObjectModel> Models
        {
            get
            {
                ObservableCollection<IObjectModel> models = new ObservableCollection<IObjectModel>();

                foreach (IObjectSource objectSource in ObjectSources)
                    foreach (IObjectModel model in objectSource.GetObjects())
                    {
                        models.Add(model);
                    }

                return models;
            }
        }

        public ObservableCollection<IObjectSource> ObjectSources
        {
            get;
            set;
        }

        public ICommand AddDataSourceCommand
        {
            get;
            set;
        }

        public WorkSpaceViewModel()
        {
            ObjectSources = new ObservableCollection<IObjectSource>();
            ObjectSources.CollectionChanged += (send, e) =>
            {
                PropertyChange(nameof(ObjectSources));
                PropertyChange(nameof(Models));
            };

            Folder folder = new Folder("example", @"C:\dir", null);

            for (int i = 0; i < 1000; i++)
            {
                string fictivePath = $"exmple {i}.fbx";
                
                folder.AddObject(fictivePath, ObjectModelFactory.GetObject(fictivePath));
            }

            ObjectSources.Add(folder);

            RelayCommand<object> addDataSourceCommand = new RelayCommand<object>();
            RelayCommand<IObjectSource> selectObjectSourceCommand = new RelayCommand<IObjectSource>();

            addDataSourceCommand.RegisterCallback(AddDataSource);

            AddDataSourceCommand = addDataSourceCommand;
        }

        public override void OnDropDown(DragEventArgs e)
        {
            if (ObjectSources.Count == 0)
            {
                return;
            }

            e.Effects = DragDropEffects.Copy;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            AddModelDialog modelDialog = new AddModelDialog(ObjectSources, files);
            modelDialog.ShowDialog();

            PropertyChange(nameof(Models));
        }

        private void AddDataSource()
        {
            AddDatasourceDialog datasourceDialog = new AddDatasourceDialog(null);

            if (datasourceDialog.ShowDialog() == true)
            {
                ObjectSources.Add(datasourceDialog.Source);
            }
        }
    }
}