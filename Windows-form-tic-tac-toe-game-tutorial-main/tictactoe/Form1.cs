using System.Reflection.Emit;

namespace tictactoe
{
    public partial class Form1 : Form
    {

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
            InitializeComponent();
            resetGame(); // call the set game function
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
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
                    ((Button)X).Text = "?"; // set the text to question mark
                    ((Button)X).BackColor = default(Color); // change the background colour to default button colors
                }
            }

            loadbuttons(); // run the load buttons function so all the buttons are inserted back in the array
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
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
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

                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game
            }

            else if (buttons.Count == 0)
            {
                
                AImoves.Stop();
                MessageBox.Show("Empate!");
                draws++;
                label3.Text = "Empates- " + draws;
                resetGame();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
