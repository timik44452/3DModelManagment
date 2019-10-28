using System.IO;
using ServiceAPI;
using System.Security;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Collections.Generic;

namespace Manager.Objects
{
    public class Folder : IObjectSource, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAvailable
        {
            get => isAvailable;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChangedInvoke(nameof(Name));
            }
        }

        public string Source
        {
            get => source;
            set
            {
                source = value;
                PropertyChangedInvoke(nameof(Name));
            }
        }

        public string ItemIcon
        {
            get => itemIcon;
            set
            {
                if (itemIcon != value)
                {
                    itemIcon = value;
                    PropertyChangedInvoke(nameof(ItemIcon));
                }
            }
        }

        private const string FOLDER_ICON = "/Manager;component/Resources/folder.png";
        private const string DELETD_FOLDER_ICON = "/Manager;component/Resources/deletedFolder.png";

        private string name;
        private string source;
        private string itemIcon;
        private bool isAvailable;

        private List<IObjectModel> objects = new List<IObjectModel>();

        public Folder(string name, string source, ILogger logger)
        {
            this.name = name;
            this.source = source;

            ItemIcon = DELETD_FOLDER_ICON;

            Timer.RegisterNewAction(new TimerTask(1500, CheckDirectory, loop: true));
        }

        public void AddObject(string FilePath, IObjectModel objectModel)
        {
            objects.Add(objectModel);
        }

        public List<IObjectModel> GetObjects()
        {
            return objects;
        }

        private void PropertyChangedInvoke(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }

        private void CheckDirectory()
        {
            bool exists = IsAccessDirectory(source);

            if (isAvailable != exists)
            {
                isAvailable = exists;
                PropertyChangedInvoke(nameof(IsAvailable));
            }

            ItemIcon = IsAvailable ? FOLDER_ICON : DELETD_FOLDER_ICON;
        }

        private bool IsAccessDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }

            bool canWrite = false;
            bool canRead = false;

            foreach (FileSystemAccessRule rule in Directory.GetAccessControl(path).GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if ((rule.FileSystemRights & FileSystemRights.Write) == FileSystemRights.Write)
                    canWrite = true;
                if ((rule.FileSystemRights & FileSystemRights.Read) == FileSystemRights.Read)
                    canRead = true;
            }

            return canWrite && canRead;
        }
    }
}
