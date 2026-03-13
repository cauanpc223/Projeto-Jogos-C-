using System.Media;

namespace tictactoe
{
    public class PlayerNameForm : Form
    {
        private Label lblTitle;
        private TextBox txtName;
        private Button btnStart;
        private Label lblError;

        public string PlayerName { get; private set; } = "";

        public PlayerNameForm()
        {
            this.Text = "Tic Tac Toe - Entrar";
            this.Size = new Size(360, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

            lblTitle = new Label();
            lblTitle.Text = "Digite seu nome para jogar:";
            lblTitle.ForeColor = Color.Black;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.AutoSize = true;

            txtName = new TextBox();
            txtName.Location = new Point(30, 70);
            txtName.Size = new Size(280, 30);
            txtName.BackColor = Color.White;
            txtName.ForeColor = Color.Black;
            txtName.MaxLength = 20;

            lblError = new Label();
            lblError.Text = "";
            lblError.ForeColor = Color.Salmon;
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.Location = new Point(30, 105);
            lblError.AutoSize = true;

            btnStart = new Button();
            btnStart.Text = "Jogar";
            btnStart.Location = new Point(110, 130);
            btnStart.Size = new Size(120, 38);
            btnStart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStart.BackColor = Color.MediumSeaGreen;
            btnStart.ForeColor = Color.White;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Click += BtnStart_Click;

            this.Controls.AddRange(new Control[] { lblTitle, txtName, lblError, btnStart });
            this.AcceptButton = btnStart;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                lblError.Text = "Por favor, digite um nome!";
                return;
            }

            PlayerName = name;
            this.DialogResult = DialogResult.OK;
            this.Close();
            SoundPlayer startSound = new SoundPlayer("C:\\Users\\igore\\source\\repos\\cauanpc223\\Projeto-Jogos-C-\\Windows-form-tic-tac-toe-game-tutorial-main\\tictactoe\\Resources\\meme-okay-lets-go.wav");
            startSound.Play();
        }
    }
}