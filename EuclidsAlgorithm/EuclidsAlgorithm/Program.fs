open System

let rec inputNumber (display : string) =
    Console.WriteLine display
    let mutable i = 0
    match Console.ReadLine() |> Int32.TryParse with
    | true, num -> i <- num
    | false, _ -> i <- inputNumber display
    i

let rec euclid first second =
    let remainder = first % second
    let mutable result = second
    if remainder <> 0 then
        result <- euclid second remainder
    result

[<EntryPoint>]
let main argv =
    let first = inputNumber "Pick your first number"
    let second = inputNumber "Pick your second number"

    let hcf = euclid first second
    let lcm = (first * second) / hcf

    Console.WriteLine("Highest Common Factor: " + string hcf)
    Console.WriteLine("Lowest Common Multiple: " + string lcm)
    0
