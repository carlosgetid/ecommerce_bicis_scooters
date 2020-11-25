USE master
GO

IF DB_ID('BD_VENTAS_BICICLETA_SCOOTER') IS NOT NULL
DROP DATABASE BD_VENTAS_BICICLETA_SCOOTER
GO

CREATE DATABASE BD_VENTAS_BICICLETA_SCOOTER
GO

USE BD_VENTAS_BICICLETA_SCOOTER
GO

-------------------------------------------------------------------------------------------------------------------------------------------
		/*CREACION DE TABLAS*/

CREATE TABLE TB_UBIGEO(
cod_ubigeo int IDENTITY(1,1) PRIMARY KEY not null ,
cod_departamento varchar(2) not null,
cod_provincia varchar(2) not null,
cod_distrito varchar(2) not null,
descrp_ubigeo varchar(300) not null
)
GO

CREATE TABLE TB_DIRECCION(
cod_direccion int IDENTITY(1,1) PRIMARY KEY not null ,
descrip_direccion varchar(250) not null,
cod_cliente int null,
cod_departamento varchar(2) not null,
cod_provincia varchar(2) not null,
cod_distrito varchar(2) not null,
)
GO

CREATE TABLE TB_TRABAJADOR(
cod_trabajador int IDENTITY(1,1) primary key not null,
nom_trabajador varchar(200) not null,
ape_trabajador varchar(200) not null,
dni_trabajador char(8) not null,
correo_trabajador varchar(250) not null,
cel_trabajador char(9) not null,
username_trabajador varchar(20) null, 
password_trabajador varchar(20) not null
)
GO

CREATE TABLE TB_CLIENTE(
cod_cliente int IDENTITY(1,1) primary key not null,
nom_cliente varchar(200) not null,
ape_cliente varchar(200) not null,
dni_cliente char(8) not null,
correo_cliente varchar(250) not null, /*funcionara como username */
cel_cliente char(9) not null,
password_cliente varchar(20) not null,
estado_cliente bit not null
)
GO

CREATE TABLE TB_MARCA(
cod_marca int IDENTITY(1,1) primary key not null,
descrp_marca varchar(200) not null
)
GO


CREATE TABLE TB_IMAGENES(
cod_imagen int IDENTITY(1,1) primary key not null,
descrp_imagen varchar(500) not null,
url_imagen varchar(500) not null 
)
GO

CREATE TABLE TB_SCOOTER(
cod_scooter int IDENTITY(101,1) primary key not null,
descrp_scooter varchar(350) not null,
cod_marca int not null,
aro_scooter varchar(200) not null,
color_scooter varchar(200) not null,
velocidad_scooter varchar(200) not null,
motor_scooter varchar(200) not null,
freno_scooter varchar(200) not null,
material_scooter varchar(200) not null,
precio_scooter decimal not null,
stock_scooter int not null,
cod_imagen int not null
)
GO

CREATE TABLE TB_ACCESORIO(
cod_accesorio int IDENTITY(201,1) primary key not null,
descrp_accesorio varchar(350) not null,
cod_marca int not null,
color_accesorio varchar(200) not null,
peso_accesorio varchar(200) not null,
material_accesorio varchar(200) not null,
dimension_accesorio varchar(200)  not null,
precio_accesorio decimal not null,
stock_accesorio int not null,
cod_imagen int not null
)
GO

CREATE TABLE TB_BICICLETA(
cod_bicicleta int IDENTITY(1,1) primary key not null,
descrp_bicicleta varchar(350) not null,
cod_marca int not null,
aro_bicicleta varchar(200) not null,
color_bicicleta varchar(200) not null,
freno_bicicleta varchar(200) not null,
peso_bicicleta varchar(200) not null,
precio_bicicleta decimal not null,
stock_bicicleta int not null,
cod_imagen int not null
)
GO

CREATE TABLE TB_PEDIDO(
nro_pedido int IDENTITY(1,1) primary key not null,
cod_cliente int not null,
fecha_pedido date not null,
tipo_pedido varchar(200) not null,
sub_total decimal not null,
igv_pedido decimal not null,
total_pedido decimal not null
)
GO

/*
CREATE TABLE TB_TIPO_PEDIDO
(
cod_tipo_pedido  int IDENTITY(1,1) primary key not null,
descrp_tipo varchar(200) not null,
direccion int not null,
nro_tarjeta varchar(200) not null,
cod_seguridad_tarjeta varchar(200) not null,
)
GO
*/

CREATE TABLE TB_DETALLE_PEDIDOS(
cod_detalle_pedido int IDENTITY(1,1) primary key not null,
nro_pedido int not null,
cod_scooter int not null,
cod_accesorio int not null,
cod_bicicleta int not null,
cantidad int not null,
total decimal not null
)
GO






CREATE TABLE TB_BOLETA(
nro_boleta int IDENTITY(1,1) primary key not null,
fecha_boleta Date not null,
nro_pedido int not null 
)
GO

CREATE TABLE TB_FACTURA(
nro_factura int IDENTITY(1,1) primary key not null,
cod_ruc char(11) not null,
fecha_factura Date not null,
nro_pedido int not null 
)
GO

------------------------------------------------------------------------------------------------------------------------------------------------
					/*AGREGANDO CONSTRAINT*/

ALTER TABLE TB_DIRECCION
ADD CONSTRAINT FK_DIRECCION_UBIGEO FOREIGN KEY (cod_direccion) REFERENCES TB_UBIGEO(cod_ubigeo)

ALTER TABLE TB_DIRECCION
ADD CONSTRAINT FK_DIRECCION_CLIENTE FOREIGN KEY (cod_cliente) REFERENCES TB_CLIENTE(cod_cliente)






ALTER TABLE TB_SCOOTER
ADD CONSTRAINT FK_SCOOTER_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)

ALTER TABLE TB_ACCESORIO
ADD CONSTRAINT FK_ACCESORIO_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)

ALTER TABLE TB_BICICLETA
ADD CONSTRAINT FK_BICICLETA_MARCA FOREIGN KEY (cod_marca) REFERENCES TB_MARCA(cod_marca)


ALTER TABLE TB_BOLETA
ADD CONSTRAINT FK_BOLETA_PEDIDO FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)
ALTER TABLE TB_FACTURA
ADD CONSTRAINT FK_FACTURA_PEDIDO FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)

ALTER TABLE TB_BICICLETA
ADD CONSTRAINT FK_BICICLETA_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)
ALTER TABLE TB_ACCESORIO
ADD CONSTRAINT FK_ACCESORIO_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)
ALTER TABLE TB_SCOOTER
ADD CONSTRAINT FK_SCOOTER_IMAGENES FOREIGN KEY (cod_imagen) REFERENCES TB_IMAGENES(cod_imagen)

ALTER TABLE TB_PEDIDO
ADD CONSTRAINT FK_CLIENTE_PEDIDO FOREIGN KEY (cod_cliente) REFERENCES TB_CLIENTE(cod_cliente)






ALTER TABLE TB_DETALLE_PEDIDOS
ADD CONSTRAINT FK_DETALLE_SCOOTER FOREIGN KEY (cod_scooter) REFERENCES TB_SCOOTER(cod_scooter)
ALTER TABLE TB_DETALLE_PEDIDOS
ADD CONSTRAINT FK_DETALLE_ACCESORIO FOREIGN KEY (cod_accesorio) REFERENCES TB_ACCESORIO(cod_accesorio)
ALTER TABLE TB_DETALLE_PEDIDOS
ADD CONSTRAINT FK_DETALLE_BICICLETA FOREIGN KEY (cod_bicicleta) REFERENCES TB_BICICLETA(cod_bicicleta)
ALTER TABLE TB_DETALLE_PEDIDOS
ADD CONSTRAINT FK_DETALLE_PEDIDO_SCOOTER FOREIGN KEY (nro_pedido) REFERENCES TB_PEDIDO(nro_pedido)









----------------------------------------------------------------------------------------------------------------------------------------
					/*INSERTANDO REGISTROS NECESARIO*/

--INSERT UBIGEO (COMPLETO)


--INSERT DIRECCION (5 A 10 DIRECCIONES)


--INSERT CLIENTE (5 A 10) 


--INSERT MARCA (TODAS LAS MARCAS DEL MERCADO QUE PRODUCEN NUESTROS PRODUCTOS )

--SCOOTER

INSERT TB_MARCA VALUES('Xiomi')
INSERT TB_MARCA VALUES('Cecotec')
INSERT TB_MARCA VALUES('Segway Ninebot')
INSERT TB_MARCA VALUES('Razor Power')
INSERT TB_MARCA VALUES('Revolt')
--BICICLETA
INSERT TB_MARCA VALUES('Monark')
INSERT TB_MARCA VALUES('Monarette')
INSERT TB_MARCA VALUES('Giant')
INSERT TB_MARCA VALUES('Liv')
INSERT TB_MARCA VALUES('Felt')

--ACCESORIO
INSERT TB_MARCA VALUES('CAR-partment')

SELECT * FROM TB_MARCA

--IMAGENES

INSERT TB_IMAGENES VALUES ('Bicicleta Montañera Monark Dakar Thypoon',N'/Content/img/1.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Mirage',N'/Content/img/Bicicleta Mirage.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Tricicargo Crosstown',N'/Content/img/Bicicleta Tricicargo Crosstown.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Delta ADV',N'/Content/img/Bicicleta Delta ADV.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Master Bike',N'/Content/img/Bicicleta Master Bike.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta XTC JR',N'/Content/img/Bicicleta XTC JR.jpg')
INSERT TB_IMAGENES VALUES ('Scooter Eléctrico XIAOMI M365 PRO',N'/Content/img/Scooter Eléctrico XIAOMI M365 PRO.jpg')
INSERT TB_IMAGENES VALUES ('Scooter electrico Xiaomi M365',N'/Content/img/Scooter electrico Xiaomi M365.jpg')
INSERT TB_IMAGENES VALUES ('Scooter electrico Bongo Serie S Unlimited',N'/Content/img/Scooter electrico Bongo Serie S Unlimited.jpg')
INSERT TB_IMAGENES VALUES ('Scooter electrico Bongo Serie A',N'/Content/img/Scooter electrico Bongo Serie A.jpg')
INSERT TB_IMAGENES VALUES ('Scooter Eléctrico Ninebot Max G30P',N'/Content/img/Scooter Eléctrico Ninebot Max G30P.jpg')
INSERT TB_IMAGENES VALUES ('Lámpara luz frontal 3 LED Ultra brillante',N'/Content/img/Lámpara luz frontal 3 LED Ultra brillante.jpg')
INSERT TB_IMAGENES VALUES ('Set de inflador de bolsillo con manómetro',N'/Content/img/Set de inflador de bolsillo con manómetro.jpg')
INSERT TB_IMAGENES VALUES ('Set de herramientas múltiples',N'/Content/img/Set de herramientas múltiples.jpg')
INSERT TB_IMAGENES VALUES ('Soporte para celular de plástico',N'/Content/img/Soporte para celular de plástico.jpg')
INSERT TB_IMAGENES VALUES ('Asiento ajustable para scooter eléctrico',N'/Content/img/Asiento ajustable para scooter eléctrico.jpg')
INSERT TB_IMAGENES VALUES ('Luces Bolt combo led',N'/Content/img/Luces Bolt combo led.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta 2020 Suede 2',N'/Content/img/Bicicleta 2020 Suede 2.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Enchant',N'/Content/img/Bicicleta Enchant.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta TEMPT 3',N'/Content/img/Bicicleta TEMPT 3.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Fr Advanced Ultegra Plasma Red',N'/Content/img/Bicicleta Fr Advanced Ultegra Plasma Red.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Fr Advanced Ultegra Aquafresh',N'/Content/img/Bicicleta Fr Advanced Ultegra Aquafresh.jpg')
INSERT TB_IMAGENES VALUES ('Scooter electrico Ninebot ES3',N'/Content/img/Scooter electrico Ninebot ES3.jpg')
INSERT TB_IMAGENES VALUES ('Scooter electrico Razor E300',N'/Content/img/Scooter electrico Razor E300.jpg')
INSERT TB_IMAGENES VALUES ('Scooter eléctrico E-Prime III',N'/Content/img/Scooter eléctrico E-Prime III.jpg')
INSERT TB_IMAGENES VALUES ('Scooter eléctrico N4',N'/Content/img/Scooter eléctrico N4.jpg')
INSERT TB_IMAGENES VALUES ('Scooter Electrico Silver N2',N'/Content/img/Scooter Electrico Silver N2.jpg')
INSERT TB_IMAGENES VALUES ('Porta Botella',N'/Content/img/Porta Botella.jpg')
INSERT TB_IMAGENES VALUES ('Set de protección Krown 2 rodilleras 2 coderas 2 muñequeras',N'/Content/img/Set de protección Krown 2 rodilleras 2 coderas 2 muñequeras.jpg')
INSERT TB_IMAGENES VALUES ('Casco de Bicicleta Unisex',N'/Content/img/Casco de Bicicleta Unisex.jpg')
INSERT TB_IMAGENES VALUES ('Candado U-Lock Con Alarma Inteligente',N'/Content/img/Candado U-Lock Con Alarma Inteligente.jpg')
INSERT TB_IMAGENES VALUES ('Mochila de Hidra Drafter 10L',N'/Content/img/Mochila de Hidra Drafter 10L.jpg')
INSERT TB_IMAGENES VALUES ('Scooter Electrico Zero 9',N'/Content/img/Scooter Electrico Zero 9.jpg')
INSERT TB_IMAGENES VALUES ('Scooter Electrico HX X7',N'/Content/img/Scooter Electrico HX X7.jpg')
INSERT TB_IMAGENES VALUES ('Bicicleta Mtb',N'/Content/img/Bicicleta Mtb.jpg')
INSERT TB_IMAGENES VALUES ('Protector De Asiento Para Bicicleta',N'/Content/img/Protector De Asiento Para Bicicleta.jpg')
INSERT TB_IMAGENES VALUES ('Espejo Retrovisor Para Bicicleta',N'/Content/img/Espejo Retrovisor Para Bicicleta.jpg')






SELECT * FROM TB_IMAGENES
GO

--INSERT SCOOTER (10 A 15)

INSERT TB_SCOOTER VALUES('Scooter Eléctrico XIAOMI M365 PRO',1,'Neumaticos de 8.5 pulgadas inflables','Negro','25 km/h','Brushless 300W','De disco ventilado trasero de 120 mm y un sistema de frenos antibloqueo regenerativo E-ABS delantero','Aleación de aluminio',1899,5,7)
INSERT TB_SCOOTER VALUES('Scooter electrico Xiaomi M365',1,'Neumaticos de 8.5 pulgadas inflables','Negro','25 km/h','Brushless 250W','Sistema de frenado de disco y un sistema de frenado antibloqueo regenerativo eABS','Aleación de aluminio',1399,2,8)
INSERT TB_SCOOTER VALUES('Scooter electrico Bongo Serie S Unlimited',2,'Tubeless antirreventón de 10 pulgadas','Negro','25 km/h','Potencia nominal de 350W','Doble disco de freno delantero y trasero','Aleación de aluminio',2321,3,9)

INSERT TB_SCOOTER VALUES('Scooter electrico Bongo Serie A',2,'Tubeless antirreventón de 8,5 pulgadas','Gris','25 km/h','Potencia nominal de 350W','Triple sistema de frenado de seguridad extrema disco-electrico-manual','Aleación de aluminio',1264.57,4,10)
INSERT TB_SCOOTER VALUES('Scooter Eléctrico Ninebot Max G30P',3,'Neumatico de 10 pulgadas','Gris','25 km/h','350W Brushless','De tambor delantero mecánico simultáneo y el posterior eléctrico regenerativo','Aleación de aluminio',2799,2,11)
INSERT TB_SCOOTER VALUES('Scooter electrico Ninebot ES3',3,'Llanta sólida de 8 pulgadas','Negro','25 km/h','Potencia nominal de 250W','Electrónico y mecánico','Aleación de aluminio',1999.5,5,23)

INSERT TB_SCOOTER VALUES('Scooter electrico Razor E300',4,'Neumático de 10 pulgadas inflables','Gris','24 km/h','Potencia de 250W','Delantero','Aleación de aluminio',999.89,3,24)
INSERT TB_SCOOTER VALUES('Scooter eléctrico E-Prime III',4,'Neumático delantero de 8 pulgada','Negro','18 km/h','Potencia de 250W','Trasero','Aleación de aluminio',1649.33,2,25)
INSERT TB_SCOOTER VALUES('Scooter eléctrico N4',5,'Neumático delantero de 8 pulgadas con cámara','Negro','25 km/h','Brushless 300W','De disco delantero y freno de pie posterior','Aleación de aluminio',1199,2,26)


INSERT TB_SCOOTER VALUES('Scooter Electrico Silver N2',5,'Llantas de 8.5 tubeless','Gris','25 km/h','Brushless 250W','Delantero','Aleación de aluminio',1099,2,27)
INSERT TB_SCOOTER VALUES('Scooter Electrico Zero 9',4,'Neumaticos de 8.5 pulgadas','Negro','48 km/h','Potencia de 600W','Delantero de disco y trasero tambor','Aleación de aluminio',2699,2,33)
INSERT TB_SCOOTER VALUES('Scooter Electrico HX X7',3,'Neumaticos de 10 pulgadas','Negro','25 km/h','Potencia de 350W','Delantero de disco y trasero disco','Aleación de aluminio',1500,2,34)




select * from TB_SCOOTER
go



--INSERT ACCESORIO (10 A 15)



INSERT TB_ACCESORIO VALUES('Set de inflador de bolsillo con manómetro',1,'Negro','95 gr','Plástico','21 cm de alto y 3 cm de ancho',69.90,2,13)
INSERT TB_ACCESORIO VALUES('Set de herramientas múltiples',2,'Negro','500 gr','Acero','9 x 4.5 x 2.5 cm',39.90,2,14)
INSERT TB_ACCESORIO VALUES('Soporte para celular de plástico',3,'Negro y Rojo','120 gr','Plástico','20 cm de alto y 15 cm de ancho',29.90,2,15)

INSERT TB_ACCESORIO VALUES('Asiento ajustable para scooter eléctrico ',4,'Negro','2.8 kg','Cuerina Alumnio y Hierro','16.5 x 27 cm',189.90,2,16)
INSERT TB_ACCESORIO VALUES('Luces Bolt combo led',5,'Negro','30 gr','Aluminio de alta calidad y plástico de nylon de primera clase','21 cm de alto y 3 cm de ancho',69.90,2,17)
INSERT TB_ACCESORIO VALUES('Porta Botella',6,'Negro','50 gr','PVC','abrazadera 1.5 pies para botellas de 1 litro',39.90,2,28)

INSERT TB_ACCESORIO VALUES('Set de protección Krown',7,'Negro','500 gr','Proteccion de PVC','Acolchado con espuma de alta densidad',119.90,2,29)
INSERT TB_ACCESORIO VALUES('Casco de Bicicleta Unisex',8,'Negro','228 gr','Policarbonato','30 cm',179.90,2,30)
INSERT TB_ACCESORIO VALUES('Candado U-Lock Con Alarma Inteligente',9,'Negro y amarillo','1 kg','Acero templado','30 cm y más grueso del momento 16mm',270,2,31)

INSERT TB_ACCESORIO VALUES('Mochila de Hidra Drafter 10L',10,'Azul marino','1 kg','Lona','46 cm de alto y 25 cm de ancho',479,2,32)
INSERT TB_ACCESORIO VALUES('Protector De Asiento Para Bicicleta',8,'Negro','50 gr','Asiento acolchado y relleno de gel','29 cm de largo x 21 de ancho',45,2,36)
INSERT TB_ACCESORIO VALUES('Espejo Retrovisor Para Bicicleta ',10,'Negro','47.4 gr','Silicona','20 cm de largo x 10.5 de ancho',35,2,37)



select * from TB_ACCESORIO
go


--INSERT BICICLETA (10 A 15)


INSERT TB_BICICLETA VALUES('Bicicleta Montañera Monark Dakar Thypoon',6,'Aro 24','Gris','V-Brake Delantero y posterior','16 kg',729,2,1)
INSERT TB_BICICLETA VALUES('Bicicleta Mirage',6,'24','Negro','V Brake','16 kg',849,2,2)
INSERT TB_BICICLETA VALUES('Bicicleta Tricicargo Crosstown',6,'26','Negro','V Brake delantero y tambor posterior','20 kg',1699,2,3)

INSERT TB_BICICLETA VALUES('Bicicleta Delta ADV',7,'26','Negro Verde','Disco Delantero y V Brake Trasero','16 kg',549,2,4)
INSERT TB_BICICLETA VALUES('Bicicleta Master Bike',7,'26','Negro Verde','V Brake','18 kg',459,2,5)
INSERT TB_BICICLETA VALUES('Bicicleta XTC JR',8,'20','Metallic Blue','Alloy Linear Pull','18 kg',1199,2,6)

INSERT TB_BICICLETA VALUES('Bicicleta 2020 Suede 2',8,'26','Azul','Aluminio Direct Pull','18 kg',1899,2,18)
INSERT TB_BICICLETA VALUES('Bicicleta Enchant',9,'20','Azul','Alloy Linear Pull','17 kg',1099,2,19)
INSERT TB_BICICLETA VALUES('Bicicleta TEMPT 3',9,'27.5','Negro','SHIMANO M315','19 kg',2799,2,20)

INSERT TB_BICICLETA VALUES('Bicicleta Fr Advanced Ultegra Plasma Red',10,'24','Rojo','Disco hidráulico Shimano BR8070','10 kg',2500,2,21)
INSERT TB_BICICLETA VALUES('Bicicleta Fr Advanced Ultegra Aquafresh',10,'24','Oceano','Disco hidráulico Shimano BR8070','10 kg',2500,2,22)	
INSERT TB_BICICLETA VALUES('Bicicleta Mtb',8,'26','Negro','Frenos V-Braker','17 kg',800,2,35)	


select * from TB_BICICLETA



--INSERT TRABAJADOR (1 a 4)

insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Carlos', 'Gomez', '87654321', 'carlos@gmail.com', '987654321', 't20201', '123');
insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Pablo', 'Saravia', '82654322', 'pablo@gmail.com', '985644322', 't20202', '123');
insert TB_TRABAJADOR (nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador, username_trabajador, password_trabajador) values ('Eduardo', 'Cordoba', '87558393', 'eduardo@gmail.com', '985423433', 't20203', '123');



--GENERAR PEDIDO (2 A 5 )



/*CADA INSERCION TIENE QUE ESTAR BIEN REALIZADA*/





-------------------------------------------------------------------------------------------------------------------------------------------------------------------
														/*GENERAR SP*/

/*** TABLA CLIENTE *****/

/*
update dbo.TB_CLIENTE set estado_cliente=1
go
*/

go
create proc usp_Cliente_Consultar
@dni char(8)
as
begin
	select cod_cliente,nom_cliente,ape_cliente,dni_cliente,correo_cliente,cel_cliente
	from TB_CLIENTE 
	where  @dni= '' or	dni_cliente = @dni
	
end 
go




create proc usp_Cliente_Buscar
@correo_cliente varchar(250),
@password_cliente varchar(20)
as
begin
	select nom_cliente,ape_cliente,dni_cliente,correo_cliente,cel_cliente,password_cliente
	from TB_CLIENTE 
	where correo_cliente=@correo_cliente and password_cliente=@password_cliente
end 
go


create proc usp_Cliente_Insertar
@nom_cliente varchar(200),
@ape_cliente varchar(200),
@dni_cliente char(8),
@correo_cliente varchar(250),
@cel_cliente char(9),
@password_cliente varchar(20)
as
begin
	insert into TB_CLIENTE(nom_cliente,ape_cliente,dni_cliente,correo_cliente,cel_cliente,password_cliente,estado_cliente)
	Values(@nom_cliente,@ape_cliente,@dni_cliente,@correo_cliente,@cel_cliente,@password_cliente,1)
end 
go


create proc usp_Cliente_Actualizar
@cod_cliente int,
@nom_cliente varchar(200),
@ape_cliente varchar(200),
@dni_cliente char(8),
@correo_cliente varchar(250),
@cel_cliente char(9),
@password_cliente varchar(20)
as
begin	
	update TB_CLIENTE 
	set nom_cliente=@nom_cliente,
		ape_cliente=@ape_cliente,
		dni_cliente=@dni_cliente,
		correo_cliente=@correo_cliente,
		cel_cliente=@cel_cliente,
		password_cliente=@password_cliente
	where cod_cliente=@cod_cliente
end 
go


create proc usp_Cliente_Find
@cod_cliente int
as
begin
	select cod_cliente,nom_cliente,ape_cliente,dni_cliente,correo_cliente,cel_cliente,password_cliente
	from TB_CLIENTE 
	where cod_cliente=@cod_cliente
end 
go


-----------------------------------------------------------------------------
/*** TABLA SCOOTER *****/

create proc usp_Scooter_Listar
as
begin
	select cod_scooter,descrp_scooter,m.descrp_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter,i.url_imagen
	from TB_SCOOTER s 
	join TB_MARCA m on s.cod_marca=m.cod_marca
	join TB_IMAGENES i on s.cod_imagen=i.cod_imagen
end
go


create proc usp_Scooter_Consultar
@descp_scooter varchar(350),
@cod_marca int 
as
begin
	select cod_scooter,descrp_scooter,m.descrp_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter
	from TB_SCOOTER s 
	join TB_MARCA m on s.cod_marca=m.cod_marca
	where @descp_scooter='' or  UPPER(descrp_scooter)=UPPER(@descp_scooter) and s.cod_marca=@cod_marca 
end
go



create proc usp_Scooter_Buscar
@id int 
as
begin
	select cod_scooter,descrp_scooter,s.cod_marca,m.descrp_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter,s.cod_imagen,i.url_imagen
	from TB_SCOOTER s
	join TB_MARCA m on s.cod_marca=m.cod_marca
	join TB_IMAGENES i on s.cod_imagen=i.cod_imagen
	where cod_scooter=@id
end
go




/* Creado por Brandon */
create proc usp_Scooter_Insertar
@Descrp_Scooter varchar(350), 
@Cod_Marca int,
@Aro_Scooter varchar(200), 
@Color_Scooter varchar(200), 
@Velocidad_Scooter varchar(200), 
@Motor_Scooter varchar(200),
@Freno_Scooter varchar(200), 
@Material_Scooter varchar(200),
@Precio_Scooter decimal, 
@Stock_Scooter int,
@Cod_Imagen int
as
begin
	insert TB_SCOOTER(descrp_scooter,cod_marca,aro_scooter,color_scooter,velocidad_scooter,motor_scooter,freno_scooter,material_scooter,precio_scooter,stock_scooter,cod_imagen)
	values(@Descrp_Scooter,@Cod_Marca,@Aro_Scooter,@Color_Scooter,@Velocidad_Scooter,@Motor_Scooter,@Freno_Scooter,@Material_Scooter,@Precio_Scooter,@Stock_Scooter,@Cod_Imagen)
end
go






create proc usp_Scooter_Actualizar
@Cod_Scooter int ,
@Descrp_Scooter varchar(350), 
@Cod_Marca int,
@Aro_Scooter varchar(200), 
@Color_Scooter varchar(200), 
@Velocidad_Scooter varchar(200), 
@Motor_Scooter varchar(200),
@Freno_Scooter varchar(200), 
@Material_Scooter varchar(200),
@Precio_Scooter decimal, 
@Stock_Scooter int,
@Cod_Imagen int
as
begin
	update TB_SCOOTER 
	set descrp_scooter=@Descrp_Scooter, 
		cod_marca=@Cod_Marca,
		aro_scooter=@Aro_Scooter,
		color_scooter=@Color_Scooter,
		velocidad_scooter=@Velocidad_Scooter,
		motor_scooter=@Motor_Scooter, 
		freno_scooter=@Freno_Scooter,
		material_scooter=@Material_Scooter, 
		precio_scooter=@Precio_Scooter, 
		stock_scooter=@Stock_Scooter,
		cod_imagen=@Cod_Imagen
	where cod_scooter=@Cod_Scooter
end
go






create proc usp_Marca_Listar
as
begin
	select cod_marca,descrp_marca
	from TB_MARCA 
end
go






-----------------------------------------------------------------------------
/*** TABLA TRABAJADOR *****/

create proc usp_Trabajador_Buscar
@username varchar(20),
@password varchar(20)
as
begin
	select nom_trabajador, ape_trabajador, dni_trabajador, correo_trabajador, cel_trabajador,username_trabajador, password_trabajador
	from TB_TRABAJADOR
	where username_trabajador = @username and password_trabajador = @password
end
go





-----------------------------------------------------------------------------
/*** TABLA BICICLETA *****/

create proc usp_Bicicleta_Listar
as
begin
	select cod_bicicleta,descrp_bicicleta,m.descrp_marca,aro_bicicleta,color_bicicleta,freno_bicicleta,peso_bicicleta,precio_bicicleta,stock_bicicleta,i.url_imagen
	from TB_BICICLETA B
	join TB_MARCA m on B.cod_marca=m.cod_marca
	join TB_IMAGENES i on b.cod_imagen=i.cod_imagen
end
go



create proc usp_Bicicleta_Insertar
@desc varchar(350),
@codmarca int ,
@aro varchar(200), 
@color varchar(200),
@freno varchar(200),
@peso varchar(200),
@precio decimal,
@stock int,
@codimg int
as
begin
	insert into TB_BICICLETA (descrp_bicicleta,cod_marca,aro_bicicleta,color_bicicleta,freno_bicicleta,peso_bicicleta,precio_bicicleta,stock_bicicleta,cod_imagen) 
	values (@desc,@codmarca,@aro,@color,@freno,@peso,@precio,@stock,@codimg)
end
go

create proc usp_Bicicleta_Actualizar
@Id int, @desc varchar(350),@codmarca int ,@aro varchar(200), @color varchar(200),@freno varchar(200), @peso varchar(200),@precio decimal,@stock int,@codimg int
as
begin
	update TB_BICICLETA 
	set	descrp_bicicleta=@desc,
		cod_marca=@codmarca,
		aro_bicicleta=@aro,
		color_bicicleta=@color,
		freno_bicicleta=@freno,
		peso_bicicleta=@peso,
		precio_bicicleta=@precio,
		stock_bicicleta=@stock,
		cod_imagen=@codimg
	where cod_bicicleta=@Id
end
go


create proc usp_Bicicleta_Buscar
@id int 
as
begin
	select cod_bicicleta,descrp_bicicleta,b.cod_marca,m.descrp_marca,aro_bicicleta,color_bicicleta,freno_bicicleta,peso_bicicleta,precio_bicicleta,stock_bicicleta,b.cod_imagen,i.url_imagen
	from TB_BICICLETA b
	join TB_MARCA m on  b.cod_marca=m.cod_marca
	join TB_IMAGENES i on b.cod_imagen=i.cod_imagen
	where cod_bicicleta=@id
end
go


create proc usp_Bicicleta_Consultar
@descp_bicicleta varchar(350),
@cod_marca int 
as
begin
	select cod_bicicleta,descrp_bicicleta,m.descrp_marca,aro_bicicleta,color_bicicleta,freno_bicicleta,peso_bicicleta,precio_bicicleta,stock_bicicleta
	from TB_BICICLETA B
	join TB_MARCA m on B.cod_marca=m.cod_marca
	where @descp_bicicleta= '' or UPPER(descrp_bicicleta)=UPPER(@descp_bicicleta) and B.cod_marca=@cod_marca 
end
go







-----------------------------------------------------------------------------
/*** TABLA ACCESORIO *****/

create proc usp_Accesorio_Listar
as
begin
	select cod_accesorio,descrp_accesorio,m.descrp_marca,color_accesorio,peso_accesorio,material_accesorio,dimension_accesorio,precio_accesorio,stock_accesorio,i.url_imagen
	from TB_ACCESORIO a
	join TB_MARCA m on a.cod_marca=m.cod_marca
	join TB_IMAGENES i on a.cod_imagen=i.cod_imagen
end
go



create proc usp_Accesorio_Buscar
@Id int
as
begin
	select cod_accesorio,descrp_accesorio,a.cod_marca,m.descrp_marca,color_accesorio,peso_accesorio,material_accesorio,dimension_accesorio,precio_accesorio,stock_accesorio,a.cod_imagen,i.url_imagen
	from TB_ACCESORIO a
	join TB_MARCA m on a.cod_marca=m.cod_marca
	join TB_IMAGENES i on a.cod_imagen=i.cod_imagen
	where cod_accesorio=@Id
end
go





create proc usp_Accesorio_Insertar
@desc_accesorio varchar(350),
@codmarca int , 
@color_accesorio varchar(200),
@peso_accesorio varchar(200),
@material_accesorio varchar(200),
@dimension_accesorio varchar(200),
@precio_accesorio decimal,
@stock_accesorio int,
@codimg int
as
begin
	insert TB_ACCESORIO(descrp_accesorio,cod_marca,color_accesorio,peso_accesorio,material_accesorio,dimension_accesorio,precio_accesorio,stock_accesorio,cod_imagen) 
	values (@desc_accesorio,@codmarca,@color_accesorio,@peso_accesorio, @material_accesorio,@dimension_accesorio,@precio_accesorio,@stock_accesorio,@codimg)
end
go







create proc usp_Accesorio_Actualizar
@Cod_accesorio int,
@desc_accesorio varchar(350),
@codmarca int , 
@color_accesorio varchar(200),
@peso_accesorio varchar(200),
@material_accesorio varchar(200),
@dimension_accesorio varchar(200),
@precio_accesorio decimal,
@stock_accesorio int,
@codimg int
as
begin
	update TB_ACCESORIO
	set descrp_accesorio=@desc_accesorio,
		cod_marca=@codmarca,
		color_accesorio=@color_accesorio,
		peso_accesorio=@peso_accesorio,
		material_accesorio=@material_accesorio,
		dimension_accesorio=@dimension_accesorio,
		precio_accesorio=@precio_accesorio,
		stock_accesorio=@stock_accesorio,
		cod_imagen=@codimg
	where cod_accesorio=@Cod_accesorio
end
go









create proc usp_Accesorio_Consultar
@descp_accesorio varchar(350),
@cod_marca int 
as
begin
	select cod_accesorio,descrp_accesorio,m.descrp_marca,color_accesorio,peso_accesorio,material_accesorio,dimension_accesorio,precio_accesorio,stock_accesorio
	from TB_ACCESORIO a
	join TB_MARCA m on a.cod_marca=m.cod_marca
	where @descp_accesorio= '' or UPPER(descrp_accesorio)=UPPER(@descp_accesorio) and a.cod_marca=@cod_marca 
end
go








































