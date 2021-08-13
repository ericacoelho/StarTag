--bd do ultimo salao 
drop database bdSalao2
create database bdSalao3
go

use bdSalao2

create table tbCliente(
	codCliente int primary key identity (1,1) not null
	,dataNasc date not null
	,nomeCliente varchar(50) not null
	,cpfCliente char(14) not null
	,ruaCliente varchar(40) not null
	,numRuaCliente varchar(10) not null
	,compCliente varchar(20)
	,cepCliente varchar(10) not null
	,bairroCliente varchar(30) not null
	,cidadeCliente varchar(30) not null
	,estadoCliente varchar(30) not null
	,email varchar(100)
	,sexo varchar(10) not null
)

create table tbEspecialidade(
	codEspecialidade int primary key identity(1,1) not null
	,descEspecialidade varchar(40) not null
) 

create table tbFoneCliente(
	codFoneCliente int primary key identity(1,1) not null
	,numFoneCliente varchar(15) not null
	,codCliente int foreign key references tbCliente(codCliente)
)

create table tbProfissional(
	codProfissional int primary key identity (1,1) not null
	,dataNasc date not null
	,nomeProfissional varchar (50) not null
	,cpfProfissional char(14) not null
	,ruaProfissional varchar(40) 
	,numRuaProfissional varchar(10) 
	,compProfissional varchar(20)
	,cepProfissional varchar(10) 
	,bairroProfissional varchar(30) 
	,cidadeProfissional varchar(30) 
	,estado varchar(30) 
	,email varchar(100) 
	,sexo varchar(10) not null
	,codEspecialidade int foreign key references tbEspecialidade(codEspecialidade) not null
)

create table tbFoneProfissional(
	codFoneProfissional int primary key identity(1,1) not null
	,numFoneProfissional varchar(15) not null
	,codProfissional int foreign key references tbProfissional(codProfissional)
)

create table tbComanda(
	codComanda int primary key identity (1,1) not null
	,dataComanda smalldatetime not null
	,valorTotalComanda money not null
	,codCliente int foreign key references tbCliente(codCliente)
)
create table tbFormaPagto(
	codFormaPagto int primary key identity(1,1) not null
	,descFormaPagto varchar(15) not null
)
create table tbParcela(
	codParcela int primary key identity(1,1) not null
	,codComanda int foreign key references tbComanda(codComanda) not null
	,codFormaPagto int foreign key references  tbFormaPagto(codFormaPagto)
	,valor money not null
)
create table tbServico(
	codServico int primary key identity(1,1) not null
	,descServico varchar(20) not null
	,valor money not null
)
create table tbFabricante(
	codFabricante int primary key identity(1,1) not null
	,descFabricante varchar(30) not null
	,cnpjFabricante varchar (18) 
)

create table tbMarca(
	codMarca int primary key identity(1,1)not null
	,descMarca varchar(30)
)

create table tbLinha(
	codLinha int primary key identity(1,1) not null
	,codMarca int foreign key references tbMarca(codMarca)
	,descLinha varchar(30)
)

create table tbProduto(
	codProduto int primary key identity(1,1) not null
	,descProduto varchar(20) not null
	,valor money not null
	,codMarca int foreign key references tbMarca(codMarca) 
	,codLinha int foreign key references tbLinha(codLinha) 
	,codFabricante int foreign key references tbFabricante(codFabricante) not null
	,quantEstoque int not null
)

create table tbComandaServico(
	codComandaServico int primary key identity(1,1) not null
	,codServico int foreign key references tbServico(codServico) not null
	,codComanda int foreign key references tbComanda(codComanda) not null
	,quantidade varchar(20) not null
)
create table tbComandaProduto(
	codComandaProduto int primary key identity(1,1) not null
	,codProduto int foreign key references tbProduto(codProduto) not null
	,codComanda int foreign key references tbComanda(codComanda) not null
	,quantidade varchar(20) not null
)
create table tbStatusAgenda(
	codStatusAgenda int primary key identity(1,1) not null
	,descStatusAgenda varchar(20) not null
)
create table tbUsuario(
	codUsuario int primary key identity (1,1) not null
	,nomeUsuario varchar(40) not null
	,loginUsuario varchar(20) not null
	,senhaUsuario varchar(50) not null
)
create table tbAgenda(
	codAgenda int primary key identity(1,1) not null
	,codCliente int foreign key references tbCliente(codCliente) not null
	,dataHora smalldatetime 
	,codServico int foreign key references tbServico(codServico)
	,codStatusAgenda int foreign key references tbStatusAgenda(codStatusAgenda)
	,codUsuario int foreign key references tbUsuario(codUsuario)
	,codProfissional int foreign key references tbProfissional(codProfissional)
)

create table tbEntradaProduto(
	codEntrada int primary key identity (1,1)
	, dataEntradaProduto smalldatetime not null
	, codProduto int foreign key references tbProduto (codProduto)
	, qtdeEntradaProduto int not null
)
create table tbSaidaProduto(
	codSaidaProduto int primary key identity (1,1)
	, dataSaidaProduto smalldatetime not null
	, codProduto int foreign key references tbProduto (codProduto)
	, qtdeSaidaProduto int not null 
)
create table tbCaixa(
	codCaixa int primary key identity (1,1) not null
	,descCaixa varchar(40) 
	,valorInicial money 
	,valorFinal money
	,statusCaixa varchar(30)
)

select * from tbUsuario;
select * from tbCliente;
select * from tbEspecialidade;
select * from tbAgenda;
select * from tbProfissional;
select * from tbFoneCliente;

delete from tbEspecialidade;
delete from tbUsuario;
delete from tbServico;
delete from tbCliente where codCliente = 5; 
DELETE FROM tbCliente WHERE nomeCliente LIKE 'oii%';



insert into tbUsuario(loginUsuario,nomeUsuario,senhaUsuario)
values
('erica','erica','123')

insert into tbFabricante(descFabricante)
values
('Palmolive')

insert into tbFoneCliente(numFoneCliente,codCliente)
values
('20161080',5)

insert into tbAgenda(codCliente,dataHora)
values
(1,'2000/05/23 10:30:00')

INSERT INTO tbCliente(nomeCliente, dataNasc, cpfCliente, ruaCliente, numRuaCliente, compCliente, cepCliente, bairroCliente, cidadeCliente, estadoCliente, email, sexo)
values
('n', '2000/09/20', '487.498.758-33','r','12','as2','08161500','d','s','e','erf','sfdedc')


SELECT codProfissional FROM tbProfissional 
	WHERE nomeProfissional LIKE '%adolpho';


SELECT codAgenda, nomeCliente as 'Cliente', descServico as 'Serviço' FROM tbAgenda 
                    INNER JOIN tbCliente
                        on tbAgenda.codCliente = tbCliente.codCliente
                            INNER JOIN tbServico
                                on tbAgenda.codServico = tbServico.codServico;


SELECT codAgenda FROM tbAgenda 
	WHERE codProfissional = 2 and dataHora = '05/05/2019 13:00:00';
	
select * from tbProfissional

select codAgenda, dataHora, nomeCliente, descServico from tbAgenda
	inner join tbCliente
				on tbAgenda.codCliente = tbCliente.codCliente
					inner join tbServico
						on tbAgenda.codServico = tbServico.codServico
							where codProfissional = '1'
							

select numFoneCliente,nomeCliente from tbFoneCliente
	inner join tbCliente						
		on tbFoneCliente.codCliente = tbCliente.codCliente		
							
SELECT codAgenda, dataHora as 'Data e Hora', nomeCliente as 'Cliente', nomeProfissional as 'Profissional', descServico as 'Serviço' FROM tbAgenda 
                    INNER JOIN tbCliente 
                        on tbAgenda.codCliente = tbCliente.codCliente 
                           INNER JOIN tbProfissional 
                                on tbAgenda.codProfissional = tbProfissional.codProfissional 
                                    INNER JOIN tbServico 
                                        on tbAgenda.codServico = tbServico.codServico WHERE nomeProfissional = 'eeee' order by dataHora