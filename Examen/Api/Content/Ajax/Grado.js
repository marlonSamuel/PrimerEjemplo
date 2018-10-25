console.log("define grado ajax");

Grado = {
    Listar: function (callback) {
        $.ajax("/api/grado/get", {
            type: "GET",
            success: function (data) {
                if (typeof callback === 'function') {
                    callback(data);
                }

            }, error: function (data) {
                toastr.error("Error al obtener las categorias");
            }
        });
    },

    Guardar: function (grado, callback) {
        $.ajax("/api/grado/Guardar", {
            type: "POST",
            data: grado,
            success: function (data) {
                if (data != null) {
                    toastr.info("categoria guardada correctamente");

                }
                else {
                    toastr.error("Error al guardar");
                }
                if (typeof callback === 'function') {
                    callback(data);
                }
            },
            error: function (data) {
                toastr.error("Error al guardar");
            }
        });
    },

    Remover: function (grado, callback) {
        $.ajax("/api/grado/Remover?id=" + grado.gradoId, {
            type: "DELETE",
            data: grado,
            success: function (data) {
                if (data != null) {
                    toastr.info("categoria removida correctamente");

                }
                else {
                    toastr.error("Error al eliminar");
                }
                if (typeof callback === 'function') {
                    callback(data);
                }
            },
            error: function (data) {
                toastr.error("Error al eliminar");
            }
        });
    },


}