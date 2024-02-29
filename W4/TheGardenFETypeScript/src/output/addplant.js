"use strict";
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
function addNewPlant(e) {
    return __awaiter(this, void 0, void 0, function* () {
        e.preventDefault();
        const form = document.getElementsByName('addPlantForm')[0];
        const fd = new FormData(form);
        let data = {
            commonName: '',
            scientificName: '',
            size: 0,
            zone: 0,
            adoptionDate: ''
        };
        for (let kvp of fd.entries()) {
            const key = kvp[0];
            if (key === 'zone' || key === 'size') {
                data[key] = parseInt(kvp[1].toString());
            }
            else if (key === 'commonName' || key === 'scientificName' || key === 'adoptionDate') {
                data[key] = kvp[1].toString();
            }
        }
        const response = yield fetch("http://localhost:5239/api/Plant", {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        });
        form.reset();
        alert('plant successfully added!');
    });
}
