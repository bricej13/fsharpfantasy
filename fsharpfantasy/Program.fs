// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Text.Json
open System.Text.Json.Serialization
open Hopac
open HttpFs.Client
open fsharpfantasy.types

// Define a function to construct a message to print
    
let getRequest (year:int) (week:int) =
    let request =
      Request.createUrl Post "https://fantasydata.com/NFL_FantasyStats/FantasyStats_Read"
      |> Request.body (BodyForm [
          NameValue("sort", "FantasyPoints-desc")
          NameValue("pageSize", "10")
          NameValue("filters.season", year.ToString())
          NameValue("filters.startweek", week.ToString())
          NameValue("filters.endweek", week.ToString())
          NameValue("filters.seasontype", "1")
          NameValue("filters.scope", "2")
          NameValue("filters.subscope", "1")
          NameValue("filters.aggregatescope", "1")
          NameValue("filters.range", "3")
          NameValue("group", null)
          NameValue("filter", null)
          NameValue("filters.position", "1") // offense
          NameValue("filters.team", null)
          NameValue("filters.teamkey", null)
          NameValue("filters.cheatsheettype", null)
          NameValue("filters.redzonescope", null)
          NameValue("filters.scoringsystem", null)
          NameValue("filters.leaguetype", null)
          NameValue("filters.searchtext", null)
          NameValue("filters.week", null)
          NameValue("filters.minimumsnaps", null)
          NameValue("filters.teamaspect", null)
          NameValue("filters.stattype", null)
          NameValue("filters.exportType", null)
          NameValue("filters.desktop", null)
          NameValue("filters.dfsoperator", null)
          NameValue("filters.dfsslateid", null)
          NameValue("filters.dfsslategameid", null)
          NameValue("filters.dfsrosterslot", null)
          NameValue("filters.page", null)
          NameValue("filters.showfavs", null)
          NameValue("filters.posgroup", null)
          NameValue("filters.oddsstate", null)
          NameValue("filters.showall", null)
          NameValue("filters.rangescope", null)
          NameValue("filters.type", null)
          ]
      )
    request
    
let fetchData (request : Request) =
    request
    |> Request.responseAsString
    |> run
    
let fetchDummyData =
    """
{
  "Data": [
    {
      "PlayerID": 21810,
      "Season": 2021,
      "Played": 1,
      "Started": 0,
      "Week": 3,
      "Opponent": "WAS",
      "TeamHasPossession": false,
      "HomeOrAway": null,
      "TeamIsHome": false,
      "Result": "W",
      "HomeScore": 3,
      "AwayScore": 37,
      "Quarter": "F",
      "QuarterDisplay": "F",
      "IsGameOver": true,
      "GameDate": "\/Date(1630188000000)\/",
      "TimeRemaining": null,
      "ScoreSummary": "F (W) 3 - 37 @ WAS",
      "PassingCompletions": 24,
      "PassingAttempts": 33,
      "PassingCompletionPercentage": 72.7,
      "PassingYards": 285,
      "PassingYardsPerAttempt": 8.6,
      "PassingTouchdowns": 4.00,
      "PassingInterceptions": 0.00,
      "PassingRating": 138.26,
      "RushingAttempts": 6.00,
      "RushingYards": 14.00,
      "RushingYardsPerAttempt": 2.3,
      "RushingTouchdowns": 1.00,
      "Receptions": 0.00,
      "ReceivingTargets": 0.00,
      "ReceivingYards": 0.00,
      "ReceptionPercentage": 0,
      "ReceivingTouchdowns": 0.00,
      "ReceivingLong": 0.00,
      "ReceivingYardsPerTarget": 0,
      "ReceivingYardsPerReception": 0,
      "Fumbles": 0.00,
      "FumblesLost": 0.00,
      "FieldGoalsMade": 0.00,
      "FieldGoalsAttempted": 0.00,
      "FieldGoalPercentage": 0,
      "FieldGoalsLongestMade": 0.00,
      "ExtraPointsMade": 0.00,
      "ExtraPointsAttempted": 0.00,
      "TacklesForLoss": 0.00,
      "Sacks": 0.00,
      "QuarterbackHits": 0.00,
      "Interceptions": 0.00,
      "FumblesRecovered": 0.00,
      "Safeties": 0.00,
      "DefensiveTouchdowns": 0,
      "SpecialTeamsTouchdowns": 0,
      "SoloTackles": 0.00,
      "AssistedTackles": 0.00,
      "SackYards": 0.00,
      "PassesDefended": 0.00,
      "FumblesForced": 0.00,
      "FantasyPoints": 34.80,
      "FantasyPointsPPR": 34.80,
      "FantasyPointsFanDuel": 34.80,
      "FantasyPointsYahoo": 34.80,
      "FantasyPointsFantasyDraft": 34.80,
      "FantasyPointsDraftKings": 34.80,
      "FantasyPointsHalfPointPpr": 34.80,
      "FantasyPointsSixPointPassTd": 42.80,
      "FantasyPointsPerGame": 34.8,
      "FantasyPointsPerGamePPR": 34.8,
      "FantasyPointsPerGameFanDuel": 34.8,
      "FantasyPointsPerGameYahoo": 34.8,
      "FantasyPointsPerGameDraftKings": 34.8,
      "FantasyPointsPerGameHalfPointPPR": 34.8,
      "FantasyPointsPerGameSixPointPassTd": 42.8,
      "FantasyPointsPerGameFantasyDraft": 34.8,
      "PlayerUrlString": "/nfl/tyler-huntley-fantasy/21810",
      "GameStatus": "",
      "GameStatusClass": "",
      "PointsAllowedByDefenseSpecialTeams": null,
      "UsaTodayHeadshotNoBackgroundUrlSlug": "tyler-huntley-21810-2cc2041f",
      "TotalTackles": 0.00,
      "StatSummary": [
        {
          "Items": [
            {
              "StatValue": "24/33",
              "StatTitle": ""
            },
            {
              "StatValue": "285",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "4",
              "StatTitle": "TD"
            }
          ]
        },
        {
          "Items": [
            {
              "StatValue": "QB RAT 138.26",
              "StatTitle": ""
            },
            {
              "StatValue": "72.7",
              "StatTitle": "%"
            },
            {
              "StatValue": "8.6",
              "StatTitle": "YDS/ATT"
            }
          ]
        },
        {
          "Items": [
            {
              "StatValue": "6",
              "StatTitle": "ATT"
            },
            {
              "StatValue": "14",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "2.3",
              "StatTitle": "AVG"
            },
            {
              "StatValue": "TD",
              "StatTitle": null
            }
          ]
        }
      ],
      "Name": "Tyler Huntley",
      "ShortName": "T. Huntley",
      "FirstName": "Tyler",
      "LastName": "Huntley",
      "FantasyPosition": "QB",
      "Position": "QB",
      "TeamUrlString": "/nfl/baltimore-ravens-depth-chart",
      "Team": "BAL",
      "IsScrambled": false,
      "Rank": 1,
      "StaticRank": 0,
      "PositionRank": null,
      "IsFavorite": false
    },
    {
      "PlayerID": 20812,
      "Season": 2021,
      "Played": 1,
      "Started": 0,
      "Week": 3,
      "Opponent": "TEN",
      "TeamHasPossession": false,
      "HomeOrAway": null,
      "TeamIsHome": false,
      "Result": "W",
      "HomeScore": 24,
      "AwayScore": 27,
      "Quarter": "F",
      "QuarterDisplay": "F",
      "IsGameOver": true,
      "GameDate": "\/Date(1630191600000)\/",
      "TimeRemaining": null,
      "ScoreSummary": "F (W) 24 - 27 @ TEN",
      "PassingCompletions": 0,
      "PassingAttempts": 0,
      "PassingCompletionPercentage": 0,
      "PassingYards": 0,
      "PassingYardsPerAttempt": 0,
      "PassingTouchdowns": 0.00,
      "PassingInterceptions": 0.00,
      "PassingRating": 0,
      "RushingAttempts": 0.00,
      "RushingYards": 0.00,
      "RushingYardsPerAttempt": 0,
      "RushingTouchdowns": 0.00,
      "Receptions": 5.00,
      "ReceivingTargets": 5.00,
      "ReceivingYards": 104.00,
      "ReceptionPercentage": 100,
      "ReceivingTouchdowns": 3.00,
      "ReceivingLong": 54.00,
      "ReceivingYardsPerTarget": 20.8,
      "ReceivingYardsPerReception": 20.8,
      "Fumbles": 0.00,
      "FumblesLost": 0.00,
      "FieldGoalsMade": 0.00,
      "FieldGoalsAttempted": 0.00,
      "FieldGoalPercentage": 0,
      "FieldGoalsLongestMade": 0.00,
      "ExtraPointsMade": 0.00,
      "ExtraPointsAttempted": 0.00,
      "TacklesForLoss": 0.00,
      "Sacks": 0.00,
      "QuarterbackHits": 0.00,
      "Interceptions": 0.00,
      "FumblesRecovered": 0.00,
      "Safeties": 0.00,
      "DefensiveTouchdowns": 0,
      "SpecialTeamsTouchdowns": 0,
      "SoloTackles": 0.00,
      "AssistedTackles": 0.00,
      "SackYards": 0.00,
      "PassesDefended": 0.00,
      "FumblesForced": 0.00,
      "FantasyPoints": 28.40,
      "FantasyPointsPPR": 33.40,
      "FantasyPointsFanDuel": 30.90,
      "FantasyPointsYahoo": 30.90,
      "FantasyPointsFantasyDraft": 36.40,
      "FantasyPointsDraftKings": 36.40,
      "FantasyPointsHalfPointPpr": 30.90,
      "FantasyPointsSixPointPassTd": 28.40,
      "FantasyPointsPerGame": 28.4,
      "FantasyPointsPerGamePPR": 33.4,
      "FantasyPointsPerGameFanDuel": 30.9,
      "FantasyPointsPerGameYahoo": 30.9,
      "FantasyPointsPerGameDraftKings": 36.4,
      "FantasyPointsPerGameHalfPointPPR": 30.9,
      "FantasyPointsPerGameSixPointPassTd": 28.4,
      "FantasyPointsPerGameFantasyDraft": 36.4,
      "PlayerUrlString": "/nfl/jesper-horsted-fantasy/20812",
      "GameStatus": "",
      "GameStatusClass": "",
      "PointsAllowedByDefenseSpecialTeams": null,
      "UsaTodayHeadshotNoBackgroundUrlSlug": "jesper-horsted-20812-ae0803ae",
      "TotalTackles": 0.00,
      "StatSummary": [
        {
          "Items": [
            {
              "StatValue": "5",
              "StatTitle": "TGT"
            },
            {
              "StatValue": "5",
              "StatTitle": "REC"
            },
            {
              "StatValue": "104",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "3",
              "StatTitle": "TD"
            }
          ]
        }
      ],
      "Name": "Jesper Horsted",
      "ShortName": "J. Horsted",
      "FirstName": "Jesper",
      "LastName": "Horsted",
      "FantasyPosition": "TE",
      "Position": "TE",
      "TeamUrlString": "/nfl/chicago-bears-depth-chart",
      "Team": "CHI",
      "IsScrambled": false,
      "Rank": 2,
      "StaticRank": 0,
      "PositionRank": null,
      "IsFavorite": false
    },
    {
      "PlayerID": 90,
      "Season": 2021,
      "Played": 1,
      "Started": 1,
      "Week": 3,
      "Opponent": "LAC",
      "TeamHasPossession": false,
      "HomeOrAway": null,
      "TeamIsHome": true,
      "Result": "W",
      "HomeScore": 27,
      "AwayScore": 0,
      "Quarter": "F",
      "QuarterDisplay": "F",
      "IsGameOver": true,
      "GameDate": "\/Date(1630202400000)\/",
      "TimeRemaining": null,
      "ScoreSummary": "F (W) 27 - 0 vs. LAC",
      "PassingCompletions": 0,
      "PassingAttempts": 0,
      "PassingCompletionPercentage": 0,
      "PassingYards": 0,
      "PassingYardsPerAttempt": 0,
      "PassingTouchdowns": 0.00,
      "PassingInterceptions": 0.00,
      "PassingRating": 0,
      "RushingAttempts": 0.00,
      "RushingYards": 0.00,
      "RushingYardsPerAttempt": 0,
      "RushingTouchdowns": 0.00,
      "Receptions": 0.00,
      "ReceivingTargets": 0.00,
      "ReceivingYards": 0.00,
      "ReceptionPercentage": 0,
      "ReceivingTouchdowns": 0.00,
      "ReceivingLong": 0.00,
      "ReceivingYardsPerTarget": 0,
      "ReceivingYardsPerReception": 0,
      "Fumbles": 0.00,
      "FumblesLost": 0.00,
      "FieldGoalsMade": 0.00,
      "FieldGoalsAttempted": 0.00,
      "FieldGoalPercentage": 0,
      "FieldGoalsLongestMade": 0.00,
      "ExtraPointsMade": 0.00,
      "ExtraPointsAttempted": 0.00,
      "TacklesForLoss": 4.00,
      "Sacks": 5.00,
      "QuarterbackHits": 7.00,
      "Interceptions": 0.00,
      "FumblesRecovered": 1.00,
      "Safeties": 0.00,
      "DefensiveTouchdowns": 1,
      "SpecialTeamsTouchdowns": 0,
      "SoloTackles": 36.00,
      "AssistedTackles": 17.00,
      "SackYards": 30.00,
      "PassesDefended": 2.00,
      "FumblesForced": 1.00,
      "FantasyPoints": 23.00,
      "FantasyPointsPPR": 23.00,
      "FantasyPointsFanDuel": 23.00,
      "FantasyPointsYahoo": 23.00,
      "FantasyPointsFantasyDraft": 23.00,
      "FantasyPointsDraftKings": 23.00,
      "FantasyPointsHalfPointPpr": 23.00,
      "FantasyPointsSixPointPassTd": 23.00,
      "FantasyPointsPerGame": 23.0,
      "FantasyPointsPerGamePPR": 23.0,
      "FantasyPointsPerGameFanDuel": 23.0,
      "FantasyPointsPerGameYahoo": 23.0,
      "FantasyPointsPerGameDraftKings": 23.0,
      "FantasyPointsPerGameHalfPointPPR": 23.0,
      "FantasyPointsPerGameSixPointPassTd": 23.0,
      "FantasyPointsPerGameFantasyDraft": 23.0,
      "PlayerUrlString": "/nfl/seattle-seahawks-depth-chart",
      "GameStatus": "",
      "GameStatusClass": "",
      "PointsAllowedByDefenseSpecialTeams": 0.00,
      "UsaTodayHeadshotNoBackgroundUrlSlug": null,
      "TotalTackles": 53.00,
      "StatSummary": [
        {
          "Items": [
            {
              "StatValue": "5",
              "StatTitle": "SCK"
            },
            {
              "StatValue": "FR",
              "StatTitle": null
            },
            {
              "StatValue": "DEF TD",
              "StatTitle": null
            },
            {
              "StatValue": "0",
              "StatTitle": "PA"
            }
          ]
        }
      ],
      "Name": "Seattle Seahawks",
      "ShortName": "Seahawks",
      "FirstName": "Seattle",
      "LastName": "Seahawks",
      "FantasyPosition": "DST",
      "Position": "DST",
      "TeamUrlString": "/nfl/seattle-seahawks-depth-chart",
      "Team": "SEA",
      "IsScrambled": false,
      "Rank": 3,
      "StaticRank": 0,
      "PositionRank": null,
      "IsFavorite": false
    },
    {
      "PlayerID": 22674,
      "Season": 2021,
      "Played": 1,
      "Started": 0,
      "Week": 3,
      "Opponent": "DET",
      "TeamHasPossession": false,
      "HomeOrAway": null,
      "TeamIsHome": false,
      "Result": "W",
      "HomeScore": 17,
      "AwayScore": 27,
      "Quarter": "F",
      "QuarterDisplay": "F",
      "IsGameOver": true,
      "GameDate": "\/Date(1630105200000)\/",
      "TimeRemaining": null,
      "ScoreSummary": "F (W) 17 - 27 @ DET",
      "PassingCompletions": 0,
      "PassingAttempts": 0,
      "PassingCompletionPercentage": 0,
      "PassingYards": 0,
      "PassingYardsPerAttempt": 0,
      "PassingTouchdowns": 0.00,
      "PassingInterceptions": 0.00,
      "PassingRating": 0,
      "RushingAttempts": 10.00,
      "RushingYards": 81.00,
      "RushingYardsPerAttempt": 8.1,
      "RushingTouchdowns": 1.00,
      "Receptions": 1.00,
      "ReceivingTargets": 1.00,
      "ReceivingYards": 3.00,
      "ReceptionPercentage": 100,
      "ReceivingTouchdowns": 1.00,
      "ReceivingLong": 3.00,
      "ReceivingYardsPerTarget": 3,
      "ReceivingYardsPerReception": 3,
      "Fumbles": 0.00,
      "FumblesLost": 0.00,
      "FieldGoalsMade": 0.00,
      "FieldGoalsAttempted": 0.00,
      "FieldGoalPercentage": 0,
      "FieldGoalsLongestMade": 0.00,
      "ExtraPointsMade": 0.00,
      "ExtraPointsAttempted": 0.00,
      "TacklesForLoss": 0.00,
      "Sacks": 0.00,
      "QuarterbackHits": 0.00,
      "Interceptions": 0.00,
      "FumblesRecovered": 0.00,
      "Safeties": 0.00,
      "DefensiveTouchdowns": 0,
      "SpecialTeamsTouchdowns": 0,
      "SoloTackles": 0.00,
      "AssistedTackles": 0.00,
      "SackYards": 0.00,
      "PassesDefended": 0.00,
      "FumblesForced": 0.00,
      "FantasyPoints": 22.40,
      "FantasyPointsPPR": 23.40,
      "FantasyPointsFanDuel": 22.90,
      "FantasyPointsYahoo": 22.90,
      "FantasyPointsFantasyDraft": 23.40,
      "FantasyPointsDraftKings": 23.40,
      "FantasyPointsHalfPointPpr": 22.90,
      "FantasyPointsSixPointPassTd": 22.40,
      "FantasyPointsPerGame": 22.4,
      "FantasyPointsPerGamePPR": 23.4,
      "FantasyPointsPerGameFanDuel": 22.9,
      "FantasyPointsPerGameYahoo": 22.9,
      "FantasyPointsPerGameDraftKings": 23.4,
      "FantasyPointsPerGameHalfPointPPR": 22.9,
      "FantasyPointsPerGameSixPointPassTd": 22.4,
      "FantasyPointsPerGameFantasyDraft": 23.4,
      "PlayerUrlString": "/nfl/deon-jackson-fantasy/22674",
      "GameStatus": "",
      "GameStatusClass": "",
      "PointsAllowedByDefenseSpecialTeams": null,
      "UsaTodayHeadshotNoBackgroundUrlSlug": null,
      "TotalTackles": 0.00,
      "StatSummary": [
        {
          "Items": [
            {
              "StatValue": "10",
              "StatTitle": "ATT"
            },
            {
              "StatValue": "81",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "8.1",
              "StatTitle": "AVG"
            },
            {
              "StatValue": "TD",
              "StatTitle": null
            }
          ]
        },
        {
          "Items": [
            {
              "StatValue": "1",
              "StatTitle": "TGT"
            },
            {
              "StatValue": "1",
              "StatTitle": "REC"
            },
            {
              "StatValue": "3",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "TD",
              "StatTitle": null
            }
          ]
        }
      ],
      "Name": "Deon Jackson",
      "ShortName": "D. Jackson",
      "FirstName": "Deon",
      "LastName": "Jackson",
      "FantasyPosition": "RB",
      "Position": "RB",
      "TeamUrlString": "/nfl/indianapolis-colts-depth-chart",
      "Team": "IND",
      "IsScrambled": false,
      "Rank": 4,
      "StaticRank": 0,
      "PositionRank": null,
      "IsFavorite": false
    },
    {
      "PlayerID": 22514,
      "Season": 2021,
      "Played": 1,
      "Started": 0,
      "Week": 3,
      "Opponent": "PHI",
      "TeamHasPossession": false,
      "HomeOrAway": null,
      "TeamIsHome": true,
      "Result": "T",
      "HomeScore": 31,
      "AwayScore": 31,
      "Quarter": "F",
      "QuarterDisplay": "F",
      "IsGameOver": true,
      "GameDate": "\/Date(1630107000000)\/",
      "TimeRemaining": null,
      "ScoreSummary": "F (T) 31 - 31 vs. PHI",
      "PassingCompletions": 0,
      "PassingAttempts": 0,
      "PassingCompletionPercentage": 0,
      "PassingYards": 0,
      "PassingYardsPerAttempt": 0,
      "PassingTouchdowns": 0.00,
      "PassingInterceptions": 0.00,
      "PassingRating": 0,
      "RushingAttempts": 0.00,
      "RushingYards": 0.00,
      "RushingYardsPerAttempt": 0,
      "RushingTouchdowns": 0.00,
      "Receptions": 4.00,
      "ReceivingTargets": 5.00,
      "ReceivingYards": 100.00,
      "ReceptionPercentage": 80.0,
      "ReceivingTouchdowns": 2.00,
      "ReceivingLong": 49.00,
      "ReceivingYardsPerTarget": 20,
      "ReceivingYardsPerReception": 25,
      "Fumbles": 0.00,
      "FumblesLost": 0.00,
      "FieldGoalsMade": 0.00,
      "FieldGoalsAttempted": 0.00,
      "FieldGoalPercentage": 0,
      "FieldGoalsLongestMade": 0.00,
      "ExtraPointsMade": 0.00,
      "ExtraPointsAttempted": 0.00,
      "TacklesForLoss": 0.00,
      "Sacks": 0.00,
      "QuarterbackHits": 0.00,
      "Interceptions": 0.00,
      "FumblesRecovered": 0.00,
      "Safeties": 0.00,
      "DefensiveTouchdowns": 0,
      "SpecialTeamsTouchdowns": 0,
      "SoloTackles": 0.00,
      "AssistedTackles": 0.00,
      "SackYards": 0.00,
      "PassesDefended": 0.00,
      "FumblesForced": 0.00,
      "FantasyPoints": 22.00,
      "FantasyPointsPPR": 26.00,
      "FantasyPointsFanDuel": 24.00,
      "FantasyPointsYahoo": 24.00,
      "FantasyPointsFantasyDraft": 29.00,
      "FantasyPointsDraftKings": 29.00,
      "FantasyPointsHalfPointPpr": 24.00,
      "FantasyPointsSixPointPassTd": 22.00,
      "FantasyPointsPerGame": 22.0,
      "FantasyPointsPerGamePPR": 26.0,
      "FantasyPointsPerGameFanDuel": 24.0,
      "FantasyPointsPerGameYahoo": 24.0,
      "FantasyPointsPerGameDraftKings": 29.0,
      "FantasyPointsPerGameHalfPointPPR": 24.0,
      "FantasyPointsPerGameSixPointPassTd": 22.0,
      "FantasyPointsPerGameFantasyDraft": 29.0,
      "PlayerUrlString": "/nfl/kenny-yeboah-fantasy/22514",
      "GameStatus": "",
      "GameStatusClass": "",
      "PointsAllowedByDefenseSpecialTeams": null,
      "UsaTodayHeadshotNoBackgroundUrlSlug": "kenny-yeboah-22514-0fda93b9",
      "TotalTackles": 0.00,
      "StatSummary": [
        {
          "Items": [
            {
              "StatValue": "5",
              "StatTitle": "TGT"
            },
            {
              "StatValue": "4",
              "StatTitle": "REC"
            },
            {
              "StatValue": "100",
              "StatTitle": "YDS"
            },
            {
              "StatValue": "2",
              "StatTitle": "TD"
            }
          ]
        }
      ],
      "Name": "Kenny Yeboah",
      "ShortName": "K. Yeboah",
      "FirstName": "Kenny",
      "LastName": "Yeboah",
      "FantasyPosition": "TE",
      "Position": "TE",
      "TeamUrlString": "/nfl/new-york-jets-depth-chart",
      "Team": "NYJ",
      "IsScrambled": false,
      "Rank": 5,
      "StaticRank": 0,
      "PositionRank": null,
      "IsFavorite": false
    }
  ],
  "Total": 1440,
  "AggregateResults": null,
  "Errors": null
}
"""

let deserialize (body:string) =
    let opts = JsonSerializerOptions()
    opts.Converters.Add(JsonFSharpConverter(
        unionEncoding = (
          JsonUnionEncoding.Untagged
          ||| JsonUnionEncoding.UnwrapFieldlessTags
          ||| JsonUnionEncoding.UnwrapOption
        )
    ))

    JsonSerializer.Deserialize<StatsResponse>(body, opts)

[<EntryPoint>]
let main argv =
    let season2021Request = getRequest 2021
    let singleWeekRequest = season2021Request 1
    let res = fetchData (singleWeekRequest)
    let stats = deserialize res
    printfn $"%i{stats.Data.Length} of %i{stats.Total}"
    
    for player in stats.Data do
        printfn $"%s{player.Name}: %.1f{player.FantasyPointsHalfPointPpr}pts | %s{player.ScoreSummary}"
    0 // return an integer exit code