using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ItinerariApp.DataAccess;

namespace ItinerariApp.Forms
{
    public partial class EntityDashboardForm : Form
    {
        private ListView lvItineraries;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private Label label1;
        private Button btnEditItinerary;
        private Button btnDeleteItinerary;
        private Button btnViewStats;
        private Button btnAddItinerary;
        private Button btnExit;
        private ColumnHeader columnHeader2;

        private void InitializeComponent()
        {
            this.lvItineraries = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditItinerary = new System.Windows.Forms.Button();
            this.btnDeleteItinerary = new System.Windows.Forms.Button();
            this.btnViewStats = new System.Windows.Forms.Button();
            this.btnAddItinerary = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvItineraries
            // 
            this.lvItineraries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvItineraries.FullRowSelect = true;
            this.lvItineraries.GridLines = true;
            this.lvItineraries.HideSelection = false;
            this.lvItineraries.Location = new System.Drawing.Point(21, 87);
            this.lvItineraries.Name = "lvItineraries";
            this.lvItineraries.Size = new System.Drawing.Size(526, 314);
            this.lvItineraries.TabIndex = 4;
            this.lvItineraries.UseCompatibleStateImageBehavior = false;
            this.lvItineraries.View = System.Windows.Forms.View.Details;
            this.lvItineraries.SelectedIndexChanged += new System.EventHandler(this.lvItineraries_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Itinerary ID";
            this.columnHeader1.Width = 71;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 245;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ente Dashboard";
            // 
            // btnEditItinerary
            // 
            this.btnEditItinerary.Location = new System.Drawing.Point(154, 58);
            this.btnEditItinerary.Name = "btnEditItinerary";
            this.btnEditItinerary.Size = new System.Drawing.Size(127, 23);
            this.btnEditItinerary.TabIndex = 8;
            this.btnEditItinerary.Text = "Edit Itinerary";
            this.btnEditItinerary.UseVisualStyleBackColor = true;
            this.btnEditItinerary.Click += new System.EventHandler(this.btnEditItinerary_Click);
            // 
            // btnDeleteItinerary
            // 
            this.btnDeleteItinerary.Location = new System.Drawing.Point(287, 58);
            this.btnDeleteItinerary.Name = "btnDeleteItinerary";
            this.btnDeleteItinerary.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteItinerary.TabIndex = 9;
            this.btnDeleteItinerary.Text = "Delete Itinerary";
            this.btnDeleteItinerary.UseVisualStyleBackColor = true;
            this.btnDeleteItinerary.Click += new System.EventHandler(this.btnDeleteItinerary_Click);
            // 
            // btnViewStats
            // 
            this.btnViewStats.Location = new System.Drawing.Point(420, 58);
            this.btnViewStats.Name = "btnViewStats";
            this.btnViewStats.Size = new System.Drawing.Size(127, 23);
            this.btnViewStats.TabIndex = 10;
            this.btnViewStats.Text = "View Stats";
            this.btnViewStats.UseVisualStyleBackColor = true;
            this.btnViewStats.Click += new System.EventHandler(this.btnViewStats_Click);
            // 
            // btnAddItinerary
            // 
            this.btnAddItinerary.Location = new System.Drawing.Point(21, 58);
            this.btnAddItinerary.Name = "btnAddItinerary";
            this.btnAddItinerary.Size = new System.Drawing.Size(127, 23);
            this.btnAddItinerary.TabIndex = 11;
            this.btnAddItinerary.Text = "Add Itinerary";
            this.btnAddItinerary.UseVisualStyleBackColor = true;
            this.btnAddItinerary.Click += new System.EventHandler(this.btnAddItinerary_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(554, 377);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // EntityDashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(614, 413);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddItinerary);
            this.Controls.Add(this.btnViewStats);
            this.Controls.Add(this.btnDeleteItinerary);
            this.Controls.Add(this.btnEditItinerary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvItineraries);
            this.Name = "EntityDashboardForm";
            this.Load += new System.EventHandler(this.EntityDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public EntityDashboardForm()
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
                    string query = "SELECT itinerary_id, title, description FROM gsv_itineraries";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
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

        private void btnAddItinerary_Click(object sender, EventArgs e)
        {
            var addItineraryForm = new AddItineraryForm();
            addItineraryForm.FormClosed += (s, args) => LoadItineraries(); // Ricarica la lista degli itinerari
            addItineraryForm.ShowDialog();
        }

        private void btnEditItinerary_Click(object sender, EventArgs e)
        {
            if (lvItineraries.SelectedItems.Count > 0)
            {
                int selectedItineraryId = int.Parse(lvItineraries.SelectedItems[0].Text);
                var editItineraryForm = new EditItineraryForm(selectedItineraryId);
                editItineraryForm.FormClosed += (s, args) => LoadItineraries(); // Ricarica gli itinerari
                editItineraryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an itinerary to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteItinerary_Click(object sender, EventArgs e)
        {
            if (lvItineraries.SelectedItems.Count > 0)
            {
                int selectedItineraryId = int.Parse(lvItineraries.SelectedItems[0].Text);

                var result = MessageBox.Show("Are you sure you want to delete this itinerary?", "Confirmation",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var connection = Database.GetConnection())
                        {
                            connection.Open();
                            string query = @"DELETE FROM gsv_itineraries WHERE itinerary_id = @itineraryId";
                            using (var cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@itineraryId", selectedItineraryId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Itinerary deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItineraries();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting itinerary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an itinerary to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            var statsForm = new ViewStatsForm();
            statsForm.ShowDialog();
        }

        private void lvItineraries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EntityDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
