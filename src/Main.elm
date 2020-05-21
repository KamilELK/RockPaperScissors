module Main exposing (..)

import Browser exposing (sandbox)
import Html exposing (..)
import Html.Events exposing (..)
import Html.Attributes exposing (..)

main =
  Browser.sandbox { init = init, update = update, view = view }

--types

type alias Model = 
 { value : Int
 }  

type Msg
    = Rock
    | Paper
    | Scissors
    | Spock
    | Lizard
    | Reset 

type Result
    = CpuWins
    | PlayerWins
    | Draw    

type alias Score = Int


init : Model
init = Model -1





--Model


--update
choiceUpdate : Msg -> Model -> Model
choiceUpdate choice model = 
    case choice of
    Rock -> 
        { model | value = 0 }
    Paper ->
        { model | value = 1 }
    Scissors ->
        { model | value = 2 }
    Lizard -> 
        { model | value = 3 }
    Spock ->
        { model | value = 4 } 
    Reset ->
        resetGame model               



resetGame :  Model -> Model
resetGame  model =
      { model | value = -1 }

    


update : Msg -> Model -> Model 
update choice model =
    case choice of
        Reset ->
            resetGame  model 
        _ ->
            choiceUpdate choice model

            

        
            
            



--view
choiceToString : Msg -> String
choiceToString choice =
    case choice of
        Rock ->
            "Rock"
        Paper ->
            "Paper"

        Scissors ->
            "Scissors"

        Lizard ->
            "Lizard" 

        Spock ->
            "Spock"
        Reset ->
            "Reset game"   







view : Model -> Html Msg
view model =
  div []
    [   h1  [style "margin" "5vh 30vw"] [text "Rock Paper Scissors Lizar Spock"],
        button [style "margin" "5vh 5vw", onClick Rock][ text "Rock"],
        button [onClick Paper][ text "Paper"],
        button [onClick Scissors][ text "Scissors"],
        button [onClick Lizard][ text "Lizard"],
        button [onClick Spock][ text "Spock"],
        button [onClick Reset][ text "Restart"], 
        p [] [text (String.fromInt model.value)]

        
    ]
        

      