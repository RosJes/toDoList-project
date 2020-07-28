let counter = 0;
function Check(id) {
    let x = document.getElementById(id)
    let li = document.getElementById('item '+id)
    if (counter % 2 == 0) {
        x.innerText = 'true'
        li.style.textDecoration = 'line-through'
    }
    else {
        x.innerText = 'false'
        li.style.textDecoration = 'none'
    }
    counter++
}

