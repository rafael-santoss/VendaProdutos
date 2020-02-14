-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14-Fev-2020 às 01:17
-- Versão do servidor: 10.4.8-MariaDB
-- versão do PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `vendaproduto`
--

DELIMITER $$
--
-- Procedimentos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `VP_SP_BuscarProdutosPedido` (IN `idPedido` INT UNSIGNED ZEROFILL)  NO SQL
BEGIN
	SELECT pr.* FROM produto pr inner join item_pedido ip on pr.Id = ip.IdProduto inner join pedido pe on ip.IdPedido = pe.Id WHERE ip.IdPedido = idPedido;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `VP_SP_BuscarTodosPedidos` ()  NO SQL
BEGIN
	Select * From pedido;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `VP_SP_BuscarTodosProdutos` ()  NO SQL
BEGIN
	SELECT * FROM Produto;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `item_pedido`
--

CREATE TABLE `item_pedido` (
  `IdPedido` int(11) NOT NULL,
  `IdProduto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `item_pedido`
--

INSERT INTO `item_pedido` (`IdPedido`, `IdProduto`) VALUES
(1, 2),
(1, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `Id` int(11) NOT NULL,
  `Data` datetime DEFAULT NULL,
  `ValorTotal` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `pedido`
--

INSERT INTO `pedido` (`Id`, `Data`, `ValorTotal`) VALUES
(1, '2020-02-11 15:30:12', '200.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL,
  `NomeProduto` varchar(100) COLLATE utf8_swedish_ci DEFAULT NULL,
  `PrecoUnit` decimal(10,2) DEFAULT NULL,
  `QtdEstocada` int(11) DEFAULT NULL,
  `Ativo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `NomeProduto`, `PrecoUnit`, `QtdEstocada`, `Ativo`) VALUES
(1, 'Pão Francês', '0.75', 300, 1),
(2, 'Pão Bengalinha', '1.00', 120, 1),
(3, 'Requeijão', '3.29', 200, 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `item_pedido`
--
ALTER TABLE `item_pedido`
  ADD PRIMARY KEY (`IdPedido`,`IdProduto`),
  ADD KEY `fk_produto_item` (`IdProduto`);

--
-- Índices para tabela `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pedido`
--
ALTER TABLE `pedido`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `item_pedido`
--
ALTER TABLE `item_pedido`
  ADD CONSTRAINT `fk_pedido_item` FOREIGN KEY (`IdPedido`) REFERENCES `pedido` (`Id`),
  ADD CONSTRAINT `fk_produto_item` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
