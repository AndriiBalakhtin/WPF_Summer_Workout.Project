using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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

        private void databaseDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor" || currentUserData.Role == "Athlete"))
            {
                if (e.Row.Item is DataRowView rowView)
                {
                    DataRow selectedRow = rowView.Row;
                    string rowId = selectedRow["Id"].ToString();

                    string category = Convert.IsDBNull(selectedRow["Category"]) ? string.Empty : selectedRow["Category"].ToString();
                    int difficulty = Convert.IsDBNull(selectedRow["Difficulty"]) ? 0 : Convert.ToInt32(selectedRow["Difficulty"]);
                    string description = Convert.IsDBNull(selectedRow["Description"]) ? string.Empty : selectedRow["Description"].ToString();

                    var editorWindow = new Editor(
                        Convert.IsDBNull(selectedRow["Force"]) ? string.Empty : selectedRow["Force"].ToString(),
                        Convert.IsDBNull(selectedRow["1st"]) ? string.Empty : selectedRow["1st"].ToString(),
                        Convert.IsDBNull(selectedRow["Weight"]) ? string.Empty : selectedRow["Weight"].ToString(),
                        Convert.IsDBNull(selectedRow["2nd"]) ? string.Empty : selectedRow["2nd"].ToString(),
                        Convert.IsDBNull(selectedRow["Goal"]) ? string.Empty : selectedRow["Goal"].ToString(),
                        Convert.IsDBNull(selectedRow["3rd"]) ? string.Empty : selectedRow["3rd"].ToString(),
                        rowId,
                        category,
                        difficulty,
                        description
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

        private void RefreshLayout()
        {
            forceTextBox.Text       = "Enter - force";
            repeate_1stTextBox.Text = "Enter - repeate 1st";
            weightTextBox.Text      = "Enter - weight";
            repeate_2ndTextBox.Text = "Enter - repeate 2nd";
            goalTextBox.Text        = "Enter - goal";
            repeate_3rdTextBox.Text = "Enter - repeate 3rd";
            descriptionTextBox.Text = "Enter - description";
            difficultySlider.Value  = 0;
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

                    if(forceTextBox.Text == "Enter - force" || repeate_1stTextBox.Text == "Enter - repeate 1st" ||
                       weightTextBox.Text == "Enter - weight" || repeate_2ndTextBox.Text == "Enter - repeate 2nd" ||
                       goalTextBox.Text == "Enter - goal" || repeate_3rdTextBox.Text == "Enter - repeate 3rd" ||
                       descriptionTextBox.Text == "Enter - description")
                    {
                        MessageBox.Show("Fill all data in textboxes for insert");
                        return;
                    }

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

                    RefreshLayout();
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
                MessageBox.Show("You do not have permission to add this.",
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void LoadOverlay()
        {
            databaseDataGrid.ItemsSource = DataBase.GetUserData().DefaultView;
        }

        private void forceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (forceTextBox.Text == "Enter - force")
            {
                forceTextBox.Text       = "";
                forceTextBox.Foreground = Brushes.Black;
            }
        }

        private void forceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (forceTextBox.Text == "")
            {
                forceTextBox.Text       = "Enter - force";
                forceTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
            }
        }

        private void repeate_1stTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_1stTextBox.Text == "Enter - repeate 1st")
            {
                repeate_1stTextBox.Text          = "";
                repeate_1stTextBox.Foreground    = Brushes.Black;
                repeate_1stTextBox.TextAlignment = TextAlignment.Center;
            }
        }

        private void repeate_1stTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_1stTextBox.Text == "")
            {
                repeate_1stTextBox.Text          = "Enter - repeate 1st";
                repeate_1stTextBox.Foreground    = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
                repeate_1stTextBox.TextAlignment = TextAlignment.Left;
            }
        }

        private void weightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (weightTextBox.Text == "Enter - weight")
            {
                weightTextBox.Text       = "";
                weightTextBox.Foreground = Brushes.Black;
            }
        }

        private void weightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (weightTextBox.Text == "")
            {
                weightTextBox.Text       = "Enter - weight";
                weightTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
            }
        }

        private void repeate_2ndTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_2ndTextBox.Text == "Enter - repeate 2nd")
            {
                repeate_2ndTextBox.Text          = "";
                repeate_2ndTextBox.Foreground    = Brushes.Black;
                repeate_2ndTextBox.TextAlignment = TextAlignment.Center;
            }
        }

        private void repeate_2ndTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_2ndTextBox.Text == "")
            {
                repeate_2ndTextBox.Text          = "Enter - repeate 2nd";
                repeate_2ndTextBox.Foreground    = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
                repeate_2ndTextBox.TextAlignment = TextAlignment.Left;
            }
        }

        private void goalTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (goalTextBox.Text == "Enter - goal")
            {
                goalTextBox.Text       = "";
                goalTextBox.Foreground = Brushes.Black;
            }
        }

        private void goalTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (goalTextBox.Text == "")
            {
                goalTextBox.Text       = "Enter - goal";
                goalTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
            }
        }

        private void repeate_3rdTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_3rdTextBox.Text == "Enter - repeate 3rd")
            {
                repeate_3rdTextBox.Text          = "";
                repeate_3rdTextBox.Foreground    = Brushes.Black;
                repeate_3rdTextBox.TextAlignment = TextAlignment.Center;
            }
        }

        private void repeate_3rdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (repeate_3rdTextBox.Text == "")
            {
                repeate_3rdTextBox.Text          = "Enter - repeate 3rd";
                repeate_3rdTextBox.Foreground    = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
                repeate_3rdTextBox.TextAlignment = TextAlignment.Left;
            }
        }

        private void descriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (descriptionTextBox.Text == "Enter - description")
            {
                descriptionTextBox.Text       = "";
                descriptionTextBox.Foreground = Brushes.Black;
            }
        }

        private void descriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (descriptionTextBox.Text == "")
            {
                descriptionTextBox.Text       = "Enter - description";
                descriptionTextBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 123, 121, 121));
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
    }
}