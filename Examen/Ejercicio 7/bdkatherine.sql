-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-05-2024 a las 08:41:01
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
-- Base de datos: `bdkatherine`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `id` int(11) NOT NULL,
  `persona_id` int(11) DEFAULT NULL,
  `tipo_cuenta` varchar(50) DEFAULT NULL,
  `saldo` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cuenta`
--

INSERT INTO `cuenta` (`id`, `persona_id`, `tipo_cuenta`, `saldo`) VALUES
(1001, 2, 'cuenta ahorro', 300),
(1006, 3, 'cuenta de ahorro', 45),
(1012, 2, 'cuenta de ahorro', 0),
(1014, 5, 'cuenta de ahorro', 5000),
(1015, 5, 'cuenta de nomina', 60521),
(1016, 4, 'cuenta de ahorro', 200),
(1017, 3, 'cuenta corriente', 4000),
(1033, 1, 'cuenta corriente', 1000),
(1034, 2, 'cuenta de ahorro', 2500),
(1035, 3, 'cuenta de nomina', 5000),
(1036, 4, 'cuenta corriente', 300),
(1037, 5, 'cuenta de ahorro', 10000),
(1038, 12, 'cuenta de nomina', 7000),
(1039, 12, 'cuenta corriente', 1500),
(1040, 13, 'cuenta de ahorro', 4000),
(1041, 15, 'cuenta de nomina', 2000),
(1042, 18, 'cuenta corriente', 200),
(1043, 20, 'cuenta de ahorro', 1500),
(1044, 21, 'cuenta de nomina', 3000),
(1045, 19, 'cuenta corriente', 700),
(1046, 20, 'cuenta de ahorro', 2500),
(1047, 21, 'cuenta de nomina', 6000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `apellidop` varchar(100) DEFAULT NULL,
  `apellidom` varchar(100) DEFAULT NULL,
  `ci` int(11) DEFAULT NULL,
  `departamento` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`id`, `nombre`, `apellidop`, `apellidom`, `ci`, `departamento`) VALUES
(1, 'Katherine Esther', 'Limachi', 'Valdivia', 46545645, 'Oruro'),
(2, 'Maria', 'Laura', 'Torrez', 15615615, 'Chuquisaca'),
(3, 'Lucia', 'Carrasco', 'Gutierrez', 2298136, 'Beni'),
(4, 'Marco', 'Sanchez', 'Perez', 368569788, 'Potosi'),
(5, 'Raul', 'Flores', 'Jimenez', 2159489, 'Tarija'),
(12, 'Juan', 'Martínez', 'López', 123456, 'La Paz'),
(13, 'María', 'García', 'Pérez', 789012, 'Santa Cruz'),
(14, 'Pedro', 'Chávez', 'Sánchez', 345678, 'Cochabamba'),
(15, 'Ana', 'Rodríguez', 'Gómez', 901234, 'La Paz'),
(16, 'Luis', 'López', 'Hernández', 567890, 'Santa Cruz'),
(17, 'Carla', 'Fernández', 'Martínez', 234567, 'Cochabamba'),
(18, 'José', 'Sánchez', 'González', 890123, 'La Paz'),
(19, 'Sofía', 'Martínez', 'Gómez', 456789, 'Santa Cruz'),
(20, 'Diego', 'Gómez', 'Fernández', 123890, 'Cochabamba'),
(21, 'Laura', 'Pérez', 'García', 678901, 'La Paz');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `transaccion`
--

CREATE TABLE `transaccion` (
  `id` int(11) NOT NULL,
  `cuenta_origen_id` int(11) DEFAULT NULL,
  `cuenta_destino_id` int(11) DEFAULT NULL,
  `monto` float DEFAULT NULL,
  `fecha` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `persona_id` (`persona_id`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `transaccion`
--
ALTER TABLE `transaccion`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cuenta_origen_id` (`cuenta_origen_id`),
  ADD KEY `cuenta_destino_id` (`cuenta_destino_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1048;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `transaccion`
--
ALTER TABLE `transaccion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`persona_id`) REFERENCES `persona` (`id`);

--
-- Filtros para la tabla `transaccion`
--
ALTER TABLE `transaccion`
  ADD CONSTRAINT `transaccion_ibfk_1` FOREIGN KEY (`cuenta_origen_id`) REFERENCES `cuenta` (`id`),
  ADD CONSTRAINT `transaccion_ibfk_2` FOREIGN KEY (`cuenta_destino_id`) REFERENCES `cuenta` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
