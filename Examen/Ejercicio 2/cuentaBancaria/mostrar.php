
<?php
include 'cabecera.php';
$existe_registro=false;
if(isset($_REQUEST["nombre"])&&!empty($_REQUEST["nombre"])
&& isset($_REQUEST["apellidop"])&&!empty($_REQUEST["apellidop"])
&& isset($_REQUEST["apellidom"])&&!empty($_REQUEST["apellidom"])
&& isset($_REQUEST["ci"])&&!empty($_REQUEST["ci"])){
$nombre=$_REQUEST["nombre"];
$apellidop=$_REQUEST["apellidop"];
$apellidom=$_REQUEST["apellidom"];
$ci=$_REQUEST["ci"];
$existe_registro=true;
}
//CONEXION CON BASE DE DATOS
include("conexion.php");
//ESTABLECEMOS CONEXION PARA INSERTAR DATOS
if($existe_registro){
	$consulta_registro="INSERT INTO persona(nombre,apellidop,apellidom,ci) VALUES ('$nombre','$apellidop','$apellidom','$ci')";
	$resultado=mysqli_query($conexion,$consulta_registro)or die("No se ha podido realizar el registro.");
}
//********************
//CONEXION CON LA TABLA DE REGISTRO PARA MOSTRAR
$consulta="SELECT * FROM persona";
$resultado=mysqli_query($conexion, $consulta)or die("No se ha podido mostrar la consulta.");

// mensaje de eliminacion y actualizacion
if (isset($_GET['mensaje'])) {
    $mensaje = $_GET['mensaje'];
    echo "<script>alert('$mensaje');</script>";
}
?>
<h1>MOSTRAR REGISTROS</h1>
<table border="1">
	<tr>
		<th>ID</th>
		<th>Nombre</th>
		<th>Apellido Paterno</th>
		<th>Apellido Materno</th>
		<th>CI</th>
		<th colspan="2">OPERACIONES</th>
		<th colspan="2">OPERACIONES CUENTA</th>
	</tr>
<?php
while($columna=mysqli_fetch_array($resultado)){
	echo "<tr>";
	echo "<td>".$columna['id']."</td>";
	echo "<td>".$columna['nombre']."</td>";
	echo "<td>".$columna['apellidop']."</td>";
	echo "<td>".$columna['apellidom']."</td>";
	echo "<td>".$columna['ci']."</td>";
	$id=$columna['id'];
	echo "<td> <a class='actualizar' href='modificarCC.php?id=$id'>ACTUALIZAR</a></td>";
	echo "<td> <a class='eliminar' href='eliminarCC.php?id=$id'>ELIMINAR</a></td>";
	echo "<td> <a class='opcuenta' href='añadirCuenta.php?id=$id'>Añadir Cuenta</a></td>";
	echo "<td> <a class='opcuenta' href='mostrarCuenta.php?id=$id'>Ver cuentas</a></td>";
	echo "</tr>";
}
?>	
</table>
<?php 
include("pie.php");
 ?>