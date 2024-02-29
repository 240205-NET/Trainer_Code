"use strict";
// // C# equivalent string foo = "bar";
// let foo : string = "bar"
// let bar : any = 123
// bar = "123"
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
function getAllPlantsAsyncAwait() {
    return __awaiter(this, void 0, void 0, function* () {
        const resStream = yield fetch("http://localhost:5239/api/Plant");
        const resBody = yield resStream.json();
        betterAddToTable(resBody);
    });
}
function betterAddToTable(dataArr) {
    var _a, _b;
    const table = document.getElementById('plants-table');
    for (let row of dataArr) {
        let newRow = table.insertRow(-1);
        newRow.insertCell(0).innerText = (_b = (_a = row.plantID) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "n/a";
        newRow.insertCell(1).innerText = row.scientificName;
        newRow.insertCell(2).innerText = row.commonName;
        newRow.insertCell(3).innerText = row.zone.toString();
        newRow.insertCell(4).innerText = row.size.toString();
        newRow.insertCell(5).innerText = row.adoptionDate.toString();
    }
}
