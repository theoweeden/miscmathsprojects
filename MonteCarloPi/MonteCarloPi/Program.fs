open System

let CalcPi iterations = 
    let r = System.Random()
    
    let mutable total = 0
    
    for i in 1..iterations do
        let x = r.NextDouble();
        let y = r.NextDouble();
        if Math.Pow(x, float 2) + Math.Pow(y, float 2) < float 1 then 
            total <- total + 1

    let probability = float total / float iterations 
    let pi = probability * float 4
    pi

[<EntryPoint>]
let main argv =
    Console.WriteLine(CalcPi 10000000)
    0
