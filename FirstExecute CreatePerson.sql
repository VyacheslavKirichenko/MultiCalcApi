create table Person
(
 Id uniqueidentifier NOT NULL PRIMARY KEY ,
 Name nvarchar(MAX)
)



CREATE TABLE [dbo].[Person] (
    [Id]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Name] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);


