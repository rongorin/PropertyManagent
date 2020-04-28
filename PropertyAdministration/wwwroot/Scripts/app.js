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
            .fail(function (data) {
                alert("Something Failed!!");
            });
    }

    return {
        init: init
    }
}();
 

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



