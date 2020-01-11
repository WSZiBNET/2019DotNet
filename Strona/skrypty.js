function zegar(){
    alert(1);
}

function zegar(){
    var Data = new Date();
    var godziny = Data.getHours();
    var minuty = Data.getMinutes();
    var sekundy = Data.getSeconds();
    var czas = godziny;
    czas += ((minuty<10) ? ":0":":") + minuty;
    czas += ((sekundy<10) ? ":0":":") + sekundy;
    document.getElementById('zegar').innerHTML = czas;
    setTimeout("zegar()")
}

window.onload = setTimeout("zegar()", 1000);
//window.onload = zegar(); // setTimeout("zegar()", 100);