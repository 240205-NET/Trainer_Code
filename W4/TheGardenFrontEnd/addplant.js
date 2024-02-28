async function addNewPlant(e) {
    e.preventDefault()
    const form = document.addPlantForm
    const fd = new FormData(form)

    let data = {};
    for(let [k, v] of fd.entries()) {
        console.log(k, v)
        data[k] = v;
    }

    const response = await fetch("http://localhost:5239/api/Plant", {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    })
    console.log(response.json())
}
