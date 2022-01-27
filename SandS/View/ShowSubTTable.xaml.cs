using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SandS.Model;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для ShowSubTTable.xaml
    /// </summary>
    public partial class ShowSubTTable : UserControl
    {
        public ShowSubTTable()
        {
            InitializeComponent();
        }

        public int IdGroup { get; set; }
        public BindingList<SubTTable> SubTTables { get; set; }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsEnabled == false) return;
            SubTtablesGrid.ItemsSource = SubTTables;
        }
    }
}