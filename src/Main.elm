module Main exposing (..)

import Browser
import Http
import Html exposing (..)
import Html.Events exposing (..)
import Html.Attributes exposing (..)
import Json.Decode as D exposing (Decoder, field, string)



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
  | Success Resultat


type alias Resultat = 
    {cpu_move : String,
     user_move : String,
     result : String,
     global_score : String   
    }

init : () -> (Model, Cmd Msg)
init _ =
  ( None
  , Cmd.none
  )



-- UPDATE


type Msg
  = GotResult (Result Http.Error Resultat)
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
      (None, Cmd.none)  
    GotResult some->
      (Loading, Cmd.none)  
    

getRps : Int -> Cmd Msg 
getRps  nbr = 
        Http.get 
        {url = apiUrl  ++ String.fromInt nbr,
        expect = Http.expectJson GotResult myDecoder
        } 

apiUrl : String
apiUrl = "https://localhost:5001/getRps/" 


myDecoder : Decoder Resultat
myDecoder =
     D.map4 Resultat
     (D.field "cpu_move" D.string )  
     (D.field "user_move" D.string )  
     (D.field "result" D.string )  
     (D.field "global_score " D.string )   

update : Msg -> Model -> (Model, Cmd Msg)
update msg model =
  case msg of
    GotResult result ->
      case result of
        Ok fullText ->
          (Success fullText, Cmd.none)

        Err _ ->
          (Failure, Cmd.none)
    _ -> updateChoice msg model


-- SUBSCRIPTIONS


subscriptions : Model -> Sub Msg
subscriptions model =
  Sub.none



-- VIEW

view : Model -> Html Msg
view model =
  div []
    [   h1  [style "margin" "5vh 30vw"] [text "Rock Paper Scissors Lizard Spock"],
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
        

        case model of 
          Success fullText ->
            pre [] [ text fullText.cpu_move ]
          Loading ->
            pre [] [ text "status : loading" ] 
          Failure ->
            pre [] [ text "status : failure" ]  
          None ->
            pre [] [ text "status : none" ]   
    ]      