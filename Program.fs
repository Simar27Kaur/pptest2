// For more information see https://aka.ms/fsharp-console-apps

//PART A : OSCAR PREDICTIONS
// Genre as a Discriminated Union
type Genre = 
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Director Record Type
type Director = {
    Name: string
    Movies: int
}

// Movie Record Type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

// PART B Create Movie Instances

let coda = {
    Name = "CODA"
    RunLength = 111
    Genre = Drama
    Director = { Name = "Sian Heder"; Movies = 9 }
    IMDBRating = 8.1
}

let belfast = {
    Name = "Belfast"
    RunLength = 98
    Genre = Comedy
    Director = { Name = "Kenneth Branagh"; Movies = 23 }
    IMDBRating = 7.3
}

let dontLookUp = {
    Name = "Don't Look Up"
    RunLength = 138
    Genre = Comedy
    Director = { Name = "Adam McKay"; Movies = 27 }
    IMDBRating = 7.2
}

let driveMyCar = {
    Name = "Drive My Car"
    RunLength = 179
    Genre = Drama
    Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
    IMDBRating = 7.6
}

let dune = {
    Name = "Dune"
    RunLength = 155
    Genre = Fantasy
    Director = { Name = "Denis Villeneuve"; Movies = 24 }
    IMDBRating = 8.1
}

let kingRichard = {
    Name = "King Richard"
    RunLength = 144
    Genre = Sport
    Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }
    IMDBRating = 7.5
}

let licoricePizza = {
    Name = "Licorice Pizza"
    RunLength = 133
    Genre = Comedy
    Director = { Name = "Paul Thomas Anderson"; Movies = 49 }
    IMDBRating = 7.4
}

let nightmareAlley = {
    Name = "Nightmare Alley"
    RunLength = 150
    Genre = Thriller
    Director = { Name = "Guillermo Del Toro"; Movies = 22 }
    IMDBRating = 7.1
}

printfn""
printfn"PART C"
printfn""

// PART C: CREATE A LIST

let movieList = [coda; belfast; dontLookUp; driveMyCar; dune; kingRichard; licoricePizza; nightmareAlley]

movieList |> List.iter (fun movie -> 
    printfn "Name: %s" movie.Name
    printfn "Run Length: %d minutes" movie.RunLength
    printfn "Genre: %A" movie.Genre
    printfn "Director: %s" movie.Director.Name
    printfn "Director's Movies: %d" movie.Director.Movies
    printfn "IMDB Rating: %.1f\n" movie.IMDBRating
)

printfn""
printfn"PART D"
printfn""

// PART D: FILTER FUNCTION TO IDENTIFY PROBABLE OSCAR WINNERS

let probableOscarWinners = 
    movieList |> List.filter (fun movie -> movie.IMDBRating > 7.4)

probableOscarWinners |> List.iter (fun movie -> 
    printfn $"{movie.Name} - {movie.IMDBRating:F1}")


printfn""
printfn"PART E"
printfn""

// PART E: MAP FILTER TO CONVERT MOVIE RUNLENGTH TO HOURS
let convertToHoursAndMinutes (minutes: int) =
    let hours = minutes / 60
    let remainingMinutes = minutes % 60
    sprintf "%dh %02dmin" hours remainingMinutes

let movieRunLengthsWithNames = 
    movieList |> List.map (fun movie -> 
        sprintf "%s: %s" movie.Name (convertToHoursAndMinutes movie.RunLength))

movieRunLengthsWithNames |> List.iter (fun movie -> printfn "%s" movie)

printfn""
printfn""