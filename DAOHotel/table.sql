CREATE TABLE customer (id int primary key identity(1,1), firstName varchar not null, lastname varchar not null, phone varchar not null);

CREATE TABLE room (id int primary key identity(1,1), price decimal not null, max int not null, status int not null);

CREATE TABLE reservation (id int primary key identity(1,1), customer_id int not null, status int not null);


CREATE TABLE reservation_room (id int primary key identity(1,1), room_id int not null, reservation_id int not null);