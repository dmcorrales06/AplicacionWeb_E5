-- MySQL Script generated by MySQL Workbench
-- Sat Nov 19 16:16:52 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Ejercicio5_BD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Ejercicio5_BD
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Ejercicio5_BD` DEFAULT CHARACTER SET utf8 ;
USE `Ejercicio5_BD` ;

-- -----------------------------------------------------
-- Table `Ejercicio5_BD`.`Login`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Ejercicio5_BD`.`Login` (
  `CodUsuario` VARCHAR(20) NOT NULL,
  `Correo` VARCHAR(45) NOT NULL,
  `Clave` VARCHAR(120) NOT NULL,
  PRIMARY KEY (`CodUsuario`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
