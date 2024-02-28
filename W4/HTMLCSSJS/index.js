// let foo = "bar"
// const bar = "foo"

// bar = "bar" //not good, error will ensue

// function foobar() {
//     let foo = 'foo'
//     if(true) {
//         let a = 'b'
//     }
//     console.log(a) //will not work. a is not available here
// }

function btnClickHandler(e) {
    console.log('i was clicked!', e)
    let div = document.querySelector('#js-demo')
    div.innerHTML += "You clicked this button!"
    e.stopPropagation()
}

function addNewButton() {
    let div = document.querySelector('#js-demo')
    let newButton = document.createElement('button')
    newButton.innerText = "New Button"
    newButton.addEventListener('click', () => btnClickHandler())
    // newButton.addEventListener('mouseup', () => addNewButton())
    div.appendChild(newButton)
}