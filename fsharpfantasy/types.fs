module fsharpfantasy.types

open System


type Team = ATL|BAL|BUF|CAR|CHI|CIN|CLE|DAL|DEN|DET|GB|HOU|IND|JAX|KC|LAC|LAR|LV|MIA|MIN|NE|NO|NYG|NYJ|PHI|PIT|SEA|SF|TB|TEN|WAS
type Position = QB|RB|WR|TE|DST|K|DL|LB|DB
type GameResult = W|L|T

type PlayerStats = {
    Name: string
    ShortName: string
    FirstName: string
    LastName: string
    FantasyPosition: Position
    Position: Position
    Team: Team
    PlayerID: int
    Season: int
    Played: int
    Started: int
    Week: int
    Opponent: Team
    TeamHasPossession: bool
//    HomeOrAway: null,
    TeamIsHome: bool
//    Result: GameResult
    HomeScore: int
    AwayScore: int
    Quarter: string
    QuarterDisplay: string
    IsGameOver: bool
//    GameDate: DateTime
    ScoreSummary: string
    PassingCompletions: int
    PassingAttempts: int
    PassingCompletionPercentage: float
    PassingYards: int
    PassingYardsPerAttempt: float
    PassingTouchdowns: float
    PassingInterceptions: float
    PassingRating: float
    RushingAttempts: float
    RushingYards: float
    RushingYardsPerAttempt: float
    RushingTouchdowns: float
    Receptions: float
    ReceivingTargets: float
    ReceivingYards: float
    ReceptionPercentage: float
    ReceivingTouchdowns: float
    ReceivingLong: float
    ReceivingYardsPerTarget: float
    ReceivingYardsPerReception: float
    Fumbles: float
    FumblesLost: float
    FieldGoalsMade: float
    FieldGoalsAttempted: float
    FieldGoalPercentage: float
    FieldGoalsLongestMade: float
    ExtraPointsMade: float
    ExtraPointsAttempted: float
    TacklesForLoss: float
    Sacks: float
    QuarterbackHits: float
    Interceptions: float
    FumblesRecovered: float
    Safeties: float
    DefensiveTouchdowns: int
    SpecialTeamsTouchdowns: int
    SoloTackles: float
    AssistedTackles: float
    SackYards: float
    PassesDefended: float
    FumblesForced: float
    FantasyPoints: float
    FantasyPointsPPR: float
    FantasyPointsFanDuel: float
    FantasyPointsYahoo: float
    FantasyPointsFantasyDraft: float
    FantasyPointsDraftKings: float
    FantasyPointsHalfPointPpr: float
    FantasyPointsSixPointPassTd: float
    FantasyPointsPerGame: float
    FantasyPointsPerGamePPR: float
    FantasyPointsPerGameFanDuel: float
    FantasyPointsPerGameYahoo: float
    FantasyPointsPerGameDraftKings: float
    FantasyPointsPerGameHalfPointPPR: float
    FantasyPointsPerGameSixPointPassTd: float
    FantasyPointsPerGameFantasyDraft: float
    GameStatus: string
    GameStatusClass: string
    PointsAllowedByDefenseSpecialTeams: float option
    UsaTodayHeadshotNoBackgroundUrlSlug: string option
    TotalTackles: float
//    StatSummary: [
//        {
//            "Items": [
//                {
//                    "StatValue": "24/33",
//                    "StatTitle": ""
//                },
//                {
//                    "StatValue": "285",
//                    "StatTitle": "YDS"
//                },
//                {
//                    "StatValue": "4",
//                    "StatTitle": "TD"
//                }
//            ]
//        },
//        {
//            "Items": [
//                {
//                    "StatValue": "QB RAT 138.26",
//                    "StatTitle": ""
//                },
//                {
//                    "StatValue": "72.7",
//                    "StatTitle": "%"
//                },
//                {
//                    "StatValue": "8.6",
//                    "StatTitle": "YDS/ATT"
//                }
//            ]
//        },
//        {
//            "Items": [
//                {
//                    "StatValue": "6",
//                    "StatTitle": "ATT"
//                },
//                {
//                    "StatValue": "14",
//                    "StatTitle": "YDS"
//                },
//                {
//                    "StatValue": "2.3",
//                    "StatTitle": "AVG"
//                },
//                {
//                    "StatValue": "TD",
//                    "StatTitle": null
//                }
//            ]
//        }
//    ],
    IsScrambled: bool
    Rank: int
    StaticRank: int
    PositionRank: int option
    IsFavorite: bool
}

type StatsResponse = {
    Errors: string list option
    Data: PlayerStats list
    Total: int
}