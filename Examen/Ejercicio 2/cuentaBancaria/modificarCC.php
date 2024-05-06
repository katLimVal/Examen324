<?php
include "cabecera.php";
	if(isset($_REQUEST["id"])){
		//echo $_REQUEST["id"]."prueba";
		include("conexion.php");
		//********************
		//MODIFICACION DE DATOS SEGUN EL ID
		$id=$_REQUEST["id"];
		$consulta="SELECT * FROM persona WHERE id='$id'";
		$resultado=mysqli_query($conexion, $consulta) or die ("No se ha podido ejecutar la consulta");
		$columna=mysqli_fetch_array($resultado);
	}
?>
<h1>FORMULARIO ACTUALIZACION DE DATOS</h1>
        <form action="actualizarCC.php" method="REQUEST">
        		<label>CI: </label>
			    <input type="text" name="id" value="<?php echo $columna['id']; ?>" readonly="readonly">
			    <label>Nombres: </label>
			    <input type="text" name="nombre" value="<?php echo $columna['nombre']; ?>">

			    <label>Apellido Paterno: </label>
			    <input type="text" name="apellidop" value="<?php echo $columna['apellidop']; ?>">

			    <label>Apellido Materno</label>
			    <input type="text" name="apellidom" value="<?php echo $columna['apellidom']; ?>">
			    <label>Número CI:</label>
			    <input type="text" name="ci" value="<?php echo $columna['ci']; ?>">
			    <input type="submit" value="MODIFICAR">
        </form>
	<form action="mostrar.php" method="REQUEST">
		<input type="submit" value="REGRESAR A LOS REGISTROS REGISTROS">
	</form>
<?php 
include "pie.php";
 ?>