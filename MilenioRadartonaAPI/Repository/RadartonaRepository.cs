using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Relatorios;

using System;
using System.Collections.Generic;
using System.Linq;
using MilenioRadartonaAPI.Context;
using System.Data;
using MilenioRadartonaAPI.Models.Postgres;
using MilenioRadartonaAPI.DTO;
using System.Threading.Tasks;
using System.Text;

namespace MilenioRadartonaAPI.Repository
{
    public interface IRadartonaRepository
    {
        List<BaseRadaresDTO> GetLocalizacaoRadares();
        List<BaseRadaresDTO> GetRadaresTipoEnquadramento(string[] Enquadramentos);
        List<BaseRadaresDTO> GetRadaresZonaConcessao(string ZonaConcessao);
        List<FluxoVeiculosRadarDTO> GetFluxoVeiculosRadares(string[] Radares, string DataConsulta);
        List<TipoVeiculosRadaresDTO> GetTipoVeiculosRadares(string[] Radares, string DataConsulta);
        List<InfracoesPorRadarDTO> GetInfracoesPorRadar(string[] Radares, string DataConsulta);
        List<AcuraciaIdentificacaoRadaresDTO> GetAcuraciaIdentificacaoRadares(string[] Radares, string DataConsulta);
        List<BaseRadaresDTO> GetPerfilVelocidadesRadar(int VelocidadeMin, int VelocidadeMax);
        List<TrajetosDTO> GetTrajetos(string[] Radares, string DataConsulta);
        List<VelocidadeMediaTrajetoDTO> GetVelocidadeMediaTrajeto(string DataConsulta, string[] Radares);
        List<ViagensDTO> GetViagens(string DataConsulta, string[] Radares);
        List<DistanciaViagemDTO> GetDistanciaViagem(string DataConsulta);

        bool VerificaChaveTaValida(string chave);
        bool UsuarioPodePedirMaisReq(string chave);
        Task LogRequest(string Usuario, string Endpoint, long TempoRequisicao);


        // ======= CSV =======
        byte[] GetLocalizacaoRadaresCSV();
        byte[] GetRadaresTipoEnquadramentoCSV(string[] Enquadramentos);
        byte[] GetRadaresZonaConcessaoCSV(string ZonaConcessao);
        byte[] GetFluxoVeiculosRadaresCSV(string[] Radares, string DataConsulta);
        byte[] GetTipoVeiculosRadaresCSV(string[] Radares, string DataConsulta);
        byte[] GetInfracoesPorRadarCSV(string[] Radares, string DataConsulta);
        byte[] GetAcuraciaIdentificacaoRadaresCSV(string[] Radares, string DataConsulta);
        byte[] GetPerfilVelocidadesRadarCSV(int VelocidadeMin, int VelocidadeMax);
        byte[] GetTrajetosCSV(string DataConsulta, string[] Radares);
        byte[] GetVelocidadeMediaTrajetoCSV(string DataConsulta, string[] Radares);
        byte[] GetViagensCSV(string DataConsulta, string[] Radares);
        byte[] GetDistanciaViagemCSV(string DataConsulta);
    }


    public class RadartonaRepository : BaseRepository<BaseRadares>, IRadartonaRepository
    {
        private static string connString = "###";

        public RadartonaRepository(ApplicationContext ctx) : base(ctx)
        {

        }

        public List<BaseRadaresDTO> GetLocalizacaoRadares()
        {
            List<BaseRadaresDTO> lstRetorno = new List<BaseRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    BaseRadaresDTO ett = new BaseRadaresDTO();
                    ett.lote = Convert.ToInt32(dr["lote"]);
                    ett.codigo = dr["codigo"].ToString();
                    ett.endereco = dr["endereco"].ToString();
                    ett.sentido = dr["sentido"].ToString();
                    ett.referencia = dr["referencia"].ToString();
                    ett.tipoEquipamento = dr["tipo_equip"].ToString();
                    ett.enquadramento = dr["enquadrame"].ToString();
                    try
                    {
                        ett.qtdeFaixas = Convert.ToInt32(dr["qtde_fxs_f"]);
                    }
                    catch { }

                    ett.dataPublicacao = dr["data_publi"].ToString();
                    ett.velocidade = dr["velocidade"].ToString();
                    ett.lat = dr["lat"].ToString();
                    ett.lon = dr["lon"].ToString();
                    ett.bairro = dr["bairro"].ToString();

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<BaseRadaresDTO> GetRadaresTipoEnquadramento(string[] Enquadramentos)
        {
            List<BaseRadaresDTO> lstRetorno = new List<BaseRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    BaseRadaresDTO ett = new BaseRadaresDTO();
                    ett.lote = Convert.ToInt32(dr["lote"]);
                    ett.codigo = dr["codigo"].ToString();
                    ett.endereco = dr["endereco"].ToString();
                    ett.sentido = dr["sentido"].ToString();
                    ett.referencia = dr["referencia"].ToString();
                    ett.tipoEquipamento = dr["tipo_equip"].ToString();
                    ett.enquadramento = dr["enquadrame"].ToString();

                    try
                    {
                        ett.qtdeFaixas = Convert.ToInt32(dr["qtde_fxs_f"]);
                    }
                    catch { }

                    ett.dataPublicacao = dr["data_publi"].ToString();
                    ett.velocidade = dr["velocidade"].ToString();
                    ett.lat = dr["lat"].ToString();
                    ett.lon = dr["lon"].ToString();
                    ett.bairro = dr["bairro"].ToString();

                    lstRetorno.Add(ett);
                }
            }

            lstRetorno = lstRetorno.Where(d => Enquadramentos.Any(e => d.enquadramento.Split("-").Contains(e))).ToList();

            return lstRetorno;
        }

        public List<BaseRadaresDTO> GetRadaresZonaConcessao(string ZonaConcessao)
        {

            List<BaseRadaresDTO> lstRetorno = new List<BaseRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b where bairro = '" + ZonaConcessao + "';";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    BaseRadaresDTO ett = new BaseRadaresDTO();
                    ett.lote = Convert.ToInt32(dr["lote"]);
                    ett.codigo = dr["codigo"].ToString();
                    ett.endereco = dr["endereco"].ToString();
                    ett.sentido = dr["sentido"].ToString();
                    ett.referencia = dr["referencia"].ToString();
                    ett.tipoEquipamento = dr["tipo_equip"].ToString();
                    ett.enquadramento = dr["enquadrame"].ToString();

                    try
                    {
                        ett.qtdeFaixas = Convert.ToInt32(dr["qtde_fxs_f"]);
                    }
                    catch { }

                    ett.dataPublicacao = dr["data_publi"].ToString();
                    ett.velocidade = dr["velocidade"].ToString();
                    ett.lat = dr["lat"].ToString();
                    ett.lon = dr["lon"].ToString();
                    ett.bairro = dr["bairro"].ToString();

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<FluxoVeiculosRadarDTO> GetFluxoVeiculosRadares(string[] Radares, string DataConsulta)
        {
            List<FluxoVeiculosRadarDTO> lstRetorno = new List<FluxoVeiculosRadarDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select c.localidade as codigo, c.data_e_hora as data_hora, c.tipo as tipo_veiculo, c.contagem, c.autuacoes, c.placas, b.qtde_fxs_f as qtde_faixas,\n" +
                                   "b.velocidade, b.lat, b.lon, b.bairro\n" +
                                   "from contagens c inner join \"BaseRadares\" b \n" +
                                   "on b.codigo like concat('%', c.localidade, '%')\n" +
                                   "where cast(c.data_e_hora as date) = '" + DataConsulta + "'\n" +
                                   "and c.localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    FluxoVeiculosRadarDTO ett = new FluxoVeiculosRadarDTO();

                    ett.codigo = Convert.ToInt32(dr["codigo"]);
                    ett.data_hora = Convert.ToDateTime(dr["data_hora"]);
                    ett.tipo_veiculo = Convert.ToInt32(dr["tipo_veiculo"]);
                    ett.contagem = Convert.ToInt32(dr["contagem"]);
                    ett.autuacoes = Convert.ToInt32(dr["autuacoes"]);
                    ett.placas = Convert.ToInt32(dr["placas"]);
                    ett.qtde_faixas = Convert.ToInt32(dr["qtde_faixas"]);
                    ett.lat = Convert.ToDecimal(dr["lat"]);
                    ett.lon = Convert.ToDecimal(dr["lon"]);
                    ett.bairro = dr["bairro"].ToString();

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<TipoVeiculosRadaresDTO> GetTipoVeiculosRadares(string[] Radares, string DataConsulta)
        {
            List<TipoVeiculosRadaresDTO> lstRetorno = new List<TipoVeiculosRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select localidade as codigo, data_e_hora as data_hora, sum(contagem) as contagem, sum(autuacoes) as autuacoes, sum(placas) as placas from contagens where localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ") and cast(data_e_hora as date) = '" + DataConsulta + "' group by localidade, data_e_hora order by codigo, data_e_hora;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TipoVeiculosRadaresDTO ett = new TipoVeiculosRadaresDTO();

                    ett.codigo = Convert.ToInt32(dr["codigo"]);
                    ett.dataHora = Convert.ToDateTime(dr["data_hora"]);
                    ett.contagem = Convert.ToInt32(dr["contagem"]);
                    ett.autuacoes = Convert.ToInt32(dr["autuacoes"]);
                    ett.placas = Convert.ToInt32(dr["placas"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<InfracoesPorRadarDTO> GetInfracoesPorRadar(string[] Radares, string DataConsulta)
        {
            List<InfracoesPorRadarDTO> lstRetorno = new List<InfracoesPorRadarDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from contagens where cast(data_e_hora as date) = '" + DataConsulta + "' and localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    InfracoesPorRadarDTO ett = new InfracoesPorRadarDTO();

                    ett.codigoRadar = Convert.ToInt32(dr["localidade"]);
                    ett.dataHora = Convert.ToDateTime(dr["data_e_hora"]);
                    ett.tipoVeiculo = Convert.ToInt32(dr["tipo"]);
                    ett.contagem = Convert.ToInt32(dr["contagem"]);
                    ett.autuacoes = Convert.ToInt32(dr["autuacoes"]);
                    ett.placas = Convert.ToInt32(dr["placas"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<AcuraciaIdentificacaoRadaresDTO> GetAcuraciaIdentificacaoRadares(string[] Radares, string DataConsulta)
        {
            List<AcuraciaIdentificacaoRadaresDTO> lstRetorno = new List<AcuraciaIdentificacaoRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select localidade as codigo, data_e_hora, tipo, contagem, placas, cast(placas as decimal)/cast(contagem as decimal) as acuracia_identificacao\n" +
                                   "from contagens where cast(data_e_hora as date) = '" + DataConsulta + "' and localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    AcuraciaIdentificacaoRadaresDTO ett = new AcuraciaIdentificacaoRadaresDTO();

                    ett.codigoRadar = Convert.ToInt32(dr["codigo"]);
                    ett.dataHora = Convert.ToDateTime(dr["data_e_hora"]);
                    ett.tipoVeiculo = Convert.ToInt32(dr["tipo"]);
                    ett.contagem = Convert.ToInt32(dr["contagem"]);
                    ett.placas = Convert.ToInt32(dr["placas"]);
                    ett.acuraciaIdentificacao = Convert.ToDecimal(dr["acuracia_identificacao"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<BaseRadaresDTO> GetPerfilVelocidadesRadar(int VelocidadeMin, int VelocidadeMax)
        {
            List<BaseRadaresDTO> lstRetorno = new List<BaseRadaresDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b where velocidade_carro_moto between " + VelocidadeMin.ToString() + " and " + VelocidadeMax + ";";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    BaseRadaresDTO ett = new BaseRadaresDTO();
                    ett.lote = Convert.ToInt32(dr["lote"]);
                    ett.codigo = dr["codigo"].ToString();
                    ett.endereco = dr["endereco"].ToString();
                    ett.sentido = dr["sentido"].ToString();
                    ett.referencia = dr["referencia"].ToString();
                    ett.tipoEquipamento = dr["tipo_equip"].ToString();
                    ett.enquadramento = dr["enquadrame"].ToString();
                    ett.qtdeFaixas = Convert.ToInt32(dr["qtde_fxs_f"]);
                    ett.dataPublicacao = dr["data_publi"].ToString();
                    ett.velocidade = dr["velocidade"].ToString();
                    ett.lat = dr["lat"].ToString();
                    ett.lon = dr["lon"].ToString();
                    ett.bairro = dr["bairro"].ToString();

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<TrajetosDTO> GetTrajetos(string[] Radares, string DataConsulta)
        {
            List<TrajetosDTO> lstRetorno = new List<TrajetosDTO>();


            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select t.viagem_id,\n" +
                                    "t.origem,\n" +
                                    "case when date_part('hour', t.data_inicio) between 0 and 4 then 'madrugada'\n" +
                                         "when date_part('hour', t.data_inicio) between 5 and 12 then 'manha'\n" +
                                         "when date_part('hour', t.data_inicio) between 13 and 18 then 'tarde'\n" +
                                         "when date_part('hour', t.data_inicio) between 18 and 23 then 'noite'\n" +
                                         "end as periodo_dia,\n" +
                                            "avg((DATE_PART('day', t.data_final::timestamp - t.data_inicio::timestamp) * 24 + \n" +
                                                   "DATE_PART('hour', t.data_final::timestamp - t.data_inicio::timestamp)) * 60 +\n" +
                                                   "DATE_PART('minute', t.data_final::timestamp - t.data_inicio::timestamp)) as media_minutos_trajeto,\n" +
                                            "avg(t.v0) as media_v0,\n" +
                                            "t.destino,\n" +
                                            "avg(t.v1) as media_v1\n" +
                                    "from trajetos t\n" +
                                    "where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                                    "and (t.origem in " + InClause + " or t.destino in " + InClause + ")\n" +
                                    "group by t.viagem_id, t.origem, periodo_dia, t.destino;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TrajetosDTO ett = new TrajetosDTO();

                    ett.codigoRadarOrigem = Convert.ToInt32(dr["origem"]);
                    ett.mediaVelOrigem = Convert.ToDecimal(dr["media_v0"]);
                    ett.periodoDia = dr["periodo_dia"].ToString();
                    ett.mediaMinutosTrajeto = Convert.ToDecimal(dr["media_minutos_trajeto"]);
                    ett.codigoRadarDestino = Convert.ToInt32(dr["destino"]);
                    ett.mediaVelDestino = Convert.ToDecimal(dr["media_v1"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<VelocidadeMediaTrajetoDTO> GetVelocidadeMediaTrajeto(string DataConsulta, string[] Radares)
        {
            List<VelocidadeMediaTrajetoDTO> lstRetorno = new List<VelocidadeMediaTrajetoDTO>();

            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select  t.viagem_id,\n" +
                                            "t.origem,\n" +
                                            "case when date_part('hour', t.data_inicio) between 0 and 4 then 'madrugada'\n" +
                                                 "when date_part('hour', t.data_inicio) between 5 and 12 then 'manha'\n" +
                                                 "when date_part('hour', t.data_inicio) between 13 and 18 then 'tarde'\n" +
                                                 "when date_part('hour', t.data_inicio) between 18 and 23 then 'noite'\n" +
                                                 "end as periodo_dia,\n" +
                                                    "avg((t.v0 + t.v1) / 2 ) as velocidade_media,\n" +
                                                    "t.destino\n" +
                                            "from trajetos t\n" +
                                            "where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                                            "and (t.origem in " + InClause + " or t.destino in " + InClause + ")\n" +
                                            "group by t.viagem_id, t.origem, periodo_dia, t.destino;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    VelocidadeMediaTrajetoDTO ett = new VelocidadeMediaTrajetoDTO();

                    ett.codigoRadarOrigem = Convert.ToInt32(dr["origem"]);
                    ett.periodoDia = dr["periodo_dia"].ToString();
                    ett.velocidadeMedia = Convert.ToDecimal(dr["velocidade_media"]);
                    ett.codigoRadarDestino = Convert.ToInt32(dr["destino"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<ViagensDTO> GetViagens(string DataConsulta, string[] Radares)
        {
            List<ViagensDTO> lstRetorno = new List<ViagensDTO>();

            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select id, inicio, data_inicio, final, data_final, tipo from viagens where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                    "and (inicio in " + InClause + " or final in " + InClause + ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    ViagensDTO ett = new ViagensDTO();

                    ett.viagemId = Convert.ToInt32(dr["id"]);
                    ett.codigoRadarInicio = Convert.ToInt32(dr["inicio"]);
                    ett.dataHoraInicio = Convert.ToDateTime(dr["data_inicio"]);
                    ett.codigoRadarFinal = Convert.ToInt32(dr["final"]);
                    ett.dataHoraFinal = Convert.ToDateTime(dr["data_final"]);
                    ett.tipoVeiculo = Convert.ToInt32(dr["tipo"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public List<DistanciaViagemDTO> GetDistanciaViagem(string DataConsulta)
        {
            List<DistanciaViagemDTO> lstRetorno = new List<DistanciaViagemDTO>();

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select distinct v.inicio,\n" +
                                   "v.final,\n" +
                                   "ST_Distance(ST_Transform(concat('SRID=4326;POINT(', cast(br0.lat as varchar(20)), ' ', cast(br0.lon as varchar(20)), ')')::geometry, 3857),\n" +
                                   "ST_Transform(concat('SRID=4326;POINT(', cast(br1.lat as varchar(20)), ' ', cast(br1.lon as varchar(20)), ')')::geometry, 3857)) * cosd(42.3521) as distancia\n" +
                "from viagens v\n" +
                "inner join base_radares_lat_lon br0\n" +
                "   on br0.codigo = v.inicio\n" +
                "inner join base_radares_lat_lon br1\n" +
                "   on br1.codigo = v.final\n" +
                "where cast(v.data_inicio as date) = '" + DataConsulta + "'\n" +
                "and v.inicio != v.final; ";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    DistanciaViagemDTO ett = new DistanciaViagemDTO();

                    ett.codigoRadarInicio = Convert.ToInt32(dr["inicio"]);
                    ett.codigoRadarFinal = Convert.ToInt32(dr["final"]);
                    ett.distancia = Convert.ToDecimal(dr["distancia"]);

                    lstRetorno.Add(ett);
                }
            }

            return lstRetorno;
        }

        public bool VerificaChaveTaValida(string chave)
        {
            return _ctx.Chaves.Where(c => c.Token.Equals(chave)).Any();
        }

        public bool UsuarioPodePedirMaisReq(string chave)
        {
            Chave chaveAchada = _ctx.Chaves.Where(c => c.Token.Equals(chave)).FirstOrDefault();
            Usuario u = _ctx.Usuarios.Where(us => us.UsuarioId == chaveAchada.UsuarioId).FirstOrDefault();

            if (u.ReqInfos.LastOrDefault().QtdReqFeitasNoDia < u.ReqInfos.LastOrDefault().QtdReqDiaMax && u.Bloqueado == false)
            {
                return true;
            }

            return false;
        }

        public async Task LogRequest(string Usuario, string Endpoint, long TempoRequisicao)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();

                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO LogRequest (Usuario, Endpoint, TempoRequisicao, DataRequest) VALUES ('" + Usuario + "', '" + Endpoint + "', " + TempoRequisicao.ToString() + ", now());";

                conn.Open();

                await comm.ExecuteNonQueryAsync();

            }
        }


        // ======= CSV ========
        public byte[] GetLocalizacaoRadaresCSV()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("lote;codigo;endereco;sentido;referencia;tipo_equip;enquadrame;qtde_fxs_f;data_publi;velocidade;lat;lon;bairro");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = String.Empty;

                    linha += dr["lote"].ToString() + ";";
                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["endereco"].ToString() + ";";
                    linha += dr["sentido"].ToString() + ";";
                    linha += dr["referencia"].ToString() + ";";
                    linha += dr["tipo_equip"].ToString() + ";";
                    linha += dr["enquadrame"].ToString() + ";";
                    try
                    {
                        linha += dr["qtde_fxs_f"].ToString() + ";";
                    }
                    catch { linha += ";"; }

                    linha += dr["data_publi"].ToString() + ";";
                    linha += dr["velocidade"].ToString() + ";";
                    linha += dr["lat"].ToString() + ";";
                    linha += dr["lon"].ToString() + ";";
                    linha += dr["bairro"].ToString() + ";";


                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetRadaresTipoEnquadramentoCSV(string[] Enquadramentos)
        {
            List<BaseRadaresDTO> lstRadares = new List<BaseRadaresDTO>();
            StringBuilder sb = new StringBuilder();
            string linha = String.Empty;

            sb.AppendLine("lote;codigo;endereco;sentido;referencia;tipo_equip;enquadrame;qtde_fxs_f;data_publi;velocidade;lat;lon;bairro;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    BaseRadaresDTO ett = new BaseRadaresDTO();
                    ett.lote = Convert.ToInt32(dr["lote"]);
                    ett.codigo = dr["codigo"].ToString();
                    ett.endereco = dr["endereco"].ToString();
                    ett.sentido = dr["sentido"].ToString();
                    ett.referencia = dr["referencia"].ToString();
                    ett.tipoEquipamento = dr["tipo_equip"].ToString();
                    ett.enquadramento = dr["enquadrame"].ToString();

                    try
                    {
                        ett.qtdeFaixas = Convert.ToInt32(dr["qtde_fxs_f"]);
                    }
                    catch { ett.qtdeFaixas = 0; }

                    ett.dataPublicacao = dr["data_publi"].ToString();
                    ett.velocidade = dr["velocidade"].ToString();
                    ett.lat = dr["lat"].ToString();
                    ett.lon = dr["lon"].ToString();
                    ett.bairro = dr["bairro"].ToString();

                    lstRadares.Add(ett);
                }
            }

            lstRadares = lstRadares.Where(d => Enquadramentos.Any(e => d.enquadramento.Split("-").Contains(e))).ToList();

            foreach (BaseRadaresDTO ett in lstRadares)
            {
                linha += ett.lote + ";" + ett.codigo + ";" + ett.endereco + ";" + ett.sentido + ";" + ett.referencia + ";" +
                    ett.tipoEquipamento + ";" + ett.enquadramento + ";" + ett.qtdeFaixas + ";" + ett.dataPublicacao + ";" +
                    ett.velocidade + ";" + ett.lat.ToString() + ";" + ett.lon.ToString() + ";" + ett.bairro + ";";

                sb.AppendLine(linha);
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetRadaresZonaConcessaoCSV(string ZonaConcessao)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("lote;codigo;endereco;sentido;referencia;tipo_equip;enquadrame;qtde_fxs_f;data_publi;velocidade;lat;lon;bairro;");


            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b where bairro = '" + ZonaConcessao + "';";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";
                    linha += dr["lote"].ToString() + ";";
                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["endereco"].ToString() + ";";
                    linha += dr["sentido"].ToString() + ";";
                    linha += dr["referencia"].ToString() + ";";
                    linha += dr["tipo_equip"].ToString() + ";";
                    linha += dr["enquadrame"].ToString() + ";";

                    try
                    {
                        linha += dr["qtde_fxs_f"].ToString() + ";";
                    }
                    catch { linha += ";"; }

                    linha += dr["data_publi"].ToString() + ";";
                    linha += dr["velocidade"].ToString() + ";";
                    linha += dr["lat"].ToString() + ";";
                    linha += dr["lon"].ToString() + ";";
                    linha += dr["bairro"].ToString() + ";";

                    sb.AppendLine(linha);
                }

                byte[] csv = Encoding.Default.GetBytes(sb.ToString());

                return csv;
            }
        }

        public byte[] GetFluxoVeiculosRadaresCSV(string[] Radares, string DataConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo;data_hora;tipo_veiculo;contagem;autuacoes;placas;qtde_faixas;lat;lon;bairro;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select c.localidade as codigo, c.data_e_hora as data_hora, c.tipo as tipo_veiculo, c.contagem, c.autuacoes, c.placas, b.qtde_fxs_f as qtde_faixas,\n" +
                                   "b.velocidade, b.lat, b.lon, b.bairro\n" +
                                   "from contagens c inner join \"BaseRadares\" b \n" +
                                   "on b.codigo like concat('%', c.localidade, '%')\n" +
                                   "where cast(c.data_e_hora as date) = '" + DataConsulta + "'\n" +
                                   "and c.localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";
                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["data_hora"].ToString() + ";";
                    linha += dr["tipo_veiculo"].ToString() + ";";
                    linha += dr["contagem"].ToString() + ";";
                    linha += dr["autuacoes"].ToString() + ";";
                    linha += dr["placas"].ToString() + ";";
                    linha += dr["qtde_faixas"].ToString() + ";";
                    linha += dr["lat"].ToString() + ";";
                    linha += dr["lon"].ToString() + ";";
                    linha += dr["bairro"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetTipoVeiculosRadaresCSV(string[] Radares, string DataConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo;data_hora;contagem;autuacoes;placas;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select localidade as codigo, data_e_hora as data_hora, sum(contagem) as contagem, sum(autuacoes) as autuacoes, sum(placas) as placas from contagens where localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ") and cast(data_e_hora as date) = '" + DataConsulta + "' group by localidade, data_e_hora order by codigo, data_e_hora;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["data_hora"].ToString() + ";";
                    linha += dr["contagem"].ToString() + ";";
                    linha += dr["autuacoes"].ToString() + ";";
                    linha += dr["placas"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetInfracoesPorRadarCSV(string[] Radares, string DataConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo_radar;data_hora;tipo_veiculo;contagem;autuacoes;placas;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select id,data_e_hora,localidade,tipo,contagem,autuacoes,placas from contagens where cast(data_e_hora as date) = '" + DataConsulta + "' and localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";
                    linha += dr["localidade"].ToString() + ";";
                    linha += dr["data_e_hora"].ToString() + ";";
                    linha += dr["tipo"].ToString() + ";";
                    linha += dr["contagem"].ToString() + ";";
                    linha += dr["autuacoes"].ToString() + ";";
                    linha += dr["placas"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetAcuraciaIdentificacaoRadaresCSV(string[] Radares, string DataConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo;data_hora;tipo_veiculo;contagem;placas;acuracia_identificacao;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select localidade as codigo, data_e_hora, tipo, contagem, placas, cast(placas as decimal)/cast(contagem as decimal) as acuracia_identificacao\n" +
                                   "from contagens where cast(data_e_hora as date) = '" + DataConsulta + "' and localidade in (";

                for (int i = 0; i < Radares.Count(); i++)
                {
                    if (i == 0)
                    {
                        comm.CommandText += "'" + Radares[i] + "'";
                    }
                    else
                    {
                        comm.CommandText += ",'" + Radares[i] + "'";
                    }
                }

                comm.CommandText += ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["data_e_hora"].ToString() + ";";
                    linha += dr["tipo"].ToString() + ";";
                    linha += dr["contagem"].ToString() + ";";
                    linha += dr["placas"].ToString() + ";";
                    linha += dr["acuracia_identificacao"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetPerfilVelocidadesRadarCSV(int VelocidadeMin, int VelocidadeMax)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("lote;codigo;endereco;sentido;referencia;tipo_enquadramento;enquadramento;qtde_faixas;data_publicacao;velocidade;lat;lon;bairro;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select lote, codigo, endereco, sentido, referencia, tipo_equip, enquadrame, qtde_fxs_f,  \n" +
                                   "data_publi, velocidade, lat, lon, bairro  from \"BaseRadares\" b where velocidade_carro_moto between " + VelocidadeMin.ToString() + " and " + VelocidadeMax + ";";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += dr["lote"].ToString() + ";";
                    linha += dr["codigo"].ToString() + ";";
                    linha += dr["endereco"].ToString() + ";";
                    linha += dr["sentido"].ToString() + ";";
                    linha += dr["referencia"].ToString() + ";";
                    linha += dr["tipo_equip"].ToString() + ";";
                    linha += dr["enquadrame"].ToString() + ";";
                    linha += dr["qtde_fxs_f"].ToString() + ";";
                    linha += dr["data_publi"].ToString() + ";";
                    linha += dr["velocidade"].ToString() + ";";
                    linha += dr["lat"].ToString() + ";";
                    linha += dr["lon"].ToString() + ";";
                    linha += dr["bairro"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetTrajetosCSV(string DataConsulta, string[] Radares)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo_radar_origem;media_vel_origem;periodo_dia;media_minutos_trajeto;codigo_radar_destino;media_vel_destino;");
            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select t.viagem_id,\n" +
                                    "t.origem,\n" +
                                    "case when date_part('hour', t.data_inicio) between 0 and 4 then 'madrugada'\n" +
                                         "when date_part('hour', t.data_inicio) between 5 and 12 then 'manha'\n" +
                                         "when date_part('hour', t.data_inicio) between 13 and 18 then 'tarde'\n" +
                                         "when date_part('hour', t.data_inicio) between 18 and 23 then 'noite'\n" +
                                         "end as periodo_dia,\n" +
                                            "avg((DATE_PART('day', t.data_final::timestamp - t.data_inicio::timestamp) * 24 + \n" +
                                                   "DATE_PART('hour', t.data_final::timestamp - t.data_inicio::timestamp)) * 60 +\n" +
                                                   "DATE_PART('minute', t.data_final::timestamp - t.data_inicio::timestamp)) as media_minutos_trajeto,\n" +
                                            "avg(t.v0) as media_v0,\n" +
                                            "t.destino,\n" +
                                            "avg(t.v1) as media_v1\n" +
                                    "from trajetos t\n" +
                                    "where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                                    "and (t.origem in " + InClause + " or t.destino in " + InClause + ")\n" +
                                    "group by t.viagem_id, t.origem, periodo_dia, t.destino;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += Convert.ToInt32(dr["origem"]) + ";";
                    linha += Convert.ToDecimal(dr["media_v0"]) + ";";
                    linha += dr["periodo_dia"].ToString() + ";";
                    linha += Convert.ToDecimal(dr["media_minutos_trajeto"]) + ";";
                    linha += Convert.ToInt32(dr["destino"]) + ";";
                    linha += Convert.ToDecimal(dr["media_v1"]) + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetVelocidadeMediaTrajetoCSV(string DataConsulta, string[] Radares)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("codigo_radar_origem;periodo_dia;velocidade_media;codigo_radar_destino;");

            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select  t.viagem_id,\n" +
                                            "t.origem,\n" +
                                            "case when date_part('hour', t.data_inicio) between 0 and 4 then 'madrugada'\n" +
                                                 "when date_part('hour', t.data_inicio) between 5 and 12 then 'manha'\n" +
                                                 "when date_part('hour', t.data_inicio) between 13 and 18 then 'tarde'\n" +
                                                 "when date_part('hour', t.data_inicio) between 18 and 23 then 'noite'\n" +
                                                 "end as periodo_dia,\n" +
                                                    "avg((t.v0 + t.v1) / 2 ) as velocidade_media,\n" +
                                                    "t.destino\n" +
                                            "from trajetos t\n" +
                                            "where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                                            "and (t.origem in " + InClause + " or t.destino in " + InClause + ")\n" +
                                            "group by t.viagem_id, t.origem, periodo_dia, t.destino;";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += dr["origem"].ToString() + ";";
                    linha += dr["periodo_dia"].ToString() + ";";
                    linha += dr["velocidade_media"].ToString() + ";";
                    linha += dr["destino"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetViagensCSV(string DataConsulta, string[] Radares)
        {
            string InClause = "";

            InClause += "(";

            for (int i = 0; i < Radares.Count(); i++)
            {
                if (i == 0)
                {
                    InClause += "'" + Radares[i] + "'";
                }
                else
                {
                    InClause += ",'" + Radares[i] + "'";
                }
            }

            InClause += ")";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("viagem_id;codigo_radar_inicio;data_hora_inicio;codigo_radar_final;data_hora_final;tipo_veiculo;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select id, inicio, data_inicio, final, data_final, tipo from viagens where cast(data_inicio as date) = '" + DataConsulta + "'\n" +
                    "and (inicio in " + InClause + " or final in " + InClause + ");";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";

                    linha += dr["id"].ToString() + ";";
                    linha += dr["inicio"].ToString() + ";";
                    linha += dr["data_inicio"].ToString() + ";";
                    linha += dr["final"].ToString() + ";";
                    linha += dr["data_final"].ToString() + ";";
                    linha += dr["tipo"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }

            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }

        public byte[] GetDistanciaViagemCSV(string DataConsulta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("inicio;final;distancia;");

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                Npgsql.NpgsqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 420;

                comm.CommandType = CommandType.Text;
                comm.CommandText = "select distinct v.inicio,\n" +
                                   "v.final,\n" +
                                   "ST_Distance(ST_Transform(concat('SRID=4326;POINT(', cast(br0.lat as varchar(20)), ' ', cast(br0.lon as varchar(20)), ')')::geometry, 3857),\n" +
                                   "ST_Transform(concat('SRID=4326;POINT(', cast(br1.lat as varchar(20)), ' ', cast(br1.lon as varchar(20)), ')')::geometry, 3857)) * cosd(42.3521) as distancia\n" +
                "from viagens v\n" +
                "inner join base_radares_lat_lon br0\n" +
                "   on br0.codigo = v.inicio\n" +
                "inner join base_radares_lat_lon br1\n" +
                "   on br1.codigo = v.final\n" +
                "where cast(v.data_inicio as date) = '" + DataConsulta + "'\n" +
                "and v.inicio != v.final; ";

                conn.Open();

                Npgsql.NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    string linha = "";
                    
                    linha += dr["inicio"].ToString() + ";";
                    linha += dr["final"].ToString() + ";";
                    linha += dr["distancia"].ToString() + ";";

                    sb.AppendLine(linha);
                }
            }


            byte[] csv = Encoding.Default.GetBytes(sb.ToString());

            return csv;
        }
    }
}
