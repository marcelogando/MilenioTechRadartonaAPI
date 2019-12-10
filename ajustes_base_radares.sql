alter table "BaseRadares"
add velocidade_cam_oni int;

alter table "BaseRadares"
add velocidade_carro_moto int;

update "BaseRadares"
set velocidade = 0
where velocidade = '';

update "BaseRadares"
   set velocidade_carro_moto = cast(case when (CHAR_LENGTH(velocidade) - CHAR_LENGTH(REPLACE(velocidade, '/', ''))) / CHAR_LENGTH('/') > 1
									then substring(velocidade, 0, position('/' in velocidade))
							   else replace(velocidade, 'km/h', '') end as int),
	   velocidade_cam_oni = cast(case when (CHAR_LENGTH(velocidade) - CHAR_LENGTH(REPLACE(velocidade, '/', ''))) / CHAR_LENGTH('/') > 1
								 then substring(replace(velocidade, 'km/h', ''), position('/' in velocidade) + 1, char_length(velocidade) -  position('/' in velocidade) - 1)
								 else replace(velocidade, 'km/h', '') end as int);
								 

-- Criacao da tabela base_radares_lat_lon
insert into base_radares_lat_lon (codigo, enquadramento, qtde_faixas, velocidade_cam_oni, velocidade_carro_moto, lat, lon, codigo_agrupado)
with codRadar as (
	   select trim((regexp_split_to_table (codigo, E'-'))) as codigo
from "BaseRadares" b)
select cast(codRadar.codigo as int), b.enquadrame, cast(b.qtde_fxs_f as int), b.velocidade_cam_oni, b.velocidade_carro_moto, cast(b.lat as decimal), cast(b.lon as decimal), b.codigo as codigo_agrupado
from "BaseRadares" b
inner join codRadar
on b.codigo like concat('%', codRadar.codigo, '%');