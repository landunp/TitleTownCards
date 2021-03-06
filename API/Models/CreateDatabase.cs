using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class CreateDatabase
    {
        public void Create()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                //Dropping and Creating the tables 

                //Manager Table
                cmd.CommandText = "DROP TABLE IF EXISTS Manager";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Manager    (
                    ManagerID       INTEGER     PRIMARY KEY,
                    ManagerName     TEXT,
                    ManagerPhone    TEXT,
                    ManagerEmail    TEXT,
                    ManagerAddress  TEXT
                    )";
                cmd.ExecuteNonQuery();

                //Employee Table
                cmd.CommandText = "DROP TABLE IF EXISTS Employee";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Employee    (
                    EmployeeID      INTEGER     PRIMARY KEY,
                    EmployeeName    TEXT,
                    EmployeePhone   TEXT,
                    EmployeeEmail   TEXT,
                    EmployeeAddress TEXT
                    )";
                cmd.ExecuteNonQuery();

                //Member Table
                cmd.CommandText = "DROP TABLE IF EXISTS Member";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Member    (
                    MemberID        INTEGER AUTO_INCREMENT PRIMARY KEY,
                    MemberName      TEXT,
                    MemberAddress   TEXT,
                    MemberEmail     TEXT,
                    MemberDOB       TEXT,
                    MemberPhone     TEXT
                    )";
                cmd.ExecuteNonQuery();

                //Product Table
                cmd.CommandText = "DROP TABLE IF EXISTS Product";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Product    (
                    ProductID       INTEGER AUTO_INCREMENT PRIMARY KEY,
                    ProductName     TEXT,
                    ProductPrice    INTEGER,
                    ProductType     TEXT,
                    ProductStatus   TEXT,
                    ProductDiscount INTEGER,
                    DateOrdered     TEXT,
                    DateAddedToInv  TEXT,
                    ManagerID       INTEGER,
                    ManagerName     TEXT,
                    EmployeeID      INTEGER,
                    EmployeeName    TEXT,
                    FOREIGN KEY (ManagerID)
                        REFERENCES Manager (ManagerID),
                    FOREIGN KEY (EmployeeID)
                        REFERENCES Employee (EmployeeID)
                    )";
                cmd.ExecuteNonQuery();

                //Transaction
                cmd.CommandText = "DROP TABLE IF EXISTS Transactions";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Transactions    (
                    TransactionID   INTEGER PRIMARY KEY,
                    TransactionDate TEXT,
                    TransactionCost INTEGER,
                    ManagerID       INTEGER,
                    ManagerName     TEXT,
                    EmployeeID      INTEGER,
                    EmployeeName    TEXT,
                    MemberID        INTEGER,
                    FOREIGN KEY (ManagerID)
                        REFERENCES Manager (ManagerID),
                    FOREIGN KEY (EmployeeID)
                        REFERENCES Employee (EmployeeID),
                    FOREIGN KEY (MemberID)
                        REFERENCES Member (MemberID)
                    )";
                cmd.ExecuteNonQuery();

                //Transaction Line Item
                cmd.CommandText = "DROP TABLE IF EXISTS TransactionLineItem";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE TransactionLineItem    (
                    ProductID       INTEGER PRIMARY KEY,
                    ProductName     TEXT,
                    ProductPrice    INTEGER,
                    ProductType     TEXT,
                    ProductDiscount INTEGER,
                    TransactionID   INTEGER,
                    FOREIGN KEY (ProductID)
                        REFERENCES Product (ProductID),
                    FOREIGN KEY (TransactionID)
                        REFERENCES Transactions (TransactionID)
                    )";
                cmd.ExecuteNonQuery();

                //Inserting data

                //Manager
                cmd.CommandText = @"INSERT INTO Manager(ManagerID, ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
                    VALUES(@ManagerID, @ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
                cmd.Parameters.AddWithValue("@ManagerID","100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@ManagerPhone","111-111-1111");
                cmd.Parameters.AddWithValue("@ManagerEmail","prgates@crimson.ua.edu");
                cmd.Parameters.AddWithValue("@ManagerAddress","321 Bidgood Ln. Tuscaloosa, AL 35407");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Manager(ManagerID, ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
                    VALUES(@ManagerID, @ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
                cmd.Parameters.AddWithValue("@ManagerID","200");
                cmd.Parameters.AddWithValue("@ManagerName","Bobby Smith");
                cmd.Parameters.AddWithValue("@ManagerPhone","121-121-1221");
                cmd.Parameters.AddWithValue("@ManagerEmail","bobsmith@crimson.ua.edu");
                cmd.Parameters.AddWithValue("@ManagerAddress","330 Bidgood Ln. Tuscaloosa, AL 35407");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //Employee
                cmd.CommandText = @"INSERT INTO Employee(EmployeeID, EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress)
                    VALUES(@EmployeeID, @EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress)";
                cmd.Parameters.AddWithValue("@EmployeeID", "10");
                cmd.Parameters.AddWithValue("@EmployeeName","Molly");
                cmd.Parameters.AddWithValue("@EmployeePhone","222-222-2222");
                cmd.Parameters.AddWithValue("@EmployeeEmail","molly@email.com");
                cmd.Parameters.AddWithValue("@EmployeeAddress","321 Hewson Ln. Tuscaloosa, AL 35407");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Employee(EmployeeID, EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress)
                    VALUES(@EmployeeID, @EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress)";
                cmd.Parameters.AddWithValue("@EmployeeID", "20");
                cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
                cmd.Parameters.AddWithValue("@EmployeePhone","212-212-2112");
                cmd.Parameters.AddWithValue("@EmployeeEmail","kevin@email.com");
                cmd.Parameters.AddWithValue("@EmployeeAddress","330 Hewson Ln. Tuscaloosa, AL 35407");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //Member
                cmd.CommandText = @"INSERT INTO Member(MemberName, MemberAddress, MemberEmail, MemberDOB, MemberPhone)
                    VALUES(@MemberName, @MemberAddress, @MemberEmail, @MemberDOB, @MemberPhone)";
                cmd.Parameters.AddWithValue("@MemberName","Johnny Smith");
                cmd.Parameters.AddWithValue("@MemberAddress","123 Computer Science Dr. Apt 15. Tuscaloosa, AL 35407");
                cmd.Parameters.AddWithValue("@MemberEmail","jsmith@crimson.ua.edu");
                cmd.Parameters.AddWithValue("@MemberDOB","05/18/1999");
                cmd.Parameters.AddWithValue("@MemberPhone","333-333-3333");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //Product
                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName","2020 Albert Pujols - Los Angeles Angels: PSA 7");
                cmd.Parameters.AddWithValue("@ProductPrice","10.00");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductStatus","Sold");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@DateOrdered","10/11/2020");
                cmd.Parameters.AddWithValue("@DateAddedToInv","11/03/2020");
                cmd.Parameters.AddWithValue("@ManagerID","100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@EmployeeID","10");
                cmd.Parameters.AddWithValue("@EmployeeName","Molly");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName","2020 Dylan Bundy - Los Angeles Angels: PSA 6");
                cmd.Parameters.AddWithValue("@ProductPrice","9.50");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@DateOrdered","10/13/2020");
                cmd.Parameters.AddWithValue("@DateAddedToInv","11/04/2020");
                cmd.Parameters.AddWithValue("@ManagerID","200");
                cmd.Parameters.AddWithValue("@ManagerName","Bobby Smith");
                cmd.Parameters.AddWithValue("@EmployeeID","20");
                cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName","2020 Tommy La Stella - Los Angeles Angels: PSA 6");
                cmd.Parameters.AddWithValue("@ProductPrice","9.50");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@DateOrdered","10/09/2020");
                cmd.Parameters.AddWithValue("@DateAddedToInv","11/02/2020");
                cmd.Parameters.AddWithValue("@ManagerID","200");
                cmd.Parameters.AddWithValue("@ManagerName","Bobby Smith");
                cmd.Parameters.AddWithValue("@EmployeeID","10");
                cmd.Parameters.AddWithValue("@EmployeeName","Molly");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName","2020 Matt Thais - Los Angeles Angels: PSA 7");
                cmd.Parameters.AddWithValue("@ProductPrice","10.50");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@DateOrdered","10/15/2020");
                cmd.Parameters.AddWithValue("@DateAddedToInv","11/02/2020");
                cmd.Parameters.AddWithValue("@ManagerID","100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@EmployeeID","20");
                cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName","2020 Patrick Sandoval - Los Angeles Angels: PSA 6");
                cmd.Parameters.AddWithValue("@ProductPrice","9.50");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@DateOrdered","10/06/2020");
                cmd.Parameters.AddWithValue("@DateAddedToInv","11/02/2020");
                cmd.Parameters.AddWithValue("@ManagerID","100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@EmployeeID","10");
                cmd.Parameters.AddWithValue("@EmployeeName","Molly");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //Transactions
                cmd.CommandText = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
                    VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
                cmd.Parameters.AddWithValue("@TransactionID","1");
                cmd.Parameters.AddWithValue("@TransactionDate","10/26/2020");
                cmd.Parameters.AddWithValue("@TransactionCost", "10.00");
                cmd.Parameters.AddWithValue("@ManagerID","100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@EmployeeID","20");
                cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
                cmd.Parameters.AddWithValue("@MemberID","1");
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //Transaction Line Item
                cmd.CommandText = @"INSERT INTO TransactionLineItem(ProductID, ProductName, ProductPrice, ProductType, ProductDiscount, TransactionID)
                    VALUES(@ProductID, @ProductName, @ProductPrice, @ProductType, @ProductDiscount, @TransactionID)";
                cmd.Parameters.AddWithValue("@ProductID","1");
                cmd.Parameters.AddWithValue("@ProductName","2020 Albert Pujols - Los Angeles Angels: PSA 7");
                cmd.Parameters.AddWithValue("@ProductPrice","10.00");
                cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
                cmd.Parameters.AddWithValue("@ProductDiscount","0");
                cmd.Parameters.AddWithValue("@TransactionID","1");
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            
                //close connection
                db.CloseConnection();
            }
        }
    }
    
}