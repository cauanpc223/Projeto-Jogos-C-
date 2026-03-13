using System.Media;
using System.Text.Json;

public class PlayerData
{
    public string Name { get; set; } = "";
    public int Wins { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Draws { get; set; } = 0;
}

public static class GlobalData
{
    public static string CurrentPlayerName { get; set; } = "";
    public static List<PlayerData> AllPlayers { get; set; } = new List<PlayerData>();

    private static readonly string SavePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "TicTacToe", "leaderboard.json");

    public static void Load()
    {
        try
        {
            string dir = Path.GetDirectoryName(SavePath)!;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (File.Exists(SavePath))
            {
                string json = File.ReadAllText(SavePath);
                AllPlayers = JsonSerializer.Deserialize<List<PlayerData>>(json) ?? new List<PlayerData>();
            }
        }
        catch { AllPlayers = new List<PlayerData>(); }
    }

    public static void Save()
    {
        try
        {
            string json = JsonSerializer.Serialize(AllPlayers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SavePath, json);
        }
        catch { }
    }

    public static PlayerData GetOrCreatePlayer(string name)
    {
        var player = AllPlayers.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (player == null)
        {
            player = new PlayerData { Name = name };
            AllPlayers.Add(player);
        }
        return player;
    }

    public static List<PlayerData> GetTop10()
    {
        return AllPlayers.OrderByDescending(p => p.Wins).Take(10).ToList();
    }
}

namespace tictactoe
{
    public partial class Form1 : Form
    {
        Panel leaderboardPanel;
        Label[] leaderLabels = new Label[11];
        private readonly SoundPlayer clickSound = new SoundPlayer("C:\\Users\\igore\\source\\repos\\cauanpc223\\Projeto-Jogos-C-\\Windows-form-tic-tac-toe-game-tutorial-main\\tictactoe\\Resources\\click_sound.wav");
        // below is the player class which has two value
        // X and O
        // by doing this we can control the player and AI symbols
        public enum Player
        {
            X, O
        }

        Player currentPlayer; // calling the player class 

        List<Button> buttons; // creating a LIST or array of buttons
        Random rand = new Random(); // importing the random number generator class
        int playerWins = 0; // set the player win integer to 0
        int computerWins = 0; // set the computer win integer to 0
        int draws = 0;

        public Form1()
        {
            GlobalData.Load();

            using var nameForm = new PlayerNameForm();
            if (nameForm.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
                return;
            }
            GlobalData.CurrentPlayerName = nameForm.PlayerName;

            InitializeComponent();
            BuildLeaderboard();
            UpdateLeaderboard();
            resetGame();
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            clickSound.Play();
            buttons.Remove(button);
            Check();

            // Desabilita TODOS os botões disponíveis enquanto IA pensa
            foreach (Button b in buttons)
                b.Enabled = false;

            AImoves.Start();
        }

        private void AImove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                currentPlayer = Player.O;
                AImoves.Stop();

                List<Button[]> winCombos = new List<Button[]>
        {
            new[] { button1, button2, button3 },
            new[] { button4, button5, button6 },
            new[] { button7, button8, button9 },
            new[] { button1, button4, button7 },
            new[] { button2, button5, button8 },
            new[] { button3, button6, button9 },
            new[] { button1, button5, button9 },
            new[] { button3, button5, button7 }
        };

                Button chosen = null;

                // 1. tentar vencer
                foreach (var combo in winCombos)
                {
                    var empty = combo.Where(b => buttons.Contains(b)).ToList();
                    var filled = combo.Where(b => b.Text == "O").ToList();
                    if (filled.Count == 2 && empty.Count == 1)
                    {
                        chosen = empty[0];
                        break;
                    }
                }

                // 2. bloquear o jogador
                if (chosen == null)
                {
                    foreach (var combo in winCombos)
                    {
                        var empty = combo.Where(b => buttons.Contains(b)).ToList();
                        var filled = combo.Where(b => b.Text == "X").ToList();
                        if (filled.Count == 2 && empty.Count == 1)
                        {
                            chosen = empty[0];
                            break;
                        }
                    }
                }

                // 3. jogar aleatório
                if (chosen == null)
                {
                    int index = rand.Next(buttons.Count);
                    chosen = buttons[index];
                }

                chosen.Enabled = false;
                chosen.Text = currentPlayer.ToString();
                chosen.BackColor = System.Drawing.Color.DarkSalmon;
                clickSound.Play();
                buttons.Remove(chosen);
                Check();

                // Reabilita os botões restantes para o jogador
                foreach (Button b in buttons)
                    b.Enabled = true;
            }
        }
        private void restartGame(object sender, EventArgs e)
        {
            // this function is linked with the reset button
            // when the reset button is clicked then
            // this function will run the reset game function
            resetGame();
        }

        private void loadbuttons()
        {
            // this the custom function which will load all the buttons from the form to the buttons list
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button9, button8 };
        }

        private void resetGame()
        {
            //check each of the button with a tag of play
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; // change them all back to enabled or clickable
                    ((Button)X).Text = ""; // set the text to question mark
                    ((Button)X).BackColor = default(Color); // change the background colour to default button colors
                }
            }

            loadbuttons(); // run the load buttons function so all the buttons are inserted back in the array
        }

        private void BuildLeaderboard()
        {
            this.ClientSize = new Size(this.ClientSize.Width + 220, this.ClientSize.Height);

            leaderboardPanel = new Panel();
            leaderboardPanel.Size = new Size(200, 560);
            leaderboardPanel.Location = new Point(this.ClientSize.Width - 208, 60);
            leaderboardPanel.BackColor = this.BackColor;
            leaderboardPanel.BorderStyle = BorderStyle.None;

            Label separator = new Label();
            separator.BorderStyle = BorderStyle.Fixed3D;
            separator.Location = new Point(10, 30);
            separator.Size = new Size(180, 2);
            leaderboardPanel.Controls.Add(separator);

            leaderLabels[0] = new Label();
            leaderLabels[0].Text = "🏆 Top 10 Jogadores";
            leaderLabels[0].ForeColor = Color.FromArgb(0, 150, 0);
            leaderLabels[0].Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            leaderLabels[0].Location = new Point(4, 6);
            leaderLabels[0].Size = new Size(192, 22);
            leaderboardPanel.Controls.Add(leaderLabels[0]);

            for (int i = 1; i <= 10; i++)
            {
                Panel row = new Panel();
                row.Location = new Point(4, 28 + i * 48);
                row.Size = new Size(192, 44);
                row.BackColor = Color.FromArgb(220, 220, 220);
                leaderboardPanel.Controls.Add(row);

                leaderLabels[i] = new Label();
                leaderLabels[i].ForeColor = Color.Black;
                leaderLabels[i].Font = new Font("Microsoft Sans Serif", 9F);
                leaderLabels[i].Location = new Point(6, 4);
                leaderLabels[i].Size = new Size(180, 36);
                leaderLabels[i].Text = $"{i}. —";
                row.Controls.Add(leaderLabels[i]);
            }

            this.Controls.Add(leaderboardPanel);
            leaderboardPanel.BringToFront();
        }

        private void UpdateLeaderboard()
        {
            var top5 = GlobalData.GetTop10();
            for (int i = 1; i <= 10; i++)
            {
                if (i - 1 < top5.Count)
                {
                    var p = top5[i - 1];
                    bool isCurrent = p.Name.Equals(GlobalData.CurrentPlayerName, StringComparison.OrdinalIgnoreCase);
                    leaderLabels[i].Text = $"{i}. {p.Name}\n   ✔{p.Wins}   ✘{p.Losses}    ={p.Draws}";
                    leaderLabels[i].ForeColor = isCurrent ? Color.FromArgb(180, 0, 0) : Color.Black;
                }
                else
                {
                    leaderLabels[i].Text = $"{i}. —";
                    leaderLabels[i].ForeColor = Color.Gray;
                }
            }
        }

        private void RecordResult(string result)
        {
            var player = GlobalData.GetOrCreatePlayer(GlobalData.CurrentPlayerName);

            if (result == "win")
            {
                playerWins++;
                player.Wins++;
                label1.Text = "Player Wins- " + playerWins;
            }
            else if (result == "loss")
            {
                computerWins++;
                player.Losses++;
                label2.Text = "AI Wins- " + computerWins;
            }
            else
            {
                draws++;
                player.Draws++;
                label3.Text = "Empates- " + draws;
            }

            GlobalData.Save();
            UpdateLeaderboard();
        }

        private void Check()
        {
            //in this function we will check if the player or the AI has won
            // we have two very large if statements with the winning possibilities
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                /*
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
                */

                AImoves.Stop();
                SoundPlayer victorySound = new SoundPlayer("C:\\Users\\igore\\source\\repos\\cauanpc223\\Projeto-Jogos-C-\\Windows-form-tic-tac-toe-game-tutorial-main\\tictactoe\\Resources\\victory.wav");
                victorySound.Play();
                MessageBox.Show($"{GlobalData.CurrentPlayerName} Venceu!");
                RecordResult("win");
                resetGame();
            }
            // below if statement is for when the AI wins the game
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                /*
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
                */

                AImoves.Stop();
                SoundPlayer defeatedSound = new SoundPlayer("C:\\Users\\igore\\source\\repos\\cauanpc223\\Projeto-Jogos-C-\\Windows-form-tic-tac-toe-game-tutorial-main\\tictactoe\\Resources\\defeated.wav");
                defeatedSound.Play();
                MessageBox.Show("Computador Venceu!");
                RecordResult("loss");
                resetGame();
            }

            else if (buttons.Count == 0)
            {

                AImoves.Stop();
                SoundPlayer drawSound = new SoundPlayer("C:\\Users\\igore\\source\\repos\\cauanpc223\\Projeto-Jogos-C-\\Windows-form-tic-tac-toe-game-tutorial-main\\tictactoe\\Resources\\i-mean-its-alright-like.wav");
                drawSound.Play();
                MessageBox.Show("Empate!");
                RecordResult("draw");
                resetGame();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
