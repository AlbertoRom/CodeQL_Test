const express = require('express');
const app = express();

app.get('/ejecutar', (req, res) => {
  // FUENTE: Un parámetro que viene directamente de la URL
  const codigoSucio = req.query.cmd;

  // SUMIDERO: La función eval() es extremadamente peligrosa.
  // CodeQL detectará que cualquier usuario puede enviar código JS 
  // en la URL y ejecutarlo en tu servidor.
  const resultado = eval(codigoSucio); 

  res.send('Resultado: ' + resultado);
});

app.listen(3000);