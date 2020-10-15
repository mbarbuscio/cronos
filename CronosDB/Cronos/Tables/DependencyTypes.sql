CREATE TABLE [cronos].[dependency_types]
(
    [id] BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT pk_dependency_types PRIMARY KEY,
    [dependency_name] VARCHAR(50) NOT NULL
)
