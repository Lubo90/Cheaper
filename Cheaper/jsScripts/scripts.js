var webServiceUrl = "http://localhost:51129/Cheaper/WebService.asmx/";

$(function () {
    $(document).tooltip({
        track: true
    });

    $("#tbPurchaseDate").datepicker({dateFormat: 'yy-mm-dd'});
});

$(document).ready(function () {
    // inicjalizacja podpowiedzi dla nazwy produktu
    $("#tbProducts").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: false,
                url: webServiceUrl + "ProductsAutocomplete",
                data: JSON.stringify({ 'danePrzeslane': request.term }),
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        var splitted = item.split('~');
                        return {
                            id: splitted[0],
                            value: splitted[1]
                        };
                    }))
                },
                error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
            });
        },
        select: function (e, i) {
            $("#tbProducts").val(i.item.value);
            $("#tbProductsId").val(i.item.id);
        },
        minLength: 1
    });

    $("#tbShops").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: true,
                url: webServiceUrl + "ShopsAutocomplete",
                data: JSON.stringify({ 'danePrzeslane': request.term }),
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        var splitted = item.split('~');
                        if (splitted.length == 2) {
                            return {
                                id: splitted[0],
                                value: splitted[1]
                            };
                        }
                    }))
                },
                error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
            });
        },
        select: function (e, i) {
            $("#tbShops").val(i.item.value);
            $("#tbShopId").val(i.item.id);
        },
        minLength: 1
    });
});

function inicjuj() {
    $("#pupLogowanie").dialog({
        modal: true, autoOpen: false, width: 250, resizable: false, buttons: {
            "Zaloguj": function () { logIn(); }
        }
    });

    $("#pupNowyBudzet").dialog({
        modal: true, autoOpen: false, width: 250, resizable: false, buttons: {
            "Zapisz": function () { addBudget(); }
        }
    });

    $("#pupNowyProdukt").dialog({
        modal: true, autoOpen: false, width: 300, resizable: false, buttons: {
            "Zapisz": function () { addProduct(); }
        }
    });

    $("#pupKwotaKatWyd").dialog({
        modal: true, autoOpen: false, width: 250, resizable: false, buttons: {
            "Zapisz": function () { changeExpenseAmount(); }
        }
    });

    $("#pupNowaKatWyd").dialog({
        modal: true, autoOpen: false, width: 250, resizable: false, buttons: {
            "Zapisz": function () { addExpenseCategory(); }
        }
    });

    $("#pupNowySklep").dialog({
        modal: true, autoOpen: false, width: 250, resizable: false, buttons: {
            "Zapisz": function () { addShop(); }
        }
    });
}

function addShop() {
    var friendlyName = $("#tbShopFriendlyName").val();
    var ulica = $("#tbShopUlica").val();
    var miasto = $("#tbShopMiasto").val();
    var kodPocztowy = $("#tbShopKodPocztowy").val();

    $.ajax({
        type: "POST",
        async: true,
        url: webServiceUrl + "DodajSklep",
        data: JSON.stringify({
            'przyjaznaNazwa': friendlyName,
            'ulica': ulica,
            'miasto': miasto,
            'kodPocztowy': kodPocztowy
        }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == false)
                alert("Wystąpił błąd podczas dodawania sklepu.");
            else
                $("#pupNowySklep").dialog('close');
            //else if (data.d == true)
            //    location.reload();
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function addExpenseCategory() {
    var nazwaKat = $("#tbNazwaKatWyd").val();
    var kwotaKat = $("#tbKwotaKatWyd").val();

    $.ajax({
        type: "POST",
        async: true,
        url: webServiceUrl + "DodajKatWyd",
        data: JSON.stringify({
            'nazwaKat': nazwaKat,
            'kwotaKat': kwotaKat
        }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == false)
                alert("Wystąpił błąd podczas dodawania kategorii wydatków.");
            else if (data.d == true)
                location.reload();
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function changeExpenseAmount() {
    var kwota = $("#tbKwota").val();
    var idKat = $("#valExpenseCatId").val();

    $.ajax({
        type: "POST",
        async: true,
        url: webServiceUrl + "ZmienKwoteKatWyd",
        data: JSON.stringify({
            'kwota': kwota,
            'idKatWyd': idKat
        }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == false)
                alert("Wystąpił błąd podczas zmiany kwoty.");
            else if (data.d == true)
                location.reload();
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function addBudget() {
    var budgetName = $("#tbNazwaBudzetu").val();

    $.ajax({
        type: "POST",
        async: true,
        url: webServiceUrl + "DodajBudzet",
        data: JSON.stringify({ 'nazwaBudzetu': budgetName }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == false)
                alert("Wystąpił błąd podczas dodawania budżetu.");
            else if (data.d == true)
                location.reload();
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function addProduct() {
    var nazwaProduktu = $("#tbNazwaProduktu").val();
    var idKat = $("#ddlKategorie").val();

    $.ajax({
        type: "POST",
        async: true,
        url: webServiceUrl + "DodajProdukt",
        data: JSON.stringify({
            'nazwaProduktu' : nazwaProduktu,
            'idKategorii' : idKat
        }),
        dataType: "json",
        contentType: "application/json",
        context: $(this),
        success: function (data) {
            if (data.d == false)
                alert("Wystąpił błąd podczas dodawania produktu.");
            else
                $("#pupNowyProdukt").dialog('close');
            //else if (data.d == true)
            //    location.reload();
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function logIn() {
    var login = $("#tbbLogin").val();
    var pw = $("#tbbPassword").val();
    var loginAndPw = login + "~" + pw;

    $.ajax({
        type: "POST",
        url: webServiceUrl + "AuthorizeUser",
        data: JSON.stringify({ 'loginData': loginAndPw }),
        dataType: "json",
        contentType: "application/json",
        success: function (wynik) {
            if (wynik.d == true)
                location.reload();
            else {
                $("#trNieudaneLogowanie").show();
            }
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

function parseResult(wynik) {
    var indexStart = wynik.indexOf("\">") + 2;
    var indexStop = wynik.indexOf("</");

    return wynik.substr(indexStart, indexStop - indexStart);
}

function openKatWydPopUp(idKat) {
    $("#valExpenseCatId").val(idKat);
    $("#pupKwotaKatWyd").dialog("open");
}