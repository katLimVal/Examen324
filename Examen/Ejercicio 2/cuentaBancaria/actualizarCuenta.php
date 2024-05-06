<?php
include("conexion.php");
$existe_registro=false;
if( isset($_REQUEST["id_per"])&&!empty($_REQUEST["id_per"])
	&&isset($_REQUEST["id_cuenta"])&&!empty($_REQUEST["id_cuenta"])
&& isset($_REQUEST["tipocuenta"])&&!empty($_REQUEST["tipocuenta"])
&& isset($_REQUEST["saldo"])&&!empty($_REQUEST["saldo"])){
$id_cuenta=$_REQUEST["id_cuenta"];
$id_per=$_REQUEST["id_per"];
$tipocuenta=$_REQUEST["tipocuenta"];
$saldo=$_REQUEST["saldo"];
$existe_registro=true;
}
if($existe_registro){
	$consulta="UPDATE cuenta SET tipo_cuenta='$tipocuenta',saldo='$saldo' WHERE id=$id_cuenta";
	$resultado=mysqli_query($conexion,$consulta)or die("No se ha podido realizar el registro.");
	if($resultado){
		header("Location: mostrarCuenta.php?mensaje=" . urlencode("Se ha realizado la actualizacion de la cuenta"). "&id=" . urlencode($id_per)); 
	}else{
		header("Location: mostrar.php?mensaje=" . urlencode("No se ha realizado la actualizacion")); 
	}
}
?>