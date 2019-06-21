// Add function in F#
let add a b = a + b

let add' (a:int) (b:int) = a + b

let add'' (a:int, b:int) = a + b

printfn "El resultado es %i" (add 2 5)

let add2 = add 2

printfn "El resultado es %i" (add2 5)

// Add function in EC6
// let add = (a, b) => a + b;

// Add function in TypeScript
// let add = (a: number, b: number) => a + b;

// Add function in Kotlin
// fun sum(a: Int, b: Int) = a + b

// Add function in C#
// static int add(int a, int b) => a + b;