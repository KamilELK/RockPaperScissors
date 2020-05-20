using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsLizSpock.Services
{
    public partial class Game
    {
        private Partie.moves userMove;
        private Partie.moves cpuMove;
        private Partie currentRound;
        public List<Partie> gameData;


        public Game()
        {
            //InitializeComponent();

            //drpAvailableMoves.Items.Clear();

            //foreach (string moveName in Enum.GetNames(typeof(Partie.moves)))
            //{
            //    drpAvailableMoves.Items.Add(moveName);
            //}
            //drpAvailableMoves.SelectedIndex = 0;

            // Ensure that we have a new list to store all game data in
            gameData = new List<Partie>();
        }

        public string Play(string i)
        {
            // Parse the user input to a Round.moves enum value
            userMove = parseUserChoice(i);

            // Generate the data for this round
            cpuMove = cpuPlay();
            currentRound = new Partie(userMove, cpuMove);

            // Add the data from this round to the list of previous
            // rounds
            gameData.Add(currentRound);

            //// Write the result of this round to the log
            //rtbResults.AppendText("Game number: " + gameData.Count + Environment.NewLine);
            //rtbResults.AppendText("______________" + Environment.NewLine);
            //rtbResults.AppendText(currentRound.ToString() + Environment.NewLine);

            //// Ensure we scroll to the end of the line
            //rtbResults.ScrollToCaret();

            //if (gameData.Count >= 10)
            //{
            //    btnGenerateStats.Enabled = true;
            //    btnGenerateStats.Visible = true;
            //}

            return currentRound.ToString();
        }

        private Partie.moves cpuPlay()
        {
            // Extremely bad algorithm for generating the CPU guess
            Random randChoice = new Random(System.DateTime.Now.Second);
            switch (randChoice.Next(1, 5))
            {
                case 1:
                    return Partie.moves.Rock;
                case 2:
                    return Partie.moves.Paper;
                case 3:
                    return Partie.moves.Scissors;
                case 4:
                    return Partie.moves.Lizard;
                case 5:
                    return Partie.moves.Spock;
                default:
                    throw new Exception("Random value generated was not as expected");
            }
        }

        private Partie.moves parseUserChoice(string inUserInput)
        {
            switch (inUserInput)
            {
                case "Rock":
                    return Partie.moves.Rock;
                case "Paper":
                    return Partie.moves.Paper;
                case "Scissors":
                    return Partie.moves.Scissors;
                case "Lizard":
                    return Partie.moves.Lizard;
                case "Spock":
                    return Partie.moves.Spock;
                default:
                    throw new Exception("Une erreur s'est produite");
            }
        }

    }
}
