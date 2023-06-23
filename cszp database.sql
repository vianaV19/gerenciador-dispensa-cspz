

drop database if exists cspz;
create database cspz
default charset 'utf8';

use cspz;

-- ================
-- TABLES 
-- ================

create table if not exists tb_dispensa (
	id int not null auto_increment primary key,
    `data` datetime default current_timestamp,
    assist mediumint not null,
    colab mediumint not null,
    projet mediumint not null,
    total mediumint not null,
	proteina varchar(150) not null,
    qntd_proteina mediumint not null,
	sobremesa varchar(150) not null,
    qntd_sobremesa mediumint not null
);

create table if not exists tb_acompanhamento  (
	id int auto_increment primary key,
	`data` datetime default current_timestamp,
    acompanhamento varchar(150) not null,
    qntd mediumint not null
);

create table if not exists tb_guarnicao (
	id int auto_increment primary key,
	`data` datetime default current_timestamp,
    guarnicao varchar(150) not null,
    qntd mediumint not null
);

create table if not exists tb_lanche (
	id int auto_increment primary key,
	`data` datetime default current_timestamp,
    lanche varchar(150) not null,
    turno varchar(50) not null,
    qntd mediumint not null
);

-- ================
-- INSERTS 
-- ================

insert into tb_dispensa 
(assist, colab, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa)
values
(3, 10, 2, 15, 'carne', 3, 'bolo', 5),
(4, 11, 3, 16, 'carne', 3, 'bolo', 5),
(5, 12, 5, 17, 'carne', 3, 'bolo', 5);

INSERT INTO `tb_acompanhamento` 
( `acompanhamento`, `qntd`) 
VALUES 
( 'arroz', '3');

insert into  tb_guarnicao
(guarnicao, qntd)
values
('guarnicao', 32);

insert into  tb_lanche
(lanche, turno, qntd)
values
('sanduiche', 'manha', 32),
('pao de sal', 'tade', 20);

-- ================
-- SELECT 
-- ================
-- select data, assist, colab, total, a.acompanhamento, a.qntd from tb_dispensa as d inner join tb_acompanhamento as a on(d.id = a.id_dispensa);



