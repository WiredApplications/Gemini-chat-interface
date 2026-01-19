using GenerativeAI;
using GenerativeAI.Clients;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;


namespace telikiergasia2
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "AIzaSyDTQuoxfp3w-jT9E_91_c6zCqRVZL_j8o8";
        private const string ModelId = "models/gemini-2.5-flash";

        private readonly string connectionString = "Data Source=Database.db;Version=3;";
        private readonly SQLiteConnection connection;

        private ChatSession _chatSession;


        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(1116, 825);
            this.MinimumSize = new System.Drawing.Size(1116, 825);

            connection = new SQLiteConnection(connectionString);
            textBox1.PlaceholderText = "Τι σκέφτεσται σήμερα?";
            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            connection.Open();
            string createTable = @"
                CREATE TABLE IF NOT EXISTS Gamemode (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Question TEXT NOT NULL,
                    Answer TEXT NOT NULL
                );";
            using (var cmd = new SQLiteCommand(createTable, connection))
            {
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            string userPrompt = textBox1.Text;

            richTextBox1.AppendText($"Χρήστης: {userPrompt}\n");

            textBox1.Clear();
            button1.Enabled = false;
            textBox1.Enabled = false;

            try
            {
                if (_chatSession == null)
                {
                    var adapter = new GoogleAIPlatformAdapter(ApiKey);
                    var model = new GenerativeModel(adapter, ModelId);
                    _chatSession = model.StartChat();
                }

                var response = await _chatSession.GenerateContentAsync(userPrompt);

                richTextBox1.AppendText($"AI: {response.Text}\n");
                richTextBox1.AppendText("-----\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Σφάλμα: {ex.Message}");
                richTextBox1.AppendText("AI: Σφάλμα κατά την απάντηση\n");
                richTextBox1.AppendText("-----\n");
            }
            finally
            {
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox1.Focus();
            }
        }

        private void έξοδοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ηΟμάδαΜαςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new about();
            form2.ShowDialog();
        }

        private void εξαγωγηΔιαλόγουtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Αποθήκευση αρχείου";
                saveFileDialog.Filter = "Text Files|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    MessageBox.Show("Η συνομιλία αποθηκεύτηκε επιτυχώς!");
                }
            }
        }
        
        private void εισαγωγηΕρώτησηςtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Επιλέξτε αρχείο κειμένου";
                openFileDialog.Filter = "Text Files|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(openFileDialog.FileName);
                        textBox1.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Σφάλμα κατά το φόρτωμα του αρχείου: {ex.Message}");
                    }
                }
            }
        }

        private void νέοςΔιάλογοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            _chatSession = null;
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void αποθήκευσηΤρέχουσαςΑπάντησηςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;
            string lastQuestion = "";
            string lastAnswer = "";

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].StartsWith("AI:") && string.IsNullOrEmpty(lastAnswer))
                    lastAnswer = lines[i].Substring(4);
                else if (lines[i].StartsWith("Χρήστης:") && string.IsNullOrEmpty(lastQuestion))
                {
                    lastQuestion = lines[i].Substring(8);
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(lastQuestion) || string.IsNullOrWhiteSpace(lastAnswer))
            {
                MessageBox.Show("Δεν βρέθηκε ερώτηση ή απάντηση για αποθήκευση.");
                return;
            }

            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO Gamemode (Question, Answer) VALUES (@q, @a)";
                using (var cmd = new SQLiteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@q", lastQuestion.Trim());
                    cmd.Parameters.AddWithValue("@a", lastAnswer.Trim());
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Η ερώτηση και η απάντηση αποθηκεύτηκαν στη βάση δεδομένων!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Σφάλμα κατά την αποθήκευση: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void προβοληΙστορικούToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new DataBase();
            form2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
