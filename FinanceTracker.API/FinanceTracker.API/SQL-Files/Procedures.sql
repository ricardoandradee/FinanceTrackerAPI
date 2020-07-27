If Exists (Select 1 From sys.procedures Where Name = 'PerformAccountTransaction')
Begin
	Drop Procedure PerformAccountTransaction
End

Go


Create Procedure PerformAccountTransaction
(
	@action Varchar(10),
	@amount Decimal(10, 2),
	@description Varchar(100),
	@createdDate DateTime,
	@accountId Int,
    @transactionId Int Output
)
As
Begin

	Declare @balanceAfterTransaction As Decimal(10, 2);

	Begin Try
        Begin Transaction;

		Update Accounts 
		Set    Currentbalance = Case 
								  When @action = 'Deposit' Then currentbalance + @amount 
								  When @action = 'Withdraw' Then 
								  currentbalance - @amount 
								  Else currentbalance 
								End 
		Where  Id = @accountId;

		Select @balanceAfterTransaction = Currentbalance
		From Accounts
		Where  Id = @accountId;

		Insert Into Transactions 
					([Description], 
					 Amount, 
					 Balanceaftertransaction, 
					 [Action], 
					 Accountid, 
					 Createddate) 
		Values      (@description, 
					 @amount, 
					 @balanceAfterTransaction, 
					 @action, 
					 @accountId, 
					 @createdDate);

        Commit Transaction;  
    End Try
    Begin Catch
        
        -- Test if the transaction is uncommittable.  
        If (XACT_STATE()) = -1  
        Begin  
            Print  N'The transaction is in an uncommittable state.' +  
                    'Rolling back transaction.'  
			Rollback Transaction;  
        End;  
        
        -- Test if the transaction is committable.  
        If (XACT_STATE()) = 1  
        Begin  
            Print N'The transaction is committable.' +  
                'Committing transaction.'  
            Commit Transaction;    
        End;  
    End Catch

	Select @transactionId = SCOPE_IDENTITY();
End