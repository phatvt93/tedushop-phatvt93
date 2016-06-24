(function(app) {

    app.filter("statusFilter",
        function() {
            return function(input) {
                return input ? "Kích hoạt" : "Khóa";
            };
        });
})(angular.module("tedushop.common"));