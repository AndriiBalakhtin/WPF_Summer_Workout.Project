using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class ControlWindow : Window
    {
        private UserData currentUserData;

        public ControlWindow()
        {
            InitializeComponent();
            currentUserData = SettingsManager.LoadUserData();
            LoadOverlay();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void ButtonGuiArchive_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor"))
            {
                GuiArchive guiArchive = new GuiArchive();
                guiArchive.Show();
            }
            else
            {
                MessageBox.Show("You do not have permission to archive this is",
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor" || currentUserData.Role == "Athlete"))
            {
                if (!string.IsNullOrEmpty(forceTextBox.Text) &&
                    !string.IsNullOrEmpty(weightTextBox.Text) &&
                    !string.IsNullOrEmpty(goalTextBox.Text) &&
                    !string.IsNullOrEmpty(descriptionTextBox.Text) &&
                    categoryComboBox.SelectedItem != null)
                {
                    int difficulty = (int)difficultySlider.Value;
                    string description = descriptionTextBox.Text;
                    string category = (categoryComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                    DataBase.InsertUserData(
                        forceTextBox.Text,
                        repeate_1stTextBox.Text,
                        weightTextBox.Text,
                        repeate_2ndTextBox.Text,
                        goalTextBox.Text,
                        repeate_3rdTextBox.Text,
                        difficulty,
                        description,
                        category
                    );

                    LoadOverlay();
                }
                else
                {
                    MessageBox.Show("Fill in all the rows from the textboxes.",
                                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to add this is.",
                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void databaseDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor" || currentUserData.Role == "Athlete"))
            {

                if (e.Row.Item is DataRowView rowView)
                {
                    DataRow selectedRow = rowView.Row;
                    string rowId = selectedRow["Id"].ToString();

                    var editorWindow = new Editor(
                        selectedRow["Force"].ToString(),
                        selectedRow["1st"].ToString(),
                        selectedRow["Weight"].ToString(),
                        selectedRow["2nd"].ToString(),
                        selectedRow["Goal"].ToString(),
                        selectedRow["3rd"].ToString(),
                        rowId
                    );

                    bool? result = editorWindow.ShowDialog();

                    if (result == true)
                    {
                        LoadOverlay();
                    }

                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("You do not have permission for this control.",
                                 "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void descriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string description = descriptionTextBox.Text;
        }

        private void difficultySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int difficulty = (int)difficultySlider.Value;
        }


        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedCategory = selectedItem.Content.ToString();
            }
        }

        private void NumbersOnlyTextboxes(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                e.Key == Key.Tab ||
                e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void LoadOverlay()
        {
            databaseDataGrid.ItemsSource = DataBase.GetUserData().DefaultView;
        }
    }
}