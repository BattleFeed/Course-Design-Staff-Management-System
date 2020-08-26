using MySql.Data.MySqlClient;
using PersonnelManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Controls;

namespace PersonnelManagementSystem.ViewModels.PageViewModels
{
    abstract class PageViewModel<T> : NotificationObject
    {
        protected MySqlConnection connection;
        protected MySQLService service;
        protected string tableName;

        public DelegateCommand SelectCommand { get; set; }
        public DelegateCommand SubmitCommand { get; set; }

        protected string searchField;
        public string SearchField
        {
            get { return searchField; }
            set
            {
                searchField = value;
                this.RaisePropertyChanged("SearchField");
            }
        }

        protected ObservableCollection<T> table;
        public ObservableCollection<T> Table
        {
            get { return table; }
            set
            {
                table = value;
                this.RaisePropertyChanged("Table");
            }
        }

        //Initialize
        public PageViewModel()
        {
            this.SelectCommand = new DelegateCommand(new Action(SelectExecute));
            this.SubmitCommand = new DelegateCommand(new Action(SubmitExecute));
            this.connection = new MySqlConnection(
                "server=localhost;User Id=admin;password=admin;Database=hr");
            this.service = new MySQLService();

            this.editedIndexs = new List<int>();
            this.statements = new List<string>();
            SelectExecute();
        }

        protected int tableLastIndex;
        protected int count;
        protected List<int> editedIndexs;
        public abstract void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e);

        protected T item;
        protected string statement;
        protected List<string> statements;
        public abstract void SubmitExecute();
        public abstract void SelectExecute();
    }
}
