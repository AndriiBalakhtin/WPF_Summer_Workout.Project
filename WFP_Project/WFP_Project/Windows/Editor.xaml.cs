﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class Editor : Window
    {
        private string _rowId;

        public Editor(
     string force,
     string repeate1st,
     string weight,
     string repeate2nd,
     string goal,
     string repeate3rd,
     string rowId,
     string category,
     int difficulty,
     string description
 )
        {
            InitializeComponent();

            forceTextBox.Text = force;
            repeate_1stTextBox.Text = repeate1st;
            weightTextBox.Text = weight;
            repeate_2ndTextBox.Text = repeate2nd;
            goalTextBox.Text = goal;
            repeate_3rdTextBox.Text = repeate3rd;
            descriptionTextBox.Text = description;

            categoryComboBox.SelectedItem = categoryComboBox.Items
                .OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == category);

            difficultySlider.Value = difficulty;

            _rowId = rowId;
            selectedRowTextBlock.Text = $"Selected Row: {rowId}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(forceTextBox.Text) ||
                string.IsNullOrEmpty(weightTextBox.Text) ||
                string.IsNullOrEmpty(goalTextBox.Text))
            {
                MessageBox.Show("Fill in all the rows from the textboxes.",
                                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to update this record?",
                "Confirm Update",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int difficulty = (int)difficultySlider.Value;
                    string description = descriptionTextBox.Text;
                    string category = (categoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

                    DataBase.UpdateUserData(
                        _rowId,
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

                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating data: {ex.Message}",
                                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DataBase.DeleteUserData(_rowId);
                    MessageBox.Show("Record deleted successfully.",
                                    "Delete", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting data: {ex.Message}",
                                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
