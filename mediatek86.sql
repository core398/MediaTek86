-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 20 avr. 2026 à 18:02
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dateDebut` date NOT NULL,
  `dateFin` date NOT NULL,
  `idPersonnel` int DEFAULT NULL,
  `idMotif` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idPersonnel` (`idPersonnel`),
  KEY `idMotif` (`idMotif`)
) ENGINE=MyISAM AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`id`, `dateDebut`, `dateFin`, `idPersonnel`, `idMotif`) VALUES
(1, '2024-01-02', '2024-01-05', 1, 1),
(2, '2024-01-08', '2024-01-10', 2, 2),
(3, '2024-01-15', '2024-01-19', 3, 3),
(4, '2024-01-22', '2024-01-26', 4, 4),
(5, '2024-02-01', '2024-02-02', 5, 1),
(6, '2024-02-05', '2024-02-09', 6, 2),
(7, '2024-02-12', '2024-02-16', 7, 3),
(8, '2024-02-19', '2024-02-23', 8, 4),
(9, '2024-03-01', '2024-03-05', 9, 1),
(10, '2024-03-11', '2024-03-15', 10, 2),
(11, '2024-03-18', '2024-03-22', 1, 3),
(12, '2024-04-01', '2024-04-05', 2, 4),
(13, '2024-04-08', '2024-04-12', 3, 1),
(14, '2024-04-15', '2024-04-19', 4, 2),
(15, '2024-04-22', '2024-04-26', 5, 3),
(16, '2024-05-02', '2024-05-03', 6, 4),
(17, '2024-05-06', '2024-05-10', 7, 1),
(18, '2024-05-13', '2024-05-17', 8, 2),
(19, '2024-05-20', '2024-05-24', 9, 3),
(20, '2024-06-03', '2024-06-07', 10, 4),
(21, '2024-06-10', '2024-06-14', 1, 1),
(22, '2024-06-17', '2024-06-21', 2, 2),
(23, '2024-07-01', '2024-07-12', 3, 1),
(24, '2024-07-15', '2024-07-26', 4, 1),
(25, '2024-07-01', '2024-07-05', 5, 1),
(26, '2024-08-01', '2024-08-16', 6, 1),
(27, '2024-08-19', '2024-08-30', 7, 1),
(28, '2024-08-01', '2024-08-09', 8, 1),
(29, '2024-09-02', '2024-09-06', 9, 2),
(30, '2024-09-09', '2024-09-13', 10, 3),
(31, '2024-09-16', '2024-09-20', 1, 4),
(32, '2024-10-01', '2024-10-04', 2, 1),
(33, '2024-10-07', '2024-10-11', 3, 2),
(34, '2024-10-14', '2024-10-18', 4, 3),
(35, '2024-10-21', '2024-10-25', 5, 4),
(36, '2024-11-04', '2024-11-08', 6, 1),
(37, '2024-11-12', '2024-11-15', 7, 2),
(38, '2024-11-18', '2024-11-22', 8, 3),
(39, '2024-12-02', '2024-12-06', 9, 4),
(40, '2024-12-09', '2024-12-13', 10, 1),
(41, '2024-12-16', '2024-12-20', 1, 2),
(42, '2025-01-06', '2025-01-10', 2, 3),
(43, '2025-01-13', '2025-01-17', 3, 4),
(44, '2025-02-03', '2025-02-07', 4, 1),
(45, '2025-02-10', '2025-02-14', 5, 2),
(46, '2025-03-03', '2025-03-07', 6, 3),
(47, '2025-03-10', '2025-03-14', 7, 4),
(48, '2025-04-01', '2025-04-04', 8, 1),
(49, '2025-04-07', '2025-04-11', 9, 2),
(50, '2025-04-14', '2025-04-18', 10, 3);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `id` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`id`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tel` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idService` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idService` (`idService`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`id`, `nom`, `prenom`, `tel`, `mail`, `idService`) VALUES
(1, 'Martin', 'Sophie', '0612345678', 'sophie.martin@mediatek86.fr', 1),
(2, 'Dupont', 'Lucas', '0623456789', 'lucas.dupont@mediatek86.fr', 2),
(3, 'Bernard', 'Emma', '0634567890', 'emma.bernard@mediatek86.fr', 3),
(4, 'Petit', 'Hugo', '0645678901', 'hugo.petit@mediatek86.fr', 1),
(5, 'Robert', 'Lea', '0656789012', 'lea.robert@mediatek86.fr', 2),
(6, 'Moreau', 'Tom', '0667890123', 'tom.moreau@mediatek86.fr', 3),
(7, 'Laurent', 'Julie', '0678901234', 'julie.laurent@mediatek86.fr', 1),
(8, 'Simon', 'Paul', '0689012345', 'paul.simon@mediatek86.fr', 2),
(9, 'Michel', 'Clara', '0690123456', 'clara.michel@mediatek86.fr', 3),
(10, 'Leroy', 'Antoine', '0601234567', 'antoine.leroy@mediatek86.fr', 1);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`id`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
