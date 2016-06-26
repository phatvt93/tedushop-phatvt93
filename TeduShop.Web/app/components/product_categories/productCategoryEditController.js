(function (app) {

    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update',
                $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
                    $state.go('product_categories');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents',
                null,
                function (result) {
                    $scope.parentCategories = result.data;
                },
                function () {
                    console.log('Cannot get list parent');
                });
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id,
                null,
                function(result) {
                    $scope.productCategory = result.data;
                }, function(error) {
                    notificationService.displayError(error);
                });
        }

        loadParentCategory();
        loadProductCategoryDetail();
    }

})(angular.module('tedushop.product_categories'));