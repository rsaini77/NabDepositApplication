
var depositsModule = (function () {

    function init(element) {
        $.ajax({
            url: "/api/Deposits"
        }).done(render);

        function render(deposits) {
            var depositCount = 0.0;
            deposits.forEach(function (deposit) {
                depositCount = BuildTableRows(deposit, depositCount);
            });
        }
    }

    function buy() {
        var select = document.getElementById('depositoptions');
        var value = select.options[select.selectedIndex].value;
        if (value == "1") {
            return;
        }

        if (value == 2) {
            $.ajax({
                url: "/api/Deposits/Buy",
                dataType: "JSON"
            }).done(render);
        }
        if (value == 3) {
            $.ajax({
                url: "/api/Deposits/Sell",
                dataType: "JSON"
            }).done(render);
        }

        function render(deposits) {
            var depositCount = 0;
            deposits.forEach(function (deposit) {
                //deposit one bind with dropdown button
                depositCount = BuildTableRows(deposit, depositCount);
                
            });
        }
    }

    function BuildTableRows(deposit, depositCount) {
        var tableRow = "<tr><td>" + deposit.Principal + "</td><td><b>" + deposit.StartDate + "</b></td><td><b>" + deposit.EndDate + "</b></td><td><b>" + deposit.InterestRate + "</b></td><td><b>" + deposit.Term + "</b></td><td>" + deposit.MaturityAmount + "</td></tr>";
        $("#deposits").find("table").append(tableRow);
        depositCount += deposit.MaturityAmount;
        
        $('#deposittotal').html(depositCount);
        return depositCount;
    }

    return {
        init: init,
        Buy: buy

    };
})();



$(document).ready(function () {
    //Load Deposits on page Load Event
    depositsModule.init($("#deposits"));

    $(document).on("input", "#txt_Qty", function () {
        this.value = this.value.replace(/\D/g, '');
    });

    $("input[name=deposits]").click(function () {
        if ($(this).attr("data-qty") <= 0) {
            $("#btn_Sell").attr("disabled", "disabled");
        } else {
            $("#btn_Sell").removeAttr("disabled");
        }
    });

});


