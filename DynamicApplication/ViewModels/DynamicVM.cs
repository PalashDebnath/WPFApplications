using DynamicApplication.Commands;
using DynamicApplication.Helpers;
using DynamicApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DynamicApplication.ViewModels
{
    public class DynamicVM : INotifyPropertyChanged
    {
        public string CopyRight { get; set; } = "Copyright @" + DateTime.Now.Year + " Palash Debnath";

        public int Default { get; set; } = -1;

        public ObservableCollection<EntityRecord> EntityRecords { get; private set; }

        public EntityRecord SelectedEntityRecord { get; set; }

        public ExitCommand ExitCommand { get; set; }

        public AddEntityCommand AddEntityCommand { get; set; }

        public OpenDialogCommand OpenDialogCommand { get; set; }

        public AddAttributeCommand AddAttributeCommand { get; set; }

        private string _entityName;

        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; OnPropertyChanged("EntityName"); }
        }

        private string _attributeValue;

        public string AttributeValue
        {
            get { return _attributeValue; }
            set { _attributeValue = value; OnPropertyChanged("AttributeValue"); }
        }

        private string _attributeName;

        public string AttributeName
        {
            get { return _attributeName; }
            set { _attributeName = value; OnPropertyChanged("AttributeName"); }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

        public DynamicVM()
        {
            ExitCommand = new ExitCommand(this);
            AddEntityCommand = new AddEntityCommand(this);
            OpenDialogCommand = new OpenDialogCommand(this);
            AddAttributeCommand = new AddAttributeCommand(this);
            EntityRecords = new ObservableCollection<EntityRecord>();
            InItEntityRecords();
        }

        private void InItEntityRecords()
        {
            List<Entity> entities = SQLiteHelper.Read<Entity>();
            foreach (Entity e in entities)
            {
                SelectedEntityRecord = new EntityRecord() { Entity = e, EntityAttributes = new ObservableCollection<EntityAttribute>() };
                EntityRecords.Add(SelectedEntityRecord);
                ReadEntityAttributes(e.Id);
            }
        }

        public void AddEntity()
        {
            Random randomNumber = new Random();
            Entity entity = new Entity()
            {
                Name = EntityName,
                xAxis = randomNumber.Next((int)Application.Current.MainWindow.ActualWidth - 100),
                yAxis = randomNumber.Next((int)Application.Current.MainWindow.ActualWidth - 100)
            };
            entity.Id = SQLiteHelper.Insert(entity);
            EntityRecords.Add(new EntityRecord() { Entity = entity, EntityAttributes = new ObservableCollection<EntityAttribute>() });            
            Status = "Entity successfully inserted!";
        }

        public void AddAttribute(int id)
        {
            EntityAttribute attribute = new EntityAttribute()
            {
                EntityId = id,
                Name = AttributeName,
                Value = AttributeValue
            };
            AttributeName = string.Empty;
            AttributeValue = string.Empty;
            SQLiteHelper.Insert(attribute);
            ReadEntityAttributes(id);
            Status = "Attribute successfully inserted!";
        }

        private void ReadEntityAttributes(int id)
        {
            List<EntityAttribute> attributes = SQLiteHelper.Read<EntityAttribute>().Where(item => item.EntityId == id).ToList();
            SelectedEntityRecord.EntityAttributes.Clear();
            foreach (EntityAttribute a in attributes)
            {
                SelectedEntityRecord.EntityAttributes.Add(a);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
