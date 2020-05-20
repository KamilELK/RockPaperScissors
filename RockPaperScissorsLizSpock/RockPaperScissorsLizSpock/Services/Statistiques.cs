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

      private int _winsField;
      private int _lossesField;
      private int _drawsField;
      private int _numberOfGames;

      private int _rockCPU;
      private int _paperCPU;
      private int _scissorsCPU;
      private int _lizardCPU;
      private int _spockCPU;

      private int _rockUser;
      private int _paperUser;
      private int _scissorsUser;
      private int _lizardUser;
      private int _spockUser;

      public Statistiques()
      {
         this._winsField = 0;
         this._lossesField = 0;
         this._drawsField = 0;
         this._numberOfGames = 0;

         this._rockCPU = 0;
         this._scissorsCPU = 0;
         this._paperCPU = 0;
         this._lizardCPU = 0;
         this._spockCPU = 0;

         this._rockUser = 0;
         this._scissorsUser = 0;
         this._paperUser = 0;
         this._lizardUser = 0;
         this._spockUser = 0;
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

      public int wins
      {
         get
         {
            return this._winsField;
         }
         set
         {
            this._winsField = value;
         }
      }

      public int losses
      {
         get
         {
            return this._lossesField;
         }
         set
         {
            this._lossesField = value;
         }
      }

      public int draws
      {
         get
         {
            return this._drawsField;
         }
         set
         {
            this._drawsField = value;
         }
      }

      public int games
      {
         get
         {
            return this._numberOfGames;
         }
         set
         {
            this._numberOfGames = value;
         }
      }

      public int RockCPU
      {
         get
         {
            return this._rockCPU;
         }
         set
         {
            this._rockCPU = value;
         }
      }

      public int PaperCPU
      {
         get
         {
            return this._paperCPU;
         }
         set
         {
            this._paperCPU = value;
         }
      }

      public int ScissorsCPU
      {
         get
         {
            return this._scissorsCPU;
         }
         set
         {
            this._scissorsCPU = value;
         }
      }
      public int LizardCPU
      {
         get
         {
            return this._lizardCPU;
         }
         set
         {
            this._lizardCPU = value;
         }
      }
      public int SpockCPU
      {
         get
         {
            return this._spockCPU;
         }
         set
         {
            this._spockCPU = value;
         }
      }
      public int RockUser
      {
         get
         {
            return this._rockUser;
         }
         set
         {
            this._rockUser = value;
         }
      }
      public int PaperUser
      {
         get
         {
            return this._paperUser;
         }
         set
         {
            this._paperUser = value;
         }
      }
      public int ScissorsUser
      {
         get
         {
            return this._scissorsUser;
         }
         set
         {
            this._scissorsUser = value;
         }
      }
      public int LizardUser
      {
         get
         {
            return this._lizardUser;
         }
         set
         {
            this._lizardUser = value;
         }
      }

      public int SpockUser
      {
         get
         {
            return this._spockUser;
         }
         set
         {
            this._spockUser = value;
         }
      }

   }
}
