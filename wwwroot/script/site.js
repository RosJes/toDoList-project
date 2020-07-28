let counter = 0;
function Check(id) {
    console.log(counter)
    var att = document.createAttribute("class"); 
    let x = document.getElementById(id)
    let li = document.getElementById('item '+id)
    if (counter % 2 == 0) {
        x.innerText = 'true'
        att.value = "checked";    
        li.setAttributeNode(att)
    }
    else {
        x.innerText = 'false'
        att.value='unchecked'
        li.setAttributeNode(att)
    }
    counter++
}

