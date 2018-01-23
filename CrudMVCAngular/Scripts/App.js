var app = angular.module("crudApp", []);

app.controller("crudController", function ($scope, $http) {

    $http({
        method: 'GET',
        url: 'Home/GetAll'

    }).then(function (sucess) {
        $scope.items = sucess.data;
    }, function (error) {
        console.log(error.data);
    });

    $scope.Add = function (item) {
        $http({
            method: 'POST',
            url: 'Home/Add',
            data: {Name : item.NameItem}
        }).then(function (sucess) {
            $scope.items = sucess.data;
            delete $scope.item;
        }, function (error) {
            console.log(error.data);
        });
    }

    $scope.Delete = function (item) {
        $http({
            method: 'POST',
            url: 'Home/Delete',
            data: { item: item }
        }).then(function (sucess) {
            $scope.items = sucess.data;
        }, function (error) {
            console.log(error.data);
        });
    }
});