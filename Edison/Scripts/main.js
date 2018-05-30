function getPsychics() {
    $("#psyarray").empty();
    $.ajax({
        dataType: "json",
        url: "/Home/GetPsychics"
    }).done(function(data) {
        data.forEach(function (item) {
            renderPsychics(item);
        });

    });

}

function renderPsychics(psy) {

    var container = $('<div>', { class: 'psycontainer' });
    container.append($('<div>', { class: 'headerpsy', text: psy.Name }));
    container.append($('<div>', { class: 'confidencepsy', text: 'Доверие: ' + psy.Confidence }));
    container.appendTo("#psyarray");
}

function renderPlayer(number) {

}

function addConfidence(id) {
    $.ajax({
        dataType: "json",
        url: "/Home/AddConfidence",
        data: { idPsychic: id }
        
    }).done(function() {
        getPsychics();
    });

}


function testPsy() {
    number = $("#playernumber").value;
    $.ajax({
        dataType: "json",
        url: "/Home/TestPsychics",
        data: { number: number }

    }).done(function () {
        getPsychics();
    });

}
function getPlayer() {
    $("#playernumbers").empty();
    $.ajax({
        dataType: "json",
        url: "/Home/GetPlayer"
    }).done(function (data) {
        data.forEach(function (item) {
            renderPlayer(item);
        });

    });

}
