let counter = 0;
function Check(id) {
    console.log(counter)
    let att = document.createAttribute("class"); 
    let x = document.getElementById(id)
    let li = document.getElementById('item '+id)
    if (counter % 2 == 0) {
        x.innerText = 'true'
        //att.value = "checked";    
        //li.setAttributeNode(att)
        li.style.textDecoration = 'line-through'
    }
    else {
        x.innerText = 'false'
        //att.value='unchecked'
        //li.setAttributeNode(att)
        li.style.textDecoration = 'none'
    }
    counter++
}

