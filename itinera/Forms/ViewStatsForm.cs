using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using ItinerariApp.DataAccess;
using ItinerariApp.Models;

namespace ItinerariApp.Forms
{
    public partial class ViewStatsForm : Form
    {
        private Label label1;
        private Button btnClose;
        private Chart chartStats;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStats.Legends.Add(legend1);
            this.chartStats.Location = new System.Drawing.Point(35, 64);
            this.chartStats.Name = "chartStats";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStats.Series.Add(series1);
            this.chartStats.Size = new System.Drawing.Size(740, 472);
            this.chartStats.TabIndex = 0;
            this.chartStats.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistiche";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(175, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Chiudi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewStatsForm
            // 
            this.ClientSize = new System.Drawing.Size(812, 562);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartStats);
            this.Name = "ViewStatsForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public ViewStatsForm()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                using (var connection = Database.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT i.title, COUNT(f.favorite_id) AS favorites_count
                FROM gsv_itineraries i
                LEFT JOIN gsv_favorites f ON i.itinerary_id = f.itinerary_id
                WHERE i.entity_id = @entityId
                GROUP BY i.itinerary_id, i.title
                ORDER BY favorites_count DESC";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@entityId", CurrentUser.UserId); // Filtra per l'utente loggato

                        using (var reader = cmd.ExecuteReader())
                        {
                            chartStats.Series.Clear();
                            var series = new Series("Favorites")
                            {
                                ChartType = SeriesChartType.Bar
                            };
                            chartStats.Series.Add(series);

                            while (reader.Read())
                            {
                                string title = reader.GetString("title");
                                int count = reader.GetInt32("favorites_count");

                                // Debug per verificare i dati
                                Console.WriteLine($"Title: {title}, Count: {count}");

                                series.Points.AddXY(title, count);
                            }

                            // Configurazioni del grafico
                            chartStats.ChartAreas[0].AxisX.Title = "Itinerary Title";
                            chartStats.ChartAreas[0].AxisY.Title = "Favorites Count";
                            chartStats.ChartAreas[0].AxisX.Interval = 1;
                            chartStats.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Ruota le etichette
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
