app.service("myService", function ($http) {

    //get All Stores
    this.getStores = function () {
       
        return $http.get("http://localhost:13489/api/Stores/getAll");
       
    };

  

    // Update Store
    this.updateStore = function (Store) {
        var response = $http({
            method: "put",
            url: "http://localhost:13489/api/Stores/UpdateStore"+Store,
            data: JSON.stringify(Store),
            dataType: "json"
        });
        return response;
    }

    // Add Store
    this.AddStore = function (Store) {
      
        var response = $http({
            method: "post",
            url: "http://localhost:13489/api/Stores/AddStore"+Store,
            data: JSON.stringify(Store),
            dataType: "json"
        });
        return response;
    }

    //Delete Store
    this.DeleteStore = function (StoreId) {
        var response = $http({
            method: "delete",
            url: "http://localhost:13489/api/Stores/DeleteStore"+ StoreId ,
            params: {
                StoreId: JSON.stringify(StoreId)
            }
        });
        return response;
    }
})