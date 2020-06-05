module Main exposing (..)

import Browser
import Http
import Html exposing (..)
import Html.Events exposing (..)
import Html.Attributes exposing (..)
import Json.Decode as D exposing (Decoder, field, string)
import Bootstrap.Table as Table
import Stylesheet
import Json.Decode.Pipeline exposing (optional, optionalAt, required, requiredAt)



-- MAINY



main =
  Browser.element
    { init = init
    , update = update
    , subscriptions = subscriptions
    , view = view
    }



-- MODEL


type Model
  = None 
  | Failure
  | Loading
  | Success String


type alias Resultat = 
    {cpu_move : String,
     global_score : String,
     result : String,
     user_move : String
    }



resultatDecoder =
    D.succeed Resultat
        |> Json.Decode.Pipeline.required "cpu_move" string
        |> Json.Decode.Pipeline.required "global_score" string
        |> Json.Decode.Pipeline.required "result" string
        |> Json.Decode.Pipeline.required "user_move" string

init : () -> (Model, Cmd Msg)
init _ =
  ( None 
  , Cmd.none
  )



-- UPDATE


type Msg
  = GotResult (Result Http.Error String)
    | NewGame (Result Http.Error String)
    | Rock
    | Paper
    | Scissors
    | Spock
    | Lizard
    | Reset
     
 







updateChoice : Msg -> Model -> (Model, Cmd Msg)  
updateChoice choice model = 
    case choice of 
    Rock ->
      (Loading, getRps 0)
    Paper ->
      (Loading, getRps 1)
    Scissors ->
      (Loading, getRps 2)
    Lizard ->
      (Loading, getRps 3)
    Spock ->   
      (Loading, getRps 4)
    Reset ->
      (Loading, resetGame "init")  
    GotResult some->
      (Loading, Cmd.none)
    NewGame str ->
      (Loading, Cmd.none)    
    

getRps : Int -> Cmd Msg 
getRps  nbr = 
        Http.get 
        {url = apiUrl  ++ String.fromInt nbr,
        expect = Http.expectString GotResult 
        } 


apiUrl : String
apiUrl = "https://localhost:5001/getRps/" 


resetGame : String -> Cmd Msg
resetGame reset =
           Http.get 
          {url = apiUrl  ++ reset,
          expect = Http.expectString NewGame    
        } 



myDecoder : Decoder Resultat
myDecoder =
     D.map4 Resultat
     (D.field "cpu_move" D.string )  
     (D.field "global_score " D.string )   
     (D.field "result" D.string )  
     (D.field "user_move" D.string )  

update : Msg -> Model -> (Model, Cmd Msg)
update msg model =
  case msg of
    GotResult result ->
      case result of
        Ok fullText ->
          (Success fullText, Cmd.none)

        Err _ ->
          (Failure, Cmd.none)

    NewGame result ->
      case result of 
        Ok text ->
          (None , Cmd.none)
        Err _ ->
          (Failure,Cmd.none)       
    _ -> updateChoice msg model

--stringDecode : string -> string
--stringDecode str =
  --get 0 (String.split "," str)




  
-- SUBSCRIPTIONS


subscriptions : Model -> Sub Msg
subscriptions model =
  Sub.none



-- VIEW

view : Model -> Html Msg
view model =
  div ([] ++ Stylesheet.divStyle)
        [ h3 ([] ++ Stylesheet.h3Style) [ text "Jouer à Rock Paper Scissors, la version Big Bang Theory" ]
            ,h5 ([] ++ Stylesheet.h3Style) [
              case model of 
                            Success fullText ->      
                              pre [] [ text fullText ]
                            Loading ->
                              pre [] [ text "Loading data" ] 
                            Failure ->
                              pre [] [ text "Oups, the oponent did not reply " ]  
                            None ->
                              pre [] [ text "New Game, Go" ]
            ]
            ,div []
                [ 
                  case model of 
                            Success fullText -> 
                              div [] [ h4 ([] ++ Stylesheet.h3Style) [
                                              img [src "img/Win.png", height 70] []
                                            , img [src "img/Lose.png", height 70] []]]
                            Loading ->
                              pre [] [] 
                            Failure ->
                              pre [] []  
                            None ->
                              pre [] [] 
                ] 
            ,Table.table
                { options = [ ]
                , thead =  Table.simpleThead
                    [ Table.th [] [  ]
                    , Table.th [] [  ]
                    , Table.th [] [  ]
                    , Table.th [] [  ]
                    , Table.th [] [  ]
                    ]
                , tbody =
                    Table.tbody []
                        [ Table.tr []
                            [ Table.td [] [ img [src "img/Pierre.png", width 60, height 60, onClick Rock] [] ]
                            , Table.td [] [ img [src "img/feuille.png", width 60, height 60, onClick Paper] [] ]
                            , Table.td [] [ img [src "img/ciseaux.png", width 60, height 60, onClick Scissors] [] ]
                            , Table.td [] [ img [src "img/Spock.png", width 60, height 60, onClick Spock] [] ]
                            , Table.td [] [ img [src "img/lezard.png", width 60, height 60, onClick Lizard] [] ]
                            ]
                        ]
                }
          ,div []
                [ div ([] ++ Stylesheet.reponseTableStyle) [ h4 ([] ++ Stylesheet.h3Style) [text "Vous"]]
                , div ([] ++ Stylesheet.reponseTableStyle) [ h4 ([] ++ Stylesheet.h3Style) [text "L'adversaire"]]
                ]
        
          ,div []
                [ h5 ([] ++ Stylesheet.h3Style) [ img [src "img/rejouer.png", height 100, onClick Reset] [] ] ]

        ]  