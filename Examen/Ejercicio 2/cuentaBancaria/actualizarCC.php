<?php
include("conexion.php");
$existe_registro=false;
if(isset($_REQUEST["nombre"])&&!empty($_REQUEST["nombre"])
&& isset($_REQUEST["apellidop"])&&!empty($_REQUEST["apellidop"])
&& isset($_REQUEST["apellidom"])&&!empty($_REQUEST["apellidom"])
&& isset($_REQUEST["ci"])&&!empty($_REQUEST["ci"])){
$id=$_REQUEST["id"];
$nombre=$_REQUEST["nombre"];
$apellidop=$_REQUEST["apellidop"];
$apellidom=$_REQUEST["apellidom"];
$ci=$_REQUEST["ci"];
$existe_registro=true;
}
if($existe_registro){
	$consulta="UPDATE persona SET nombre='$nombre',apellidop='$apellidop',apellidom='$apellidom',ci='$ci' WHERE id=$id";
	$resultado=mysqli_query($conexion,$consulta)or die("No se ha podido realizar el registro.");
	if($resultado){
		header("Location: mostrar.php?mensaje=" . urlencode("Datos Actualizados")); 
	}else{
		header("Location: mostrar.php?mensaje=" . urlencode("No se ha realizado la actualizacion")); 
	}
}
?>