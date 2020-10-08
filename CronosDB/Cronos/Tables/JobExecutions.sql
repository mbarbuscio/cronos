CREATE TABLE [cronos].[job_executions]
(
    [id] BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT pk_job_executions PRIMARY KEY,
    [job_id] BIGINT NOT NULL CONSTRAINT fk_job_execution_job FOREIGN KEY (job_id) REFERENCES [cronos].[job_metadata]([id]),
    [start_dttm] DATETIME NOT NULL,
    [end_dttm] DATETIME NULL,
    [status_desc] VARCHAR(50) NOT NULL,
    [exit_code] INT NULL,
    [completion_message] VARCHAR(MAX) NULL
)
