var enc, mensaje, hub;


$(function () {
    var hub = $.connection.dashboardHub;
    

    hub.client.updateInfo = function (data, inTopic) {
        document.querySelectorAll("[ID*=txtReceived]")[0].value = data;
        var D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14, D15, state;
        console.log("Topic: ", inTopic, "savedTopic: ", String(document.querySelectorAll("[ID*=txtData9]")[0].value), String(document.querySelectorAll("[ID*=txtData9]")[0].value) == inTopic);
        if (String(document.querySelectorAll("[ID*=txtData9]")[0].value) == inTopic) {
            try {
                mensaje = JSON.parse(data);
                D1 = mensaje.D1;
                D2 = mensaje.D2;
                D3 = mensaje.D3;
                D4 = mensaje.D4;
                D5 = mensaje.D5;
                D6 = mensaje.D6;
                D7 = mensaje.D7;
                D8 = mensaje.D8;
                D9 = mensaje.D9;
                D10 = mensaje.D10;
                D11 = mensaje.D11;
                D12 = mensaje.D12;
                D13 = mensaje.D13;
                D14 = mensaje.D14;
                D15 = mensaje.D15;

                state = mensaje.status;
            }
            catch (err) {
                console.log("Lecture failed: ", err);
            }
            finally {
                addData(temperaturesChart, "random", D1); //
                addData(temperaturesChart, "random", D2); //
                addData(temperaturesChart, "random", D3); //
                addData(temperaturesChart, "random", D4); //
                addData(temperaturesChart, "random", D5); //
                addData(temperaturesChart, "random", D6); //

                if (document.getElementById("corriente").className.includes("active")) {
                    addData(electricChart, "random", D8); //Corriente
                } else if (document.getElementById("voltaje").className.includes("active")) {
                    addData(electricChart, "random", D7); //Corriente
                } else if (document.getElementById("potencia").className.includes("active")) {
                    addData(electricChart, "random", D9); //Corriente
                }

            }
        }
    }


    $.connection.hub.start();




});