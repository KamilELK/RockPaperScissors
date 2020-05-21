module Main exposing (..)

import Browser
import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)

main =
  Browser.sandbox { init = init, update = update, view = view }

--types

type alias Model =
 { value : Int
 }  

type Choice
    = Rock
    | Paper
    | Scissors
    | Spock
    | Lizard
    | None
init : (Model, Cmd Msg)
init = (Model -1, Cmd.none)

type Result
    = CpuWins
    | PlayerWins
    | Draw    

type alias Score = Int
type Msg = OnChoiceChange
         | Reset


--Model


--update
-- 904021904021904021904021
choiceUpdate : Choice -> Model -> (Model, Cmd Msg)
choiceUpdate choice model = 
    case choice of
    Rock -> 
        ( { model | value = 0 }, Cmd.none )
    Paper ->
        ( { model | value = 1 }, Cmd.none )
    Scissors ->
        ( { model | value = 2 }, Cmd.none )
    Lizard -> 
        ( { model | value = 3 }, Cmd.none )
    Spock ->
        ( { model | value = 4 }, Cmd.none )            



resetGame : Msg -> Model -> (Model, Cmd Msg)
resetGame msg model =
     ( { model | value = -1 }, Cmd.none )

    


update : Msg -> Model -> Choice -> (Model, Cmd Msg) 
update msg model choice =
    case msg of
        OnChoiceChange ->
            choiceUpdate choice model

            

        reset ->
            resetGame msg model 
            
            



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
        [ class <| choiceToString choix ,onClick ( OnChoiceChange )]
        [ text <| choiceToString choix ]

view : Html Msg
view =
  div []
    [button Rock, button Paper, button Scissors, button Lizard, button Spock ]    

      