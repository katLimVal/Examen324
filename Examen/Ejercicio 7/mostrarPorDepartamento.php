
<?php
//CONEXION CON BASE DE DATOS
include("conexion.php");
include("cabecera.php");
//********************
//CONEXION CON LA TABLA DE REGISTRO PARA MOSTRAR
$consulta="SELECT
    SUM(CASE WHEN per.departamento='La Paz' THEN c.saldo ELSE 0 END) AS `La Paz`,
    SUM(CASE WHEN per.departamento='Beni' THEN c.saldo ELSE 0 END) AS `Beni`,
    SUM(CASE WHEN per.departamento='Cochabamba' THEN c.saldo ELSE 0 END) AS `Cochabamba`,
    SUM(CASE WHEN per.departamento='Chuquisaca' THEN c.saldo ELSE 0 END) AS `Chuquisaca`,
    SUM(CASE WHEN per.departamento='Oruro' THEN c.saldo ELSE 0 END) AS `Oruro`,
    SUM(CASE WHEN per.departamento='Pando' THEN c.saldo ELSE 0 END) AS `Pando`,
    SUM(CASE WHEN per.departamento='Potosi' THEN c.saldo ELSE 0 END) AS `Potosi`,
    SUM(CASE WHEN per.departamento='Tarija' THEN c.saldo ELSE 0 END) AS `Tarija`,
    SUM(CASE WHEN per.departamento='Santa Cruz' THEN c.saldo ELSE 0 END) AS `Santa Cruz`
FROM persona per
INNER JOIN cuenta c ON per.id = c.persona_id;
";
$resultado=mysqli_query($conexion, $consulta)or die("No se ha podido mostrar la consulta.");

?>
<h1>DIRECTOR BANCARIO</h1>
<table border="1">
	<tr>
		<th>La Paz</th>
		<th>Beni</th>
		<th>Cochabamba</th>
		<th>Chuquisaca</th>
		<th>Oruro</th>
		<th>Pando</th>
		<th>Potosi</th>
		<th>Tarija</th>
		<th>Santa Cruz</th>
	</tr>
<?php
$columna=mysqli_fetch_array($resultado);
	echo "<tr>";
	echo "<td>".$columna['La Paz']."</td>";
	echo "<td>".$columna['Beni']."</td>";
	echo "<td>".$columna['Cochabamba']."</td>";
	echo "<td>".$columna['Chuquisaca']."</td>";
	echo "<td>".$columna['Oruro']."</td>";
	echo "<td>".$columna['Pando']."</td>";
	echo "<td>".$columna['Potosi']."</td>";
	echo "<td>".$columna['Tarija']."</td>";
	echo "<td>".$columna['Santa Cruz']."</td>";
	echo "</tr>";

?>	
</table>
<?php 
include("pie.php");
 ?>