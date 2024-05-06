<?php 
include 'conexion.php';
if(isset($_REQUEST["id"])&&!empty($_REQUEST["id"])){
	$id=$_REQUEST["id"];
}
	$cons="select * FROM cuenta WHERE id='$id'";
	$res=mysqli_query($conexion,$cons)or die("No se ha podido realizar la consulta.");
	$columna=mysqli_fetch_array($res);
	$id_per=$columna['persona_id'];
	$consulta="DELETE FROM cuenta WHERE id='$id'";
	$resultado=mysqli_query($conexion,$consulta)or die("No se ha podido realizar el registro.");
	if($resultado){
		header("Location: mostrarCuenta.php?mensaje=" . urlencode("Se ha realizado la actualizacion de la cuenta"). "&id=" . urlencode($id_per)); 
	}else{
		header("Location: mostrarCuenta.php?mensaje=" . urlencode("No se ha realizado la actualizacion de la cuenta"). "&id=" . urlencode($id_per));
	}
?>