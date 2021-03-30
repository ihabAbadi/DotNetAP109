CREATE TABLE customer (id int primary key identity(1,1), firstName varchar(255) not null, lastname varchar(255) not null, phone varchar(10) not null);

CREATE TABLE room (id int primary key identity(1,1), price decimal not null, max int not null, status int not null);

CREATE TABLE reservation (id int primary key identity(1,1), customer_id int not null, status int not null);


CREATE TABLE reservation_room (id int primary key identity(1,1), room_id int not null, reservation_id int not null);