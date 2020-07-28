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
ShowForm()
function ShowForm() {
    fetch("/_todolist/",
        {
            method: "GET",
        })
        .then(res => res.text())
        .then(html =>
            document.getElementById("list").innerHTML = html);

}
function Delete(x) {
    topFunction()
    fetch("/Delete/" + x,
        {
            method: "GET",
        })
        .then(res => res.text())
        .then(html =>
            document.getElementById("Delete").innerHTML = html);

}
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
function Edit(x) {
    let listitem = document.getElementById('list-item')
    listitem.style.display='inline'
    let li = document.getElementById('item ' + x)
    li.style.display = 'none'
    topFunction()
    fetch("/Edit/" + x,
        {
            method: "GET",
        })
        .then(res => res.text())
        .then(html =>
            document.getElementById("Edit").innerHTML = html);


}
