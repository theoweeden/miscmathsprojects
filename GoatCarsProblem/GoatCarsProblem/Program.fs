// Learn more about F# at http://fsharp.org

open System

let generateDoors (r : System.Random) =
    let mutable doors = [| for b in 1..3 -> false |]
    doors.[r.Next(doors.Length)] <- true
    doors;

let pickDoor (r : System.Random) (doors : bool array) (check) =
    let mutable newDoor = r.Next(doors.Length)
    while check newDoor do
        newDoor <- newDoor + 1
        if newDoor >= doors.Length then
            newDoor <- 0
    newDoor


[<EntryPoint>]
let main argv =
    let r = System.Random()
    
    let iterations = 100000
    let mutable total = 0
    
    for i in 1..iterations do
        //generate doors
        let doors = generateDoors r
        //player decision
        let originalPlayerPick = r.Next(doors.Length)
        let checkComputerPick n = n = originalPlayerPick || doors.[n] 
        let computerPick = pickDoor r doors checkComputerPick

        //player switches
        let checkPlayerPick n = computerPick = n || n = originalPlayerPick
        let playerPick = pickDoor r doors checkPlayerPick
                
        if doors.[playerPick] then
            total <- total + 1

    let probability = float total / float iterations 
    Console.WriteLine probability
    
    0