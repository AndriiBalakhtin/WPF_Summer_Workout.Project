using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class ArchiveWindow : Window
    {
        private string archiveRootPath = @"C:\Reposotory\C#\Summer_product.api\Archive";

        public ArchiveWindow()
        {
            InitializeComponent();
            LoadArchiveTree();
        }

        private void Windows_Load(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {
            string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name:", "Create Folder", "NewFolder");

            if (!string.IsNullOrEmpty(folderName))
            {
                string folderPath = Path.Combine(archiveRootPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    LoadArchiveTree();
                    MessageBox.Show("Folder created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Folder already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            if (archiveTreeView.SelectedItem is TreeViewItem selectedFolder)
            {
                string folderPath = selectedFolder.Tag.ToString();
                DataTable data = DataBase.GetUserData();

                string filePath = Path.Combine(folderPath, $"UserData_{DateTime.Now:yyyyMMddHHmmss}.csv");
                SaveDataToCsv(filePath, data);
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a folder to save data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadArchiveTree()
        {
            archiveTreeView.Items.Clear();
            if (!Directory.Exists(archiveRootPath))
            {
                Directory.CreateDirectory(archiveRootPath);
            }

            DirectoryInfo rootDirectory = new DirectoryInfo(archiveRootPath);
            LoadFolder(rootDirectory, null);
        }

        private void LoadFolder(DirectoryInfo directoryInfo, TreeViewItem parentItem)
        {
            TreeViewItem newItem = new TreeViewItem()
            {
                Header = directoryInfo.Name,
                Tag = directoryInfo.FullName
            };

            if (parentItem == null)
            {
                archiveTreeView.Items.Add(newItem);
            }
            else
            {
                parentItem.Items.Add(newItem);
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                LoadFolder(directory, newItem);
            }
        }

        private void SaveDataToCsv(string filePath, DataTable dataTable)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Write column headers
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write(dataTable.Columns[i]);

                    if (i < dataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        sw.Write(row[i]);

                        if (i < dataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
