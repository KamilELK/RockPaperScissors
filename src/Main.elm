module Main exposing (..)

import Browser
import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)

main =
  Browser.sandbox { model = initModel, update = update, view = view }

--types
type Choice
    = Rock
    | Paper
    | Scissors
    | Spock
    | Lizard
    | None
initModel : Int
initModel = -1

type Result
    = CpuWins
    | PlayerWins
    | Draw    

type alias Score = Int
type Msg = OnChoiceChange | Reset


--Model
model : initModel

--update

choiceUpdate : Choice -> Int
choiceUpdate choice = 
    case choice of
    Rock -> 
        initModel 0
    Paper ->
        initModel 1
    Scissors ->
        initModel 2
    Lizard -> 
        initModel 3
    Spock ->
        initModel 4            



resetGame = 
    initModel - 1

    


update : Msg -> Choice -> (initModel) 
update msg choice  =
    case msg of
        OnChoiceChange ->
            choiceUpdate choice

            

        reset ->
            resetGame
            
            



--view
choiceToString : Choice -> String
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
        None ->
            ""   





button : Choice -> Html Msg
button choix =
    button
        [ onClick (OnChoiceChange choix)]
        [ text <| choiceToString choix ]

view : Html Msg
view =
  div []
    [button Rock, button Paper, button Scissors, button Lizard, button Spock ]    

      