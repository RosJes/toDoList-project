let counter = 0;
function Check(id) {
    console.log(counter)
    var att = document.createAttribute("class"); 
    att.value = "checked";     
    let x = document.getElementById(id)
    let y = document.getElementsByTagName('LI')[id];
    if (counter % 2 == 0) {
        x.innerText = 'true'
       y.setAttributeNode(att);           
       
    }
    else
        x.innerText = 'false'

    counter++
}

