CREATE PROCEDURE DeleteTransactionsByAccountID
    @AccountID INT
AS
BEGIN
    DELETE FROM [dbo].[Transactions]
    WHERE [AccountID] = @AccountID;
END;