using Nancy.Json;
using Newtonsoft.Json;
using RockPaperScissors.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Statistiques stats;



        public Game()
        {
            stats = new Statistiques();

            gameData = new List<Partie>();
        }

        public string Play(string i)
        {
            userMove = parseUserChoice(i);

            cpuMove = cpuPlay();
            currentRound = new Partie(userMove, cpuMove);

            gameData.Add(currentRound);

            stats.generateStats(gameData);

            JsonSerializer serializer = new JsonSerializer();
            var res = currentRound.ResultToJson(stats);
            var json = new JavaScriptSerializer().Serialize(res);

            return json;
        }

        private Partie.moves cpuPlay()
        {
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
