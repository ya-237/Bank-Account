CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT NOT NULL,
    TransactionType VARCHAR(10) NOT NULL CHECK (TransactionType IN ('Deposit', 'Withdraw', 'Transfer')),
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    SourceAccountID INT, -- Used for transfers
    DestinationAccountID INT, -- Used for transfers
    FOREIGN KEY (AccountID) REFERENCES Account(account_id),
    FOREIGN KEY (SourceAccountID) REFERENCES Account(account_id),
    FOREIGN KEY (DestinationAccountID) REFERENCES Account(account_id)
);

-- Indexes for frequently queried columns
CREATE INDEX idx_AccountID ON Transactions(AccountID);
CREATE INDEX idx_TransactionDate ON Transactions(TransactionDate);