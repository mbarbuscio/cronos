CREATE TABLE [cronos].[job_dependencies]
(
    [job_id] BIGINT NOT NULL CONSTRAINT fk_job_dependencies_job FOREIGN KEY (job_id) REFERENCES [cronos].[job_metadata](id),
    [dependency_type] BIGINT NOT NULL CONSTRAINT fk_job_dependency_dependency_type FOREIGN KEY (dependency_type) REFERENCES [cronos].[dependency_types](id),
    [dependant_job_id] BIGINT NOT NULL CONSTRAINT fk_job_dependencies_dependant_job FOREIGN KEY (dependant_job_id) REFERENCES [cronos].[job_metadata](id),
    CONSTRAINT pk_job_dependencies PRIMARY KEY (job_id, dependant_job_id)
)
