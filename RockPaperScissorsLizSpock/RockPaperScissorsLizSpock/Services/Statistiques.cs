using RockPaperScissorsLizSpock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
   public class Statistiques
    {

      private static int _winsField;
      private static int _lossesField;
      private static int _drawsField;
      private static int _numberOfGames;

      private static int _rockCPU;
      private static int _paperCPU;
      private static int _scissorsCPU;
      private static int _lizardCPU;
      private static int _spockCPU;

      private static int _rockUser;
      private static int _paperUser;
      private static int _scissorsUser;
      private static int _lizardUser;
      private static int _spockUser;

      public Statistiques()
      {
         
      }

      public void generateStats(List<Partie> inGameData)
      {
         games = inGameData.Count;

         foreach (Partie game in inGameData)
         {
            switch (game.getResult())
            {
               case Partie.result.Win:
                  ++wins;
                  break;
               case Partie.result.Loss:
                  ++losses;
                  break;
               case Partie.result.Draw:
                  ++draws;
                  break;
            }

            switch (game.UsersMove)
            {
               case Partie.moves.Rock:
                  ++RockUser;
                  break;
               case Partie.moves.Paper:
                  ++PaperUser;
                  break;
               case Partie.moves.Scissors:
                  ++ScissorsUser;
                  break;
               case Partie.moves.Lizard:
                  ++LizardUser;
                  break;
               case Partie.moves.Spock:
                  ++SpockUser;
                  break;
            }

            switch(game.CpuMove)
            {
               case Partie.moves.Rock:
                  ++RockCPU;
                  break;
               case Partie.moves.Paper:
                  ++PaperCPU;
                  break;
               case Partie.moves.Scissors:
                  ++ScissorsCPU;
                  break;
               case Partie.moves.Lizard:
                  ++LizardCPU;
                  break;
               case Partie.moves.Spock:
                  ++SpockCPU;
                  break;
            }
         }
      }
      
      public void ClearStats()
      {
            _winsField = 0;
            _lossesField = 0;
            _drawsField = 0;
            _numberOfGames = 0;

            _rockCPU = 0;
            _scissorsCPU = 0;
            _paperCPU = 0;
            _lizardCPU = 0;
            _spockCPU = 0;

            _rockUser = 0;
            _scissorsUser = 0;
            _paperUser = 0;
            _lizardUser = 0;
            _spockUser = 0;
      }

      public int wins
      {
         get
         {
            return _winsField;
         }
         set
         {
            _winsField = value;
         }
      }

      public int losses
      {
         get
         {
            return _lossesField;
         }
         set
         {
            _lossesField = value;
         }
      }

      public int draws
      {
         get
         {
            return _drawsField;
         }
         set
         {
            _drawsField = value;
         }
      }

      public int games
      {
         get
         {
            return _numberOfGames;
         }
         set
         {
            _numberOfGames = value;
         }
      }

      public int RockCPU
      {
         get
         {
            return _rockCPU;
         }
         set
         {
            _rockCPU = value;
         }
      }

      public int PaperCPU
      {
         get
         {
            return _paperCPU;
         }
         set
         {
            _paperCPU = value;
         }
      }

      public int ScissorsCPU
      {
         get
         {
            return _scissorsCPU;
         }
         set
         {
            _scissorsCPU = value;
         }
      }
      public int LizardCPU
      {
         get
         {
            return _lizardCPU;
         }
         set
         {
            _lizardCPU = value;
         }
      }
      public int SpockCPU
      {
         get
         {
            return _spockCPU;
         }
         set
         {
            _spockCPU = value;
         }
      }
      public int RockUser
      {
         get
         {
            return _rockUser;
         }
         set
         {
            _rockUser = value;
         }
      }
      public int PaperUser
      {
         get
         {
            return _paperUser;
         }
         set
         {
            _paperUser = value;
         }
      }
      public int ScissorsUser
      {
         get
         {
            return _scissorsUser;
         }
         set
         {
            _scissorsUser = value;
         }
      }
      public int LizardUser
      {
         get
         {
            return _lizardUser;
         }
         set
         {
            _lizardUser = value;
         }
      }

      public int SpockUser
      {
         get
         {
            return _spockUser;
         }
         set
         {
            _spockUser = value;
         }
      }

   }
}
