using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ItinerariApp.DataAccess;

namespace ItinerariApp.Forms
{
    public partial class ViewItineraryForm : Form
    {
        private Label lblTitle;
        private Label lblDescription;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnClose;
        private ListView lvStages;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lvStages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(316, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(333, 95);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "label1";
            // 
            // lvStages
            // 
            this.lvStages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStages.HideSelection = false;
            this.lvStages.Location = new System.Drawing.Point(55, 137);
            this.lvStages.Name = "lvStages";
            this.lvStages.Size = new System.Drawing.Size(617, 350);
            this.lvStages.TabIndex = 2;
            this.lvStages.UseCompatibleStateImageBehavior = false;
            this.lvStages.View = System.Windows.Forms.View.Details;
            this.lvStages.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stage Order";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stage Title";
            this.columnHeader2.Width = 215;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stage Description";
            this.columnHeader3.Width = 308;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(321, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewItineraryForm
            // 
            this.ClientSize = new System.Drawing.Size(740, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvStages);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "ViewItineraryForm";
            this.Load += new System.EventHandler(this.ViewItineraryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private readonly int _itineraryId;

        public ViewItineraryForm(int itineraryId)
        {
            InitializeComponent();
            _itineraryId = itineraryId;
            LoadItineraryDetails();
            LoadStages();
        }

        private void LoadItineraryDetails()
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT title, description FROM gsv_itineraries WHERE itinerary_id = @itineraryId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@itineraryId", _itineraryId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTitle.Text = reader.GetString("title");
                                lblDescription.Text = reader.GetString("description");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading itinerary details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStages()
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT stage_order, title, description 
                        FROM gsv_stages 
                        WHERE itinerary_id = @itineraryId 
                        ORDER BY stage_order";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@itineraryId", _itineraryId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            lvStages.Items.Clear();
                            while (reader.Read())
                            {
                                var listItem = new ListViewItem(reader.GetInt32("stage_order").ToString());
                                listItem.SubItems.Add(reader.GetString("title"));
                                listItem.SubItems.Add(reader.GetString("description"));
                                lvStages.Items.Add(listItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewItineraryForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

