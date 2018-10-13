let selector = document.getElementById("selector");
let updateDiv = document.getElementById("update");
let displayDiv = document.getElementById("display");

selector.onchange = function () {
    if (selector.value == "update") {
        displayDiv.style.display = "none";
        updateDiv.style.display = "block";
    } else if (selector.value == "display") {
        displayDiv.style.display = "block";
        updateDiv.style.display = "none";
    } else {
        displayDiv.style.display = "none";
        updateDiv.style.display = "none";
    }
}

$('.table').click(function () {
    alert('asdsa');
});