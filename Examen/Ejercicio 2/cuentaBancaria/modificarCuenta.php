<?php
include "cabecera.php";
	if(isset($_REQUEST["id"])){
		//echo $_REQUEST["id"]."prueba";
		include("conexion.php");
		//********************
		//MODIFICACION DE DATOS SEGUN EL ID
		$id_cuenta=$_REQUEST["id"];
		$consulta="SELECT * FROM cuenta WHERE id='$id_cuenta'";
		$resultado=mysqli_query($conexion, $consulta) or die ("No se ha podido ejecutar la consulta");
		$columna=mysqli_fetch_array($resultado);
		$id_per=$columna['persona_id'];
		$cons="SELECT * FROM persona where id ='".$id_per."'";
		$res=mysqli_query($conexion,$cons)or die("No se ha podido realizar la verificacion.");
		$col=mysqli_fetch_array($res);
		$nombre=$col['nombre']." ".$col['apellidop']." ".$col['apellidom'];
	}
?>
<h1>FORMULARIO ACTUALIZACION DE DATOS CUENTA</h1>
  <form action="actualizarCuenta.php">
    <label>ID Cliente: </label>
    <input type="text" name="id_per" value="<?php echo $id_per;?>" readonly="readonly">
    <label>Nombre cliente: </label>
    <input type="text" name="cliente" value="<?php 
      echo $nombre;
    ?>">
    <label>Número de Cuenta: </label>
    <input type="text" name="id_cuenta" value="<?php 
      echo $id_cuenta; 
    ?>" readonly="readonly">
    <label>Tipo de cuenta</label>
    <select name="tipocuenta">
      <option value="cuenta corriente" 
      <?php
                        if($columna['tipo_cuenta']=="cuenta de ahorro"){
                        	echo "selected='select'";
                        }
                    ?>
      >Cuenta corriente</option>
      <option value="cuenta de ahorro"
      <?php
                        if($columna['tipo_cuenta']=="cuenta de ahorro"){
                        	echo "selected='select'";
                        }
                    ?>
      >Cuenta de ahorro</option>
      <option value="cuenta de nomina"
      <?php
                        if($columna['tipo_cuenta']=="cuenta de ahorro"){
                        	echo "selected='select'";
                        }
                    ?>
      >Cuenta de nomina</option>
  </select>
  <label>Saldo: </label>
    <input type="text" name="saldo" value="<?php 
      echo $columna['saldo'];
    ?>">
    <input type="submit" value="ACTUALIZAR">
  </form>
	<form action="mostrar.php" method="REQUEST">
		<input type="submit" value="REGRESAR A LOS REGISTROS REGISTROS">
	</form>
<?php 
include "pie.php";
 ?>