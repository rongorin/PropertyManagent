
//db services etc:
var InvoiceService = function () {

    var setInvoiceToPaid = function (invoiceId, success, failure) {
        var url = mtpApp.Urls.baseUrl + "/api/paid/";
        $.get(url + invoiceId)
            .done(success)
            .fail(failure); 
    }

    return {
        setInvoiceToPaid: setInvoiceToPaid
    }
}();
var housesController = function () { 
    var mySearchTerm;
    var mySearchingUrl;

    var init = function (sUrl) {

        mySearchingUrl = sUrl; 
        $('#SearchForm').submit(function (event) {
            event.preventDefault();
                    var form = $(this).parent("form");
                    console.log(mySearchingUrl);
                    console.log(window.location + "Index");
                    console.log(window.location + "  " + window.location.origin + "  " + window.location.host);
            mySearchTerm = $('#search-text').val();
            getHouses();
        }); 
    }; 

    var getHouses = function () {
        $.get(mySearchingUrl, { searchTerm: mySearchTerm })
            .done(function (data) {
                $('#housesListing').html(data);
            })
            .fail(fail);
    }
    var fail = function () {
        alert("Something Failed!!");
    }

    return {
        init: init
    }
}();

var InvoicesController = function (invoiceService) { 
    var button;
    var selectedRow
    var init = function () {   
        $(".js-toggle-paid").click(changeToPaid);
    };

    var changeToPaid = function (e) { 
         selectedRow = $(this).closest("tr");

        var amount = selectedRow.find('#Amount').text();
        var fullname = selectedRow.find('#Fullname').text();
     
        if (confirm("Are you sure the following invoice is paid?" + fullname + amount)) {
            button = $(e.target);
            setInvoiceToPaid(); 
        }
        else
            return false;
    }

    var setInvoiceToPaid = function () {
        var invId = button.attr("data-inv-id");
        invoiceService.setInvoiceToPaid(invId, success, fail); 
    }
    var fail = function () { 
            alert("Something Failed!!"); 
    }
    var success = function () {
        button
            .removeClass("btn-default")
            .removeClass("btn-info")
            .addClass("hide");
        selectedRow.find('#YesOrNo').text("Yes!");
        var refreshBut = $("#BtnRefresh");
        refreshBut.removeClass("hide");
    }
    return {
        init: init
    }
}(InvoiceService);


//function initialiseSearch() {
//    var mySearchingUrl = mtpApp.Urls.baseUrl + "House/Index";
//    $(function () {
//        $('#SearchForm').submit(function (event) {
//            event.preventDefault();
//            var form = $(this).parent("form");
//            console.log(mySearchingUrl);
//            console.log(window.location + "Index");
//            console.log(window.location + "  " + window.location.origin + "  " + window.location.host);
//            var mySearchTerm = $('#search-text').val();
//            getHouses(mySearchTerm);
//        });
//    });

//    var getHouses = function (search) {
//        $.get(mySearchingUrl, { searchTerm: search })
//            .done(function (data) {
//                $('#housesListing').html(data);
//            })
//            .fail(function (data) {
//                alert("Something Failed!!");
//            });
//    }

//}



