create table users(
    id integer primary key,
    username varchar(255) not null,
    password varchar(64) not null
);

insert into users ('username', 'password') values ('topolino', 'topo');
insert into users ('username', 'password') values ('minnie',   'topo1');
insert into users ('username', 'password') values ('orazio',   'topo2');