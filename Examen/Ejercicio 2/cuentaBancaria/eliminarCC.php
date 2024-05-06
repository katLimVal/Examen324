<?php 
include 'conexion.php';
if(isset($_REQUEST["id"])&&!empty($_REQUEST["id"])){
	$id=$_REQUEST["id"];
}
$cons="SELECT * FROM persona p JOIN cuenta cb ON p.id = cb.persona_id WHERE p.id ='".$id."'";
$verificando=mysqli_query($conexion,$cons)or die("No se ha podido realizar la verificacion.");
//ESTABLECEMOS CONEXION PARA MODIFICAR LOS DATOS
if($verificando->num_rows == 0){
	$consulta="DELETE FROM persona WHERE id='$id'";
	$resultado=mysqli_query($conexion,$consulta)or die("No se ha podido realizar el registro.");
	if($resultado){
		header("Location: mostrar.php?mensaje=" . urlencode("La eliminación se realizó correctamente")); 
	}else{
		echo "No se ha realizado la eliminacion";
	}
	
}else{
	header("Location: mostrar.php?mensaje=" . urlencode("No se puede realizar la eliminacion, la persona tiene registrada cuentas bancarias"));
}

?>