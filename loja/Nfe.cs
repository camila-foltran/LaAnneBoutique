using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace loja
{
    public class Formato : Attribute
    {
        public string formato;
        public string cultura;

        public Formato(string formatoInf, string culturaInf)
        {
            this.formato = formatoInf;
            this.cultura = culturaInf;
        }
    }

    public class Obrigatorio : Attribute
    {
        public bool propriedadeObrigatoria;

        public Obrigatorio()
        {
            propriedadeObrigatoria = true;
        }
    }

    public class NFe
    {


        private void objetoParaXML(XmlWriter xmlWriter, object objeto, bool ignorarDeclaracaoElemento)
        {
            if (objeto == null)
                return;

            Type tipoObjeto;
            tipoObjeto = objeto.GetType();
            PropertyInfo[] propriedades;
            propriedades = tipoObjeto.GetProperties();

            if (!ignorarDeclaracaoElemento)
                xmlWriter.WriteStartElement(tipoObjeto.Name);

            foreach (PropertyInfo propriedade in propriedades)
            {
                if (Funcoes.novaTag(propriedade) && !(propriedade.GetValue(objeto, null) == null))
                {
                    objetoParaXML(xmlWriter, propriedade.GetValue(objeto, null), false);
                    continue;
                }

                object[] obj = propriedade.GetCustomAttributes(false);
                Funcoes.gravarElemento(xmlWriter, propriedade.Name, propriedade.GetValue(objeto, null), obj);
            }
            if (!ignorarDeclaracaoElemento)
                xmlWriter.WriteEndElement();
        }



        public XmlDocument GerarXML()
        {
            XmlWriterSettings configXML = new XmlWriterSettings();
            configXML.Indent = true;
            configXML.IndentChars = "";
            configXML.NewLineOnAttributes = false;
            configXML.OmitXmlDeclaration = false;

            Stream xmlSaida = new MemoryStream();

            XmlWriter oXmlGravar = XmlWriter.Create(xmlSaida, configXML);

            oXmlGravar.WriteStartDocument();
            oXmlGravar.WriteStartElement("NFe", "http://www.portalfiscal.inf.br/nfe"); //abre nfe
            oXmlGravar.WriteStartElement("infNFe");
            oXmlGravar.WriteAttributeString("Id", "NFe" + Id.ToString());
            oXmlGravar.WriteAttributeString("versao", versao.ToString());

            Type tipoObjeto;
            tipoObjeto = infNFE.Ide.GetType();
            PropertyInfo[] propriedades;
            propriedades = tipoObjeto.GetProperties();

            objetoParaXML(oXmlGravar, infNFE.Ide, false);
            objetoParaXML(oXmlGravar, infNFE.Emit, false);
            objetoParaXML(oXmlGravar, infNFE.Dest, false);


            foreach (infNFE.det detalhe in infNFE.Det)
            {
                oXmlGravar.WriteStartElement("det");
                oXmlGravar.WriteAttributeString("nItem", detalhe.nItem.ToString());

                objetoParaXML(oXmlGravar, detalhe.Prod, false);

                oXmlGravar.WriteStartElement("imposto");
                objetoParaXML(oXmlGravar, detalhe.Imposto.Icms, false);
                objetoParaXML(oXmlGravar, detalhe.Imposto.Ii, false);
                objetoParaXML(oXmlGravar, detalhe.Imposto.Ipi, false);
                objetoParaXML(oXmlGravar, detalhe.Imposto.Pis, false);
                objetoParaXML(oXmlGravar, detalhe.Imposto.Cofins, false);

                oXmlGravar.WriteEndElement(); //fecha TAG imposto...
                oXmlGravar.WriteEndElement(); //fecha TAG det...
            }

            objetoParaXML(oXmlGravar, infNFE.Total, false);
            objetoParaXML(oXmlGravar, infNFE.Transp, false);
            //objetoParaXML(oXmlGravar, infNFE.Cobr, false);

            if (infNFE.Cobr != null)
            {
                oXmlGravar.WriteStartElement("cobr");
                foreach (infNFE.cobr.dup duplicata in infNFE.Cobr.Dup)
                {
                    objetoParaXML(oXmlGravar, duplicata, false);
                }

                oXmlGravar.WriteEndElement(); //fecha tag cobr

            }
            objetoParaXML(oXmlGravar, infNFE.InfAdic, false);

            oXmlGravar.WriteEndElement(); //fecha infNFe

            oXmlGravar.WriteEndElement(); //fecha NFe            

            oXmlGravar.Flush();
            xmlSaida.Flush();
            xmlSaida.Position = 0;

            XmlDocument documento = new XmlDocument();
            documento.Load(xmlSaida);

            //documento.Save("c:\\testeXML.xml");

            oXmlGravar.Close();

            return documento;
        }




        private infNFE _infNFE;

        //private string _Id;

        public string versao { get; set; }

        public string Id { get; set; }
        /// <summary>
        /// Utilizado na geração de XML para consulta de recibo
        /// </summary>
        public string nRec { get; set; }
        /// <summary>
        /// Informar o número do Protocolo de Autorização da NF-e a ser Cancelada.
        /// 1 posição (1 – Secretaria de Fazenda Estadual 
        /// 2 – Receita Federal); 2 posições para código da UF;
        /// 2 posições ano;
        /// 10 seqüencial no ano
        /// </summary>
        public string nProt { get; set; }
        public string xJust { get; set; }
        public string ano { get; set; }
        public int NumNf_Ini { get; set; }
        public int NumNf_Fin { get; set; }

        public infNFE infNFE
        {
            get
            {
                return _infNFE;
            }
        }

        public NFe()
        {
            _infNFE = new infNFE();
        }
    }

    /// <summary>
    /// Classe que armazena os dados para identificação da nota eletrônica
    /// </summary>
    public class infNFE
    {
        private emit _emit;
        public ide _ide;
        private dest _dest;
        private List<det> _det;

        public infNFE()
        {
            //Inicializa automaticamente apenas aqueles que são obrigatórios
            _emit = new emit();
            _dest = new dest();
            _ide = new ide();
            _det = new List<det>();
            /*_retirada = new retirada();
            _avulsa = new avulsa(); */
        }


        /*       Por enquanto não vou gerar o ID aqui... para que a Danfe possa ser impressa de imediato,
            *       o ERP deve gerar este ID
            * 
            * public string gerarChaveNFE() 
                {
            
                } */

        public ide Ide
        {
            get { return _ide; }
        }

        public emit Emit
        {
            get
            {
                return _emit;
            }
        }

        public avulsa Avulsa { get; set; }

        public total Total { get; set; }

        public cobr Cobr { get; set; }

        public infAdic InfAdic { get; set; }

        public dest Dest
        {
            get { return _dest; }
        }

        public List<det> Det
        {
            get { return _det; }
        }


        public retirada Retirada { get; set; }
        public entrega Entrega { get; set; }

        public transp Transp { get; set; }



        public class ide
        {
            public ide()
            {

            }

            /// <summary>
            /// Código da UF do emitente do Documento Fiscal. Utilizar a Tabela do IBGE de código de unidades da
            /// federação (Anexo IV - Tabela de UF, Município e País)
            /// </summary>            
            public int cUF { get; set; }
            /// <summary>
            /// Código numérico que compõe a Chave de Acesso. Número aleatório gerado pelo emitente para
            /// cada NF-e para evitar acessos indevidos da NF-e.
            /// </summary>
            public string cNF { get; set; }
            /// <summary>
            /// Informar a natureza da operação de que decorrer a saída ou a entrada, tais como: venda, compra,
            /// transferência, devolução, importação, consignação, remessa (para fins de demonstração, de
            /// industrialização ou outra), conforme previsto na alínea 'i', inciso I, art. 19
            /// do CONVÊNIO S/Nº, de 15 de dezembro de 1970
            /// </summary>
            public string natOp { get; set; }
            /// <summary>
            /// 0 – pagamento à vista;
            /// 1 – pagamento à prazo;
            /// 2 - outros.
            /// </summary>
            public string indPag { get; set; }
            /// <summary>
            /// Utilizar o código 55 para identificação da NF-e, emitida em substituição ao modelo 1 ou 1A.
            /// </summary>        
            public string mod { get; set; }
            /// <summary>
            /// Série do Documento Fiscal, preencher com zeros na hipótese de a NF-e não possuir série.
            /// </summary>
            public string serie { get; set; }
            /// <summary>
            /// Número do Documento Fiscal.
            /// </summary>
            public string nNF { get; set; }
            /// <summary>
            /// Data de emissão do documento fiscal, Formato “AAAA-MM-DD”
            /// </summary>
            public DateTime dEmi { get; set; }
            /// <summary>
            /// Data de saída ou da entrada da mercadoria/produto,  Formato “AAAA-MM-DD”
            /// </summary>
            public DateTime? dSaiEnt { get; set; }
            /// <summary>
            /// 0-entrada / 1-saída
            /// </summary>
            public int tpNF { get; set; }
            /// <summary>
            /// Informar o município de ocorrência do fato gerador do ICMS. Utilizar a 
            /// Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
            /// </summary>
            public int cMunFG { get; set; }
            /// <summary>
            /// Formato de Impressão do DANFE
            /// </summary>   

            public int tpImp { get; set; }
            /// <summary>
            /// 1 – Normal – emissão normal;
            /// 2 – Contingência FS – emissão em contingência com impressão do DANFE em Formulário de Segurança;
            /// 3 – Contingência SCAN – emissão em contingência no Sistema de Contingência do Ambiente Nacional – SCAN;
            /// 4 – Contingência DPEC - emissão em contingência com envio da Declaração Prévia de Emissão em Contingência – DPEC;
            /// 5 – Contingência FS-DA - emissão em contingência com impressão do DANFE em Formulário de Segurança para Impressão de
            /// Documento Auxiliar de Documento Fiscal Eletrônico (FS-DA).
            /// </summary>
            public string tpEmis { get; set; }
            /// <summary>
            /// Informar o DV da Chave de Acesso da NF-e, o DV será calculado com a aplicação do algoritmo módulo 11
            /// (base 2,9) da Chave de Acesso. (vide item 5 do Manual de Integração)
            /// </summary>
            public string cDV { get; set; }
            /// <summary>
            /// 1-Produção/ 2-Homologação
            /// </summary>
            public int tpAmb { get; set; }
            /// <summary>
            /// 1- NF-e normal/ 2-NF-e complementar / 3 – NF-e de ajuste
            /// </summary>            
            public string finNFe { get; set; }
            /// <summary>
            /// Identificador do processo de emissão da NF-e: 0 - emissão de NF-e com aplicativo do contribuinte;
            /// 1 - emissão de NF-e avulsa pelo Fisco;
            /// 2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
            /// 3- emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.
            /// </summary>
            public string procEmi { get; set; }
            /// <summary>
            /// Identificador da versão do processo de emissão (informar a versão do aplicativo emissor de NF-e).
            /// </summary>
            public string verProc { get; set; }

            public NFref NFRef { get; set; }

            /// <summary>
            /// Grupo com as informações das NF/NF-e referenciadas
            /// </summary>
            public class NFref
            {
                private NFref _nfRef;
                private refNF _RefNF;
                /// <summary>
                /// Utilizar esta TAG para referenciar uma Nota Fiscal Eletrônica emitida
                /// anteriormente, vinculada a NF-e atual.
                /// Esta informação será utilizada nas hipóteses previstas na legislação.
                /// (Ex.: Devolução de Mercadorias, Substituição de NF cancelada, Complementação de NF, etc.).
                /// </summary>

                public NFref()
                {
                    _RefNF = new refNF();
                    _nfRef = new NFref();
                }

                public string refNFE { get; set; }

                public NFref nfRef
                {
                    get
                    {
                        return _nfRef;
                    }
                }

                public refNF RefNF
                {
                    get
                    {
                        return _RefNF;
                    }
                }
                /// <summary>
                /// Grupo com as informações das NF referenciadas Idem a informação da TAG anterior, referenciando 
                /// uma Nota Fiscal modelo 1/1A normal (a NF referenciada não é uma NF-e).
                /// </summary>
                public class refNF
                {
                    /// <summary>
                    /// Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
                    /// </summary>
                    public int cUF { get; set; }
                    /// <summary>
                    /// AAMM da emissão da NF
                    /// </summary>
                    public string AAMM { get; set; }
                    /// <summary>
                    /// Informar o CNPJ do emitente da NF
                    /// </summary>
                    public string CNPJ { get; set; }
                    /// <summary>
                    /// Informar o código do modelo do Documento fiscal: 01 – modelo 01
                    /// </summary>
                    public string mod { get; set; }
                    /// <summary>
                    /// Informar a série do documento fiscal (informar zero se inexistente).
                    /// </summary>
                    public string serie { get; set; }
                    /// <summary>
                    /// 1 – 999999999
                    /// </summary>
                    public string nNF { get; set; }
                    /// <summary>
                    /// 1-Retrato/ 2-Paisagem
                    /// </summary>
                }
            }
        }

        /// <summary>
        /// Grupo com as informações do emitente da NF-e
        /// </summary>
        public class emit
        {
            public emit()
            {
                _enderEmit = new enderEmit();
            }

            private enderEmit _enderEmit;

            /// <summary>
            /// Informar o CNPJ do emitente. Em se tratando de emissão de NF-e avulsa pelo Fisco, as informações
            /// do remente serão informadas neste grupo. O CNPJ ou CPF deverão ser informados com os zeros não
            /// significativos.
            /// </summary>
            public string CNPJ { get; set; }
            /// <summary>
            /// Informar o CNPJ do emitente. Em se tratando de emissão de NF-e avulsa pelo Fisco, as informações
            /// do remente serão informadas neste grupo. O CNPJ ou CPF deverão ser informados com os zeros não
            /// significativos.
            /// </summary>
            public string CPF { get; set; }
            /// <summary>
            /// Razão social ou nome do emitente
            /// </summary>
            public string xNome { get; set; }
            /// <summary>
            /// Nome fantasia
            /// </summary>
            public string xFant { get; set; }
            /// <summary>
            /// TAG de grupo do Endereço do emitente
            /// </summary>
            public enderEmit EnderEmit
            {
                get
                {
                    return _enderEmit;
                }
            }

            /// <summary>
            /// Campo de informação obrigatória nos casos de emissão própria (procEmi = 0, 2 ou 3).
            /// A IE deve ser informada apenas com algarismos para destinatários contribuintes do ICMS, sem
            /// caracteres de formatação (ponto,barra, hífen, etc.);
            /// O literal “ISENTO” deve ser informado apenas para contribuintes do ICMS que são isentos de inscrição no cadastro de
            /// contribuintes do ICMS e estejam emitindo NF-e avulsa;
            /// </summary>
            [Obrigatorio]
            public string IE { get; set; }
            /// <summary>
            /// Informar a IE do ST da UF de destino da mercadoria, quando houver a retenção do ICMS ST para a UF de destino.
            /// </summary>
            public string IEST { get; set; }
            /// <summary>
            /// Este campo deve ser informado, quando ocorrer a emissão de NF-e conjugada, com prestação de
            /// serviços sujeitos ao ISSQN e fornecimento de peças sujeitos ao ICMS.
            /// </summary>
            public string IM { get; set; }
            /// <summary>
            /// Este campo deve ser informado quando o campo IM (C19) for informado.
            /// </summary>
            public string CNAE { get; set; }

            /// <summary>
            /// Código de Regime Tributário
            /// Será obrigatoriamente preenchido com:  1 – Simples Nacional; 2 – Simples Nacional – excesso de sublimite de receita bruta; 3 – Regime Normal.
            /// </summary>
            public int CRT { get; set; }

            /// <summary>
            /// Telefone
            /// Somente numeros
            /// </summary>
            public int fone { get; set; }

            public class enderEmit
            {
                /// <summary>
                /// Logradouro
                /// </summary>
                public string xLgr { get; set; }
                /// <summary>
                /// Número
                /// </summary>
                public string nro { get; set; }
                /// <summary>
                /// Complemento
                /// </summary>
                public string xCpl { get; set; }
                /// <summary>
                /// Bairro
                /// </summary>
                public string xBairro { get; set; }
                /// <summary>
                /// Código do municipio, Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
                /// Informar ‘9999999 ‘para operações com o exterior.
                /// </summary>
                public int cMun { get; set; }
                /// <summary>
                /// Informar ‘EXTERIOR ‘para operações com o exterior.
                /// </summary>
                public string xMun { get; set; }
                /// <summary>
                /// Informar ‘EX ‘para operações com o exterior.
                /// </summary>
                public string UF { get; set; }
                /// <summary>
                /// Informar os zeros não significativos.
                /// </summary>
                public string CEP { get; set; }
                /// <summary>
                /// 1058 - Brasil
                /// </summary>
                public int cPais { get; set; }
                /// <summary>
                /// Brasil ou BRASIL
                /// </summary>
                public string xPais { get; set; }
                /// <summary>
                /// Preencher com Código DDD + número do telefone.
                /// </summary>
                public string fone { get; set; }
            }
        }

        /// <summary>
        /// Informações do fisco emitente, grupo de uso exclusivo do fisco.
        /// </summary>
        public class avulsa
        {
            public avulsa()
            {

            }

            /// <summary>
            /// CNPJ do órgão emitente
            /// </summary>
            public string CNPJ { get; set; }
            /// <summary>
            /// Órgão emitente
            /// </summary>
            public string xOrgao { get; set; }
            /// <summary>
            /// Matrícula do agente
            /// </summary>
            public string matr { get; set; }
            /// <summary>
            /// Nome do agente
            /// </summary>
            public string xAgente { get; set; }
            /// <summary>
            /// Preencher com Código DDD + número do telefone
            /// </summary>
            public string fone { get; set; }
            /// <summary>
            /// Sigla da UF
            /// </summary>
            public string UF { get; set; }
            /// <summary>
            /// Número do Documento de Arrecadação de Receita
            /// </summary>
            public string nDAR { get; set; }
            /// <summary>
            /// Data de emissão do Documento de Arrecadação
            /// </summary>
            public DateTime dEmi { get; set; }
            /// <summary>
            /// Valor Total constante no Documento de arrecadação de Receita
            /// </summary>
            public double vDAR { get; set; }
            /// <summary>
            /// Repartição Fiscal emitente
            /// </summary>
            public string repEmi { get; set; }
            /// <summary>
            /// Data de pagamento do Documento de Arrecadação
            /// </summary>
            public DateTime dPag { get; set; }
        }

        /// <summary>
        /// Grupo com as informações do destinatário da NF-e.
        /// </summary>
        public class dest
        {
            private enderDest _enderDest;
            public dest()
            {
                _enderDest = new enderDest();
            }
            /// <summary>
            /// Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos.
            /// Não informar o conteúdo da TAG se a operação for realizada com o exterior.
            /// </summary>
            public string CNPJ { get; set; }
            /// <summary>
            /// Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos.
            /// Não informar o conteúdo da TAG se a operação for realizada com o exterior.
            /// </summary>
            public string CPF { get; set; }
            /// <summary>
            /// Razão Social ou nome do destinatário
            /// </summary>
            public string xNome { get; set; }
            /// <summary>
            /// Obrigatório, nas operações que se beneficiam de incentivos fiscais existentes nas áreas sob controle
            /// da SUFRAMA. A omissão da Inscrição SUFRAMA impede o processamento da operação pelo Sistema de
            /// Mercadoria Nacional da SUFRAMA e a liberação da Declaração de Ingresso, prejudicando a
            /// comprovação do ingresso/internamento da mercadoria nas áreas sob controle da SUFRAMA.
            /// </summary>
            public string ISUF { get; set; }

            /// <summary>
            /// Telefone
            /// Somente numeros
            /// </summary>
            public int fone { get; set; }

            /// <summary>
            /// email
            /// Campo pode ser utilizado para informar o e-mail de recepção da NF-e indicada pelo destinatário
            /// </summary>
            public int email { get; set; }

            public int idDest { get; set; }

            //Indica operação com Consumidor final  0-Não  1-Consumidor Final
            public int indFinal { get; set; }

            /*Indicador de presença do comprador no estabelecimento comercial no momento da operação
                0=Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste);
                1=Operação presencial;
                2=Operação não presencial, pela Internet;
                3=Operação não presencial, Teleatendimento;
                4=NFC-e em operação com entrega a domicílio;
                9=Operação não presencial, outros.
            * */

            public int indPres { get; set; }

            //Indicador da IE do Destinatário
            public int indIEDest { get; set; }


            public enderDest EnderDest
            {
                get
                {
                    return _enderDest;
                }
            }
            /// <summary>
            /// Informar a IE quando o destinatário for contribuinto do ICMS. Informar ISENTO quando o
            /// destinatário for contribuinto do ICMS, mas não estiver obrigado à inscrição no cadastro de
            /// contribuintes do ICMS. Não informar o conteúdo da TAG se o destinatário não for contribuinte do ICMS.
            /// Esta tag aceita apenas: . ausência de conteúdo (<IE></IE> ou <IE/>) para destinatários não
            /// contribuintes do ICMS; . algarismos para destinatários contribuintes do ICMS, sem caracteres de formatação (ponto,
            /// barra, hífen, etc.); . literal “ISENTO” para destinatários contribuintes do ICMS que são isentos de inscrição no cadastro de
            /// contribuintes do ICMS;
            /// </summary>
            [Obrigatorio]
            public string IE { get; set; }
            public class enderDest
            {
                /// <summary>
                /// Logradouro
                /// </summary>
                public string xLgr { get; set; }
                /// <summary>
                /// Número
                /// </summary>
                public string nro { get; set; }
                /// <summary>
                /// Complemento
                /// </summary>
                public string xCpl { get; set; }
                /// <summary>
                /// Bairro
                /// </summary>
                public string xBairro { get; set; }
                /// <summary>
                /// Código do municipio, Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
                /// Informar ‘9999999 ‘para operações com o exterior.
                /// </summary>
                public int cMun { get; set; }
                /// <summary>
                /// Informar ‘EXTERIOR ‘para operações com o exterior.
                /// </summary>
                public string xMun { get; set; }
                /// <summary>
                /// Informar ‘EX ‘para operações com o exterior.
                /// </summary>
                public string UF { get; set; }
                /// <summary>
                /// Informar os zeros não significativos.
                /// </summary>
                public string CEP { get; set; }
                /// <summary>
                /// 1058 - Brasil
                /// </summary>
                public int cPais { get; set; }
                /// <summary>
                /// Brasil ou BRASIL
                /// </summary>
                public string xPais { get; set; }
                /// <summary>
                /// Preencher com Código DDD + número do telefone.
                /// </summary>
                public string fone { get; set; }
            }

        }

        /// <summary>
        /// Informar apenas quando for diferente do endereço do remetente.
        /// </summary>
        public class retirada
        {
            public string CNPJ { get; set; }
            public string xLgr { get; set; }
            public string nro { get; set; }
            public string xCpl { get; set; }
            public string xBairro { get; set; }
            /// <summary>
            /// Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País). Informar ‘9999999 ‘para operações
            /// com o exterior.
            /// </summary>
            public int cMun { get; set; }
            public string xMun { get; set; }
            public string UF { get; set; }
        }

        public class entrega
        {
            public string CNPJ { get; set; }
            public string xLgr { get; set; }
            public string nro { get; set; }
            public string xCpl { get; set; }
            public string xBairro { get; set; }
            /// <summary>
            /// Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País). Informar ‘9999999 ‘para operações
            /// com o exterior.
            /// </summary>
            public int cMun { get; set; }
            public string xMun { get; set; }
            public string UF { get; set; }
        }

        /// <summary>
        /// H01
        /// </summary>
        public class det
        {
            private prod _prod;
            private imposto _imposto;
            public det()
            {
                _prod = new prod();
                _imposto = new imposto();
            }

            public int nItem { get; set; }
            public prod Prod
            {
                get { return _prod; }
            }

            public imposto Imposto
            {
                get { return _imposto; }
            }



            /// <summary>
            /// TAG de grupo do detalhamento de Produtos e Serviços da NF-e
            /// </summary>
            public class prod
            {
                public prod()
                {
                    //vDesc = null;
                }
                /// <summary>
                /// Código de produto ou serviço
                /// Preencher com CFOP, caso se trate de itens não relacionados com mercadorias/produto e que o
                /// contribuinte não possua codificação própria.
                /// Formato ”CFOP9999”
                /// </summary>


                public string cProd { get; set; }
                /// <summary>
                /// GTIN (Global Trade Item Number) do produto, antigo código EAN ou código de barras
                /// 
                /// Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 
                /// (antigos códigos EAN, UPC e DUN-14), não informar o conteúdo da TAG em caso de o produto não
                /// possuir este código.
                /// </summary>

                [Obrigatorio]
                public string cEAN { get; set; }
                /// <summary>
                /// Descrição do produto ou serviço
                /// </summary>
                public string xProd { get; set; }
                /// <summary>
                /// Preencher de acordo com a Tabela de Capítulos da NCM. Em caso deserviço, não incluir a TAG.
                /// </summary>
                public string NCM { get; set; }
                /// <summary>
                /// Preencher de acordo com o código EX da TIPI. Em caso de serviço,não incluir a TAG
                /// </summary>
                public string EXTIPI { get; set; }
                /// <summary>
                /// Gênero do produto ou serviço. Preencher de acordo com a Tabela de Capítulos da NCM. Em caso de serviço, não incluir a TAG.
                /// </summary>
                public string genero { get; set; }
                /// <summary>
                /// Utilizar Tabela de CFOP.
                /// </summary>
                public string CFOP { get; set; }
                /// <summary>
                /// Informar a unidade de comercialização do produto.
                /// </summary>
                public string uCom { get; set; }
                /// <summary>
                /// Informar a quantidade de comercialização do produto
                /// </summary>
                //[Formato("N4", "pt-BR")]
                [Formato("#####0.00", "en-US")]
                public decimal qCom { get; set; }
                /// <summary>
                /// Informar o valor unitário de comercialização do produto
                /// </summary>
                //[Formato("N4", "pt-BR")]
                [Formato("#####0.00", "en-US")]
                public double vUnCom { get; set; }
                /// <summary>
                /// Valor Total Bruto dos Produtos ou Serviços
                /// </summary>
                public double vProd { get; set; }
                /// <summary>
                /// GTIN (Global Trade Item Number) da unidade tributável,antigo código EAN ou código de barras
                /// 
                /// Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 (antigos códigos EAN, UPC e DUN-14) da unidade tributável do
                /// produto, não informar o conteúdo da TAG em caso de o produto não possuir este código.
                /// </summary>                
                [Obrigatorio]
                public string cEANTrib { get; set; }
                /// <summary>
                /// Unidade Tributável
                /// </summary>
                public string uTrib { get; set; }
                /// <summary>
                /// Quantidade Tributável
                /// </summary>                
                [Formato("#####0.00", "en-US")]
                public decimal? qTrib { get; set; }
                /// <summary>
                /// Valor Unitário de tributação
                /// 
                /// Informar o valor unitário de tributação do produto
                /// </summary>                
                [Formato("#####0.00", "en-US")]
                public double? vUnTrib { get; set; }
                /// <summary>
                /// Valor total do frete
                /// </summary>
                public double? vFrete { get; set; }
                /// <summary>
                /// Valor total do seguro
                /// </summary>
                public double? vSeg { get; set; }
                /// <summary>
                /// Valor do desconto
                /// </summary>
                public double? vDesc { get; set; }

                /// <summary>
                /// Este campo deverá ser preenchido com: 0 – o valor do item (vProd) não compõe o valor total da NF-e (vProd) . 1 – o valor do item (vProd) compõe o valor total da NF-e
                ///(vProd) (v2.0)
                /// </summary>
                public int indTot { get; set; }

                public DI Di { get; set; }
                public veicProd VeicProd { get; set; }
                public med Med { get; set; }
                public arma Arma { get; set; }
                public comb Comb { get; set; }

                /// <summary>
                /// Tag da Declaração de Importação
                /// </summary>
                public class DI
                {
                    private List<adi> _adi;
                    public DI()
                    {
                        _adi = new List<adi>();
                    }

                    /// <summary>
                    /// Número do Documento de Importação DI/DSI/DA (DI/DSI/DA)
                    /// </summary>
                    public string nDI { get; set; }
                    /// <summary>
                    /// Data de Registro da DI/DSI/DA
                    /// Formato “AAAA-MM-DD”
                    /// </summary>
                    public DateTime dDI { get; set; }
                    /// <summary>
                    /// Local de desembaraço
                    /// </summary>
                    public string xLocDesemb { get; set; }
                    /// <summary>
                    /// Sigla da UF onde ocorreu o Desembaraço Aduaneiro
                    /// </summary>
                    public string UFDesemb { get; set; }
                    /// <summary>
                    /// Data do Desembaraço Aduaneiro
                    /// </summary>
                    public DateTime dDesemb { get; set; }
                    /// <summary>
                    /// Código do exportador, usado nos sistemas internos de informação do emitente da NF-e
                    /// </summary>
                    public string cExportador { get; set; }

                    /// <summary>
                    /// Adições
                    /// </summary>
                    public List<adi> Adi
                    {
                        get { return _adi; }
                    }

                    public class adi
                    {
                        /// <summary>
                        /// Numero da adição
                        /// </summary>
                        public string nAdicao { get; set; }
                        /// <summary>
                        /// Numero seqüencial do item dentro da adição
                        /// </summary>
                        public string nSeqAdic { get; set; }
                        /// <summary>
                        /// Código do fabricante estrangeiro, usado nos sistemas internos de
                        /// informação do emitente da NF-e
                        /// </summary>
                        public string cFabricante { get; set; }
                        /// <summary>
                        /// Valor do desconto do item da DI – adição
                        /// </summary>
                        public double vDescDI { get; set; }
                    }
                }

                /// <summary>
                /// TAG de grupo do detalhamento de Veículos novos
                /// 
                /// Informar apenas quando se tratar de veículos novos
                /// </summary>
                public class veicProd
                {
                    /// <summary>
                    /// 1 – Venda concessionária,
                    /// 2 – Faturamento direto
                    /// 3 – Venda direta
                    /// 0 – Outros
                    /// </summary>
                    public int tpOp { get; set; }
                    /// <summary>
                    /// Chassi do veículo
                    /// </summary>
                    public string chassi { get; set; }
                    /// <summary>
                    /// Código de cada montadora
                    /// </summary>
                    public string cCor { get; set; }
                    /// <summary>
                    /// Descrição da Cor
                    /// </summary>
                    public string xCor { get; set; }
                    /// <summary>
                    /// Potência Motor
                    /// </summary>
                    public string pot { get; set; }
                    /// <summary>
                    /// CM3 (Potência)
                    /// </summary>
                    public string CM3 { get; set; }
                    /// <summary>
                    /// Peso Líquido
                    /// </summary>
                    public double pesoL { get; set; }
                    /// <summary>
                    /// Peso bruto
                    /// </summary>
                    public double pesoB { get; set; }
                    /// <summary>
                    /// Serial (série)
                    /// </summary>
                    public string nSerie { get; set; }
                    /// <summary>
                    /// Tipo de combustível
                    /// </summary>
                    public string tpComb { get; set; }
                    /// <summary>
                    /// Numero do motor
                    /// </summary>
                    public string nMotor { get; set; }
                    public string CMKG { get; set; }
                    /// <summary>
                    /// Distância entre eixos
                    /// </summary>
                    public string dist { get; set; }
                    /// <summary>
                    /// RENAVAM
                    /// </summary>
                    public string RENAVAM { get; set; }
                    /// <summary>
                    /// Ano Modelo de Fabricação
                    /// </summary>
                    public string anoMod { get; set; }
                    /// <summary>
                    /// Ano de fabricação
                    /// </summary>
                    public string anoFab { get; set; }
                    /// <summary>
                    /// Tipo de pintura
                    /// </summary>
                    public string tpPint { get; set; }
                    /// <summary>
                    /// Tipo de veiculo
                    /// </summary>
                    public string tpVeic { get; set; }
                    /// <summary>
                    /// Espécie do veiculo
                    /// </summary>
                    public string espVeic { get; set; }
                    /// <summary>
                    /// Condição do VIN
                    /// </summary>
                    public string VIN { get; set; }
                    /// <summary>
                    /// Condição do veiculo
                    /// </summary>
                    public string condVeic { get; set; }
                    /// <summary>
                    /// Código Marca Modelo
                    /// </summary>
                    public string cMod { get; set; }
                }

                /// <summary>
                /// Informar apenas quando se tratar de medicamentos, permite múltiplas ocorrências (ilimitado)
                /// </summary>
                public class med
                {
                    /// <summary>
                    /// Número do Lote do medicamento
                    /// </summary>
                    public string nLote { get; set; }
                    /// <summary>
                    /// Quantidade de produto no Lote do medicamento
                    /// </summary>
                    [Formato("N0", "pt-BR")]
                    public decimal qLote { get; set; }
                    /// <summary>
                    /// Data de fabricação
                    /// </summary>
                    public DateTime dFab { get; set; }
                    /// <summary>
                    /// Data de validade
                    /// </summary>
                    public DateTime dVal { get; set; }
                    /// <summary>
                    /// Preço máximo consumidor
                    /// </summary>
                    public decimal vPMC { get; set; }
                }

                /// <summary>
                /// Informar apenas quando se tratar de armamento, permite múltiplas
                /// ocorrências (ilimitado)
                /// </summary>
                public class arma
                {
                    /// <summary>
                    /// Indicador do tipo de arma de fogo
                    /// 
                    /// 0 - Uso permitido;
                    /// 1 - Uso restrito;
                    /// </summary>
                    public string tpArma { get; set; }
                    /// <summary>
                    /// Número de série da arma
                    /// </summary>
                    public string nSerie { get; set; }
                    /// <summary>
                    /// Número de série do cano
                    /// </summary>
                    public string nCano { get; set; }
                    /// <summary>
                    /// Descrição completa da arma, compreendendo: calibre, marca, capacidade, tipo de
                    /// funcionamento, comprimento e demais elementos que permitam a sua perfeita identificação.
                    /// </summary>
                    public string descr { get; set; }
                }


                /// <summary>
                /// TAG de grupo de informações específicas para combustíveis líquidos
                /// </summary>
                public class comb
                {
                    private CIDE _CIDE;
                    public comb()
                    {
                        _CIDE = new CIDE();
                    }

                    public CIDE Cide
                    {
                        get { return _CIDE; }
                    }

                    /// <summary>
                    /// Informar apenas quando se tratar de produtos regulados pela ANP -Agência Nacional do Petróleo.
                    /// Utilizar a codificação de produtos do Sistema de Informações de Movimentação de produtos - SIMP
                    /// (http://www.anp.gov.br/simp/index.htm)
                    /// </summary>
                    public string cProdANP { get; set; }
                    /// <summary>
                    /// Informar apenas quando a UF utilizar o CODIF (Sistema de Controle do Diferimento do Imposto nas Operações com AEAC - Álcool
                    /// Etílico Anidro Combustível).
                    /// </summary>
                    public string CODIF { get; set; }
                    /// <summary>
                    /// Informar quando a quantidade faturada informada no campo qCom (I10) tiver sido ajustada para
                    /// uma temperatura diferente da ambiente.
                    /// </summary>
                    public string qTemp { get; set; }

                    public class CIDE
                    {
                        public decimal qBCProd { get; set; }
                        public double vAliqProd { get; set; }
                        public double vCIDE { get; set; }
                    }

                    public class ICMSComb
                    {
                        public double vBCICMS { get; set; }
                        public double vICMS { get; set; }
                        public double vBCICMSST { get; set; }
                        public double vICMSST { get; set; }
                    }

                    public class ICMSInter
                    {
                        public double vBCICMSSTDest { get; set; }
                        public double vICMSSTDest { get; set; }
                    }

                    public class ICMSCons
                    {
                        public double vBCICMSSTCons { get; set; }
                        public double vICMSSTCons { get; set; }
                        public string UFcons { get; set; }
                    }





                }
            }

            public class imposto
            {
                public imposto()
                {
                    //Só instância aqueles que são obritórios e utilizados sempre...                    
                }

                public ICMS Icms { get; set; }

                public IPI Ipi { get; set; }

                public II Ii { get; set; }

                public PIS Pis { get; set; }
                public PISST PisST { get; set; }

                public COFINS Cofins { get; set; }
                public COFINSST CofinsST { get; set; }

                public ISSQN Issqn { get; set; }

                /// <summary>
                /// Informar apenas um dos grupos N02, N03, N04, N05, N06, N07, N08, N09 ou N10, com base no
                /// conteúdo informado na TAG CST.
                /// </summary>
                public class ICMS
                {
                    public ICMS()
                    {

                    }

                    public ICMS00 Icms00 { get; set; }
                    public ICMS10 Icms10 { get; set; }
                    public ICMS20 Icms20 { get; set; }
                    public ICMS30 Icms30 { get; set; }
                    public ICMS40 Icms40 { get; set; }
                    public ICMS51 Icms51 { get; set; }
                    public ICMS60 Icms60 { get; set; }
                    public ICMS70 Icms70 { get; set; }
                    public ICMS90 Icms90 { get; set; }

                    public class ICMS00
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }
                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                    }

                    public class ICMS10
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }
                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                        /// <summary>
                        /// Modalidade de determinação da BC do ICMS ST
                        /// 0 – Preço tabelado ou máximo sugerido;
                        /// 1 - Lista Negativa (valor);
                        /// 2 - Lista Positiva (valor);
                        /// 3 - Lista Neutra (valor);
                        /// 4 - Margem Valor Agregado (%);
                        /// 5 - Pauta (valor);
                        /// </summary>
                        public string modBCST { get; set; }
                        /// <summary>
                        /// Percentual da margem de valor Adicionado do ICMS ST
                        /// </summary>
                        public double? pMVAST { get; set; }
                        /// <summary>
                        /// Percentual da Redução de BC do ICMS ST
                        /// </summary>                    
                        public double? pRedBCST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST
                        /// </summary>
                        public double vBCST { get; set; }
                        /// <summary>
                        /// Alíquota do imposto do ICMS ST
                        /// </summary>
                        public double pICMSST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST retido
                        /// </summary>
                        public double vICMSST { get; set; }
                    }

                    /// <summary>
                    /// CST – 20 - Com redução de base de cálculo
                    /// </summary>
                    public class ICMS20
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }

                        /// <summary>
                        /// Percentual da Redução de BC do ICMS
                        /// </summary>                    
                        public double pRedBC { get; set; }

                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }

                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                    }

                    /// <summary>
                    /// CST – 30 - Isenta ou não tributada e com cobrança do ICMS por
                    /// substituição tributária
                    /// </summary>
                    public class ICMS30
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBCST { get; set; }
                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double? pMVAST { get; set; }
                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        /// <summary>
                        /// Percentual da Redução de BC do ICMS ST
                        /// </summary>                    
                        public double? pRedBCST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST
                        /// </summary>
                        public double vBCST { get; set; }
                        /// <summary>
                        /// Alíquota do imposto do ICMS ST
                        /// </summary>
                        public double pICMSST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST retido
                        /// </summary>
                        public double vICMSST { get; set; }
                    }
                    /// <summary>
                    /// CST 
                    /// 40 - Isenta
                    /// 41 - Não tributada
                    /// 50 - Suspensão
                    /// </summary>
                    public class ICMS40
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                    }

                    public class ICMS51
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }

                        /// <summary>
                        /// Percentual da Redução de BC do ICMS
                        /// </summary>                    
                        public double pRedBC { get; set; }

                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                        /// <summary>
                        /// Modalidade de determinação da BC do ICMS ST
                        /// 0 – Preço tabelado ou máximo sugerido;
                        /// 1 - Lista Negativa (valor);
                        /// 2 - Lista Positiva (valor);
                        /// 3 - Lista Neutra (valor);
                        /// 4 - Margem Valor Agregado (%);
                        /// 5 - Pauta (valor);
                        /// </summary>


                    }

                    /// <summary>
                    /// CST – 60 - ICMS cobrado anteriormente por substituição tributária
                    /// </summary>
                    public class ICMS60
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Valor da base de calculo
                        /// </summary>
                        public double vBCST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST cobrado anteriormente por ST
                        /// </summary>
                        public double vICMSST { get; set; }
                    }

                    public class ICMS70
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }
                        /// <summary>
                        /// Percentual da Redução de BC
                        /// </summary>
                        public double pRedBC { get; set; }
                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                        /// <summary>
                        /// Modalidade de determinação da BC do ICMS ST
                        /// 0 – Preço tabelado ou máximo sugerido;
                        /// 1 - Lista Negativa (valor);
                        /// 2 - Lista Positiva (valor);
                        /// 3 - Lista Neutra (valor);
                        /// 4 - Margem Valor Agregado (%);
                        /// 5 - Pauta (valor);
                        /// </summary>
                        public string modBCST { get; set; }
                        /// <summary>
                        /// Percentual da margem de valor Adicionado do ICMS ST
                        /// </summary>
                        public double? pMVAST { get; set; }
                        /// <summary>
                        /// Percentual da Redução de BC do ICMS ST
                        /// </summary>                    
                        public double? pRedBCST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST
                        /// </summary>
                        public double vBCST { get; set; }
                        /// <summary>
                        /// Alíquota do imposto do ICMS ST
                        /// </summary>
                        public double pICMSST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST retido
                        /// </summary>
                        public double vICMSST { get; set; }
                    }

                    public class ICMS90
                    {
                        /// <summary>
                        /// Origem da mercadoria: 
                        /// 0 – Nacional; 
                        /// 1 – Estrangeira – Importação direta;
                        /// 2 – Estrangeira – Adquirida no mercado interno.
                        /// </summary>
                        public string orig { get; set; }
                        /// <summary>
                        /// </summary>
                        /// Tributação do ICMS: 00 – Tributada integralmente
                        public string CST { get; set; }
                        /// <summary>
                        /// 0 - Margem Valor Agregado (%);
                        /// 1 - Pauta (Valor);
                        /// 2 - Preço Tabelado Máx. (valor);
                        /// 3 - valor da operação.
                        /// </summary>
                        public string modBC { get; set; }
                        /// <summary>
                        /// Valor da base de calculo do imposto
                        /// </summary>
                        public double vBC { get; set; }

                        /// <summary>
                        /// Percentual da Redução de BC
                        /// </summary>
                        public double? pRedBC { get; set; }

                        /// <summary>
                        /// Aliquota do imposto
                        /// </summary>
                        public double pICMS { get; set; }
                        /// <summary>
                        /// Valor do ICMS
                        /// </summary>
                        public double vICMS { get; set; }
                        /// <summary>
                        /// Modalidade de determinação da BC do ICMS ST
                        /// 0 – Preço tabelado ou máximo sugerido;
                        /// 1 - Lista Negativa (valor);
                        /// 2 - Lista Positiva (valor);
                        /// 3 - Lista Neutra (valor);
                        /// 4 - Margem Valor Agregado (%);
                        /// 5 - Pauta (valor);
                        /// </summary>
                        public string modBCST { get; set; }
                        /// <summary>
                        /// Percentual da margem de valor Adicionado do ICMS ST
                        /// </summary>
                        public double? pMVAST { get; set; }
                        /// <summary>
                        /// Percentual da Redução de BC do ICMS ST
                        /// </summary>                    
                        public double? pRedBCST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST
                        /// </summary>
                        public double vBCST { get; set; }
                        /// <summary>
                        /// Alíquota do imposto do ICMS ST
                        /// </summary>
                        public double pICMSST { get; set; }
                        /// <summary>
                        /// Valor do ICMS ST retido
                        /// </summary>
                        public double vICMSST { get; set; }
                    }
                }

                /// <summary>
                /// Informar apenas quando o item for sujeito ao IPI
                /// </summary>
                public class IPI
                {
                    public string clEnq { get; set; }
                    public string CNPJProd { get; set; }
                    public string cSelo { get; set; }
                    public decimal qSelo { get; set; }
                    public string cEnq { get; set; }

                    public IPITrib IpiTrib { get; set; }
                    public IPINT IpiNT { get; set; }

                    /// <summary>
                    /// Informar apenas um dos grupos O07 ou O08 com base valor atribuído ao campo O09 – CST do
                    /// IPI
                    /// </summary>
                    public class IPITrib
                    {
                        /// <summary>
                        /// 00-Entrada com recuperação de crédito
                        /// 49-Outras entradas
                        /// 50-Saída tributada
                        /// 99-Outras saídas
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Campo 010
                        /// 
                        /// Informar os campos O10 e O14 caso o cálculo do IPI seja por 
                        /// alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
                        /// unidade.
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Campo 011
                        /// 
                        /// Informar os campos O10 e O14 caso o cálculo do IPI seja por 
                        /// alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
                        /// unidade.
                        /// </summary>
                        public decimal qUnid { get; set; }
                        /// <summary>
                        /// Campo 012
                        /// 
                        /// Informar os campos O10 e O14 caso o cálculo do IPI seja por 
                        /// alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
                        /// unidade.
                        /// </summary>
                        public double vUnid { get; set; }
                        /// <summary>
                        /// Campo 013
                        /// 
                        /// Informar os campos O10 e O14 caso o cálculo do IPI seja por 
                        /// alíquota ou os campos O11 e O12 caso o cálculo do IPI seja valor por
                        /// unidade.
                        /// </summary>
                        public double pIPI { get; set; }
                        /// <summary>
                        /// Valor do IPI
                        /// </summary>
                        public double vIPI { get; set; }
                    }

                    /// <summary>
                    /// TAG de grupo do CST 01, 02, 03,04, 51, 52, 53, 54 e 55
                    /// </summary>
                    public class IPINT
                    {
                        /// <summary>
                        /// 01-Entrada tributada com alíquota zero
                        /// 02-Entrada isenta
                        /// 03-Entrada não-tributada
                        /// 04-Entrada imune
                        /// 05-Entrada com suspensão
                        /// 51-Saída tributada com alíquota zero
                        /// 52-Saída isenta
                        /// 53-Saída não-tributada
                        /// 54-Saída imune
                        /// 55-Saída com suspensão
                        /// </summary>
                        public string CST { get; set; }
                    }
                }

                /// <summary>
                /// TAG de grupo do Imposto de Importação
                /// Informar apenas quando o item for sujeito ao II
                /// </summary>
                public class II
                {
                    /// <summary>
                    /// Valor da BC do Imposto de Importação
                    /// </summary>
                    public double vBC { get; set; }
                    /// <summary>
                    /// Valor das despesas aduaneiras
                    /// </summary>
                    public double vDespAdu { get; set; }
                    /// <summary>
                    /// Valor do Imposto de Importação
                    /// </summary>
                    public double vII { get; set; }
                    /// <summary>
                    /// Valor do Imposto sobre Operações Financeiras
                    /// </summary>
                    public double vIOF { get; set; }
                }

                /// <summary>
                /// Informar apenas um dos grupos Q02, Q03, Q04 ou Q05 com base valor atribuído ao campo Q06 –CST do PIS
                /// </summary>
                public class PIS
                {
                    public PISAliq PisAliq { get; set; }
                    public PISQtde PisQtd { get; set; }
                    public PISNT PisNT { get; set; }
                    public PISOutr PisOutr { get; set; }

                    public class PISAliq
                    {
                        /// <summary>
                        /// Código de situação tributária do PIS
                        /// 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
                        /// 02 - Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada));
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Valor da Base de Cálculo do PIS
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Alíquota do PIS (em percentual)
                        /// </summary>
                        public double pPIS { get; set; }
                        /// <summary>
                        /// Valor do PIS
                        /// </summary>
                        public double vPIS { get; set; }
                    }

                    /// <summary>
                    /// TAG do grupo de PIS tributado por Qtde
                    /// CST = 03
                    /// </summary>
                    public class PISQtde
                    {
                        /// <summary>
                        /// 03 - Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto);
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Quantidade Vendida
                        /// </summary>
                        public decimal qBCProd { get; set; }
                        /// <summary>
                        /// Alíquota do PIS (em reais)
                        /// </summary>
                        public double vAliqProd { get; set; }
                        /// <summary>
                        /// Valor do PIS
                        /// </summary>
                        public double vPIS { get; set; }
                    }

                    /// <summary>
                    /// TAG do grupo de PIS não tributado
                    /// CST = 04, 06, 07, 08 ou 09
                    /// </summary>
                    public class PISNT
                    {
                        /// <summary>
                        /// 04 - Operação Tributável (tributação monofásica (alíquota zero));
                        /// 06 - Operação Tributável (alíquota zero);
                        /// 07 - Operação Isenta da Contribuição;
                        /// 08 - Operação Sem Incidência da Contribuição;
                        /// 09 - Operação com Suspensão da Contribuição;
                        /// </summary>
                        public string CST { get; set; }
                    }

                    /// <summary>
                    /// TAG do grupo de PIS Outras Operações
                    /// CST = 99
                    /// </summary>
                    public class PISOutr
                    {
                        /// <summary>
                        /// 99 - Outras Operações;
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Informar campos para cálculo do PIS em percentual (P07 e P08) ou campos para PIS em valor (P10 e P11).
                        /// </summary>
                        public double vBC { get; set; }
                        public double pPIS { get; set; }
                        public decimal qBCProd { get; set; }
                        public double vAliqProd { get; set; }
                        public double vPIS { get; set; }
                    }
                }

                /// <summary>
                /// TAG do grupo de PIS Substituição Tributária
                /// </summary>
                public class PISST
                {
                    /// <summary>
                    /// Informar campos para cálculo do PIS em percentual (R02 e R03) ou campos para PIS em valor (R04 e R05).
                    /// </summary>
                    public double vBC { get; set; }
                    public double pPIS { get; set; }
                    public decimal qBCProd { get; set; }
                    public double vAliqProd { get; set; }
                    public double vPIS { get; set; }
                }

                /// <summary>
                /// TAG de grupo do COFINS
                /// Informar apenas um dos grupos S02, S03, S04 ou S04 com base valor atribuído ao campo 
                /// S06 – CST do COFINS
                /// </summary>
                public class COFINS
                {
                    public COFINSAliq CofinsAliq { get; set; }
                    public COFINSQtde CofinsQtde { get; set; }
                    public COFINSNT CofinsNT { get; set; }
                    public COFINSOutr CofinsOutr { get; set; }

                    /// <summary>
                    /// TAG do grupo de COFINS tributado pela alíquota
                    /// CST = 01 ou 02
                    /// </summary>
                    public class COFINSAliq
                    {
                        /// <summary>
                        /// 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
                        /// 02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada));
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Valor da Base de Cálculo da COFINS
                        /// </summary>
                        public double vBC { get; set; }
                        /// <summary>
                        /// Alíquota da COFINS (em percentual)
                        /// </summary>
                        public double pCOFINS { get; set; }
                        /// <summary>
                        /// Valor do COFINS
                        /// </summary>
                        public double vCOFINS { get; set; }
                    }
                    /// <summary>
                    /// CST = 03
                    /// </summary>
                    public class COFINSQtde
                    {
                        /// <summary>
                        /// 03 - Operação Tributável (base de cálculo = quantidade vendida x  alíquota por unidade de produto);
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Quantidade Vendida
                        /// </summary>
                        public decimal qBCProd { get; set; }
                        /// <summary>
                        /// Aliquota do COFINS (em Reais)
                        /// </summary>
                        public double vAliqProd { get; set; }
                        /// <summary>
                        /// Valor do COFINS
                        /// </summary>
                        public double vCOFINS { get; set; }
                    }

                    /// <summary>
                    /// TAG do grupo de COFINS não tributado
                    /// CST = 04, 06, 07, 08, 09
                    /// </summary>
                    public class COFINSNT
                    {
                        /// <summary>
                        /// 04 - Operação Tributável (tributação monofásica (alíquota zero));
                        /// 06 - Operação Tributável (alíquota zero);
                        /// 07 - Operação Isenta da Contribuição; 
                        /// 08 - Operação Sem Incidência da Contribuição;
                        /// 09 - Operação com Suspensão da Contribuição;
                        /// </summary>
                        public string CST { get; set; }
                    }

                    /// <summary>
                    /// TAG do grupo de COFINS outras operações
                    /// CST = 99
                    /// </summary>
                    public class COFINSOutr
                    {
                        /// <summary>
                        /// 99 - Outras Operações;
                        /// </summary>
                        public string CST { get; set; }
                        /// <summary>
                        /// Informar campos para cálculo do COFINS em percentual (S07 e S08) ou campos para COFINS em valor (S09 e S10).
                        /// </summary>
                        public double vBC { get; set; }
                        public double pCOFINS { get; set; }
                        public decimal qBCProd { get; set; }
                        public double vAliqProd { get; set; }
                        public double vCOFINS { get; set; }
                    }
                }

                /// <summary>
                /// TAG do grupo de COFINS Substituição Tributária
                /// </summary>
                public class COFINSST
                {
                    /// <summary>
                    /// Informar campos para cálculo do COFINS Substituição Tributária em percentual (T02 e T03) ou campos
                    /// para COFINS em valor (T04 e T05).
                    /// </summary>
                    public double vBC { get; set; }
                    public double pCOFINS { get; set; }
                    public decimal qBCProd { get; set; }
                    public double vAliqProd { get; set; }
                    public double vCOFINS { get; set; }
                }

                /// <summary>
                /// TAG do grupo do ISSQN
                /// Informar os campos para cálculo do ISSQN nas NFe conjugadas, onde há a prestação de serviços
                /// sujeitos ao ISSQN e fornecimento de peças sujeitas ao ICMS 
                /// </summary>
                public class ISSQN
                {
                    public double vBC { get; set; }
                    public double vAliq { get; set; }
                    public double vISSQN { get; set; }
                    /// <summary>
                    /// Informar o município de ocorrência do fato gerador do ISSQN. Utilizar
                    /// a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
                    /// </summary>
                    public int cMunFG { get; set; }
                    /// <summary>
                    /// Informar o código da lista de serviços da LC 116/03 em que se
                    /// classifica o serviço.
                    /// </summary>
                    public string cListServ { get; set; }
                }
            }

            /// <summary>
            /// Informações adicionais do produto
            /// Norma referenciada, informações complementares, etc...
            /// </summary>
            public string infAdProd { get; set; }

            public double TotalImpostos { get; set; }

        }

        /// <summary>
        /// TAG de valores totais
        /// </summary>
        public class total
        {
            public ICMSTot IcmsTot { get; set; }
            public ISSQNtot ISSQNTot { get; set; }
            public retTrib RetTrib { get; set; }

            /// <summary>
            /// TAG de grupo de Valores Totais referentes ao ICMS
            /// </summary>
            public class ICMSTot
            {
                /// <summary>
                /// Base de Cálculo do ICMS
                /// </summary>
                public double vBC { get; set; }
                /// <summary>
                /// Valor Total do ICMS
                /// </summary>
                public double vICMS { get; set; }
                /// <summary>
                /// Base de Cálculo do ICMS ST
                /// </summary>
                public double vBCST { get; set; }
                /// <summary>
                /// Valor Total do ICMS ST
                /// </summary>
                public double vST { get; set; }
                /// <summary>
                /// Valor Total dos produtos e serviços
                /// </summary>
                public double vProd { get; set; }
                /// <summary>
                /// Valor Total do Frete
                /// </summary>
                public double vFrete { get; set; }
                /// <summary>
                /// Valor Total do Seguro
                /// </summary>                
                public double vSeg { get; set; }
                /// <summary>
                /// Valor Total do Desconto
                /// </summary>                
                public double vDesc { get; set; }
                /// <summary>
                /// Valor Total do II
                /// </summary>                
                public double vII { get; set; }
                /// <summary>
                /// Valor Total do IPI
                /// </summary>                
                public double vIPI { get; set; }
                /// <summary>
                /// Valor Total do PIS
                /// </summary>                
                public double vPIS { get; set; }
                /// <summary>
                /// Valor total do COFINS
                /// </summary>                
                public double vCOFINS { get; set; }
                /// <summary>
                /// Outras Despesas acessórias
                /// </summary>                
                public double vOutro { get; set; }
                /// <summary>
                /// Valor total da NFE
                /// </summary>
                public double vNF { get; set; }
            }

            /// <summary>
            /// TAG de grupo de Valores Totais referentes ao ISSQN
            /// </summary>
            public class ISSQNtot
            {
                /// <summary>
                /// Valor Total dos Serviços sob não incidência ou não tributados pelo ICMS
                /// </summary>
                public double vServ { get; set; }
                /// <summary>
                /// Base de Cálculo do ISS
                /// </summary>
                public double vBC { get; set; }
                /// <summary>
                /// Valor Total do ISS
                /// </summary>
                public double vISS { get; set; }
                /// <summary>
                /// Valor do PIS sobre serviços
                /// </summary>
                public double vPIS { get; set; }
                /// <summary>
                /// Valor do COFINS sobre serviços
                /// </summary>
                public double vCOFINS { get; set; }
            }

            /// <summary>
            /// TAG de grupo de retenções de tributos
            /// 
            /// Exemplos de atos normativos que definem obrigatoriedade da retenção de contribuições:
            /// a) IRPJ/CSLL/PIS/COFINS - Fonte - Recebimentos de Órgãos Públicos Federais
            /// Lei nº 9.430, de 27 de dezembro de 1996, art. 64 Lei nº 10.833/2003, art. 34
            /// como normas infra-legais, temos como exemplo:
            /// Instrução Normativa SRF nº 480/2004 e Instrução Normativa nº 539, de 25/04/2005.
            /// b) Retenção do Imposto de Renda pelas Fontes Pagadoras REMUNERAÇÃO DE SERVIÇOS
            /// PROFISSIONAIS PRESTADOS POR PESSOA JURÍDICA LEI Nº 7.450/85, ART. 52 
            /// c) IRPJ, CSLL, COFINS e PIS - Serviços Prestados por Pessoas Jurídicas - Retenção na Fonte
            /// Lei nº 10.833 de 29.12.2003, arts. 30, 31, 32, 35 e 36
            /// </summary>
            public class retTrib
            {
                /// <summary>
                /// Valor Retido de PIS
                /// </summary>
                public double vRetPIS { get; set; }
                /// <summary>
                /// Valor Retido de COFINS
                /// </summary>
                public double vRetCOFINS { get; set; }
                /// <summary>
                /// Valor Retido de CSLL
                /// </summary>
                public double vRetCSSL { get; set; }
                /// <summary>
                /// Base de Cálculo do IRRF
                /// </summary>
                public double vBCIRRF { get; set; }
                /// <summary>
                /// Valor Retido do IRRF
                /// </summary>
                public double vIRRF { get; set; }
                /// <summary>
                /// Base de Cálculo da Retenção da Previdência Social
                /// </summary>
                public double vBCRetPrev { get; set; }
                /// <summary>
                /// Valor da Retenção da Previdência Social
                /// </summary>
                public double vRetPrev { get; set; }
            }

            public double vTotTrib { get; set; }
        }

        /// <summary>
        /// Tag de grupo de informações do transporte da NFE
        /// </summary>
        public class transp
        {
            public transporta Transporta { get; set; }
            public retTransp RetTransp { get; set; }
            public veicTransp VeicTransp { get; set; }
            public reboque Reboque { get; set; }
            public vol Vol { get; set; }
            /// <summary>
            /// Modalidade do frete
            /// </summary>
            public string modFrete { get; set; }

            /// <summary>
            /// TAG de grupo transportador
            /// </summary>
            public class transporta
            {
                /// <summary>
                /// CNPJ
                /// Informar o CNPJ do Transportador, preenchendo os zeros não significativos.
                /// </summary>
                public string CNPJ { get; set; }
                /// <summary>
                /// CNPJ
                /// Informar o CPF do Transportador, preenchendo os zeros não significativos.
                /// </summary>
                public string CPF { get; set; }
                /// <summary>
                /// Razão social ou nome
                /// </summary>
                public string xNome { get; set; }
                /// <summary>
                /// Inscrição estadual
                /// </summary>
                public string IE { get; set; }
                /// <summary>
                /// Endereço completo
                /// </summary>
                public string xEnder { get; set; }
                /// <summary>
                /// Nome do municipio
                /// </summary>
                public string xMun { get; set; }
                /// <summary>
                /// Sigla da UF
                /// </summary>
                public string UF { get; set; }
            }

            /// <summary>
            /// TAG de grupo de Retenção do ICMS do transporte
            /// 
            /// Informar o valor do ICMS do serviço de transporte retido.
            /// </summary>
            public class retTransp
            {
                /// <summary>
                /// Valor do Serviço
                /// </summary>
                public double vServ { get; set; }
                /// <summary>
                /// BC da Retenção do ICMS
                /// </summary>
                public double vBCRet { get; set; }
                /// <summary>
                /// Alíquota da Retenção
                /// </summary>
                public double pICMSRet { get; set; }
                /// <summary>
                /// Valor do ICMS Retido
                /// </summary>
                public double vICMSRet { get; set; }
                /// <summary>
                /// CFOP
                /// </summary>
                public string CFOP { get; set; }
                /// <summary>
                /// Código do município de ocorrência do fato gerador do ICMS do transporte
                /// 
                /// Informar o município de ocorrência do fato gerador do ICMS do transporte. 
                /// Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País)
                /// </summary>
                public string cMunFG { get; set; }
            }

            /// <summary>
            /// TAG de grupo Veículo
            /// </summary>
            public class veicTransp
            {
                /// <summary>
                /// Placa do Veículo
                /// </summary>
                public string placa { get; set; }
                /// <summary>
                /// Sigla da UF
                /// </summary>
                public string UF { get; set; }
                /// <summary>
                /// Registro Nacional de Transportador de Carga (ANTT)
                /// </summary>
                public string RNTC { get; set; }
            }

            /// <summary>
            /// TAG de grupo Reboque
            /// </summary>
            public class reboque
            {
                /// <summary>
                /// Placa do veiculo
                /// </summary>
                public string placa { get; set; }
                /// <summary>
                /// Sigla da UF
                /// </summary>
                public string UF { get; set; }
                /// <summary>
                /// Registro Nacional de Transportador de Carga (ANTT)
                /// </summary>
                public string RTNC { get; set; }
            }

            /// <summary>
            /// TAG de grupo Volumes
            /// </summary>
            public class vol
            {
                /// <summary>
                /// Quantidade de volumes transportados
                /// </summary>
                public string qVol { get; set; }
                /// <summary>
                /// Espécie dos volumes transportados
                /// </summary>
                public string esp { get; set; }
                /// <summary>
                /// Marca dos volumes transportados
                /// </summary>
                public string marca { get; set; }
                /// <summary>
                /// Numeração dos volumes transportados
                /// </summary>
                public string nVol { get; set; }
                /// <summary>
                /// Peso Líquido (em kg)
                /// </summary>
                [Formato("####0.000", "pt-BR")]
                public decimal pesoL { get; set; }
                /// <summary>
                /// Peso Bruto (em kg)
                /// </summary>
                [Formato("####0.000", "pt-BR")]
                public decimal pesoB { get; set; }

                /// <summary>
                /// TAG de grupo de Lacres
                /// </summary>
                public class lacres
                {
                    /// <summary>
                    /// Número dos lacres
                    /// </summary>
                    public string nLacre { get; set; }
                }
            }

        }

        /// <summary>
        /// TAG de grupo de Cobrança
        /// </summary>
        public class cobr
        {
            /// <summary>
            /// TAG de grupo da Fatura
            /// </summary>
            /// 

            public List<dup> Dup { get; set; }

            public class fat
            {
                /// <summary>
                /// Número da Fatura
                /// </summary>
                public string nFat { get; set; }
                /// <summary>
                /// Valor Original da Fatura
                /// </summary>
                public string vOrig { get; set; }
                /// <summary>
                /// Valor do desconto
                /// </summary>
                public string vDesc { get; set; }
                /// <summary>
                /// Valor Líquido da Fatura
                /// </summary>
                public string vLiq { get; set; }
            }

            public class dup
            {
                /// <summary>
                /// Número da duplicata
                /// </summary>
                public string nDup { get; set; }
                /// <summary>
                /// Data de vencimento
                /// </summary>
                public DateTime dVenc { get; set; }
                /// <summary>
                /// Valor da duplicata
                /// </summary>                                                
                public double vDup { get; set; }
            }
        }


        /// <summary>
        /// TAG de grupo de Informações Adicionais
        /// </summary>
        public class infAdic
        {
            /// <summary>
            /// Informações Adicionais de Interesse do Fisco
            /// </summary>
            public string infAdFisco { get; set; }
            /// <summary>
            /// Informações Complementares de interesse do Contribuinte
            /// </summary>
            public string infCpl { get; set; }

            /// <summary>
            /// TAG de grupo do campo de uso livre do contribuinte
            /// 
            /// Campo de uso livre do contribuinte, informar o nome do campo no atributo xCampo e o conteúdo do campo no xTexto
            /// </summary>
            public class obsCont
            {
                /// <summary>
                /// Identificação do campo
                /// </summary>
                public string xCampo { get; set; }
                /// <summary>
                /// Conteúdo do campo
                /// </summary>
                public string xTexto { get; set; }
            }

            /// <summary>
            /// Campo de uso livre do Fisco Informar o nome do campo no atributo xCampo
            /// e o conteúdo do campo no xTexto
            /// </summary>
            public class obsFisco
            {
                /// <summary>
                /// Identificação do campo
                /// </summary>
                public string xCampo { get; set; }
                /// <summary>
                /// Conteúdo do campo
                /// </summary>
                public string xTexto { get; set; }
            }

            /// <summary>
            /// Tag de grupo do processo
            /// Campo de uso livre do Fisco 
            /// Informar o nome do campo no atributo xCampo
            /// e o conteúdo do campo no xTexto
            /// </summary>
            public class procRef
            {
                /// <summary>
                /// Indentificador do processo ou ato concessório
                /// </summary>
                public string nProc { get; set; }
                /// <summary>
                /// Origem do processo, informar com:
                /// 0 - SEFAZ;
                /// 1 - Justiça Federal;
                /// 2 - Justiça Estadual;
                /// 3 - Secex/RFB;
                /// 9 - Outros
                /// </summary>
                public string indProc { get; set; }
            }

        }

        /// <summary>
        /// TAG do grupo de exportação 
        /// 
        /// Informar apenas na exportação
        /// </summary>
        public class exporta
        {
            /// <summary>
            /// Sigla da UF onde ocorrerá o Embarque dos produtos
            /// </summary>
            public string UFEmbarq { get; set; }
            /// <summary>
            /// Local onde ocorrerá o Embarque dos produtos
            /// </summary>
            public string xLocEmbarq { get; set; }
        }


        /// <summary>
        /// TAG do Grupo de Compra
        /// Informar adicionais de compra
        /// </summary>
        public class compra
        {
            /// <summary>
            /// Informar a identificação da Nota de Empenho, quando se tratar de compras públicas
            /// </summary>
            public string xNEmp { get; set; }
            /// <summary>
            /// Informar o pedido.
            /// </summary>
            public string xPed { get; set; }
            /// <summary>
            /// Informar o contrato de compra
            /// </summary>
            public string xCont { get; set; }
        }
    }

    /// <summary>
    /// Classe com funções auxiliares para a nota eletronica
    /// </summary>
    public static class Funcoes
    {
        public static string removeFormatacao(string texto)
        {
            string txt = "";

            txt = texto.Replace(".", "");
            txt = txt.Replace("-", "");
            txt = txt.Replace("/", "");
            txt = txt.Replace("(", "");
            txt = txt.Replace(")", "");
            txt = txt.Replace(" ", "");

            return txt;
        }

        public static void retornaAtributos(object[] obj, out CultureInfo cultura, out string formato, out bool obrigatorio)
        {
            cultura = CultureInfo.CreateSpecificCulture("en-US");
            formato = "###0.00";
            obrigatorio = false;
            foreach (object objeto in obj)
            {
                if (objeto is Formato)
                {
                    string culturaStr = ((Formato)objeto).cultura;
                    formato = ((Formato)objeto).formato;
                    cultura = CultureInfo.CreateSpecificCulture(culturaStr);
                }
                else
                    if (objeto is Obrigatorio)
                        obrigatorio = ((Obrigatorio)objeto).propriedadeObrigatoria;

            }

            //cultura.NumberFormat.NumberDecimalSeparator = ",";
            //cultura.NumberFormat.NumberGroupSeparator = ".";
        }

        public static int modulo11(string chaveNFE)
        {
            if (chaveNFE.Length != 43)
                throw new Exception("Chave inválida, não é possível calcular o digito verificador");


            string baseCalculo = "4329876543298765432987654329876543298765432";
            int somaResultados = 0;

            for (int i = 0; i <= chaveNFE.Length - 1; i++)
            {
                int numNF = Convert.ToInt32(chaveNFE[i].ToString());
                int numBaseCalculo = Convert.ToInt32(baseCalculo[i].ToString());

                somaResultados += (numBaseCalculo * numNF);
            }

            int restoDivisao = (somaResultados % 11);
            int dv = 11 - restoDivisao;
            if ((dv == 0) || (dv > 9))
                return 0;
            else
                return dv;
        }

        public static string TirarAcento(string palavra)
        {
            if (!String.IsNullOrEmpty(palavra))
            {
                string palavraSemAcento = "";
                string caracterComAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
                string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                    {
                        int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                        palavraSemAcento += caracterSemAcento.Substring(car, 1);
                    }
                    else
                    {
                        palavraSemAcento += palavra.Substring(i, 1);
                    }
                }

                return palavraSemAcento;
            }
            return "";
        }

        /// <summary>
        /// Função que utilizo para saber se é uma propriedade simples (String, Int) ou uma nova classe, que deve gerar
        /// uma nova tag xml
        /// </summary>
        /// <param name="propriedade"></param>
        /// <returns></returns>
        public static bool novaTag(PropertyInfo propriedade)
        {
            //TODO: Buscar uma forma melhor de identificar as subclasses.

            switch (propriedade.PropertyType.ToString())
            {
                case "System.DateTime":
                case "System.Int32":
                case "System.String":
                case "System.Double":
                case "System.Nullable":
                case "System.Decimal":
                //Propriedades que podem ser nulas (com ?)...
                case "System.Nullable`1[System.Int32]":
                case "System.Nullable`1[System.DateTime]":
                case "System.Nullable`1[System.Decimal]":
                case "System.Nullable`1[System.Double]":
                    return false;
                default: return true;
            }
        }

        public static void gravarElemento(XmlWriter writer, string nomeTag, object valorTag, object[] atributos)
        {
            /*CultureInfo cultBR = new CultureInfo("pt-BR");
            CultureInfo cultUS = new CultureInfo("en-US");*/
            CultureInfo cult;
            string formato;
            bool obrigatorio;
            retornaAtributos(atributos, out cult, out formato, out obrigatorio);

            if (valorTag != null)
            {
                string valor = "";
                switch (valorTag.GetType().ToString())
                {
                    case "System.DateTime":
                        valor = ((DateTime)(valorTag)).ToString("yyyy-MM-dd");   //formata no padrão necessário para a NFe                     
                        break;
                    case "System.Int32":
                        valor = valorTag.ToString();
                        if (valor.Trim() == "0") //campos do tipo inteiro com valor 0 serão ignorados
                            valor = "";
                        break;
                    case "System.String":
                        valor = TirarAcento(valorTag.ToString().Replace("\r\n", " - ")).Trim(); //remove linhas... e tira acentos
                        break;
                    case "System.Double":
                        valor = ((double)valorTag).ToString(formato); //formata de acordo com o atributo
                        valor = valor.Replace(",", ".");
                        break;
                    case "System.Decimal":
                        valor = ((decimal)valorTag).ToString(formato); //formata de acordo com o atributo
                        valor = valor.Replace(",", ".");
                        break;

                }
                if ((valor.Trim().Length > 0) || (obrigatorio))
                    writer.WriteElementString(nomeTag, valor);
            }
        }

        public static long tamanhoXML(XmlDocument documento)
        {
            string nomeArquivo = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

            try
            {
                documento.Save(nomeArquivo);
                FileInfo info = new FileInfo(nomeArquivo);
                long tamanhoArquivo = info.Length;

                info.Delete();

                return tamanhoArquivo;
            }
            catch
            {
                return 0;
            }

        }

        public static int ListarCodigoEstado(string UF)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("FIN_L_ESTADO_CODIGO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@UF", SqlDbType.VarChar).Value = UF;

                DataTable dtRetorno = db.ExecuteDataSet(sqlCommand).Tables[0];

                if (dtRetorno.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtRetorno.Rows[0]["EST_C_ID"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ListarCodigoMunicipio(string UF, string municipio)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("FIN_L_MUNICIPIO_CODIGO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@UF_ID", SqlDbType.VarChar).Value = UF;

                sqlCommand.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = municipio;

                DataTable dtRetorno = db.ExecuteDataSet(sqlCommand).Tables[0];

                if (dtRetorno.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtRetorno.Rows[0]["MUN_C_ID"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
