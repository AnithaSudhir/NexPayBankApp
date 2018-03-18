angular.module('App', ['AngularDemo.AddBankController'])

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Home/AddBankAccount',
        controller: 'BankAddCtrl',
    });
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(false).hashPrefix('!');

}]);

//Add Bank details Controller
angular.module('AngularDemo.AddBankController', ['ngRoute'])
.controller('BankAddCtrl', function ($scope, $http) {

    $scope.BankDetailsList = {};
    $http.get('/Home/GetBankDetails').success(function (data) {
        $scope.BankDetailsList = data;
      
    });


    $scope.BankModel =
     {
         BSB: '',
         AccountNumber: '',
            AccountName: '',
            Reference: '',
            PaymentAmount: ''
     };

  

    $scope.AddBankAccount = function () {
        //debugger;
        $.ajax({
            url: '/Home/AddBankDetails',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            traditional: true,
            data: JSON.stringify({ BankModelClient: $scope.BankModel }),
            success: function (data) {
                $scope.BankDetailsList.push(data[0]);
                $scope.$apply();
                $scope.BankModel = '';               
                alert("Record is been added");
               
            }
        });
    };
});



