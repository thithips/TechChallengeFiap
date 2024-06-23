using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Seeds
{
    public static class EstadoSeed
    {
        public static void SeedsEstados(ModelBuilder modelBuilder)
        {
            Guid sulId = new Guid("667589E6-12E3-44DE-86CB-141058365C78");
            Guid norteId = new Guid("91EA2869-3FB0-4C39-8583-F420F8D48FA5");
            Guid sudesteId = new Guid("6FB578F8-5176-4906-A805-3A100ADDE0C9");
            Guid nordesteId = new Guid("78FA8876-6C2D-4A09-B981-F77538F18FBB");
            Guid centroOesteId = new Guid("8B985725-487B-4A32-92A5-CB708F44C54B");

            modelBuilder.Entity<Estado>().HasData(new Estado[] {
            new Estado(new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), "Acre", norteId, "AC"),
            new Estado(new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), "Alagoas", nordesteId, "AL"),
            new Estado(new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), "Amapa", norteId, "AP"),
            new Estado(new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), "Amazonas", norteId, "AM"),
            new Estado(new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), "Bahia", nordesteId, "BA"),
            new Estado(new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), "Ceara", nordesteId, "CE"),
            new Estado(new Guid("20792100-80af-49a8-8195-f7c36441c38d"), "Espirito Santo", sudesteId, "ES"),
            new Estado(new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), "Goias", centroOesteId, "GO"),
            new Estado(new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), "Maranhao", nordesteId, "MA"),
            new Estado(new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), "Mato Grosso", centroOesteId, "MT"),
            new Estado(new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), "Mato Grosso do Sul", centroOesteId, "MS"),
            new Estado(new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), "Minas Gerais", sudesteId, "MG"),
            new Estado(new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), "Para", norteId, "PA"),
            new Estado(new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), "Paraiba", nordesteId, "PB"),
            new Estado(new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), "Parana", sulId, "PR"),
            new Estado(new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), "Pernambuco", nordesteId, "PE"),
            new Estado(new Guid("275002db-aa62-444e-a179-b801583c3568"), "Piaui", nordesteId, "PI"),
            new Estado(new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), "Rio de Janeiro", sudesteId, "RJ"),
            new Estado(new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), "Rio Grande do Norte", nordesteId, "RN"),
            new Estado(new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), "Rio Grande do Sul", sulId, "RS"),
            new Estado(new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), "Rondonia", norteId, "RO"),
            new Estado(new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), "Roraima", norteId, "RR"),
            new Estado(new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), "Santa Catarina", sulId, "SC"),
            new Estado(new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), "Sao Paulo", sudesteId, "SP"),
            new Estado(new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), "Sergipe", nordesteId, "SE"),
            new Estado(new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), "Tocantins", norteId, "TO"),
            new Estado(new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), "Distrito Federal", centroOesteId, "DF"),
            });

        }
    }
}
