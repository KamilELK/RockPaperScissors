module Main exposing (..)

import Browser exposing (sandbox)
import Http 
import Html exposing (..)
import Html.Events exposing (..)
import Html.Attributes exposing (..)
import Json.Decode as D exposing (Decoder, field, string)

main =
  Browser.sandbox { init = init, update = update, view = view }

--types

type alias Model = 
 { value : Int,
   resultatActuel : Resultat 
    
 }  

type Msg
    = Rock
    | Paper
    | Scissors
    | Spock
    | Lizard
    | Reset 
    | GetResult(Result Http.Error (Resultat))



type alias Resultat = 
    {cpu_move : String,
     user_move : String,
     result : String,
     global_score : String   
    }





--Model

init : Model
init = { value = -1 ,
 resultatActuel = {cpu_move = "", user_move = "", result = "", global_score = ""}
  }

apiUrl : String
apiUrl = "https://localhost:5001/getRps/" 






--update
choiceUpdate : Msg -> Model -> Model
choiceUpdate choice model = 
    case choice of
    Rock -> 
        { model | value = 0  }
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


myDecoder : Decoder Resultat
myDecoder =
     D.map4 Resultat
     (D.field "cpu_move" D.string )  
     (D.field "user_move" D.string )  
     (D.field "result" D.string )  
     (D.field "global_score " D.string )                     



getRps : Model -> Cmd Msg
getRps model = 
    {url = apiUrl ++ (String.fromInt model.value),
     expect = Http.expectJson GetResult myDecoder 
     
    }

   


resetGame :  Model -> Model
resetGame  model =
      { model | value = -1 }

    


update : Msg -> Model -> Model 
update choice model =
    case choice of
        Reset ->
            resetGame  model 
        GetResult (Ok json) ->
            { model | resultatActuel = json  }
        GetResult (Err e ) ->
            Debug.log("failed to load data") model           

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
        div []
        [ button [style "margin" "5vh 45vw", onClick Reset][ text "Restart"]], 
        

        button [style "margin" "5vh 45vw", onClick Rock][ text "Rock"],
        div []
            [
            button [style "margin" "5vh 28vw", onClick Paper][ text "Paper"],
            button [style "margin" "5vh 1vw",onClick Scissors][ text "Scissors"]
            ],
        div []    
            [
            button [style "margin" "10vh 28vw",onClick Lizard][ text "Lizard"],
            button [style "margin" "10vh 1vw",onClick Spock][ text "Spock"]
            ],
        

        p [style "margin" "5vh 13vw"] [text (String.fromInt model.value)]
    ]
        

      