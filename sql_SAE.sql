/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2008                     */
/* Date de création :  11/05/2022 10:24:19                      */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRUNTE') and o.name = 'FK_EMPRUNTE_EMPRUNTE_EMPLOYE')
alter table EMPRUNTE
   drop constraint FK_EMPRUNTE_EMPRUNTE_EMPLOYE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRUNTE') and o.name = 'FK_EMPRUNTE_EMPRUNTE2_VEHICULE')
alter table EMPRUNTE
   drop constraint FK_EMPRUNTE_EMPRUNTE2_VEHICULE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EMPRUNTE') and o.name = 'FK_EMPRUNTE_EMPRUNTE3_DATE')
alter table EMPRUNTE
   drop constraint FK_EMPRUNTE_EMPRUNTE3_DATE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VEHICULE') and o.name = 'FK_VEHICULE_APPARTIEN_CATEGORI')
alter table VEHICULE
   drop constraint FK_VEHICULE_APPARTIEN_CATEGORI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIEVEHICULE')
            and   type = 'U')
   drop table CATEGORIEVEHICULE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DATE')
            and   type = 'U')
   drop table DATE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPLOYE')
            and   type = 'U')
   drop table EMPLOYE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EMPRUNTE')
            and   type = 'U')
   drop table EMPRUNTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VEHICULE')
            and   type = 'U')
   drop table VEHICULE
go

/*==============================================================*/
/* Table : CATEGORIEVEHICULE                                    */
/*==============================================================*/
create table CATEGORIEVEHICULE (
   IDCATEGORIE          int                  not null,
   LIBELLECATEGORIE     varchar(1024)        not null,
   constraint PK_CATEGORIEVEHICULE primary key nonclustered (IDCATEGORIE)
)
go

/*==============================================================*/
/* Table : DATE                                                 */
/*==============================================================*/
create table DATE (
   IDDATE               int                  not null,
   LADATE               datetime             not null,
   constraint PK_DATE primary key nonclustered (IDDATE)
)
go

/*==============================================================*/
/* Table : EMPLOYE                                              */
/*==============================================================*/
create table EMPLOYE (
   IDEMPLOYE            int                  not null,
   NOM                  varchar(40)          not null,
   PRENOM               varchar(30)          not null,
   TELEMPLOYE           varchar(12)          not null,
   MAIL                 varchar(60)          not null,
   constraint PK_EMPLOYE primary key nonclustered (IDEMPLOYE)
)
go

/*==============================================================*/
/* Table : EMPRUNTE                                             */
/*==============================================================*/
create table EMPRUNTE (
   IDEMPLOYE            int                  not null,
   IDVEHICULE           int                  not null,
   IDDATE               int                  not null,
   MISSION              varchar(1024)        null,
   constraint PK_EMPRUNTE primary key (IDEMPLOYE, IDVEHICULE, IDDATE)
)
go

/*==============================================================*/
/* Table : VEHICULE                                             */
/*==============================================================*/
create table VEHICULE (
   IDVEHICULE           int                  not null,
   IDCATEGORIE          int                  not null,
   LIBELLEVEHICULE      varchar(100)         not null,
   constraint PK_VEHICULE primary key nonclustered (IDVEHICULE)
)
go

alter table EMPRUNTE
   add constraint FK_EMPRUNTE_EMPRUNTE_EMPLOYE foreign key (IDEMPLOYE)
      references EMPLOYE (IDEMPLOYE)
go

alter table EMPRUNTE
   add constraint FK_EMPRUNTE_EMPRUNTE2_VEHICULE foreign key (IDVEHICULE)
      references VEHICULE (IDVEHICULE)
go

alter table EMPRUNTE
   add constraint FK_EMPRUNTE_EMPRUNTE3_DATE foreign key (IDDATE)
      references DATE (IDDATE)
go

alter table VEHICULE
   add constraint FK_VEHICULE_APPARTIEN_CATEGORI foreign key (IDCATEGORIE)
      references CATEGORIEVEHICULE (IDCATEGORIE)
go

