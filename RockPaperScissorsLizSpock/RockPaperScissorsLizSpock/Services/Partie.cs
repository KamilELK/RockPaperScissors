using RockPaperScissors.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsLizSpock.Services
{
    public class Partie
    {
        //{ Rock, Paper, Scissors, Lizard, Spock };
        public enum moves { Rock = 1, Paper, Scissors, Lizard, Spock };
        public enum result { Draw, Win, Loss };

        private moves _userMove;
        private moves _cpuMove;
        private result _result;

        public Partie(moves inUserMove, moves inCpuMove)
        {
            this._userMove = inUserMove;
            this._cpuMove = inCpuMove;
        }

        public result getResult()
        {
            generateResult();
            return this._result;
        }

        private void generateResult()
        {
            this._result = result.Draw;
            switch (_userMove)
            {
                case moves.Rock:
                    if (_cpuMove == moves.Scissors || _cpuMove == moves.Lizard)
                        this._result = result.Win;
                    else if (_cpuMove == moves.Spock || _cpuMove == moves.Paper)
                        this._result = result.Loss;
                    break;
                case moves.Paper:
                    if (_cpuMove == moves.Rock || _cpuMove == moves.Spock)
                        this._result = result.Win;
                    else if (_cpuMove == moves.Lizard || _cpuMove == moves.Scissors)
                        this._result = result.Loss;
                    break;
                case moves.Scissors:
                    if (_cpuMove == moves.Paper || _cpuMove == moves.Lizard)
                        this._result = result.Win;
                    else if (_cpuMove == moves.Spock || _cpuMove == moves.Rock)
                        this._result = result.Loss;
                    break;
                case moves.Lizard:
                    if (_cpuMove == moves.Paper || _cpuMove == moves.Spock)
                        this._result = result.Win;
                    else if (_cpuMove == moves.Scissors || _cpuMove == moves.Rock)
                        this._result = result.Loss;
                    break; ;
                case moves.Spock:
                    if (_cpuMove == moves.Scissors || _cpuMove == moves.Rock)
                        this._result = result.Win;
                    else if (_cpuMove == moves.Paper || _cpuMove == moves.Lizard)
                        this._result = result.Loss;
                    break;
                default:
                    this._result = result.Draw;
                    break;
            }
        }

        public object ResultToJson(Statistiques stats)
        {
            Result res = new Result();


            string data = "";

            data += "Game Stats" + Environment.NewLine;
            data += "\tWins: " + stats.wins + Environment.NewLine;
            data += "\tLosses:" + stats.losses + Environment.NewLine;
            data += "\tDraws: " + stats.draws + Environment.NewLine + Environment.NewLine;

            data += "User move stats" + Environment.NewLine;
            data += "\tRock usage (%): " + ((float)stats.RockUser / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tPaper usage (%):" + ((float)stats.PaperUser / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tScissors usage (%): " + ((float)stats.ScissorsUser / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tLizard usage (%): " + ((float)stats.LizardUser / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tSpock usage (%): " + ((float)stats.SpockUser / (float)stats.games) * 100 + Environment.NewLine + Environment.NewLine;

            data += "CPU move stats" + Environment.NewLine;
            data += "\tRock usage (%): " + ((float)stats.RockCPU / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tPaper usage (%):" + ((float)stats.PaperCPU / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tScissors usage (%): " + ((float)stats.ScissorsCPU / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tLizard usage (%): " + ((float)stats.LizardCPU / (float)stats.games) * 100 + Environment.NewLine;
            data += "\tSpock usage (%): " + ((float)stats.SpockCPU / (float)stats.games) * 100;

            res.User_move = _userMove.ToString();
            res.Cpu_move = _cpuMove.ToString();
            res.result = getResult().ToString();
            res.global_score = new string[] { data };
            return res;
        }

        public moves UsersMove
        {
            get
            {
                return this._userMove;
            }
            set
            {
                this._userMove = value;
            }
        }

        public moves CpuMove
        {
            get
            {
                return this._cpuMove;
            }
            set
            {
                this._cpuMove = value;
            }
        }
    }
}
