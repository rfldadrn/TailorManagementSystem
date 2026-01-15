-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 15, 2026 at 11:09 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tailormanagementsystems`
--

-- --------------------------------------------------------

--
-- Table structure for table `agency`
--

CREATE TABLE `agency` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `TargetDate` date DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `agency`
--

INSERT INTO `agency` (`Id`, `Name`, `Description`, `StartDate`, `TargetDate`, `RowStatus`) VALUES
(1, 'Dinas Pariwisata Kota Padang - 2026', 'Pengadaan pakaian dinas', '2026-01-15', '2026-04-30', 1);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Gender` enum('Pria','Wanita') DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`Id`, `Name`, `PhoneNumber`, `Email`, `Gender`, `RowStatus`) VALUES
(1, 'Rifaldi', '081270892182', 'rifaldiadrian26@gmail.com', 'Pria', 1),
(2, 'John Doe', '1234567890', 'john.doe@email.com', 'Pria', 1),
(3, 'Jane Smith', '0987654321', 'jane.smith@email.com', 'Wanita', 1),
(4, 'Alex Johnson', '0987654321', 'alex.j@email.com', 'Pria', 1),
(5, 'Maria Garcia', '5551234567', NULL, 'Pria', 1),
(6, 'Robert Chen', '5559876543', 'robert.chen@email.com', 'Pria', 1),
(7, 'Sarah Williams', NULL, NULL, 'Pria', 1),
(8, 'Michael Brown', '5552468135', 'michael.b@email.com', 'Pria', 1),
(9, 'Emily Davis', '5553691470', 'emily.davis@email.com', 'Pria', 1),
(10, 'Chris Taylor', '5557891234', NULL, 'Pria', 1),
(11, 'Lisa Anderson', NULL, 'lisa.a@email.com', 'Pria', 1),
(12, 'Cahyo Ade Prasetyo', NULL, NULL, 'Pria', 1),
(13, 'Ananda Navisha', '081237212312', 'anandanavisha@gmail.com', 'Pria', 1),
(14, 'Verel Prawira', '902780312', 'verel@gmail.com', 'Pria', 1),
(15, 'Martha', '0982173012', 'martha@gmail.com', 'Pria', 1),
(16, 'asdsa', '12312321', 'aasdas@gmail.com', 'Pria', 1);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Address` text DEFAULT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Gender` enum('Male','Female','Other') DEFAULT NULL,
  `JoinDate` date DEFAULT NULL,
  `EmployeeTypeId` int(11) DEFAULT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeetask`
--

CREATE TABLE `employeetask` (
  `Id` int(11) NOT NULL,
  `TransactionItemId` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  `ItemEmployeeFeeId` int(11) DEFAULT NULL,
  `Note` text DEFAULT NULL,
  `IsDone` tinyint(1) DEFAULT 0,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeetype`
--

CREATE TABLE `employeetype` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employeetype`
--

INSERT INTO `employeetype` (`Id`, `Name`, `Description`, `RowStatus`) VALUES
(1, 'Tailor', 'Sewing and alterations', 1),
(2, 'Designer', 'Design work', 1),
(3, 'Quality Control', 'Quality inspection', 1);

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `CustomerPrice` decimal(10,2) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itememployeefee`
--

CREATE TABLE `itememployeefee` (
  `Id` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `EmployeeTypeId` int(11) NOT NULL,
  `Fee` decimal(10,2) NOT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itemsize`
--

CREATE TABLE `itemsize` (
  `Id` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itemsizecustomer`
--

CREATE TABLE `itemsizecustomer` (
  `Id` int(11) NOT NULL,
  `ItemSizeId` int(11) NOT NULL,
  `Value` varchar(100) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mappingrole`
--

CREATE TABLE `mappingrole` (
  `Id` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `paymenttype`
--

CREATE TABLE `paymenttype` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `paymenttype`
--

INSERT INTO `paymenttype` (`Id`, `Name`, `Description`, `RowStatus`) VALUES
(1, 'Cash', 'Cash payment', 1),
(2, 'Bank Transfer', 'Bank transfer payment', 1),
(3, 'Credit Card', 'Credit card payment', 1);

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`Id`, `Name`, `Description`, `RowStatus`) VALUES
(1, 'Admin', 'System administrator', 1),
(2, 'Manager', 'Business manager', 1),
(3, 'Staff', 'Regular staff member', 1);

-- --------------------------------------------------------

--
-- Table structure for table `statustransaction`
--

CREATE TABLE `statustransaction` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `statustransaction`
--

INSERT INTO `statustransaction` (`Id`, `Name`, `Description`, `RowStatus`) VALUES
(1, 'Pending', 'Order is pending', 1),
(2, 'In Progress', 'Order is being processed', 1),
(3, 'Completed', 'Order is completed', 1),
(4, 'Cancelled', 'Order is cancelled', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `Id` int(11) NOT NULL,
  `CustomerId` int(11) NOT NULL,
  `AgencyId` int(11) DEFAULT NULL,
  `TransactionDate` datetime NOT NULL DEFAULT current_timestamp(),
  `CompletionDate` datetime DEFAULT NULL,
  `Amount` decimal(15,2) DEFAULT 0.00,
  `PaidAmount` decimal(15,2) DEFAULT 0.00,
  `BalanceDue` decimal(15,2) DEFAULT 0.00,
  `Note` text DEFAULT NULL,
  `PaymentTypeId` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transactionitem`
--

CREATE TABLE `transactionitem` (
  `Id` int(11) NOT NULL,
  `TransactionId` int(11) NOT NULL,
  `ItemId` int(11) NOT NULL,
  `ItemSizeCustomerId` int(11) DEFAULT NULL,
  `CustomerPrice` decimal(10,2) DEFAULT NULL,
  `Note` text DEFAULT NULL,
  `StatusTransactionId` int(11) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Gender` enum('Male','Female','Other') DEFAULT NULL,
  `Password` varchar(255) NOT NULL,
  `Avatar` varchar(255) DEFAULT NULL,
  `RowStatus` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agency`
--
ALTER TABLE `agency`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `EmployeeTypeId` (`EmployeeTypeId`);

--
-- Indexes for table `employeetask`
--
ALTER TABLE `employeetask`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TransactionItemId` (`TransactionItemId`),
  ADD KEY `EmployeeId` (`EmployeeId`),
  ADD KEY `ItemEmployeeFeeId` (`ItemEmployeeFeeId`);

--
-- Indexes for table `employeetype`
--
ALTER TABLE `employeetype`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `itememployeefee`
--
ALTER TABLE `itememployeefee`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ItemId` (`ItemId`),
  ADD KEY `EmployeeTypeId` (`EmployeeTypeId`);

--
-- Indexes for table `itemsize`
--
ALTER TABLE `itemsize`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ItemId` (`ItemId`);

--
-- Indexes for table `itemsizecustomer`
--
ALTER TABLE `itemsizecustomer`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ItemSizeId` (`ItemSizeId`);

--
-- Indexes for table `mappingrole`
--
ALTER TABLE `mappingrole`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `RoleId` (`RoleId`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `paymenttype`
--
ALTER TABLE `paymenttype`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `statustransaction`
--
ALTER TABLE `statustransaction`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CustomerId` (`CustomerId`),
  ADD KEY `AgencyId` (`AgencyId`),
  ADD KEY `PaymentTypeId` (`PaymentTypeId`),
  ADD KEY `CreatedBy` (`CreatedBy`);

--
-- Indexes for table `transactionitem`
--
ALTER TABLE `transactionitem`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TransactionId` (`TransactionId`),
  ADD KEY `ItemId` (`ItemId`),
  ADD KEY `ItemSizeCustomerId` (`ItemSizeCustomerId`),
  ADD KEY `StatusTransactionId` (`StatusTransactionId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agency`
--
ALTER TABLE `agency`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeetask`
--
ALTER TABLE `employeetask`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeetype`
--
ALTER TABLE `employeetype`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itememployeefee`
--
ALTER TABLE `itememployeefee`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itemsize`
--
ALTER TABLE `itemsize`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itemsizecustomer`
--
ALTER TABLE `itemsizecustomer`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mappingrole`
--
ALTER TABLE `mappingrole`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `paymenttype`
--
ALTER TABLE `paymenttype`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `statustransaction`
--
ALTER TABLE `statustransaction`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `transactionitem`
--
ALTER TABLE `transactionitem`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`EmployeeTypeId`) REFERENCES `employeetype` (`Id`) ON DELETE SET NULL;

--
-- Constraints for table `employeetask`
--
ALTER TABLE `employeetask`
  ADD CONSTRAINT `employeetask_ibfk_1` FOREIGN KEY (`TransactionItemId`) REFERENCES `transactionitem` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `employeetask_ibfk_2` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `employeetask_ibfk_3` FOREIGN KEY (`ItemEmployeeFeeId`) REFERENCES `itememployeefee` (`Id`) ON DELETE SET NULL;

--
-- Constraints for table `itememployeefee`
--
ALTER TABLE `itememployeefee`
  ADD CONSTRAINT `itememployeefee_ibfk_1` FOREIGN KEY (`ItemId`) REFERENCES `item` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `itememployeefee_ibfk_2` FOREIGN KEY (`EmployeeTypeId`) REFERENCES `employeetype` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `itemsize`
--
ALTER TABLE `itemsize`
  ADD CONSTRAINT `itemsize_ibfk_1` FOREIGN KEY (`ItemId`) REFERENCES `item` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `itemsizecustomer`
--
ALTER TABLE `itemsizecustomer`
  ADD CONSTRAINT `itemsizecustomer_ibfk_1` FOREIGN KEY (`ItemSizeId`) REFERENCES `itemsize` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `mappingrole`
--
ALTER TABLE `mappingrole`
  ADD CONSTRAINT `mappingrole_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `mappingrole_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`AgencyId`) REFERENCES `agency` (`Id`) ON DELETE SET NULL,
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`PaymentTypeId`) REFERENCES `paymenttype` (`Id`) ON DELETE SET NULL,
  ADD CONSTRAINT `transaction_ibfk_4` FOREIGN KEY (`CreatedBy`) REFERENCES `user` (`Id`) ON DELETE SET NULL;

--
-- Constraints for table `transactionitem`
--
ALTER TABLE `transactionitem`
  ADD CONSTRAINT `transactionitem_ibfk_1` FOREIGN KEY (`TransactionId`) REFERENCES `transaction` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transactionitem_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `item` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transactionitem_ibfk_3` FOREIGN KEY (`ItemSizeCustomerId`) REFERENCES `itemsizecustomer` (`Id`) ON DELETE SET NULL,
  ADD CONSTRAINT `transactionitem_ibfk_4` FOREIGN KEY (`StatusTransactionId`) REFERENCES `statustransaction` (`Id`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
