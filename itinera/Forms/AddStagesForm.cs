using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ItinerariApp.DataAccess;

namespace ItinerariApp.Forms
{
    public partial class AddStagesForm : Form
    {
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSaveStages;
        private Button btnAddStage;
        private TextBox txtStageDescription;
        private TextBox txtStageTitle;
        private NumericUpDown numStageOrder;

        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveStages = new System.Windows.Forms.Button();
            this.btnAddStage = new System.Windows.Forms.Button();
            this.txtStageDescription = new System.Windows.Forms.TextBox();
            this.txtStageTitle = new System.Windows.Forms.TextBox();
            this.numStageOrder = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numStageOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ordine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Titolo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Aggiungi Tappe";
            // 
            // btnSaveStages
            // 
            this.btnSaveStages.Location = new System.Drawing.Point(81, 282);
            this.btnSaveStages.Name = "btnSaveStages";
            this.btnSaveStages.Size = new System.Drawing.Size(121, 23);
            this.btnSaveStages.TabIndex = 13;
            this.btnSaveStages.Text = "Salva Tappe";
            this.btnSaveStages.UseVisualStyleBackColor = true;
            this.btnSaveStages.Click += new System.EventHandler(this.btnSaveStages_Click);
            // 
            // btnAddStage
            // 
            this.btnAddStage.Location = new System.Drawing.Point(81, 253);
            this.btnAddStage.Name = "btnAddStage";
            this.btnAddStage.Size = new System.Drawing.Size(121, 23);
            this.btnAddStage.TabIndex = 12;
            this.btnAddStage.Text = "Aggiungi";
            this.btnAddStage.UseVisualStyleBackColor = true;
            this.btnAddStage.Click += new System.EventHandler(this.btnAddStage_Click);
            // 
            // txtStageDescription
            // 
            this.txtStageDescription.Location = new System.Drawing.Point(81, 140);
            this.txtStageDescription.Multiline = true;
            this.txtStageDescription.Name = "txtStageDescription";
            this.txtStageDescription.Size = new System.Drawing.Size(121, 65);
            this.txtStageDescription.TabIndex = 10;
            // 
            // txtStageTitle
            // 
            this.txtStageTitle.Location = new System.Drawing.Point(81, 95);
            this.txtStageTitle.Name = "txtStageTitle";
            this.txtStageTitle.Size = new System.Drawing.Size(121, 20);
            this.txtStageTitle.TabIndex = 9;
            // 
            // numStageOrder
            // 
            this.numStageOrder.Location = new System.Drawing.Point(84, 229);
            this.numStageOrder.Name = "numStageOrder";
            this.numStageOrder.Size = new System.Drawing.Size(118, 20);
            this.numStageOrder.TabIndex = 18;
            // 
            // AddStagesForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 340);
            this.Controls.Add(this.numStageOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveStages);
            this.Controls.Add(this.btnAddStage);
            this.Controls.Add(this.txtStageDescription);
            this.Controls.Add(this.txtStageTitle);
            this.Name = "AddStagesForm";
            ((System.ComponentModel.ISupportInitialize)(this.numStageOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private readonly int _itineraryId;
        private readonly List<Stage> _stages;

        public AddStagesForm(int itineraryId)
        {
            InitializeComponent();
            _itineraryId = itineraryId;
            _stages = new List<Stage>();
        }

        private void btnAddStage_Click(object sender, EventArgs e)
        {
            string title = txtStageTitle.Text.Trim();
            string description = txtStageDescription.Text.Trim();
            int order = (int)numStageOrder.Value;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Stage title is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _stages.Add(new Stage { Title = title, Description = description, Order = order });
            MessageBox.Show("Stage added to the list.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset input fields
            txtStageTitle.Clear();
            txtStageDescription.Clear();
            numStageOrder.Value = 1;
        }

        private void btnSaveStages_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    foreach (var stage in _stages)
                    {
                        string query = @"INSERT INTO gsv_stages (itinerary_id, title, description, stage_order) 
                                         VALUES (@itineraryId, @title, @description, @order)";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@itineraryId", _itineraryId);
                            cmd.Parameters.AddWithValue("@title", stage.Title);
                            cmd.Parameters.AddWithValue("@description", stage.Description);
                            cmd.Parameters.AddWithValue("@order", stage.Order);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("All stages saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving stages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Stage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}

