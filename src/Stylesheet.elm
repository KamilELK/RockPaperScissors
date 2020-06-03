module Stylesheet exposing(..)
import Css exposing (..)
import Html exposing (..)
import Html.Attributes exposing (..)

buttonStyle : List (Attribute msg)
buttonStyle =
    [ style "width" "300px"
    , style "background-color" "#397cd5"
    , style "color" "white"
    , style "padding" "14px 20px"
    , style "margin-top" "10px"
    , style "border" "none"
    , style "border-radius" "4px"
    , style "font-size" "16px"
    ]
divStyle : List (Attribute msg)
divStyle =
    [ style "width" "322px"
    , style "margin" "10% auto auto auto"
    ]

imgStyle =
    [ style "width" "60px"
    , style "height" "60px"
    ]
h3Style =
    [ style "text-align" "center"
    ]
reponseTableStyle =
    [
        style "width" "50%"
        ,style "display" "inline-block"
        ,style "text-align" "center"
    ]
