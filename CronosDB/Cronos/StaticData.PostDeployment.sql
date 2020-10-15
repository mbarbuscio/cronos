/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/


IF NOT EXISTS (SELECT TOP 1 1 FROM [cronos].[dependency_types]) 
BEGIN
    INSERT INTO [cronos].[dependency_types] (id, [dependency_name])
    VALUES (1, 'OnSuccess'),
    (2, 'OnComplete'),
    (3, 'OnFail')
END
