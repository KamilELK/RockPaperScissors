using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsLizSpock.Services
{
    public class Partie
    {
        //{ Rock, Paper, Scissors, Lizard, Spock };
        public enum moves { Rock , Paper , Scissors , Lizard , Spock  };
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

        public override string ToString()
        {
            string data = "User move:\t" + _userMove.ToString() + Environment.NewLine;
            data += "Cpu move:\t" + _cpuMove.ToString() + Environment.NewLine;
            data += "Result:\t\t" + getResult() + Environment.NewLine;
            return data;
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
