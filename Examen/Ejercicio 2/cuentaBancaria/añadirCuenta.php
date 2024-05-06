<?php 
include("cabecera.php");
include 'conexion.php';
if(isset($_REQUEST["id"])&&!empty($_REQUEST["id"])){
  $id=$_REQUEST["id"];
}
$cons="SELECT * FROM persona where id ='".$id."'";
$resultado=mysqli_query($conexion,$cons)or die("No se ha podido realizar la verificacion.");
$columna=mysqli_fetch_array($resultado);
$nombre=$columna['nombre']." ".$columna['apellidop']." ".$columna['apellidom'];
 ?>
<div>
  <h2>Registro Cuenta Nueva</h2>
  <form action="mostrarCuenta.php">
    <label>ID Cliente: </label>
    <input type="text" name="id" value="<?php echo $id?>" readonly="readonly">
    <label>Nombre cliente: </label>
    <input type="text" name="cliente" value="<?php 
      echo $nombre;
    ?>">
    <label>Tipo de cuenta</label>
    <select name="tipocuenta">
      <option value="cuenta corriente">Cuenta corriente</option>
      <option value="cuenta de ahorro">Cuenta de ahorro</option>
      <option value="cuenta de nomina">Cuenta de nomina</option>
  </select>
    <input type="submit" value="REGISTRAR">
  </form>
</div>
 <?php 
include("pie.php");
 ?>
