<?php 
include("cabecera.php");
 ?>
<div>
  <h2>Registro Cliente</h2>
  <form action="mostrar.php">
    <label>Nombres: </label>
    <input type="text" name="nombre">

    <label>Apellido Paterno: </label>
    <input type="text" name="apellidop">

    <label>Apellido Materno</label>
    <input type="text" name="apellidom">
    <label>Número CI:</label>
    <input type="text" name="ci">
    <input type="submit" value="REGISTRAR">
  </form>
</div>
 <?php 
include("pie.php");
 ?>
