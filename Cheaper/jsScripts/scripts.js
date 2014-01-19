var webServiceUrl = "http://localhost:51129/Cheaper/WebService.asmx/";
var shopAutocomplete = true;
var lastValShops = '';
var productsAutocomplete = true;
var lastValProducts = '';

var usernameOk = false;
var passwordOk = false;
var emailOk = false;
var birthDateOk = false;

$(function () {
    $(document).tooltip({
        track: true
    });

    $("#tbPurchaseDate").datepicker({ dateFormat: 'yy-mm-dd' });
    $("#tbBirthDate").datepicker({ dateFormat: 'yy-mm-dd' });
});

function ValidateUsername() {
    var login = $("#tbUserName").val();

    if (login.length < 4) {
        $("#usernameTooShort").show();
        $("#usernameAvailable").hide();
        $("#usernameTaken").hide();
        return;
    }
    else
        $("#usernameTooShort").hide();

    $.ajax({
        type: "POST",
        url: webServiceUrl + "ValidateUsername",
        data: JSON.stringify({ 'login': login }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == true) {
                usernameOk = true;
                $("#usernameAvailable").show();
                $("#usernameTaken").hide();
            }
            else {
                usernameOk = false;
                $("#usernameTaken").show();
                $("#usernameAvailable").hide();
            }
        }
    });
}
function ValidatePassword() {
    if ($("#tbPasswd").val().length < 6) {
        $("#passwordTooShort").show();
        passwordOk = false;
    }
    else {
        $("#passwordTooShort").hide();
        passwordOk = true;
    }
}
function ValidateEmail() {
    var email = $("#tbEmail").val();

    if (email.length < 5) {
        $("#emailNotValid").show();
        emailOk = false;
        return;
    }

    $.ajax({
        type: "POST",
        url: webServiceUrl + "ValidateEmail",
        data: JSON.stringify({ 'email': email }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == true) {
                emailOk = true;
                $("#emailNotValid").hide();
            }
            else {
                emailOk = false;
                $("#emailNotValid").show();
            }
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}
function ValidateBirthDate() {
    var birthDate = $("#tbBirthDate").val();

    if (birthDate.length < 10) {
        $("#birthDateNotValid").show();
        birthDateOk = false;
        return;
    }

    $.ajax({
        type: "POST",
        async:false,
        url: webServiceUrl + "ValidateBirthDate",
        data: JSON.stringify({ 'birthDate': birthDate }),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data.d == true) {
                birthDateOk = true;
                $("#birthDateNotValid").hide();
            }
            else {
                birthDateOk = false;
                $("#birthDateNotValid").show();
            }
        },
        error: function (a, b, c) { alert(a + "\n" + b + "\n" + c); }
    });
}

$(document).ready(function () {
    $("#usernameAvailable").hide();
    $("#usernameTaken").hide();
    $("#usernameTooShort").hide();
    $("#passwordTooShort").hide();
    $("#emailNotValid").hide();
    $("#birthDateNotValid").hide();

    $("#tbShops").on('change keyup paste mouseup', function () {
        if ($("#tbShops").val() != lastValShops && !shopAutocomplete) {
            lastValShops = $("#tbShops").val();
            $("#tbShopId").val('');
        }
        shopAutocomplete = false;
    });

    $("#tbProducts").on('change keyup paste mouseup', function () {
        if ($("#tbProducts").val() != lastValProducts && !productsAutocomplete) {
            lastValProducts = $("#tbProducts").val();
            $("#tbProductsId").val('');
        }
        productsAutocomplete = false;
    });

    $("#tbUserName").on('change keyup paste mouseup', function () {
        ValidateUsername();
    });

    $("#tbPasswd").on('change keyup paste mouseup', function () {
        ValidatePassword();
    });

    $("#tbEmail").on('change keyup paste mouseup', function () {
        ValidateEmail();
    });

    $("#tbBirthDate").on('change keyup paste mouseup', function () {
        ValidateBirthDate();
    });

    // inicjalizacja podpowiedzi dla nazwy produktu
    $("#tbProducts").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
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
            productsAutocomplete = true;
            $("#tbProducts").val(i.item.value);
            $("#tbProductsId").val(i.item.id);
        },
        minLength: 1
    });

    $("#tbShops").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
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
            shopAutocomplete = true;
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

    $("#pupRejestracja").dialog({
        modal: true, autoOpen: false, width: 350, resizable: true, buttons: {
            "Zarejestruj": function () { registerUser(); }
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

function registerUser() {
    var login = $("#tbUserName").val();
    var password = $("#tbPasswd").val();
    var email = $("#tbEmail").val();
    var birthDate = $("#tbBirthDate").val();
    var statsEnabled = $("#cboxStats").prop('checked');

    if (usernameOk == false || passwordOk == false || emailOk == false || birthDateOk == false)
        return;

    $.ajax({
        type: "POST",
        url: webServiceUrl + "RegisterUser",
        data: JSON.stringify({
            'login': login,
            'password': password,
            'email': email,
            'birthDate': birthDate,
            'statsEnabled': statsEnabled
        }),
        contentType: "application/json",
        success: function (wynik) {
            if (wynik.d == "ok") {
                alert("Zarejestrowałeś się.\nMożesz teraz zalogować się z użyciem wprowadzonych danych.");
                $("#pupRejestracja").dialog('close');
            }
            else if (wynik.d == "login")
                alert("Uzupełnij login");
            else if (wynik.d == "pw")
                alert("Uzupełnij hasło");
            else if (wynik.d == 'email')
                alert("Wprowadziłeś(aś) niepoprawny adres e-mail");
            else if (wynik.d == "birthDate")
                alert("Wprowadziłeś(aś) niepoprawną datę urodzenia");
            else if (wynik.d == "error")
                alert("Wystąpił błąd podczas rejestracji użytkownika");
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