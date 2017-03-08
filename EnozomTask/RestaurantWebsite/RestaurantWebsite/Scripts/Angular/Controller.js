app.controller("myCntrl", function ($scope, myService) {
    $scope.divStore = false;
    GetAllStores();



    //To Get All Records 
    function GetAllStores() {
       
       
        var getData = myService.getStores();

        getData.then(function (store) {
            console.log(store.data);
            $scope.Stores = store.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editStore = function (Store) {
      
            $scope.StoreId = Store.StoreId;
            $scope.StoreName = Store.StoreName;
            $scope.StoreDescription = Store.StoreDescription;        
            $scope.StoreLogo = Store.StoreLogo;
            $scope.Action = "Update";
            $scope.divStore = true;
    }


    $scope.AddUpdateStore = function () {
     
        var Store = {
            StoreName: $scope.StoreName,
            StoreDescription: $scope.StoreDescription,
            StoreLogo: $scope.StoreLogo
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Store.StoreId = $scope.StoreId;
            var getData = myService.updateStore(Store);
            getData.then(function (msg) {
                GetAllStores();
                alert(msg.data);
                $scope.divStore = false;
            }, function () {
                alert('Error in updating record');
            });
        } else {
            
            var getData = myService.AddStore(Store);
            getData.then(function (msg) {
                GetAllStores();
                alert(msg.data);
                $scope.divStore = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.AddStoreDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divStore = true;
    }

    $scope.deleteStore = function (Store) {
        var getData = myService.DeleteStore(Store.StoreId);
        getData.then(function (msg) {
            GetAllStores();
            alert('Store Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.StoreId = "";
        $scope.StoreName = "";
        $scope.StoreDescription = "";
        $scope.StoreLogo = "";
    }
});


