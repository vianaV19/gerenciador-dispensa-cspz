


create database cspz
default charset 'utf8';

use cspz;

-- ================
-- TABLES 
-- ================

create table if not exists tb_dispensa (
    `data` datetime not null primary key,
    assist mediumint not null,
    colab mediumint not null,
    total mediumint not null,
	proteina varchar(150) not null,
    qntd_proteina mediumint not null,
	sobremesa varchar(150) not null,
    qntd_sobremesa mediumint not null
);

create table if not exists tb_acompanhamento  (
	id int auto_increment primary key,
    acompanhamento varchar(150) not null,
    qntd mediumint not null,
    id_dispensa int,
    foreign key (id_dispensa) references tb_dispensa(id)
);

create table if not exists tb_guarnicao (
	id int auto_increment primary key,
    guarnicao varchar(150) not null,
    qntd mediumint not null,
       id_dispensa int,
	foreign key (id_dispensa) references tb_dispensa(id)
);

create table if not exists tb_lanche (
	id int auto_increment primary key,
    lanche varchar(150) not null,
    turno varchar(50) not null,
    qntd mediumint not null,
       id_dispensa int,
	foreign key (id_dispensa) references tb_dispensa(id)
);

-- ================
-- INSERTS 
-- ================

insert into tb_dispensa 
(assist, colab, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa)
values
(3, 10, 15, 'carne', 3, 'bolo', 5),
(4, 11, 16, 'carne', 3, 'bolo', 5),
(5, 12, 17, 'carne', 3, 'bolo', 5);

INSERT INTO `tb_acompanhamento` 
(`id`, `acompanhamento`, `qntd`, `id_dispensa`) 
VALUES 
(NULL, 'arroz', '3', '1');

insert into  tb_guarnicao
(guarnicao, qntd, id_dispensa)
values
('guarnicao', 32, 1);

insert into  tb_lanche
(lanche, turno, qntd, id_dispensa)
values
('sanduiche', 'manha', 32, 1),
('pao de sal', 'tade', 20, 1);

-- ================
-- SELECT 
-- ================
-- select data, assist, colab, total, a.acompanhamento, a.qntd from tb_dispensa as d inner join tb_acompanhamento as a on(d.id = a.id_dispensa);



