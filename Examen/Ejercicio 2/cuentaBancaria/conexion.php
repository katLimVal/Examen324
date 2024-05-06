<?php
$usuario="root";
$password="";
$servidor="localhost";
$basedatos="bdkatherine";
//CREACION DE LA CONEXION A LA BASE DE DATOS
$conexion=mysqli_connect($servidor,$usuario,$password) or die("No se ha podido conectar al servidor");
//CONSULTA A LA BASE DE DATOS A UTILIZAR
$db=mysqli_select_db($conexion,$basedatos)or die("No se ha podido conectar con la base de datos");
?>