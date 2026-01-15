using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace telikiergasia2
{
    public partial class DataBase : Form
    {
        private string connectionString = "Data Source=Database.db;Version=3;";
        private DataGridView dataGridViewHistory;
        private Button buttonBack;

        public DataBase()
        {
            InitializeComponent();

            this.Text = "Ιστορικό Συνομιλιών";
            this.Width = 700;
            this.Height = 500;

            // Κουμπί Back πάνω
            buttonBack = new Button();
            buttonBack.Text = "Back";
            buttonBack.Height = 50;
            buttonBack.Width = 50;
            buttonBack.Dock = DockStyle.Top;
            buttonBack.Click += ButtonBack_Click;
            buttonBack.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            buttonBack.Padding = new Padding(5);

            this.Controls.Add(buttonBack);

            // Δημιουργία DataGridView κάτω από το κουμπί
            dataGridViewHistory = new DataGridView();
            dataGridViewHistory.Dock = DockStyle.Fill;
            dataGridViewHistory.ReadOnly = true;
            dataGridViewHistory.AllowUserToAddRows = false;
            dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewHistory.RowTemplate.Height = 40;
            dataGridViewHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewHistory.RowHeadersVisible = false;

            this.Controls.Add(dataGridViewHistory);

            // Ο πίνακας θα εμφανίζεται κάτω από το κουμπί
            dataGridViewHistory.BringToFront();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Κλείνει τη φόρμα
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            DataTable historyTable = new DataTable();
            historyTable.Columns.Add("ID");
            historyTable.Columns.Add("Question");
            historyTable.Columns.Add("Answer");

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT id, Question, Answer FROM Gamemode ORDER BY id ASC";
                    using (var cmd = new SQLiteCommand(selectQuery, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string q = reader["Question"].ToString();
                            string a = reader["Answer"].ToString();
                            historyTable.Rows.Add(id, q, a);
                        }
                    }
                }

                dataGridViewHistory.DataSource = historyTable;

                // Σταθερό πλάτος για το ID
                if (dataGridViewHistory.Columns["ID"] != null)
                    dataGridViewHistory.Columns["ID"].Width = 50;

                // Οι υπόλοιπες στήλες να γεμίζουν χώρο
                if (dataGridViewHistory.Columns["Question"] != null)
                    dataGridViewHistory.Columns["Question"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (dataGridViewHistory.Columns["Answer"] != null)
                    dataGridViewHistory.Columns["Answer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Σφάλμα κατά την ανάγνωση ιστορικού: {ex.Message}");
            }
        }
    }
}
