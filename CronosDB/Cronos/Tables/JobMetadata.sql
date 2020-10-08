CREATE TABLE [cronos].[job_metadata]
(
    [id] BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT pk_job_metadata PRIMARY KEY,
    [job_name] VARCHAR(150) NOT NULL,
    [job_display_name] VARCHAR(150) NOT NULL
)
