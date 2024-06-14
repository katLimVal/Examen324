-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-06-2024 a las 22:19:00
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `ejercicio3`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `datos`
--

CREATE TABLE `datos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `R1` int(11) NOT NULL,
  `G1` int(11) NOT NULL,
  `B1` int(11) NOT NULL,
  `R2` int(11) NOT NULL,
  `G2` int(11) NOT NULL,
  `B2` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `datos`
--

INSERT INTO `datos` (`id`, `nombre`, `R1`, `G1`, `B1`, `R2`, `G2`, `B2`) VALUES
(2, 'plomo', 99, 109, 118, 79, 80, 65),
(3, 'plomo oscuro', 87, 97, 104, 30, 30, 26),
(4, 'plomo oscuro 1', 70, 72, 73, 19, 19, 16),
(5, 'plomo oscuro 2', 70, 72, 73, 9, 9, 9),
(9, 'tierra', 116, 87, 50, 52, 25, 6),
(11, 'mar', 29, 45, 60, 100, 220, 230),
(12, 'mar 1', 36, 60, 65, 20, 128, 137),
(13, 'mar 1', 72, 88, 39, 48, 96, 7),
(14, 'gris2', 222, 202, 176, 0, 0, 0),
(15, 'gris3', 81, 87, 91, 87, 91, 79),
(16, 'gris4', 120, 125, 129, 108, 112, 100),
(17, 'verde 1', 120, 139, 77, 127, 237, 86),
(18, 'lila', 160, 153, 197, 197, 86, 236),
(19, 'verde', 86, 102, 57, 0, 0, 0),
(20, 'rojo', 204, 116, 161, 255, 0, 0),
(21, 'rojo1', 234, 68, 52, 255, 0, 0),
(22, 'azul', 1, 102, 218, 0, 35, 255),
(23, 'verde 2', 0, 172, 72, 12, 160, 17),
(24, 'amarillo', 254, 185, 1, 231, 207, 5),
(25, 'bl1', 167, 169, 155, 138, 141, 136),
(26, 'arena', 179, 167, 135, 184, 177, 162),
(27, 'lila osc', 58, 31, 88, 47, 19, 72);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `datos`
--
ALTER TABLE `datos`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `datos`
--
ALTER TABLE `datos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
