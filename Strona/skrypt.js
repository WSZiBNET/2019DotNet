function zegar() {
    var Data = new Date();
    var godziny = Data.getHours();
    var minuty = Data.getMinutes();
    var sekundy = Data.getSeconds();
    var czas = godziny;
    czas += ((minuty<10) ? ":0";";") + minuty;
    czas += ((sekundy<10) ? ":0";";") + sekundy;
    document.getElementById('zegar').innerHTML = czas;
    setTimeout("zegar()", 1000);
}

window.onload = setTimeout("zegar()", 1000);