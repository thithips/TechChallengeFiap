using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Seeds
{
    public static class DDDSeed
    {
        public static void SeedsDDDs(ModelBuilder modelBuilder)
        {
            Guid idSP = new Guid("5e684315-735e-4c8e-a508-8df50649dc1d");
            Guid idRJ = new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de");
            Guid idES = new Guid("20792100-80af-49a8-8195-f7c36441c38d");
            Guid idMG = new Guid("3b72bc3f-4613-4313-963c-9621db443e32");
            Guid idPR = new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e");
            Guid idSC = new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440");
            Guid idRS = new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48");
            Guid idDF = new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538");
            Guid idGO = new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef");
            Guid idTO = new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6");
            Guid idMT = new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f");
            Guid idMS = new Guid("c4dc2412-b190-411a-8352-0a857b7e327b");
            Guid idAC = new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0");
            Guid idRO = new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105");
            Guid idBA = new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf");
            Guid idSE = new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb");
            Guid idPE = new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258");
            Guid idAL = new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e");
            Guid idPB = new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa");
            Guid idRN = new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598");
            Guid idCE = new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da");
            Guid idPI = new Guid("275002db-aa62-444e-a179-b801583c3568");
            Guid idPA = new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621");
            Guid idAM = new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8");
            Guid idRR = new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402");
            Guid idAP = new Guid("489e8c02-00cc-4113-8dab-8e44ead66543");
            Guid idMA = new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759");

            modelBuilder.Entity<DDD>().HasData(new DDD[] {
                new DDD(11, idSP, "Região Metropolitana de São Paulo/Região Metropolitana de Jundiaí/Região Geográfica Imediata de Bragança Paulista"),
                new DDD(12, idSP, "Região Metropolitana do Vale do Paraíba e Litoral Norte"),
                new DDD(13, idSP, "Região Metropolitana da Baixada Santista/Vale do Ribeira"),
                new DDD(14, idSP, "Avaré/Bauru/Botucatu/Jaú/Lins/Marília/Ourinhos"),
                new DDD(15, idSP, "Itapetininga/Itapeva/Sorocaba/Tatuí"),
                new DDD(16, idSP, "Araraquara/Franca/Jaboticabal/Ribeirão Preto/São Carlos/Sertãozinho"),
                new DDD(17, idSP, "Barretos/Catanduva/Fernandópolis/Jales/São José do Rio Preto/Votuporanga"),
                new DDD(18, idSP, "Andradina/Araçatuba/Assis/Birigui/Dracena/Presidente Prudente"),
                new DDD(19, idSP, "Americana/Campinas/Limeira/Piracicaba/Rio Claro/São João da Boa Vista"),
                new DDD(21, idRJ, "Rio de Janeiro e Região Metropolitana/Teresópolis"),
                new DDD(22, idRJ, "Cabo Frio/Campos dos Goytacazes/Itaperuna/Macaé/Nova Friburgo"),
                new DDD(24, idRJ, "Angra dos Reis/Petrópolis/Volta Redonda/Piraí"),
                new DDD(27, idES, "Vitória e Região Metropolitana/Colatina/Linhares/Santa Maria de Jetibá"),
                new DDD(28, idES, "Cachoeiro de Itapemirim/Castelo/Itapemirim/Marataízes"),
                new DDD(31, idMG, "Belo Horizonte e Região Metropolitana/Conselheiro Lafaiete/Ipatinga/Viçosa"),
                new DDD(32, idMG, "Barbacena/Juiz de Fora/Muriaé/São João del-Rei/Ubá"),
                new DDD(33, idMG, "Almenara/Caratinga/Governador Valadares/Manhuaçu/Teófilo Otoni"),
                new DDD(34, idMG, "Araguari/Araxá/Patos de Minas/Uberlândia/Uberaba"),
                new DDD(35, idMG, "Alfenas/Guaxupé/Lavras/Poços de Caldas/Pouso Alegre/Varginha"),
                new DDD(37, idMG, "Bom Despacho/Divinópolis/Formiga/Itaúna/Pará de Minas"),
                new DDD(38, idMG, "Curvelo/Diamantina/Montes Claros/Pirapora/Unaí"),
                new DDD(41, idPR, "Curitiba e Região Metropolitana"),
                new DDD(42, idPR, "Ponta Grossa/Guarapuava"),
                new DDD(43, idPR, "Apucarana/Londrina"),
                new DDD(44, idPR, "Maringá/Campo Mourão/Umuarama"),
                new DDD(45, idPR, "Cascavel/Foz do Iguaçu"),
                new DDD(46, idPR, "Francisco Beltrão/Pato Branco"),
                new DDD(47, idSC, "Balneário Camboriú/Blumenau/Itajaí/Joinville"),
                new DDD(48, idSC, "Florianópolis e Região Metropolitana/Criciúma"),
                new DDD(49, idSC, "Caçador/Chapecó/Lages"),
                new DDD(51, idRS, "Porto Alegre e Região Metropolitana/Santa Cruz do Sul/Litoral Norte"),
                new DDD(53, idRS, "Pelotas/Rio Grande"),
                new DDD(54, idRS, "Caxias do Sul/Passo Fundo"),
                new DDD(55, idRS, "Santa Maria/Santana do Livramento/Santo Ângelo/Uruguaiana"),
                new DDD(61, idDF, "Abrangência em todo o Distrito Federal e alguns municípios da Região Integrada de Desenvolvimento do Distrito Federal e Entorno"),
                new DDD(62, idGO, "Goiânia e Região Metropolitana/Anápolis/Niquelândia/Porangatu"),
                new DDD(63, idTO, "Abrangência em todo o estado"),
                new DDD(64, idGO, "Caldas Novas/Catalão/Itumbiara/Rio Verde"),
                new DDD(65, idMT, "Cuiabá e Região Metropolitana"),
                new DDD(66, idMT, "Rondonópolis/Sinop"),
                new DDD(67, idMS, "Abrangência em todo o estado"),
                new DDD(68, idAC, "Abrangência em todo o estado"),
                new DDD(69, idRO, "Abrangência em todo o estado"),
                new DDD(71, idBA, "Salvador e Região Metropolitana"),
                new DDD(73, idBA, "Eunápolis/Ilhéus/Porto Seguro/Teixeira de Freitas"),
                new DDD(74, idBA, "Irecê/Jacobina/Juazeiro/Xique-Xique"),
                new DDD(75, idBA, "Alagoinhas/Feira de Santana/Paulo Afonso/Valença"),
                new DDD(77, idBA, "Barreiras/Bom Jesus da Lapa/Guanambi/Vitória da Conquista"),
                new DDD(79, idSE, "Abrangência em todo o estado "),
                new DDD(81, idPE, "Recife e Região Metropolitana/Caruaru"),
                new DDD(82, idAL, "Abrangência em todo o estado"),
                new DDD(83, idPB, "Abrangência em todo o estado"),
                new DDD(84, idRN, "Abrangência em todo o estado"),
                new DDD(85, idCE, "Fortaleza e Região Metropolitana"),
                new DDD(86, idPI, "Teresina e alguns municípios da Região Integrada de Desenvolvimento da Grande Teresina/Parnaíba"),
                new DDD(87, idPE, "Garanhuns/Petrolina/Salgueiro/Serra Talhada"),
                new DDD(88, idCE, "Juazeiro do Norte/Sobral"),
                new DDD(89, idPI, "Picos/Floriano"),
                new DDD(91, idPA, "Belém e Região Metropolitana"),
                new DDD(92, idAM, "Manaus e Região Metropolitana/Parintins"),
                new DDD(93, idPA, "Santarém/Altamira"),
                new DDD(94, idPA, "Marabá"),
                new DDD(95, idRR, "Abrangência em todo o estado"),
                new DDD(96, idAP, "Abrangência em todo o estado"),
                new DDD(97, idAM, "Abrangência no interior do estado"),
                new DDD(98, idMA, "São Luís e Região Metropolitana"),
                new DDD(99, idMA, "Caxias/Codó/Imperatriz")
            });
        }
    }
}
