using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ItinerariApp.DataAccess;

namespace ItinerariApp.Forms
{
    public partial class UserDashboardForm : Form
    {
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnViewFavorites;
        private Button btnExit;
        private ListView lvItineraries;

        private void InitializeComponent()
        {
            this.lvItineraries = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnViewFavorites = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvItineraries
            // 
            this.lvItineraries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvItineraries.FullRowSelect = true;
            this.lvItineraries.GridLines = true;
            this.lvItineraries.HideSelection = false;
            this.lvItineraries.Location = new System.Drawing.Point(21, 88);
            this.lvItineraries.Name = "lvItineraries";
            this.lvItineraries.Size = new System.Drawing.Size(256, 314);
            this.lvItineraries.TabIndex = 0;
            this.lvItineraries.UseCompatibleStateImageBehavior = false;
            this.lvItineraries.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 139;
            // 
            // btnViewFavorites
            // 
            this.btnViewFavorites.Location = new System.Drawing.Point(21, 59);
            this.btnViewFavorites.Name = "btnViewFavorites";
            this.btnViewFavorites.Size = new System.Drawing.Size(127, 23);
            this.btnViewFavorites.TabIndex = 1;
            this.btnViewFavorites.Text = "View Favorites";
            this.btnViewFavorites.UseVisualStyleBackColor = true;
            this.btnViewFavorites.Click += new System.EventHandler(this.btnViewFavorites_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(154, 59);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UserDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(622, 425);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewFavorites);
            this.Controls.Add(this.lvItineraries);
            this.Name = "UserDashboardForm";
            this.ResumeLayout(false);

        }

        public UserDashboardForm()
        {
            InitializeComponent();
            LoadItineraries();
        }

        private void LoadItineraries()
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT title, description FROM gsv_itineraries WHERE is_active = 1";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader.GetString("title");
                                string description = reader.GetString("description");

                                var listItem = new ListViewItem(title);
                                listItem.SubItems.Add(description);
                                lvItineraries.Items.Add(listItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading itineraries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewFavorites_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
