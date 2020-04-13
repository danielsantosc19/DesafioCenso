using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;

namespace DesafioMundipagg.Model
{
    [Serializable()]    
    public class Pessoa
    {
        //[JsonConverter(typeof(StringEnumConverter))]
        public enum Escolaridades
        {
            /// <summary>
            /// Nenhuma
            /// </summary>
            [Description("Nenhuma")]
            Nenhuma = 0,
            /// <summary>
            /// Fundamental
            /// </summary>
            [Description("Fundamental")]
            Fundamental = 1,
            /// <summary>
            /// Medio
            /// </summary>
            [Description("Medio")]
            Medio = 2,
            /// <summary>
            /// Superior
            /// </summary>
            [Description("Superior")]
            Superior = 3,
            /// <summary>
            /// PosGraducao
            /// </summary>
            [Description("PosGraducao")]
            PosGraducao = 4,
            /// <summary>
            /// Mestrado
            /// </summary>
            [Description("Mestrado")]
            Mestrado = 5,
            /// <summary>
            /// Doutorado
            /// </summary>
            [Description("Doutorado")]
            Doutorado = 6
        }
        //[JsonConverter(typeof(StringEnumConverter))]
        public enum Etnias
        {   
            [Description("Outra")]
            [EnumMember(Value = "Outra")]
            Outra = 0,
         
            [Description("Branco")]
            [EnumMember(Value = "Branco")]
            Branco = 1,
            
            [Description("Negro")]
            [EnumMember(Value = "Negro")]
            Negro = 2,
            
            [Description("Indigena")]
            [EnumMember(Value = "Indigena")]
            Indigena = 3,
            
            [Description("Pardo")]
            [EnumMember(Value = "Pardo")]
            Pardo = 4,
            
            [Description("Mulato")]
            [EnumMember(Value = "Mulato")]
            Mulato = 5,
            
            [Description("Caboclo")]
            [EnumMember(Value = "Caboclo")]
            Caboclo = 6,
            
            [Description("Cafuzo")]
            [EnumMember(Value = "Cafuzo")]
            Cafuzo = 7
        }

        //[JsonConverter(typeof(StringEnumConverter))]
        public enum Generos
        {   
            [Description("Masculino")]
            [EnumMember(Value = "Masculino")]
            Masculino = 0,
            
            [Description("Feminino")]
            [EnumMember(Value = "Feminino")]
            Feminino = 1
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }


        [EnumDataType(typeof(Etnias))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public Etnias? Etnia { get; set; }

        [EnumDataType(typeof(Generos))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public Generos? Genero { get; set; }

        [Required]
        public string NomePai { get; set; }


        [Required]
        public string NomeMae { get; set; }

        [Required]
        public int Filhos { get; set; }

        [EnumDataType(typeof(Escolaridades))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public Escolaridades Escolaridade { get; set; }

        [Required]
        public string Regiao { get; set; }

        public Pessoa Pai { get; set; }

        public Pessoa Mae { get; set; }



        



    }
}
