
<?php
include 'cabecera.php';
$existe_registro=false;
if(isset($_REQUEST["id"])&&!empty($_REQUEST["id"])
&& isset($_REQUEST["tipocuenta"])&&!empty($_REQUEST["tipocuenta"])){

$tipocuenta=$_REQUEST["tipocuenta"];
$existe_registro=true;
}
$id=$_REQUEST["id"];
//CONEXION CON BASE DE DATOS
include("conexion.php");
//ESTABLECEMOS CONEXION PARA INSERTAR DATOS
if($existe_registro){
	$consulta_registro="INSERT INTO cuenta (persona_id,tipo_cuenta,saldo) VALUES ('$id','$tipocuenta',0)";
	$resultado=mysqli_query($conexion,$consulta_registro)or die("No se ha podido realizar el registro.");
}
//********************
//CONEXION CON LA TABLA DE REGISTRO PARA MOSTRAR
$consulta="SELECT c.id,p.nombre,p.apellidop,p.apellidom,p.ci,c.tipo_cuenta,c.saldo FROM cuenta c join persona p on c.persona_id=p.id where p.id='".$id."'";
$resultado=mysqli_query($conexion, $consulta)or die("No se ha podido mostrar la consulta.");

// mensaje de eliminacion y actualizacion
if (isset($_GET['mensaje'])) {
    $mensaje = $_GET['mensaje'];
    echo "<script>alert('$mensaje');</script>";
}
?>
<h1>MOSTRAR CUENTAS</h1>
<table border="1">
	<tr>
		<th>Nro. Cuenta</th>
		<th>Nombre cliente</th>
		<th>CI</th>
		<th>Tipo cuenta</th>
		<th>Saldo</th>
		<th colspan="2">OPERACIONES</th>	
	</tr>
<?php
while($columna=mysqli_fetch_array($resultado)){
	$clienten=" ".$columna['nombre']." ".$columna['apellidop']." ".$columna['apellidom']." ";
	echo "<tr>";
	echo "<td>".$columna['id']."</td>";
	echo "<td>".$clienten."</td>";
	echo "<td>".$columna['ci']."</td>";
	echo "<td>".$columna['tipo_cuenta']."</td>";
	echo "<td>".$columna['saldo']."</td>";
	$idCuenta=$columna['id'];
	echo "<td> <a class='actualizar' href='modificarCuenta.php?id=$idCuenta'>ACTUALIZAR</a></td>";
	echo "<td> <a class='eliminar' href='eliminarCuenta.php?id=$idCuenta'>ELIMINAR</a></td>";
	echo "</tr>";
}
?>

</table>
<form action="mostrar.php"><input type="submit" name="Finalizar" value="Regresar"></form>

<?php 
include("pie.php");
 ?>