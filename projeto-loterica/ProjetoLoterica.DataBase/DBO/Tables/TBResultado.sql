CREATE TABLE [dbo].[TBResultado]
(
	[IdResultado] INT NOT NULL IDENTITY(1,1), 
    [ValorLoterica] DECIMAL(18, 2) NOT NULL, 
    [ValorTotal] DECIMAL(18, 2) NOT NULL, 
    [VencedorQuadra] INT NOT NULL, 
    [VencedoresQuina] INT NOT NULL, 
    [VencedoresSena] INT NOT NULL, 
    [PremioQuadra] DECIMAL(18, 2) NOT NULL, 
    [PremioQuina] DECIMAL(18, 2) NOT NULL, 
    [PremioSena] DECIMAL(18, 2) NOT NULL, 
    [ConcursoId] INT NOT NULL,
	CONSTRAINT [FK_TBResultado_ToTBConcurso] FOREIGN KEY ([ConcursoId]) REFERENCES [TBConcurso]([IdConcurso]),
	CONSTRAINT [PK_Resultado] PRIMARY KEY CLUSTERED

(
	[IdResultado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

