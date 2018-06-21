CREATE TABLE [dbo].[Person] (
    [Id]        INT            IDENTITY(1,1),
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Surname]   NVARCHAR (MAX) NOT NULL,
    [Birthdate] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

