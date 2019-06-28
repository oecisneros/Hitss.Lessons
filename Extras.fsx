// Add function in F#
let add a b = a + b

//let add' (a:int) (b:int) = a + b
//let add'' (a:int, b:int) = a + b

printfn "El resultado es %i" (add 2 5)

// Add function in EC6
// let add = (a, b) => a + b;

// Add function in TypeScript
// let add = (a: number, b: number) => a + b;

// Add function in Kotlin
// fun sum(a: Int, b: Int) = a + b

// Add function in C#
// static int add(int a, int b) => a + b;

let add5 = add 5

let double x = x * 2

let print x = printfn "El resultado es %i" x

let add5DoublePrint = add5 >> double >> print

add5DoublePrint(5)