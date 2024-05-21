-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 21 2024 г., 13:55
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `filmsNgenres`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Films`
--

CREATE TABLE `Films` (
  `Id` int NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Time` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Films`
--

INSERT INTO `Films` (`Id`, `Title`, `Date`, `Time`) VALUES
(1, 'Пиу', '2022-01-03', '12:30:00'),
(2, 'Лолипоп', '2024-05-23', '10:00:00');

-- --------------------------------------------------------

--
-- Структура таблицы `Genres`
--

CREATE TABLE `Genres` (
  `Id` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `FilmsId` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Genres`
--

INSERT INTO `Genres` (`Id`, `Name`, `FilmsId`) VALUES
(2, 'Боевик', 2);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Films`
--
ALTER TABLE `Films`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Genres`
--
ALTER TABLE `Genres`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FilmsId` (`FilmsId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Films`
--
ALTER TABLE `Films`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Genres`
--
ALTER TABLE `Genres`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Genres`
--
ALTER TABLE `Genres`
  ADD CONSTRAINT `genres_ibfk_1` FOREIGN KEY (`FilmsId`) REFERENCES `Films` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
