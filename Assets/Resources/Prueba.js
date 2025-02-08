const promesa = new Promise((resolve, reject) => {
    setTimeout(() => {
        let exito = true;
        if (exito) {
            resolve("Operación exitosa!");
        } else {
            reject("Hubo un error.");
        }
    }, 2000);
});

promesa
    .then(resultado => console.log(resultado)) // Si se cumple
    .catch(error => console.log(error)); // Si falla