// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let r = System.Random()
    
    let iterations = 1000
    let mutable total = 0
    
    for i in 1..iterations do
        //generate doors
        let mutable doors = [| for b in 1..3 -> false |]
        doors.[r.Next(doors.Length)] <- true

        //player decision
        let originalPlayerPick = r.Next(doors.Length)
        let mutable computerPick = r.Next(doors.Length)
        while computerPick = originalPlayerPick || doors.[computerPick] do
            computerPick <- computerPick + 1
            if computerPick >= doors.Length then
                computerPick <- 0
        
        //player switches
        let mutable playerPick = 0
        while computerPick = playerPick || playerPick = originalPlayerPick do
            playerPick <- playerPick + 1
            if playerPick >= doors.Length then
                playerPick <- 0
                
        if doors.[playerPick] then
            total <- total + 1

    let probability = float total / float iterations 
    Console.WriteLine probability
    0 // return an integer exit code
    