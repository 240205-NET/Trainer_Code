function getAllPlants() {
    fetch("http://localhost:5239/api/Plant")
    .then(
        // success scenarios
        (response) => response.json()
    )
    .then((json) => 
    {
        betterAddToTable(json)
    })
    .catch(
        // failure scenarios
        (e) => console.error(e)
    )
}

// Same as getAllPlants
async function getAllPlantsAsyncAwait() {
    const resStream = await fetch("http://localhost:5239/api/Plant")
    const resBody = await resStream.json()

    betterAddToTable(resBody)
}

function addToTable(dataArr) {
    let table = document.getElementById('plants-table')

    let tableBody = table.getElementsByTagName('tbody')[0]

    for(row of dataArr) {
        let newRow = document.createElement('tr')
        // plantID
        // scientificName
        // commonName
        // zone
        // size
        // adoptionDate
        let id = document.createElement('td')
        id.textContent = row.plantID
        let sName = document.createElement('td')
        sName.textContent = row.scientificName
        let commonName = document.createElement('td')
        commonName.textContent = row.commonName
        let zone = document.createElement('td')
        zone.textContent = row.zone
        let size = document.createElement('td')
        size.textContent = row.size
        let adoptionDate = document.createElement('td')
        adoptionDate.textContent = row.adoptionDate
    
        newRow.appendChild(id)
        newRow.appendChild(sName)
        newRow.appendChild(commonName)
        newRow.appendChild(zone)
        newRow.appendChild(size)
        newRow.appendChild(adoptionDate)
    
        tableBody.appendChild(newRow)
    }
}

// Same as addToTable
function betterAddToTable(dataArr) {
    let table = document.getElementById('plants-table')

    for(row of dataArr) {
        let newRow = table.insertRow(-1)

        newRow.insertCell(0).innerText = row.plantID
        newRow.insertCell(1).innerText = row.scientificName
        newRow.insertCell(2).innerText = row.commonName
        newRow.insertCell(3).innerText = row.zone
        newRow.insertCell(4).innerText = row.size
        newRow.insertCell(5).innerText = row.adoptionDate
    }
}

// document.onload = getAllPlants()