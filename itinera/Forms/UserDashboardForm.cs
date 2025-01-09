using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ItinerariApp.DataAccess;
using ItinerariApp.Models;

namespace ItinerariApp.Forms
{
    public partial class UserDashboardForm : Form
    {
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnViewFavorites;
        private Button btnExit;
        private Label label1;
        private Button btnViewAllItineraries;
        private Button btnAddToFavorites;
        private Button btnRemoveFromFavorites;
        private TextBox txtSearch;
        private ComboBox cmbSearchBy;
        private Button btnSearch;
        private Label label2;
        private Button btnViewItinerary;
        private ListView lvItineraries;

        private void InitializeComponent()
        {
            this.lvItineraries = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnViewFavorites = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAllItineraries = new System.Windows.Forms.Button();
            this.btnAddToFavorites = new System.Windows.Forms.Button();
            this.btnRemoveFromFavorites = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewItinerary = new System.Windows.Forms.Button();
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
            this.lvItineraries.Location = new System.Drawing.Point(21, 105);
            this.lvItineraries.Name = "lvItineraries";
            this.lvItineraries.Size = new System.Drawing.Size(457, 297);
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
            this.btnViewFavorites.Location = new System.Drawing.Point(484, 263);
            this.btnViewFavorites.Name = "btnViewFavorites";
            this.btnViewFavorites.Size = new System.Drawing.Size(109, 23);
            this.btnViewFavorites.TabIndex = 1;
            this.btnViewFavorites.Text = "View Favorites";
            this.btnViewFavorites.UseVisualStyleBackColor = true;
            this.btnViewFavorites.Click += new System.EventHandler(this.btnViewFavorites_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(484, 379);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Dashboard";
            // 
            // btnViewAllItineraries
            // 
            this.btnViewAllItineraries.Location = new System.Drawing.Point(484, 292);
            this.btnViewAllItineraries.Name = "btnViewAllItineraries";
            this.btnViewAllItineraries.Size = new System.Drawing.Size(109, 23);
            this.btnViewAllItineraries.TabIndex = 4;
            this.btnViewAllItineraries.Text = "View All";
            this.btnViewAllItineraries.UseVisualStyleBackColor = true;
            this.btnViewAllItineraries.Click += new System.EventHandler(this.btnViewAllItineraries_Click);
            // 
            // btnAddToFavorites
            // 
            this.btnAddToFavorites.Location = new System.Drawing.Point(484, 321);
            this.btnAddToFavorites.Name = "btnAddToFavorites";
            this.btnAddToFavorites.Size = new System.Drawing.Size(109, 23);
            this.btnAddToFavorites.TabIndex = 5;
            this.btnAddToFavorites.Text = "Add To Fav";
            this.btnAddToFavorites.UseVisualStyleBackColor = true;
            this.btnAddToFavorites.Click += new System.EventHandler(this.btnAddToFavorites_Click);
            // 
            // btnRemoveFromFavorites
            // 
            this.btnRemoveFromFavorites.Location = new System.Drawing.Point(484, 350);
            this.btnRemoveFromFavorites.Name = "btnRemoveFromFavorites";
            this.btnRemoveFromFavorites.Size = new System.Drawing.Size(109, 23);
            this.btnRemoveFromFavorites.TabIndex = 6;
            this.btnRemoveFromFavorites.Text = "Remove From Fav";
            this.btnRemoveFromFavorites.UseVisualStyleBackColor = true;
            this.btnRemoveFromFavorites.Click += new System.EventHandler(this.btnRemoveFromFavorites_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(23, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "Title",
            "Location",
            "Stage",
            "Tag"});
            this.cmbSearchBy.Location = new System.Drawing.Point(130, 78);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(71, 21);
            this.cmbSearchBy.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Cerca";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search";
            // 
            // btnViewItinerary
            // 
            this.btnViewItinerary.Location = new System.Drawing.Point(484, 234);
            this.btnViewItinerary.Name = "btnViewItinerary";
            this.btnViewItinerary.Size = new System.Drawing.Size(109, 23);
            this.btnViewItinerary.TabIndex = 14;
            this.btnViewItinerary.Text = "View Itineraries";
            this.btnViewItinerary.UseVisualStyleBackColor = true;
            this.btnViewItinerary.Click += new System.EventHandler(this.btnViewItinerary_Click);
            // 
            // UserDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(622, 425);
            this.Controls.Add(this.btnViewItinerary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRemoveFromFavorites);
            this.Controls.Add(this.btnAddToFavorites);
            this.Controls.Add(this.btnViewAllItineraries);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewFavorites);
            this.Controls.Add(this.lvItineraries);
            this.Name = "UserDashboardForm";
            this.Load += new System.EventHandler(this.UserDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public UserDashboardForm()
        {
            InitializeComponent();
            LoadItineraries(false);
        }

        private void LoadItineraries(bool showFavorites)
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string query;
                    if (showFavorites)
                    {
                        query = @"SELECT gsv_itineraries.itinerary_id, gsv_itineraries.title, gsv_itineraries.description 
                          FROM gsv_favorites 
                          INNER JOIN gsv_itineraries ON gsv_favorites.itinerary_id = gsv_itineraries.itinerary_id
                          WHERE gsv_favorites.user_id = @userId";
                    }
                    else
                    {
                        query = @"SELECT itinerary_id, title, description FROM gsv_itineraries WHERE is_active = 1";
                    }

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        if (showFavorites)
                        {
                            cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            lvItineraries.Items.Clear();
                            while (reader.Read())
                            {
                                var listItem = new ListViewItem(reader.GetInt32("itinerary_id").ToString());
                                listItem.SubItems.Add(reader.GetString("title"));
                                listItem.SubItems.Add(reader.GetString("description"));
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

        private void SearchItineraries(string query, string searchBy)
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string sqlQuery = "";

                    switch (searchBy)
                    {
                        case "Title":
                            sqlQuery = "SELECT itinerary_id, title, description FROM gsv_itineraries WHERE title LIKE @query AND is_active = 1";
                            break;
                        case "Location":
                            sqlQuery = @"SELECT i.itinerary_id, i.title, i.description 
                                 FROM gsv_itineraries i
                                 INNER JOIN gsv_locations l ON i.location_id = l.location_id
                                 WHERE l.name LIKE @query AND i.is_active = 1";
                            break;
                        case "Stage":
                            sqlQuery = @"SELECT DISTINCT i.itinerary_id, i.title, i.description 
                                 FROM gsv_itineraries i
                                 INNER JOIN gsv_stages s ON i.itinerary_id = s.itinerary_id
                                 WHERE s.title LIKE @query AND i.is_active = 1";
                            break;
                        case "Tag":
                            sqlQuery = @"SELECT DISTINCT i.itinerary_id, i.title, i.description 
                                 FROM gsv_itineraries i
                                 INNER JOIN gsv_itinerary_tags it ON i.itinerary_id = it.itinerary_id
                                 INNER JOIN gsv_tags t ON it.tag_id = t.tag_id
                                 WHERE t.name LIKE @query AND i.is_active = 1";
                            break;
                        default:
                            MessageBox.Show("Please select a valid search category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    using (var cmd = new MySqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@query", $"%{query}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            lvItineraries.Items.Clear();
                            while (reader.Read())
                            {
                                var listItem = new ListViewItem(reader.GetInt32("itinerary_id").ToString());
                                listItem.SubItems.Add(reader.GetString("title"));
                                listItem.SubItems.Add(reader.GetString("description"));
                                lvItineraries.Items.Add(listItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching itineraries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewFavorites_Click(object sender, EventArgs e)
        {
            LoadItineraries(true);
        }

        private void btnViewAllItineraries_Click(object sender, EventArgs e)
        {
            LoadItineraries(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            if (lvItineraries.SelectedItems.Count > 0)
            {
                string selectedItineraryId = lvItineraries.SelectedItems[0].Text;
                try
                {
                    using (var connection = Database.GetConnection())
                    {
                        connection.Open();
                        string query = @"INSERT INTO gsv_favorites (user_id, itinerary_id) VALUES (@userId, @itineraryId)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId); // Sostituisci con l'ID utente loggato
                            cmd.Parameters.AddWithValue("@itineraryId", selectedItineraryId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Itinerary added to favorites!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding to favorites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an itinerary to add to favorites.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveFromFavorites_Click(object sender, EventArgs e)
        {
            if (lvItineraries.SelectedItems.Count > 0)
            {
                string selectedItineraryId = lvItineraries.SelectedItems[0].Text;
                try
                {
                    using (var connection = Database.GetConnection())
                    {
                        connection.Open();
                        string query = @"DELETE FROM gsv_favorites WHERE user_id = @userId AND itinerary_id = @itineraryId";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", CurrentUser.UserId); // Sostituisci con l'ID utente loggato
                            cmd.Parameters.AddWithValue("@itineraryId", selectedItineraryId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Itinerary removed from favorites!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing from favorites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an itinerary to remove from favorites.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            string searchBy = cmbSearchBy.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(query) || string.IsNullOrEmpty(searchBy))
            {
                MessageBox.Show("Please enter a search query and select a search category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchItineraries(query, searchBy);
        }

        private void btnViewItinerary_Click(object sender, EventArgs e)
        {
            if (lvItineraries.SelectedItems.Count > 0)
            {
                int selectedItineraryId = int.Parse(lvItineraries.SelectedItems[0].Text);
                var viewItineraryForm = new ViewItineraryForm(selectedItineraryId);
                viewItineraryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an itinerary to view.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
