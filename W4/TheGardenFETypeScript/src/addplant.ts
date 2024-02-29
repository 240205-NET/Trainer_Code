import { Plant } from './models'

async function addNewPlant(e : Event) : Promise<void> {
    e.preventDefault()

    const form : HTMLFormElement = <HTMLFormElement> document.getElementsByName('addPlantForm')[0]

    const fd : FormData = new FormData(form)

    let data : Plant = {
        commonName: '',
        scientificName: '',
        size: 0,
        zone: 0,
        adoptionDate: ''
    }
    for(let kvp of fd.entries()) {
        const key : keyof Plant = kvp[0] as keyof Plant
        if(key === 'zone' || key === 'size') {
            data[key] = parseInt(kvp[1].toString())
        }
        else if(key === 'commonName' || key === 'scientificName' || key === 'adoptionDate') {
            data[key] = kvp[1].toString();
        }
    }

    const response : Response = await fetch("http://localhost:5239/api/Plant", {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    })
    form.reset()
    alert('plant successfully added!')
}