USE[LIMAVARI]
GO
CREATE PROCEDURE [dbo].[SP_EST_L_LISTAR_ENTRADA_ESTOQUE_MES]--2,'2017-03-01','2017-03-31'
@PRO_LOJ_N_CODIGO	INT,
@EST_D_DATA_INICIO	DATETIME,
@EST_D_DATA_FIM		DATETIME
AS 

BEGIN

SELECT 
		sum(est_n_qtde) as Qtde,
		(sum(est_n_qtde * est_n_valor_custo)) as total
from LIMAVARI.tb_est_estoque 
 INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO

 where (est_d_data >= @EST_D_DATA_INICIO + ' 00:00:00' and est_d_data <= @EST_D_DATA_FIM + ' 23:59:59')
 AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO)
 and (est_c_movimento = 'ENTRADA')

 group by est_c_movimento
 order by sum(est_n_qtde) desc
END

GO

CREATE PROCEDURE [dbo].[SP_EST_L_LISTAR_ENTRADA_ESTOQUE_MES_PRODUTO]--2,'2017-03-01','2017-03-31'
@PRO_LOJ_N_CODIGO	INT,
@EST_D_DATA_INICIO	DATETIME,
@EST_D_DATA_FIM		DATETIME
AS 

BEGIN

SELECT 
		est_pro_n_codigo,
		(pro_c_nome + (case when pro_c_cor = '' then '' else ' ' + pro_c_cor end) + 
		(case when pro_c_tamanho = '' then '' else ' ' + pro_c_tamanho  end) +
		' ' + fab_c_descricao) as produto,
		sum(est_n_qtde) as Qtde,
		(sum(est_n_qtde * est_n_valor_custo)) as total
 from LIMAVARI.tb_est_estoque 
 inner join LIMAVARI.tb_pro_produto on pro_n_codigo = est_pro_n_codigo
 inner join LIMAVARI.tb_fab_fabricante on pro_fab_n_codigo = fab_n_codigo
where (est_d_data >= @EST_D_DATA_INICIO + ' 00:00:00' and est_d_data <= @EST_D_DATA_FIM + ' 23:59:59')
 AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO)
 and (est_c_movimento = 'ENTRADA')
 group by est_c_movimento,est_pro_n_codigo,pro_c_nome,pro_c_cor,pro_c_tamanho,fab_c_descricao
 order by sum(est_n_qtde) desc

END

GO

ALTER PROCEDURE [dbo].[SP_PRO_L_LISTAR_PRODUTO_VENDIDO_TROCADO]--'123',1
@PRO_N_CODIGO	INT = NULL,
@PRO_LOJ_N_CODIGO INT

AS 

BEGIN

--PROCURA PRODUTO NA TABELA DE VENDA
SELECT top 1 PRO_N_CODIGO,
		PRO_C_CODIGO as 'C�digo',
		PRO_C_NOME AS 'Nome',
	    PRO_C_DESCRICAO AS 'Descri��o',
	   PRO_C_TAMANHO AS 'Tamanho',
	   PRO_C_REFERENCIA	as 'Refer�ncia',
	   PRO_C_COR AS 'Cor',
	   PRO_FAB_N_CODIGO as 'CodigoFabricante',
	   PRO_CAT_N_CODIGO AS 'CodigoCategoria',
	   PRO_B_STATUS AS 'Status'
	   
	   FROM LIMAVARI.TB_PRO_PRODUTO
	   INNER JOIN LIMAVARI.TB_ITV_ITEM_VENDA ON ITV_PRO_C_CODIGO = PRO_C_CODIGO
	   INNER JOIN LIMAVARI.TB_VEN_VENDA ON VEN_N_CODIGO = ITV_VEN_N_CODIGO

	   where(PRO_N_CODIGO = @PRO_N_CODIGO)
	   AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO)
	   AND(PRO_C_CODIGO <> '000000') --PRODUTO TROCA
	   AND(VEN_C_STATUS = 'A' AND ITV_C_STATUS = 'A')
		ORDER BY PRO_C_NOME

		--PROCURA NA TABELA DE TROCA
		SELECT top 1 PRO_N_CODIGO,
		PRO_C_CODIGO as 'C�digo',
		PRO_C_NOME AS 'Nome',
	    PRO_C_DESCRICAO AS 'Descri��o',
	   PRO_C_TAMANHO AS 'Tamanho',
	   PRO_C_REFERENCIA	as 'Refer�ncia',
	   PRO_C_COR AS 'Cor',
	   PRO_FAB_N_CODIGO as 'CodigoFabricante',
	   PRO_CAT_N_CODIGO AS 'CodigoCategoria',
	   PRO_B_STATUS AS 'Status'
	   
	   FROM LIMAVARI.TB_PRO_PRODUTO
	   INNER JOIN LIMAVARI.TB_ITT_ITEM_TROCA ON ITT_PRO_C_CODIGO = PRO_C_CODIGO
	   INNER JOIN LIMAVARI.TB_TRO_TROCA ON TRO_N_CODIGO = ITT_TRO_N_CODIGO

	   where(PRO_N_CODIGO = @PRO_N_CODIGO)
	   AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO)
	   AND(PRO_C_CODIGO <> '000000') --PRODUTO TROCA
	   AND(TRO_C_STATUS = 'A' AND ITT_C_STATUS = 'A')
		ORDER BY PRO_C_NOME

END

GO

ALTER PROCEDURE [dbo].[SP_PRO_D_EXCLUIR_PRODUTO]
@PRO_N_CODIGO		int,
@PRO_LOJ_N_CODIGO	INT

AS 

BEGIN

DELETE LIMAVARI.TB_PRO_PRODUTO

WHERE PRO_N_CODIGO = @PRO_N_CODIGO AND PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO
END

GO

CREATE PROCEDURE [dbo].[SP_PRO_L_LISTAR_PRODUTO_VENDA_COMBO]--'5757',null,2
@PRO_C_CODIGO	VARCHAR(50) = NULL,
@PRO_C_NOME		VARCHAR(400) = NULL,
@PRO_LOJ_N_CODIGO INT

AS 

BEGIN

SELECT PRO_N_CODIGO,
		PRO_C_CODIGO as 'C�digo',
		PRO_C_NOME AS 'Nome',
	    PRO_C_DESCRICAO AS 'Descri��o',
	   PRO_C_TAMANHO AS 'Tamanho',
	   PRO_C_REFERENCIA	as 'Refer�ncia',
	   PRO_C_COR AS 'Cor',
	   PRO_FAB_N_CODIGO as 'CodigoFabricante',
	   FAB_C_DESCRICAO AS 'Marca',
	   PRO_CAT_N_CODIGO AS 'CodigoCategoria',
	   CAT_C_DESCRICAO AS 'Categoria',
	   PRO_B_STATUS AS 'Status',
	   (pro_c_nome + (case when pro_c_cor = '' then '' else ' ' + pro_c_cor end) + 
		(case when pro_c_tamanho = '' then '' else ' - TAM. ' + pro_c_tamanho  end) +
		' - ' + fab_c_descricao) as produto,

	    ISNULL((select top 1 est_n_valor_venda from limavari.tb_est_estoque where 
		est_pro_N_codigo = PRO_N_CODIGO and est_c_movimento = 'ENTRADA' order by est_n_codigo desc),0)  AS 'ValorVenda',
	   (SELECT isnull(SUM(EST_N_QTDE),0) FROM LIMAVARI.TB_EST_ESTOQUE WHERE EST_PRO_N_CODIGO = PRO_N_CODIGO AND EST_C_MOVIMENTO = 'ENTRADA') -
	    (SELECT isnull(SUM(EST_N_QTDE),0) FROM LIMAVARI.TB_EST_ESTOQUE WHERE EST_PRO_N_CODIGO = PRO_N_CODIGO AND EST_C_MOVIMENTO = 'SA�DA') AS 'QtdeEstoque'

	   FROM LIMAVARI.TB_PRO_PRODUTO
	   LEFT JOIN LIMAVARI.TB_FAB_FABRICANTE ON FAB_N_CODIGO = PRO_FAB_N_CODIGO
	   LEFT JOIN LIMAVARI.TB_CAT_CATEGORIA ON CAT_N_CODIGO = PRO_CAT_N_CODIGO
	   

	   where ((PRO_C_CODIGO = @PRO_C_CODIGO OR @PRO_C_CODIGO IS NULL)
	   or(PRO_C_REFERENCIA = @PRO_C_CODIGO OR @PRO_C_CODIGO IS NULL))
	   AND(PRO_C_NOME = @PRO_C_NOME OR @PRO_C_NOME IS NULL)
	   AND(PRO_B_STATUS = 1)
	   AND (
	    (SELECT isnull(SUM(EST_N_QTDE),0) FROM LIMAVARI.TB_EST_ESTOQUE WHERE EST_PRO_N_CODIGO = PRO_N_CODIGO AND EST_C_MOVIMENTO = 'ENTRADA') -
	    (SELECT isnull(SUM(EST_N_QTDE),0) FROM LIMAVARI.TB_EST_ESTOQUE WHERE EST_PRO_N_CODIGO = PRO_N_CODIGO AND EST_C_MOVIMENTO = 'SA�DA')
	   ) > 0
	   AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO)
	   AND(PRO_C_CODIGO <> '000000') --PRODUTO TROCA
		ORDER BY PRO_C_NOME

END

GO

--CRIAR CAMPO ITV_PRO_N_CODIGO NA TABELA ITEM_VENDA, e marcar itv_pro_c_codigo para aceitar nulo

ALTER PROCEDURE [dbo].[SP_ITV_I_INSERIR_ITEM_VENDA]
@ITV_VEN_N_CODIGO		INT,
@ITV_PRO_C_CODIGO		VARCHAR(50) = NULL,
@ITV_N_QTDE				INT,
@ITV_N_VALOR_UNITARIO	DECIMAL(18,2),
@ITV_N_VALOR_TOTAL_SD	DECIMAL(18,2),
@ITV_N_DESCONTO			DECIMAL(18,2),
@ITV_N_VALOR_TOTAL		DECIMAL(18,2),
@ITV_PRO_N_CODIGO		INT

AS 

DECLARE @CODIGO_LOJA INT = (SELECT VEN_LOJ_N_CODIGO FROM LIMAVARI.TB_VEN_VENDA WHERE VEN_N_CODIGO = @ITV_VEN_N_CODIGO)
--OBT�M O �LTIMO PRE�O DE CUSTO DO PRODUTO
DECLARE @VALOR_CUSTO DECIMAL(18,2) = (SELECT TOP 1 EST_N_VALOR_CUSTO FROM LIMAVARI.TB_EST_ESTOQUE 
										INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO
										WHERE EST_PRO_N_CODIGO = @ITV_PRO_N_CODIGO 
										AND EST_C_MOVIMENTO = 'ENTRADA'
										AND PRO_LOJ_N_CODIGO = @CODIGO_LOJA
										ORDER BY EST_N_CODIGO DESC)

BEGIN

INSERT INTO LIMAVARI.TB_ITV_ITEM_VENDA
(
	ITV_VEN_N_CODIGO,
	ITV_PRO_C_CODIGO,
	ITV_N_QTDE,
	ITV_N_VALOR_UNITARIO,
	ITV_N_VALOR_TOTAL_SD,
	ITV_N_DESCONTO,
	ITV_N_VALOR_TOTAL,
	ITV_C_STATUS,
	ITV_N_VALOR_CUSTO,
	ITV_PRO_N_CODIGO
)
VALUES
(
	@ITV_VEN_N_CODIGO,
	@ITV_PRO_C_CODIGO,
	@ITV_N_QTDE,
	@ITV_N_VALOR_UNITARIO,
	@ITV_N_VALOR_TOTAL_SD,
	@ITV_N_DESCONTO,
	@ITV_N_VALOR_TOTAL,
	'T',
	@VALOR_CUSTO,
	@ITV_PRO_N_CODIGO
)

SELECT @@IDENTITY

END

go

ALTER PROCEDURE [dbo].[SP_ITV_L_LISTAR_ITENS_VENDA_DIARIA]--2,null,'05-09-2016','05-09-2016'
@VEN_LOJ_N_CODIGO   INT,
@PRO_C_TAMANHO		VARCHAR(5) = NULL,
@DATA_INICIO		DATETIME = NULL,
@DATA_FIM			DATETIME = NULL,
@CAT_C_DESCRICAO	VARCHAR(200) = NULL,
@FAB_C_DESCRICAO	VARCHAR(200) = NULL,
@VEN_USU_N_CODIGO	INT = NULL

AS 

BEGIN

SELECT 
itv_ven_n_codigo as 'C�digo Venda',
itv_n_codigo,
ITV_PRO_C_CODIGO as 'C�digo Produto',
PRO_C_REFERENCIA + ' ' +  PRO_C_NOME + ' ' + ISNULL(PRO_C_COR,'') + ' ' + ISNULL(PRO_C_TAMANHO,'') AS 'Produto',
FAB_C_DESCRICAO AS 'Marca',
ITV_N_QTDE as 'Qtde',
ISNULL(ITV_N_VALOR_UNITARIO,ITV_N_VALOR_TOTAL) as 'Valor Unit.',
ISNULL(ven_n_desconto,0) as 'Desconto',
ISNULL(ven_n_acrescimo,0) as 'Acrescimo',
ven_n_total as 'Total Venda',
(select sum(ITV_N_QTDE)  
FROM LIMAVARI.TB_ITV_ITEM_VENDA AS ITV
WHERE 
(ITV.itv_ven_n_codigo = VEN_N_CODIGO)) as 'Qtde Total',
(ven_n_total - ISNULL(ven_n_desconto,0) + ISNULL(ven_n_acrescimo,0)) as 'TOTAL'

FROM LIMAVARI.TB_ITV_ITEM_VENDA
INNER JOIN LIMAVARI.TB_VEN_VENDA ON VEN_N_CODIGO = ITV_VEN_N_CODIGO
INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = ITV_PRO_N_CODIGO
INNER JOIN LIMAVARI.TB_FAB_FABRICANTE ON FAB_N_CODIGO = PRO_FAB_N_CODIGO
INNER JOIN LIMAVARI.TB_CAT_CATEGORIA ON CAT_N_CODIGO = PRO_CAT_N_CODIGO
WHERE 
(VEN_D_DATA >= @DATA_INICIO + ' 00:00:00' OR @DATA_INICIO IS NULL)
AND(VEN_D_DATA <= @DATA_FIM + ' 23:59:59' OR @DATA_FIM IS NULL)
AND(PRO_C_TAMANHO = @PRO_C_TAMANHO OR @PRO_C_TAMANHO IS NULL)
AND(CAT_C_DESCRICAO = @CAT_C_DESCRICAO OR @CAT_C_DESCRICAO IS NULL)
AND(FAB_C_DESCRICAO = @FAB_C_DESCRICAO OR @FAB_C_DESCRICAO IS NULL)
AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO)
AND (VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
AND(PRO_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO)
AND(VEN_C_STATUS = 'A' AND ITV_C_STATUS = 'A')


ORDER BY ITV_N_CODIGO

SELECT DISTINCT * FROM LIMAVARI.TB_FPV_FORMA_PAGTO_VENDA 
INNER JOIN LIMAVARI.TB_VEN_VENDA ON VEN_N_CODIGO = FPV_VEN_N_CODIGO
WHERE 
(VEN_D_DATA >= @DATA_INICIO + ' 00:00:00' OR @DATA_INICIO IS NULL)
AND(VEN_D_DATA <= @DATA_FIM + ' 23:59:59' OR @DATA_FIM IS NULL)
AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO)
AND (VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
AND(VEN_C_STATUS = 'A')

END

go

ALTER PROCEDURE [dbo].[SP_ITV_L_LISTAR_ITEM_VENDA]--6456,NULL,NULL,NULL,NULL,1
@ITV_VEN_N_CODIGO		INT,
@ITV_PRO_C_CODIGO		varchar(50) = null,		
@PRO_C_NOME				VARCHAR(400) = NULL,
@PRO_C_TAMANHO			VARCHAR(5) = NULL,
@PRO_C_COR				VARCHAR(50) = NULL,
@PRO_LOJ_N_CODIGO		INT =NULL,
@ITV_PRO_N_CODIGO		INT = NULL
AS 

BEGIN

SELECT 
itv_n_codigo,
ITV_PRO_N_CODIGO,
ITV_PRO_C_CODIGO as 'C�digo',
PRO_C_REFERENCIA + ' ' +  PRO_C_NOME + ' ' + PRO_C_COR + ' ' + PRO_C_TAMANHO AS 'Produto',
ITV_N_VALOR_UNITARIO as 'Valor Unit.',
ITV_N_VALOR_TOTAL as 'Valor Total',
PRO_C_NOME AS 'Nome',
PRO_C_COR as 'Cor',
PRO_C_TAMANHO AS 'Tamanho',
FAB_C_DESCRICAO AS 'Marca',
PRO_C_REFERENCIA as 'Refer�ncia',
ITV_N_QTDE as 'Qtde'


FROM LIMAVARI.TB_ITV_ITEM_VENDA
INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = ITV_PRO_N_CODIGO
INNER JOIN LIMAVARI.TB_FAB_FABRICANTE ON FAB_N_CODIGO = PRO_FAB_N_CODIGO
INNER JOIN LIMAVARI.TB_VEN_VENDA ON VEN_N_CODIGO = ITV_VEN_N_CODIGO
WHERE (ITV_VEN_N_CODIGO = @ITV_VEN_N_CODIGO)
and(
     (ITV_PRO_C_CODIGO = @ITV_PRO_C_CODIGO or @ITV_PRO_C_CODIGO is null)
      or (pro_c_referencia = @ITV_PRO_C_CODIGO or @ITV_PRO_C_CODIGO is null)
)
AND(ITV_PRO_N_CODIGO = @ITV_PRO_N_CODIGO OR @ITV_PRO_N_CODIGO IS NULL)

AND(PRO_C_NOME = @PRO_C_NOME OR @PRO_C_NOME IS NULL)
AND(PRO_C_COR = @PRO_C_COR OR @PRO_C_COR IS NULL)
AND(PRO_C_TAMANHO = @PRO_C_TAMANHO OR @PRO_C_TAMANHO IS NULL)
AND(PRO_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO OR @PRO_LOJ_N_CODIGO IS NULL)
AND(VEN_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO OR @PRO_LOJ_N_CODIGO IS NULL)

ORDER BY ITV_N_CODIGO

SELECT * FROM LIMAVARI.TB_VEN_VENDA 
INNER JOIN LIMAVARI.TB_USU_USUARIO ON USU_N_CODIGO = VEN_USU_N_CODIGO
WHERE VEN_N_CODIGO = @ITV_VEN_N_CODIGO 
AND (VEN_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO OR @PRO_LOJ_N_CODIGO IS NULL)


SELECT * FROM LIMAVARI.TB_FPV_FORMA_PAGTO_VENDA 
INNER JOIN LIMAVARI.TB_FPG_FORMA_PAGTO ON FPG_N_CODIGO = FPV_FPG_N_CODIGO
INNER JOIN LIMAVARI.TB_VEN_VENDA ON VEN_N_CODIGO = FPV_VEN_N_CODIGO
WHERE FPV_VEN_N_CODIGO = @ITV_VEN_N_CODIGO
AND(VEN_LOJ_N_CODIGO = @PRO_LOJ_N_CODIGO OR @PRO_LOJ_N_CODIGO IS NULL)

END

GO

--EXECUTAR A QUERY ABAIXO PARA ATUALIZAR OS PRODUTOS
SELECT * FROM TB_ITV_ITEM_VENDA 
INNER JOIN TB_VEN_VENDA ON VEN_N_CODIGO = ITV_VEN_N_CODIGO
where itv_pro_N_codigo is null AND ITV_C_STATUS = 'A'


declare @table table(
codigo int identity,
itv_n_codigo int,
itv_pro_c_codigo varchar(50),
pro_n_codigo int,
ven_loj_n_codigo int)

insert into @table(itv_n_codigo, itv_pro_c_codigo, ven_loj_n_codigo)
(select itv_n_codigo, itv_pro_c_codigo, ven_loj_n_codigo from tb_itv_item_venda inner join tb_ven_venda on ven_N_codigo = itv_ven_N_codigo
where itv_pro_n_codigo is null and itv_pro_c_codigo <> '')

declare @inicio int = (select top 1 codigo from @table order by codigo)
declare @fim int = (select top 1 codigo from @table order by codigo desc)

while(@inicio <= @fim)
begin
	declare @codigo_item int = (select itv_n_codigo from @table where codigo = @inicio)
	declare @codigo_produto varchar(50) = (select itv_pro_c_codigo from @table where codigo = @inicio)
	declare @codigo_loja int =(select ven_loj_n_codigo from @table where codigo = @inicio) 
	declare @pro_n_codigo int = (select pro_n_codigo from tb_pro_produto where pro_c_codigo = @codigo_produto)

	update tb_itv_item_venda
	set itv_pro_n_codigo = @pro_n_codigo where itv_n_codigo = @codigo_item

	set @inicio = @inicio + 1

end

go

ALTER PROCEDURE [dbo].[SP_VEN_L_LISTAR_VENDA_ANO_MES]--'03-01-2018','03-31-2018',2,8
@VEN_D_DATA_INICIO  DATETIME = NULL,
@VEN_D_DATA_FIM		DATETIME = NULL,
@VEN_LOJ_N_CODIGO   INT = NULL,
@VEN_USU_N_CODIGO	INT = NULL

AS 

BEGIN

SELECT 
 YEAR(VEN_D_DATA) AS ANO,
 MONTH(VEN_D_DATA) AS MES,
 '' as 'M�S',
SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) AS TOTAL,


isnull((select sum(itv_n_valor_custo) from limavari.tb_itv_item_venda where itv_ven_n_codigo
in(select ven_n_codigo from LIMAVARI.TB_VEN_VENDA 
	WHERE 
	(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
	AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
	AND(VEN_C_STATUS = 'A')
	AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
	AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
	AND (YEAR(VEN_D_DATA) = YEAR(VEND.VEN_D_DATA))
	AND (MONTH(VEN_D_DATA) =  MONTH(VEND.VEN_D_DATA))
)
),0) AS TOTAL_CUSTO,


isnull((
--TOTAL VENDIDO - TOTAL PRE�O DE CUSTO = LUCRO
SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) 
-
(select sum(itv_n_valor_custo) from limavari.tb_itv_item_venda where itv_ven_n_codigo
in(select ven_n_codigo from LIMAVARI.TB_VEN_VENDA 
	WHERE 
	(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
	AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
	AND(VEN_C_STATUS = 'A')
	AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
	AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
	AND (YEAR(VEN_D_DATA) = YEAR(VEND.VEN_D_DATA))
	AND (MONTH(VEN_D_DATA) =  MONTH(VEND.VEN_D_DATA))
)
)
),0) AS LUCRO,

ISNULL((select sum(est_n_qtde * est_n_valor_custo)
 from LIMAVARI.tb_est_estoque 
 INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO
 where est_c_movimento  = 'ENTRADA'
 AND (PRO_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
 and (est_d_data >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
 and(est_d_data <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
 ),0) as COMPRA

FROM LIMAVARI.TB_VEN_VENDA  as VEND

WHERE 
(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
AND(VEN_C_STATUS = 'A')
AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)

GROUP BY YEAR(VEN_D_DATA),MONTH(VEN_D_DATA)


SELECT 
 YEAR(VEN_D_DATA) AS ANO,
 MONTH(VEN_D_DATA) AS MES,
  '' as 'M�S',
 DAY(VEN_D_DATA) AS DIA,
SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) AS TOTAL,

ISNULL((select sum(est_n_qtde * est_n_valor_custo)
 from LIMAVARI.tb_est_estoque 
 INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO
 where est_c_movimento  = 'ENTRADA'
 AND (PRO_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
 and (YEAR(est_d_data) = YEAR(VEN_D_DATA))
 and(MONTH(est_d_data) = MONTH(VEN_D_DATA))
 AND(DAY(EST_D_DATA) = DAY(VEN_D_DATA))
 ),0) as COMPRA


FROM LIMAVARI.TB_VEN_VENDA 

WHERE 
(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
AND(VEN_C_STATUS = 'A')
AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)

GROUP BY YEAR(VEN_D_DATA),MONTH(VEN_D_DATA),DAY(VEN_D_DATA)
END

go

ALTER PROCEDURE [dbo].[SP_VEN_L_LISTAR_VENDA_PERIODO_MES]--'02-01-2017','02-28-2017',2,8
@VEN_D_DATA_INICIO  DATETIME = NULL,
@VEN_D_DATA_FIM		DATETIME = NULL,
@VEN_LOJ_N_CODIGO   INT = NULL,
@VEN_USU_N_CODIGO	INT = NULL

AS 

BEGIN

SELECT 
 YEAR(VEN_D_DATA) AS ANO,
 MONTH(VEN_D_DATA) AS MES,
  '' as 'M�S',
format(DAY(VEN_D_DATA),'00') AS DIA,
 SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) AS TOTAL,

 isnull((select sum(itv_n_valor_custo) from limavari.tb_itv_item_venda where itv_ven_n_codigo
in(select ven_n_codigo from LIMAVARI.TB_VEN_VENDA 
	WHERE 
	(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
	AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
	AND(VEN_C_STATUS = 'A')
	AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
	AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
	AND (YEAR(VEN_D_DATA) = YEAR(VEND.VEN_D_DATA))
	AND (MONTH(VEN_D_DATA) =  MONTH(VEND.VEN_D_DATA))
	AND (DAY(VEN_D_DATA) = DAY(VEND.VEN_D_DATA))
)
),0) AS TOTAL_CUSTO,


isnull((
--TOTAL VENDIDO - TOTAL PRE�O DE CUSTO = LUCRO
SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) 
-
(select sum(itv_n_valor_custo) from limavari.tb_itv_item_venda where itv_ven_n_codigo
in(select ven_n_codigo from LIMAVARI.TB_VEN_VENDA 
	WHERE 
	(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
	AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
	AND(VEN_C_STATUS = 'A')
	AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
	AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)
	AND (YEAR(VEN_D_DATA) = YEAR(VEND.VEN_D_DATA))
	AND (MONTH(VEN_D_DATA) =  MONTH(VEND.VEN_D_DATA))
	AND (DAY(VEN_D_DATA) = DAY(VEND.VEN_D_DATA))
)
)
),0) AS LUCRO,

ISNULL((select sum(est_n_qtde * est_n_valor_custo)
 from LIMAVARI.tb_est_estoque 
 INNER JOIN LIMAVARI.TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO
 where est_c_movimento  = 'ENTRADA'
 AND (PRO_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
 and (YEAR(est_d_data) = YEAR(VEN_D_DATA))
 and(MONTH(est_d_data) = MONTH(VEN_D_DATA))
 AND(DAY(EST_D_DATA) = DAY(VEN_D_DATA))
 ),0) as COMPRA


FROM LIMAVARI.TB_VEN_VENDA  as vend


WHERE 
(VEN_D_DATA >= @VEN_D_DATA_INICIO + ' 00:00:00' OR @VEN_D_DATA_INICIO IS NULL)
AND (VEN_D_DATA <= @VEN_D_DATA_FIM + ' 23:59:59' OR @VEN_D_DATA_FIM IS NULL)
AND(VEN_C_STATUS = 'A')
AND(VEN_LOJ_N_CODIGO = @VEN_LOJ_N_CODIGO OR @VEN_LOJ_N_CODIGO IS NULL)
AND(VEN_USU_N_CODIGO = @VEN_USU_N_CODIGO OR @VEN_USU_N_CODIGO IS NULL)

GROUP BY YEAR(VEN_D_DATA),MONTH(VEN_D_DATA),DAY(VEN_D_DATA)


END

go