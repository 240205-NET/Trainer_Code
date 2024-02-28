function getAllPlants() {
    fetch("http://localhost:5239/api/Plant")
    .then(
        // success scenarios
        (response) => response.json()
    )
    .then((json) => 
    {
        let table = document.getElementById('plants-table')

        let tableBody = table.getElementsByTagName('tbody')[0]

        let newRow = document.createElement('tr')
        // plantID
        // scientificName
        // commonName
        // zone
        // size
        // adoptionDate
        let id = document.createElement('td')
        id.textContent = json[0].plantID
        let sName = document.createElement('td')
        sName.textContent = json[0].scientificName
        let commonName = document.createElement('td')
        commonName.textContent = json[0].commonName
        let zone = document.createElement('td')
        zone.textContent = json[0].zone
        let size = document.createElement('td')
        size.textContent = json[0].size
        let adoptionDate = document.createElement('td')
        adoptionDate.textContent = json[0].adoptionDate

        newRow.appendChild(id)
        newRow.appendChild(sName)
        newRow.appendChild(commonName)
        newRow.appendChild(zone)
        newRow.appendChild(size)
        newRow.appendChild(adoptionDate)

        tableBody.appendChild(newRow)

    })
    .catch(
        // failure scenarios
        (e) => console.error(e)
    )
}
// document.onload = getAllPlants()