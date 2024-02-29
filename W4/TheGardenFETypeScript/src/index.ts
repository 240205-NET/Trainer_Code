// // C# equivalent string foo = "bar";
// let foo : string = "bar"
// let bar : any = 123
// bar = "123"


// function sayHello() : string {
//     return "hello!"
// }
// // C# equivalent
// // public string sayHello() {
// //     return "hello";
// // }

// function greet(name : string) : void {
//     // Template literal
//     console.log(`hello ${name}!`)
// }
// // C# equivalent
// // public void greet(string name) {
// //     Console.WriteLine($"hello {name}!");
// // }


// adoptionDate
// : 
// "2024-02-26T20:47:20.39"
// commonName
// : 
// "Happy Tree Friend"
// plantID
// : 
// 1
// scientificName
// : 
// "For All You Hold Holy!!!"
// size
// : 
// 1
// zone
// : 
// 3

import { Plant } from "./models"

async function getAllPlantsAsyncAwait() : Promise<void> {
    const resStream : Response = await fetch("http://localhost:5239/api/Plant")
    const resBody : Plant[] = await resStream.json()

    betterAddToTable(resBody)
}

function betterAddToTable(dataArr : Plant[]) : void {
    const table : HTMLTableElement = <HTMLTableElement> document.getElementById('plants-table')

    for(let row of dataArr) {
        let newRow : HTMLTableRowElement = table.insertRow(-1)

        newRow.insertCell(0).innerText = row.plantID?.toString() ?? "n/a"
        newRow.insertCell(1).innerText = row.scientificName
        newRow.insertCell(2).innerText = row.commonName
        newRow.insertCell(3).innerText = row.zone.toString()
        newRow.insertCell(4).innerText = row.size.toString()
        newRow.insertCell(5).innerText = row.adoptionDate.toString()
    }
}