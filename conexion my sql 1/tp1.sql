create database tp1;

use tp1;

create table productos(
productosid int primary key auto_increment not null,
nombre varchar(100) not null,
precio int(100) not null,
stock int not null
);

use tp1;

insert into productos(nombre, precio, stock)
values
("Laptop lenovo", 750, 10),
("Mouse gamer", 250, 50),
("Teclado mecanico", 450, 25);