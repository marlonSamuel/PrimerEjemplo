console.log("Define grado ");


model.gradoController = {

    grado: {
        gradoId: ko.observable(""),
        nombre: ko.observable(""),
    },

    grados: ko.observableArray([]),
    insertMode: ko.observable(false),
    gridMode: ko.observable(true),


    mapGrado: function (grado) {
        var eGrado = model.gradoController.grado;
        eGrado.gradoId(grado.gradoId);
        eGrado.nombre(grado.nombre);
    },

    nuevo: function () {
        var grado = {
            gradoId: "",
            grado: "",
        };


        model.gradoController.mapGrado(grado);

        model.gradoController.insertMode(true);
        model.gradoController.gridMode(false);
    },


    editar: function (grado) {

        model.gradoController.mapGrado(grado);

        model.gradoController.gridMode(false);
        model.gradoController.insertMode(true);
    },

    guardar: function () {

        var grado = model.gradoController.grado;
        var gradoParam = ko.toJS(grado);

        if (!model.validateForm('#gradoForm')) {
            return;
        }
        //call api save
        Grado.Guardar(gradoParam, function (data) {

            console.log(data);
            toastr.info(data.response);
        });
    },

    remover: function (grado) {
        bootbox.confirm("¿Esta seguro que quiere remover curso " + grado.nombre + "?", function (result) {
            if (result) {
                //call api remove
                Grado.Remover(grado, function (data) {
                    model.gradoController.initialize();
                });
            }
        })
    },

    cancelar: function () {
        model.gradoController.insertMode(false);
        model.gradoController.gridMode(true);

        model.clearErrorMessage('#cursoForm');
    },


    initialize: function () {
        var self = this;
        var grados = this.grados();

        Grado.Listar(function (data) {
            grados = data;
            model.gradoController.grados(grados);
        });
    }
};