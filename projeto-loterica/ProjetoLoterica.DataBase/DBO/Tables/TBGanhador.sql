CREATE TABLE [dbo].[TBGanhador]
(
	[IdGanhador] INT NOT NULL IDENTITY(1,1), 
    [TipoPremio] DECIMAL(18, 2) NOT NULL CHECK (TipoPremio IN('QUADRA', 'QUINA', 'SENA', 'SEMPREMIACAO')), 
    [ConcursoId] INT NOT NULL, 
    [ApostaId] INT NOT NULL,
	[ResultadoId] INT NOT NULL, 
    CONSTRAINT [FK_TBGanhador_ToTBConcurso] FOREIGN KEY ([ConcursoId]) REFERENCES [TBConcurso]([IdConcurso]),
	CONSTRAINT [FK_TBGanhador_ToTBAposta] FOREIGN KEY ([ApostaId]) REFERENCES [TBAposta]([IdAposta]),
	CONSTRAINT [FK_TBGanhador_ToTBResultado] FOREIGN KEY ([ResultadoId]) REFERENCES [TBResultado]([IdResultado]),
	CONSTRAINT [PK_Ganhador] PRIMARY KEY CLUSTERED

(
	[IdGanhador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
