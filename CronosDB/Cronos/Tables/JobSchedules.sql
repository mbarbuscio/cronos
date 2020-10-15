CREATE TABLE [cronos].[job_schedules]
(
    [id] BIGINT NOT NULL IDENTITY(1,1) CONSTRAINT pk_job_schedules PRIMARY KEY,
    [job_id] BIGINT NOT NULL CONSTRAINT fk_job_schedules_job FOREIGN KEY (job_id) REFERENCES [cronos].[job_metadata](id),
    [job_schedule_type] CHAR(1) NOT NULL,
    [job_schedule_days] INT NOT NULL,
    [job_schedule_interval] INT NOT NULL,
    [job_schedule_time] TIME NULL
)
