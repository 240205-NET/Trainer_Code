async function addNewPlant(e) {
    e.preventDefault()
    const form = document.addPlantForm
    const fd = new FormData(form)

    let data = {};
    for(let [k, v]of fd.entries()) {
        console.log(k, v)
        if(k === 'zone' || k === 'size') {
            data[k] = parseInt(v)
        }
        else {
            data[k] = v;
        }
    }
    console.log(data)
    console.log('display loading...')
    const response = await fetch("http://localhost:5239/api/Plant", {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    })
    form.reset()
    alert('plant successfully added!')
    console.log('stuff happened...')
}
