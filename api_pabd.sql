create  database gestao_processos_db;
use gestao_processos_db;

create table processos (
id_pro int primary key not null auto_increment,
numero_pro varchar(200) not null,
data_pro date not null,
interessado_pro varchar(200) not null,
assunto_pro varchar(300) not null,
descricao_pro text null,
situacao_pro varchar(50) not null default "Aberto",
created_at timestamp not null default current_timestamp
);

select * from processos;