function register() {
    var FirstName = $("#nome").val();
    var LastName = $("#cognome").val();
    var username = $("#username").val();
    var email = $("#email").val();
    var PhoneNumber = $("#telefono").val();
    var password = $("#password").val();

    var body = {};
    body.FirstName = FirstName;
    body.LastName = LastName;
    body.username = username;
    body.email = email;
    body.PhoneNumber = PhoneNumber;
    body.password = password;
    $.ajax({
        method: "POST",
        url: "/Home/Register",


        data: body,

        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
}

function prenota(CurrentUser) {
    var suiteFlag = "";
    var setFlag = "";
    var currentUserName = CurrentUser.user;
    var suite1 = $("#suite1").is(":checked");
    var suite2 = $("#suite2").is(":checked");
    if (suite1 == true) {
        suiteFlag = "Silver";
    }
    else {
        suiteFlag = "Gold";
    }
    var set1 = $("#set1").is(":checked");
    var set2 = $("#set2").is(":checked");
    var set3 = $("#set3").is(":checked");
    var set4 = $("#set4").is(":checked");

    if (set1 == true) {
        setFlag = "1"
    }
    else if (set2 == true) {
        setFlag = "2"
    }
    else if (set3 == true) {
        setFlag = "3"
    }
    else {
        setFlag = "4"
    }
    var body = {};
    body.IdUser = currentUserName;
    body.Suite = suiteFlag;
    body.Week = setFlag;
    $.ajax({
        method: "POST",
        url: "/api/Prenotaz",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
}