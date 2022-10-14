$(function () {
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("home/index", function (kunder) {
        skrivUt(kunder);
    });
}



skrivUt(kunder){
    for (let kunde of kunder) {
        document.write("Kundenavn: " + kunde.navn + "<br>");
        for (let ordre of kunde.ordre) {
            document.write("Ordre-dato: " + ordre.dato + "<br>");
            for (let ordreLinje of ordre.ordreLinjer) {
                document.write("Ordrelinje-antall: " + ordreLinje.antall + "<br>");
                document.write("Vare-navn: " + ordreLinje.vare.navn + "<br>");
            }
        }
    }

}

/*function skrivUt(kunder) {



   for (let kunde of kunder) {
        document.write("Kundenavn: " + kunde.navn + "<br>");
        for (let ordre of kunde.ordre) {
            document.write("Ordre-dato: " + ordre.dato + "<br>");
            for (let ordreLinje of ordre.ordreLinjer) {
                document.write("Ordrelinje-antall: " + ordreLinje.antall + "<br>");
                document.write("Vare-navn: " + ordreLinje.vare.navn + "<br>");
            }
    }
}

}*/
