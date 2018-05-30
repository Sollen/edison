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
    container.append($('</br>'));
    container.append($('<div>', { class: 'headerpsy', text: psy.Name }));
    container.append($('<div>', { class: 'confidencepsy', text: 'Доверие: ' + psy.Confidence }));
    container.append($('<p>', {  text: 'Предсказания экстрасенса:' }));
    container.append($('<div>', { class: 'predaction', id:"predactionpsy"+psy.Id}));
    container.appendTo("#psyarray");
    psy.Prediction.forEach(function (item) {
        var psyid = "#predactionpsy" + psy.Id;
        var text = $(psyid).text();
        text = text + ' ' + item;
        $(psyid).text(text);
    });
}

function renderPlayer(number) {
    var text = $("#playernumbers").text();
    text = text + ' ' + number;
    $("#playernumbers").text(text);
}




function testPsy() {
    var number = $("#inputnumber").val();
    $.ajax({
        dataType: "json",
        url: "/Home/TestPsychics",
        data: { number: number }
    }).done(function (data) {
        $("#error").text('');
        $("#inputnumber").val('00');
        if (data != 0) {
            $("#error").text(data);
        } else {
            getPsychics();
            getPlayer();
        }
        
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
